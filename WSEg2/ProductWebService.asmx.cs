using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSEg2
{
    /// <summary>
    /// Summary description for ProductWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductWebService : System.Web.Services.WebService
    {

        SqlConnection sqlCon = null;
        public SqlConnection getConnection()
        {
            try
            {
                sqlCon = new SqlConnection("Data Source=DESKTOP-I5JQ86S\\SQLEXPRESS;Initial Catalog=web;Integrated Security=True");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);

            }
            return sqlCon;
        }

        [WebMethod]
        public string AutoProdcutId()
        {
            string ProdcutId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select ProductId from  ProductTable", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";
                bool records = dr.HasRows;
                if (records)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString();
                    }
                    string idString = id.Substring(1);
                    int CTR = Int32.Parse(idString);
                    if (CTR >= 1 && CTR < 9)
                    {
                        CTR = CTR + 1;
                        ProdcutId = "P00" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        ProdcutId = "P0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        ProdcutId = "P" + CTR;
                    }
                }
                else
                {
                    ProdcutId = "P001";
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                ProdcutId = e1.ToString();
            }
            return ProdcutId;
        }



        [WebMethod]
        public DataSet getCategoryName()
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmdCategory = new SqlCommand("Select CategoryName from CategoryTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmdCategory);

                da.Fill(ds, "CategoryTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching Category Name" + ex);
            }
            return ds;
        }

        [WebMethod]
        public string getCategoryId(string categoryName)
        {
            string CategoryId = "";
            try
            {

                getConnection();
                SqlCommand cmd = new SqlCommand
      ("Select CategoryId from  CategoryTable where CategoryName  ='" + categoryName + "'", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();

                Boolean records = dr.HasRows;//T
                if (records)
                {
                    while (dr.Read())
                    {
                        CategoryId = dr[0].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching Category Name" + ex);
            }
            return CategoryId;
        }


        [WebMethod]
        public string insertProduct(string productId, string ProductName, string categoryId,
               int price, int qty)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into ProductTable values ('" + productId +
                    "','" + ProductName + "','" + categoryId + "', " + price + "," + qty + ");", sqlCon);

                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }

        [WebMethod]
        public DataSet SearchProdcut(string productId)
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd =
             new SqlCommand("Select * from ProductTable where ProductId= '" + productId + "' or ProductName='"+productId+"'", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "ProductTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching prodcut" + ex);
            }
            return ds;
        }


        [WebMethod]
        public DataSet DisplayProduct1()
        {
            DataSet ds1 = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from ProductTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds1, "ProductTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Searching Customer" + ex);
            }
            return ds1;
        }


        [WebMethod]
        public string UpdateProduct(string productId1, string ProductName, string categoryId,
               int price, int qty)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Update ProductTable set ProductName='"+ ProductName+"', CategoryId='"+ categoryId +"', Price='"+ price +"', Quantity='"+ qty +"' where ProductId='"+ productId1+"'", sqlCon);
    

                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }



        [WebMethod]
        public string DeleteProduct(string ProductId)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Delete from ProductTable where ProductId='" + ProductId + "'", sqlCon);


                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }







        [WebMethod]
        public int AddStock(string productId, int newStock)
        {
            int noRecords = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand
        ("update ProductTable set Quantity=" + newStock + " where ProductId='" +
        productId + "'", sqlCon);
                noRecords = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error update stock " + ex);
            }
            return noRecords;
        }



    }
}
