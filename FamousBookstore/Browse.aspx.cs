using System;
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
            if (!IsPostBack)
            {
                using (BookshopModel b = new BookshopModel())
                {
                    GridView1.DataSource = b.Books.ToList<Book>();
                    GridView1.DataBind();
                    var q = b.Categories.Select(x => x.Name).ToList();
                    foreach(Category x in b.Categories)
                    {
                        DropDownList1.Items.Add(x.Name);
                    }
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateGrid();
        }

        protected void GenerateGrid()
        {
            using(BookshopModel b = new BookshopModel())
            {
                if(DropDownList1.SelectedValue != "0")
                {
                    string category = DropDownList1.SelectedItem.Text.ToString();
                    var q = from x in b.Books where x.Category.Name == DropDownList1.SelectedValue.ToString() select x;
                    GridView1.DataSource = q.ToList<Book>();
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = b.Books.ToList<Book>();
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(BookshopModel ctx = new BookshopModel())
            {
                var q = ctx.Books.Where(x => x.Title.Contains(TextBox1.Text));
                GridView1.DataSource = q.ToList<Book>();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}