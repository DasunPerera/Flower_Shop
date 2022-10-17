using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Data;
using System.Security.Cryptography;

namespace WSEg2
{
    /// <summary>
    /// Summary description for CustomerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerWebService : System.Web.Services.WebService
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
        public string AutoCustomerId()
        {
            string CategoryId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select CustomerId from  CustomerTable", sqlCon);
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
                        CategoryId = "C100" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C10" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C1" + CTR;
                    }

                }

                else
                {
                    CategoryId = "C1001";
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
        public string insertCustomer(string CustomerId, string CustomerName, string Password, string Email, string Contact, string Address)
        {
            int noRecords = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into CustomerTable values ('" + CustomerId + "', '" + CustomerName + "','"+ Password + "','" + Email + "', '" + Contact + "','"+Address+"')", sqlCon);
                noRecords = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRecords.ToString();
        }

        [WebMethod]
        public string loginCustomer(string username,string password)
        {
            int noRecords = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from CustomerTable where CustomerName='"+username+"' Password='"+password+"'", sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                noRecords = dt.Rows.Count;
            
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRecords.ToString();
        }


       





    }

}
