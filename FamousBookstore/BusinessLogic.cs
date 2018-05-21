using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Transactions;


namespace FamousBookstore
{
    public static class BusinessLogic
    {

        //For Main and Browse Page
        //To search/list by required BookTitle
        public static List<Book> SearchByBookTitle(string name)
        {
            using (BookshopModel entities = new BookshopModel())
            { return entities.Books.Where(p => p.Title.Contains(name)).ToList<Book>(); }
        }

        //For browse Page
        //To search/list by required Author
        public static List<Book> SearchByBookAuthor(string name)
        {
            using (BookshopModel entities = new BookshopModel())
            { return entities.Books.Where(p => p.Author.Contains(name)).ToList<Book>(); }
        }

        //For browse Page
        //To search/list by CategoryName (use dropdown selected index)
        public static List<Book> SearchByCategory(int CID)
        {
            using (BookshopModel entities = new BookshopModel())
            { return entities.Books.Where(p => p.CategoryID == (CID + 1)).ToList<Book>(); }
        }

        //For browse Page
        //To sort Booklist by title ascending
        public static List<Book> SortBooksByTitle()
        {   using (BookshopModel entities = new BookshopModel())
           { return entities.Books.OrderBy(x=> x.Title).ToList<Book>();  }
        }

        //For browse Page
        //To sort Booklist by title descending
        public static List<Book> SortBooksByTitleDesc()
        {
            using (BookshopModel entities = new BookshopModel())
            {
                return entities.Books.OrderByDescending(x=> x.Title).ToList<Book>();
            }
        }

        //For browse Page
        //To sort Booklist by Price ascending
        public static List<Book> SortBooksByPrice()
        {
            using (BookshopModel entities = new BookshopModel())
            {
                return entities.Books.OrderBy(x=>x.Price).ToList<Book>();
            }
        }

        //For browse Page
        //To sort Booklist by Price descending
        public static List<Book> SortBooksByPriceDesc()
        {
            using (BookshopModel entities = new BookshopModel())
            {
                return entities.Books.OrderByDescending(x=>x.Price).ToList<Book>();
            }
        }

        //For browse Page
        //To list all books
        public static List<Book> ListAllBooks()
        {
            using (BookshopModel entities = new BookshopModel())
            {
                return entities.Books.ToList<Book>();
            }
        }

        // For View Details Page
        //To View Details (use selected book ID as input argument)
        public static List<Book> ListBookDetails(int BID)
        {    using (BookshopModel entities = new BookshopModel())
            { return entities.Books.Where(p => p.BookID == BID).ToList<Book>(); }
        }

        //For CheckOut Page

        public static int GetLastOrderID()
        {
            using (BookshopModel entities = new BookshopModel())
                    {
                var q = SortOrderID();
                OrderDetail b = q.First();
                return b.OrderID;
                    }
        }

        public static List<OrderDetail> SortOrderID()
        {
            using (BookshopModel entities = new BookshopModel())
            {
                return entities.OrderDetails.OrderByDescending(x => x.OrderID).ToList<OrderDetail>();
            }
        }

        public  static void CheckOut(string UName, int bookid, int quantity, float fprice)
        {
            int LastOrderID;
            int g;
            using (TransactionScope Ts = new TransactionScope())
            {
                LastOrderID = GetLastOrderID() + 1;
                //To add order
                using (BookshopModel entities = new BookshopModel())
                {
                    OrderDetail order = new OrderDetail()
                    {
                        OrderID = LastOrderID,
                        UserName = UName,
                        BookID = bookid,
                        Quantity = quantity,
                        finalprice = (decimal)fprice,
                        Totalprice = (decimal)(quantity * (decimal)fprice)
                    };
                    entities.OrderDetails.Add(order);

                    var q = from x in entities.Books where x.BookID == bookid select x;
                    Book b = q.First();
                    g = (int)b.Stock;
                    g = g - quantity;
                    b.Stock = g;
                    entities.SaveChanges();
                }
                Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);
                Ts.Complete();
            }
        }

        public static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            if(e.Transaction.TransactionInformation.Status == TransactionStatus.Committed)
            {
                //session[“OrderID”] = LastOrderID;
            }
            else if(e.Transaction.TransactionInformation.Status == TransactionStatus.Aborted)
            {

            }
        }

        //To display Order details for Confirmation Page

        public static List<OrderDetail> DisplayOrder(int OID)
        {
            using (BookshopModel entities = new BookshopModel())
            { return entities.OrderDetails.Where(p => p.OrderID == OID).ToList<OrderDetail>(); }
        }

    }
}
