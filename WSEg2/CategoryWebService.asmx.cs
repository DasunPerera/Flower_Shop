using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WSEg2
{
    /// <summary>
    /// Summary description for CategoryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryWebService : System.Web.Services.WebService
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
        public string AutoCategoryId()
        {
            string CategoryId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select CategoryId from  CategoryTable", sqlCon);
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
                        CategoryId = "C00" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C" + CTR;
                    }

                }

                else
                {
                    CategoryId = "C001";
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
        public string insertCategory(string CategoryId, string CategoryName)
        {
            int noRecords = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into CategoryTable values ('" + CategoryId + "', '" + CategoryName + "');", sqlCon);
                noRecords = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRecords.ToString();
        }

        [WebMethod]
        public DataSet DisplayCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from CategoryTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "CategoryTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Searching Customer" + ex);
            }
            return ds;
        }



        [WebMethod]
        public string UpdateCategory(string categoryId, string categoryName)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Update CategoryTable set CategoryName='"+categoryName+"' where CategoryId='"+ categoryId+"'", sqlCon);


                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return temp.ToString();
        }

        [WebMethod]
        public string DeleteCategory(string categoryId)
        {
            int temp = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Delete from CategoryTable where CategoryId='" + categoryId + "'", sqlCon);


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
