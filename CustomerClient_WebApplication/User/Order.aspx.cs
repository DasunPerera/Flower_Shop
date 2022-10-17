using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication.User
{
    public partial class Order : System.Web.UI.Page
    {
        OrderServiceReference.OrderWebServiceSoapClient obj = new OrderServiceReference.OrderWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.getProductName();
                txtflower.DataSource = ds;
                txtflower.DataBind();

                txtflower.DataValueField = "ProductName";
                txtflower.DataBind();

                txtorder.Text = obj.AutoOrderId();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = obj.SearchProdcut(TextBox1.Text);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ProductId = obj.getProductId(txtflower.Text);
            string value = obj.InsertOrder(txtorder.Text, ProductId,txtcustomer1.Text, Convert.ToInt32(txtqty.Text));
            int norecord = Int32.Parse(value);
            
            if (norecord > 0)
            {
                Response.Write("<script> alert('Order Added Successfully '); </script>");

            }
            else
            {
                Response.Write("<script> alert('Order Adding Unsuccessful'); </script>");

            }
            txtqty.Text = "";
        }
    }
}