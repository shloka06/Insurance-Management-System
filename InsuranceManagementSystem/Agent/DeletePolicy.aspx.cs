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
                string polID = txtPolID.Text.Trim();
                DataTable dt = fn.Fetch("Select * from POLICY where POL_ID ='" + polID + "' ");
                if (dt.Rows.Count > 0)
                {

                    DataTable dt1 = fn.Fetch("Select * from PURCHASED_POLICY where POL_ID ='" + polID + "' AND Policy_Status IN ('Ongoing');");
                    if (dt1.Rows.Count > 0)
                    {
                        lblMsg.Text = "This Policy has Active Insurers - Cannot be Deleted!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    else
                    {
                        string query = "DELETE FROM POLICY WHERE POL_ID ='" + polID + "'";
                        fn.Query(query);
                        lblMsg.Text = "Deleted Successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        txtPolID.Text = string.Empty;
                    }
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