using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.DynamicData;

namespace InsuranceManagementSystem.Models
{
    public class CommonFn
    {
        public class Commonfnx
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InsuranceCS"].ConnectionString);
            public void Query(string query)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            public DataTable Fetch(string query)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dt.Columns["POL_ID"].ColumnName = "Policy ID";
                dt.Columns["Policy_Name"].ColumnName = "Policy Name";
                dt.Columns["Policy_Type"].ColumnName = "Type";
                dt.Columns["Insured_Amount"].ColumnName = "Insured Amount";
                dt.Columns["Payment_Schedule"].ColumnName = "Payment Schedule";
                dt.Columns["Payment_Amount"].ColumnName = "Payment Amount";
                dt.Columns["Payment_Duration"].ColumnName = "Payment Duration";
                dt.Columns["Cover_Duration"].ColumnName = "Cover Duration";
                return dt;
            }
        }
    }
}