using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamousBookstore
{
    public static class BusinessLogic
    {
        public static string HelloWorld()
        {
            return "Hello World";
        }

        public static string FetchData()
        {
            var context = new BookshopEntities();
            var query = from x in context.Books select x;
            string toReturn = query.First().Author;

            return toReturn;
        }
    }
}
