using CustomerClient_WebApplication.CategoryServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
   

    public partial class CategoryWebForm : System.Web.UI.Page
    {
       CategoryServiceReference.CategoryWebServiceSoapClient obj=new CategoryServiceReference.CategoryWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryId.Text = obj.AutoCategoryId();
            DataSet ds = obj.DisplayCategory();
            CatInfo.DataSource = ds;
            CatInfo.DataBind();


        }
   

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string value = obj.insertCategory(categoryId.Text, category.Text);
            int norecord = Int32.Parse(value);
            clr();
            if (norecord > 0)
            {
                Response.Write("<script> alert('Category Successfully Added'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Category Adding Unsuccessful'); </script>");

            }

        }
        protected void clr()
        {
           
            category.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}