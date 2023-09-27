using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ViewAllPolicies : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("Select * from POLICY");
                dt.Columns["POL_ID"].ColumnName = "Policy ID";
                dt.Columns["Policy_Name"].ColumnName = "Policy Name";
                dt.Columns["Policy_Type"].ColumnName = "Type";
                dt.Columns["Insured_Amount"].ColumnName = "Insured Amount";
                dt.Columns["Payment_Schedule"].ColumnName = "Payment Schedule";
                dt.Columns["Payment_Amount"].ColumnName = "Payment Amount";
                dt.Columns["Payment_Duration"].ColumnName = "Payment Duration";
                dt.Columns["Cover_Duration"].ColumnName = "Cover Duration";
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}