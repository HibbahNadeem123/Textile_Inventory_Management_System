using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectSDA.Models
{
    public class OrderHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddOrder(Order smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@quantity", smodel.quantity);
            cmd.Parameters.AddWithValue("@tprice", smodel.Price);
            

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Order> GetOrder()
        {
            connection();
            List<Order> Orderlist = new List<Order>();

            SqlCommand cmd = new SqlCommand("ViewOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Orderlist.Add(
                new Order
                {
                    Id = Convert.ToInt32(dr["OID"]),
                    quantity = Convert.ToInt32(dr["Quantity"]),
                    Price = Convert.ToInt32(dr["TotalPrice"]),
                    
                });
            }
            return Orderlist;
        }
    
        public List<Order> GetByID(string id)
        {
            connection();
            List<Order> Orderlist = new List<Order>();

            SqlCommand cmd = new SqlCommand("SearchOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OID", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Orderlist.Add(
                new Order
                {
                    Id = Convert.ToInt32(dr["OID"]),
                    quantity = Convert.ToInt32(dr["Quantity"]),
                    Price = Convert.ToInt32(dr["TotalPrice"]),
                });
            }
            return Orderlist;
        }
        public bool UpdateDetails(Order smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.Id);
            cmd.Parameters.AddWithValue("@quantity", smodel.quantity);
            cmd.Parameters.AddWithValue("@tprice", smodel.Price);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteOrder(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteOrder", con);
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