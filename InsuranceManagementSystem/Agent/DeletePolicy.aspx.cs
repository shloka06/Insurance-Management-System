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
    public partial class DeletePolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string polName = txtPolicy.Text.Trim();
                DataTable dt = fn.Fetch("Select * from POLICY where Policy_Name='" + polName + "' ");
                if (dt.Rows.Count > 0)
                {
                    string query = "DELETE FROM POLICY WHERE Policy_Name='" + polName + "'";
                    fn.Query(query);
                    lblMsg.Text = "Deleted Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    txtPolicy.Text = string.Empty;
                }
                else
                {
                    lblMsg.Text = "Policy With Entered Name Does Not Exist";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}