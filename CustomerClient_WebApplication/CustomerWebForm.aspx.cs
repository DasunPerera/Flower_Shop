using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
    public partial class CustomerWebForm : System.Web.UI.Page
    {
        CustomerServiceReference.CustomerWebServiceSoapClient obj = new CustomerServiceReference.CustomerWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Text = obj.AutoCustomerId();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            string noR = obj.insertCustomer(txtId.Text, txtcustomer.Text, txtpassword.Text, txtemail.Text, txtcontact.Text, txtaddress.Text);
            int noRecords = Int32.Parse(noR);
            if (noRecords > 0)
            {
                Response.Write("<script> alert('Registration Successfully Done'); </script>");
            }
            else
            {
                Response.Write("<script> alert('Registration Unsuccessful'); </script>");
            }
        }
    }
}