using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ViewClaimsHistory : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT C.CLAIM_ID AS \"Claim ID\", C.Claim_Status AS \"Claim Status\", C_R.INS_ID AS \"Insurer ID\", I.Ins_Name AS \"Insurer Name\", C_R.B_ID AS \"Benefactor ID\", B.B_Name AS \"Benefactor Name\", C_R.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Insured_Amount AS \"Payout Amount\" FROM CLAIM AS C INNER JOIN CLAIM_RECORD AS C_R ON C.CLAIM_ID = C_R.CLAIM_ID INNER JOIN INSURER AS I ON C_R.INS_ID = I.INS_ID INNER JOIN BENEFACTOR AS B ON C_R.B_ID = B.B_ID INNER JOIN POLICY AS P ON C_R.POL_ID = P.POL_ID;");

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
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
    }
}