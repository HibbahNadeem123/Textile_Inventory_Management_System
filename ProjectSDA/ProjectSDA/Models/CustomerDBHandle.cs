using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectSDA.Models
{
    public class CustomerDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddCustomer(CustomerModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CName", cmodel.CName);
            cmd.Parameters.AddWithValue("@Email", cmodel.Email);
            cmd.Parameters.AddWithValue("@CompanyName", cmodel.CompanyName);
            cmd.Parameters.AddWithValue("@City", cmodel.City);
            cmd.Parameters.AddWithValue("@Country", cmodel.Country);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<CustomerModel> GetCustomer()
        {
            connection();
            List<CustomerModel> CustomerModellist = new List<CustomerModel>();

            SqlCommand cmd = new SqlCommand("ViewCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CustomerModellist.Add(
                new CustomerModel
                {
                    CID = Convert.ToInt32(dr["CID"]),
                    CName = Convert.ToString(dr["CName"]),
                    Email = Convert.ToString(dr["Email"]),
                    CompanyName = Convert.ToString(dr["CompanyName"]),
                    City = Convert.ToString(dr["City"]),
                    Country = Convert.ToString(dr["Country"]),
                });
            }
            return CustomerModellist;
        }

        public bool UpdateDetails(CustomerModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCustomerModel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CID", cmodel.CID);
            cmd.Parameters.AddWithValue("@CName", cmodel.CName);
            cmd.Parameters.AddWithValue("@Email", cmodel.Email);
            cmd.Parameters.AddWithValue("@CompanyName", cmodel.CompanyName);
            cmd.Parameters.AddWithValue("@City", cmodel.City);
            cmd.Parameters.AddWithValue("@Country", cmodel.Country);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteCustomer(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
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