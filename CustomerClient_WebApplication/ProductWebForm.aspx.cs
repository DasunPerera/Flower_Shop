using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
    public partial class ProductWebForm : System.Web.UI.Page
    {
        ProductServiceReference.ProductWebServiceSoapClient obj=new ProductServiceReference.ProductWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.getCategoryName();
                dlCategory.DataSource = ds;
                dlCategory.DataBind();

                dlCategory.DataValueField = "CategoryName";
                dlCategory.DataBind();

                txtProductId.Text = obj.AutoProdcutId();


                DataSet ds1 = obj.DisplayProduct1();
                GridView1.DataSource = ds1;
                GridView1.DataBind();
             

            }
        }

       

        protected void btnAdd_Click1(object sender, EventArgs e)
        {

            string CategoryId = obj.getCategoryId(dlCategory.Text);

            string value = obj.insertProduct
               (txtProductId.Text, txtProductName.Text, CategoryId, Convert.ToInt32(txtPrice.Text),
                Convert.ToInt32(txtQty.Text));
            int record = Int32.Parse(value);
            clr();
            if (record >= 1)
            {
                Response.Write("<script> alert('Flower Added Successfuly '); </script>");
            }
            else
            {
                Response.Write("<script> alert('Flower Added Unsuccessfuly '); </script>");
            }

        }
        protected void clr()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string value = obj.DeleteProduct(txtProductId.Text);
            int norecord = Int32.Parse(value);

            if (norecord > 0)
            {
                Response.Write("<script> alert('Flower Deleted'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Flower not Deleted'); </script>");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CategoryId = obj.getCategoryId(dlCategory.Text);
            string value = obj.UpdateProduct(txtProductId.Text, txtProductName.Text, CategoryId, Convert.ToInt32(txtPrice.Text),
                Convert.ToInt32(txtQty.Text));
            int norecord = Int32.Parse(value);
            clr();
            if (norecord > 0)
            {
                Response.Write("<script> alert('Product Updated'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Product not Updated'); </script>");

            }
        }
    }
}