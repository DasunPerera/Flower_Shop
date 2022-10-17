using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
    public partial class CustomerWebForm2 : System.Web.UI.Page
    {
        CustomerServiceReference.CustomerWebServiceSoapClient obj = new CustomerServiceReference.CustomerWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = txtcustomer.Text;
            string password=txtpassword.Text;
            string noR = obj.loginCustomer(txtcustomer.Text,txtpassword.Text);
            int noRecords = Int32.Parse(noR);
            if (noRecords > 0)
            {
                if(user=="Ayesh" && password=="12345")
                {
                    Response.Redirect("ProductWebForm.aspx");
                }
                else
                {
                    Response.Redirect("./User/Home.aspx");
                }
                
            
            }
            else
            {
                Response.Write("<script> alert('Invalid user'); </script>");
            }
        }
    }
}