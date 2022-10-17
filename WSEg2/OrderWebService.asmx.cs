using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using static System.Collections.Specialized.BitVector32;

namespace WSEg2
{
    /// <summary>
    /// Summary description for OrderWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderWebService : System.Web.Services.WebService
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
        public string AutoOrderId()
        {
            string CategoryId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select OrderId from  OrderTable", sqlCon);
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
                        CTR = CTR + 1;//6
                        CategoryId = "R00" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "R0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "R" + CTR;
                    }

                }

                else
                {
                    CategoryId = "R001";
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                CategoryId = e1.ToString();
            }
            return CategoryId;
        }


        [WebMethod]
        public DataSet SearchProdcut(string productname)
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd =
             new SqlCommand("Select * from ProductTable where ProductName= '" + productname+ "'  or ProductId='"+ productname + "'", sqlCon);
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
        public DataSet getProductName()
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmdCategory = new SqlCommand("Select ProductName from ProductTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmdCategory);

                da.Fill(ds, "ProductTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching Product Name" + ex);
            }
            return ds;
        }

        [WebMethod]
        public string getProductId(string ProductName)
        {
            string ProductId = "";
            try
            {

                getConnection();
                SqlCommand cmd = new SqlCommand
      ("Select ProductId from  ProductTable where ProductName  ='" + ProductName + "'", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();

                Boolean records = dr.HasRows;//T
                if (records)
                {
                    while (dr.Read())
                    {
                        ProductId = dr[0].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching Product Name" + ex);
            }
            return ProductId;
        }


        [WebMethod]
        public string InsertOrder(string orderId, string customer,string flowerId,int qty)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into OrderTable values ('" + orderId +
                    "','" + flowerId + "'," + qty+",'" +customer + "');", sqlCon);

                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }




        [WebMethod]
        public DataSet DisplayOrder()
        {
            DataSet ds1 = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from OrderTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds1, "OrderTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Searching OrderTable" + ex);
            }
            return ds1;
        }



        [WebMethod]
        public string UpdateOrder(string OrderId, string ProductId, int Qty,string customer)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Update OrderTable set ProductId='" + ProductId + "', Quntity='" + Qty + "', CustomerName='"+customer+"' where OrderId='" +OrderId + "'", sqlCon);


                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }



        [WebMethod]
        public string DeleteOrder(string OrderId)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Delete from OrderTable where OrderId='" + OrderId + "'", sqlCon);


                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }



    }
}
