using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ViewClaimRequests : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        DataTable insIDDT = new DataTable();
        DataTable benefactorPolicyDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            int benID = Convert.ToInt32(txtBenID.Text.Trim());
            insIDDT = fn.Fetch("SELECT INS_ID FROM INSURER_BENEFACTOR WHERE B_ID = " + benID);
            if (insIDDT.Rows.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Record Exists for Entered Benefactor ID!";
                lblMsg.CssClass = "alert alert-danger";
                txtPolID.Text = string.Empty;
                txtBenID.Text = string.Empty;
                PolicyGridView.DataSource = null;
                PolicyGridView.DataBind();
            }
            else
            {
                int insID = insIDDT.Rows[0].Field<int>(0);

                lblMsg.Visible = false;
                try
                {
                    benefactorPolicyDT = fn.Fetch("SELECT P_P.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Policy_Type AS \"Policy Type\", P_P.Policy_Status AS \"Policy Status\", P_P.Start_Date AS \"Policy Purchase Date\", P_P.End_Date AS \"Policy Maturity Date\", P_P_B.B_ID AS \"Benefactor ID\" FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.INS_ID = " + insID + " AND P_P.POL_ID = P.POL_ID INNER JOIN PURCHASED_POLICY_BENEFACTOR AS P_P_B ON P_P_B.INS_ID = " + insID + " AND P_P_B.POL_ID = P_P.POL_ID AND P_P_B.B_ID = " + benID + " AND P_P.POL_ID NOT IN (SELECT C.POL_ID FROM CLAIM_RECORD AS C);");

                    if (benefactorPolicyDT.Rows.Count > 0)
                    {
                        PolicyGridView.DataSource = benefactorPolicyDT;
                        PolicyGridView.DataBind();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "No Policies Available for Entered Benefactor!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        txtBenID.Text = string.Empty;
                        PolicyGridView.DataSource = null;
                        PolicyGridView.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int polID = Convert.ToInt32(txtPolID.Text.Trim());
                int benID = Convert.ToInt32(txtBenID.Text.Trim());

                insIDDT = fn.Fetch("SELECT INS_ID FROM INSURER_BENEFACTOR WHERE B_ID = " + benID);
                int insID = insIDDT.Rows[0].Field<int>(0);

                benefactorPolicyDT = fn.Fetch("SELECT P_P.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Policy_Type AS \"Policy Type\", P_P.Policy_Status AS \"Policy Status\", P_P.Start_Date AS \"Policy Purchase Date\", P_P.End_Date AS \"Policy Maturity Date\", P_P_B.B_ID AS \"Benefactor ID\" FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.INS_ID = " + insID + " AND P_P.POL_ID = P.POL_ID INNER JOIN PURCHASED_POLICY_BENEFACTOR AS P_P_B ON P_P_B.INS_ID = " + insID + " AND P_P_B.POL_ID = P_P.POL_ID AND P_P_B.B_ID = " + benID + " AND P_P.POL_ID NOT IN (SELECT C.POL_ID FROM CLAIM_RECORD AS C);");

                bool found = false;

                for (int i = 0; i < benefactorPolicyDT.Rows.Count; i++)
                {
                    if (benefactorPolicyDT.Rows[i].Field<int>(0) == polID)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    string insertClaimQuery = "INSERT INTO CLAIM(Claim_Status) VALUES ('Submitted');";
                    fn.Query(insertClaimQuery);

                    DataTable insertedClaim = fn.Fetch("SELECT IDENT_CURRENT('CLAIM');");
                    int claimID = Convert.ToInt32(insertedClaim.Rows[0][0]);

                    string insertClaimRecordQuery = "INSERT INTO CLAIM_RECORD(CLAIM_ID, INS_ID, B_ID, POL_ID) VALUES (" + claimID + ", " + insID + ", " + benID + ", " + polID + ");";
                    fn.Query(insertClaimRecordQuery);

                    lblMsg.Visible = true;
                    lblMsg.Text = "Claim Successfully Added For Benefactor!";
                    lblMsg.CssClass = "alert alert-success";

                    txtPolID.Text = string.Empty;
                    txtBenID.Text = string.Empty;
                    PolicyGridView.DataSource = null;
                    PolicyGridView.DataBind();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Claim Cannot be Added against Entered Policy!";
                    lblMsg.CssClass = "alert alert-danger";
                    txtPolID.Text = string.Empty;
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}