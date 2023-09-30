using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class UpdateClaimStatus : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int claimID = Convert.ToInt32(txtClaimID.Text.Trim());
                string updatedClaimStatus = Request.Form["claimStatusItems"];

                DataTable dt = fn.Fetch("SELECT Claim_Status FROM CLAIM WHERE CLAIM_ID = " + claimID + ";");
                string oldClaimStatus = dt.Rows[0].Field<string>(0);
                
                if (oldClaimStatus == updatedClaimStatus)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Current Status is Same as Updated Status!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    string query = "UPDATE CLAIM SET CLAIM_STATUS = '" + updatedClaimStatus + "' WHERE CLAIM_ID = " + claimID + ";";
                    fn.Query(query);

                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Successfully!";
                    lblMsg.CssClass = "alert alert-success";

                    txtClaimID.Text = string.Empty;
                    ClaimGridView.DataSource = null;
                    ClaimGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            int claimID = Convert.ToInt32(txtClaimID.Text.Trim());
            DataTable dt = fn.Fetch("SELECT CLAIM_ID AS \"Claim ID\", Claim_Status AS \"Claim Status\" FROM CLAIM WHERE CLAIM_ID = " + claimID + ";");
            if (dt.Rows.Count > 0)
            {
                ClaimGridView.DataSource = dt;
                ClaimGridView.DataBind();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Claim Record Exists For Entered Claim ID!";
                lblMsg.CssClass = "alert alert-danger";
            }
        }

    }
}