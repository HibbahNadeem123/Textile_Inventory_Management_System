using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectSDA.Models
{
    public class ProductHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddProduct(Product smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Price", smodel.Price);
            cmd.Parameters.AddWithValue("@Description", smodel.Description);
            cmd.Parameters.AddWithValue("@Category", smodel.Category);
            cmd.Parameters.AddWithValue("@Quantity", smodel.Quantity);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Product> GetProduct()
        {
            connection();
            List<Product> Productlist = new List<Product>();

            SqlCommand cmd = new SqlCommand("ViewProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Productlist.Add(
                new Product
                {
                    Id = Convert.ToInt32(dr["ProductID"]),
                    Name = Convert.ToString(dr["ProductName"]),
                    Price = Convert.ToInt32(dr["Price"]),
                    Description = Convert.ToString(dr["ProductDescription"]),
                    Category = Convert.ToString(dr["Category"]),
                    Quantity = Convert.ToInt32(dr["ProductQuantity"]),
                });
            }
            return Productlist;
        }

        public bool UpdateDetails(Product smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.Id);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Price", smodel.Price);
            cmd.Parameters.AddWithValue("@Description", smodel.Description);
            cmd.Parameters.AddWithValue("@Category", smodel.Category);
            cmd.Parameters.AddWithValue("@Quantity", smodel.Quantity);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteProduct(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}