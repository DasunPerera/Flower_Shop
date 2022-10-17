using CustomerClient_WebApplication.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerClient_WebApplication
{
    public partial class OrderWebForm : System.Web.UI.Page
    {
        OrderServiceReference.OrderWebServiceSoapClient obj=new OrderServiceReference.OrderWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = obj.getProductName();
                txtflower.DataSource = ds;
                txtflower.DataBind();

                txtflower.DataValueField = "ProductName";
                txtflower.DataBind();

                txtOrderId.Text = obj.AutoOrderId();
                DataSet ds1 = obj.DisplayOrder();
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string ProductId = obj.getProductId(txtflower.Text);
            string value = obj.InsertOrder(txtOrderId.Text, ProductId, txtCustomer.Text, Convert.ToInt32(txtqty.Text));
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            string FlowerId = obj.getProductId(txtflower.Text);
            string value = obj.UpdateOrder(txtOrderId.Text, FlowerId,  Convert.ToInt32(txtqty.Text),txtCustomer.Text);
            int norecord = Int32.Parse(value);
            
            if (norecord > 0)
            {
                Response.Write("<script> alert('Product Updated'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Product not Updated'); </script>");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string value = obj.DeleteOrder(txtOrderId.Text);
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
    }
}