using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerClient_WebApplication
{
    public partial class SearchWebForm : System.Web.UI.Page
    {
        ProductServiceReference.ProductWebServiceSoapClient obj =
         new ProductServiceReference.ProductWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = obj.SearchProdcut(txtProductId.Text);
            GridView1.DataBind();
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            obj.AddStock(txtProductId.Text, Convert.ToInt32(txtStock.Text));

            GridView1.DataSource = obj.SearchProdcut(txtProductId.Text);
            GridView1.DataBind();

        }
    }
}