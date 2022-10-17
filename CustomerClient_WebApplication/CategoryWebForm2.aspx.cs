using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
    public partial class CategoryWebForm2 : System.Web.UI.Page
    {
        CategoryServiceReference.CategoryWebServiceSoapClient obj = new CategoryServiceReference.CategoryWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = obj.DisplayCategory();
            CatInfo.DataSource = ds;
            CatInfo.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string value = obj.UpdateCategory(txtId1.Text, txtName1.Text);
            int norecord = Int32.Parse(value);
           
            if (norecord > 0)
            {
                Response.Write("<script> alert('Category Updated'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Category not Updated'); </script>");

            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            string value = obj.DeleteCategory(txtId1.Text);
            int norecord = Int32.Parse(value);

            if (norecord > 0)
            {
                Response.Write("<script> alert('Category Deleted'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Category not Delete'); </script>");

            }
        }
    }
}