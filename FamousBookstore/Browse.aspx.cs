﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamousBookstore
{
    public partial class Browse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate the Placeholder with rows and datas of book details
            List<Book> books = BusinessLogic.ListAllBooks();
            foreach(Book b in books)
            {

            }
        }
    }
}