using System;
using System.Data;
using System.Web.UI.WebControls;
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

            if (!Page.IsPostBack)
            {
                GetClaimItems();
            }
        }

        protected void GetClaimItems()
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT C.CLAIM_ID AS \"Claim ID\", C.Claim_Status AS \"Claim Status\", C_R.INS_ID AS \"Insurer ID\", I.Ins_Name AS \"Insurer Name\", C_R.B_ID AS \"Benefactor ID\", B.B_Name AS \"Benefactor Name\", C_R.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Insured_Amount AS \"Payout Amount\" FROM CLAIM AS C INNER JOIN CLAIM_RECORD AS C_R ON C.CLAIM_ID = C_R.CLAIM_ID INNER JOIN INSURER AS I ON C_R.INS_ID = I.INS_ID INNER JOIN BENEFACTOR AS B ON C_R.B_ID = B.B_ID INNER JOIN POLICY AS P ON C_R.POL_ID = P.POL_ID;");

                if (dt.Rows.Count > 0)
                {
                    claimIDItems.Items.Clear();
                    for (int claimNo = 0; claimNo < dt.Rows.Count; claimNo++)
                    {
                        claimIDItems.Items.Add(dt.Rows[claimNo][0].ToString());
                    }
                }
                else
                {
                    lblMsg.Text = "No Claims History Found!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int claimID = Convert.ToInt32(claimIDItems.SelectedValue);
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

                    GetClaimItems();
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
            int claimID = Convert.ToInt32(claimIDItems.SelectedValue);
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