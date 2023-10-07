using System;
using System.Data;
using System.Xml.Linq;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class AddBenefactorPolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        DataTable insIDDT = new DataTable();
        DataTable benefactorPolicyDT = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
            btnAdd.Enabled = false;
        }

        protected void btnGetPol_Click(object sender, EventArgs e)
        {
            int benID = Convert.ToInt32(txtBenID.Text.Trim());
            insIDDT = fn.Fetch("SELECT INS_ID FROM INSURER_BENEFACTOR WHERE B_ID = " + benID);
            if (insIDDT.Rows.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Record Exists for Entered Benefactor ID!";
                lblMsg.CssClass = "alert alert-danger";
                txtBenID.Text = string.Empty;
                btnAdd.Enabled = false;
                polIDItems.Items.Clear();
                PolicyGridView.DataSource = null;
                PolicyGridView.DataBind();
            }
            else
            {
                int insID = insIDDT.Rows[0].Field<int>(0);

                lblMsg.Visible = false;
                try
                {
                    benefactorPolicyDT = fn.Fetch("SELECT POL_ID AS \"Policy ID\", Policy_Name AS \"Policy Name\", Policy_Type AS \"Policy Type\" FROM POLICY WHERE POL_ID IN (SELECT DISTINCT POL_ID FROM PURCHASED_POLICY WHERE INS_ID = " + insID + " AND POL_ID NOT IN (SELECT DISTINCT POL_ID FROM PURCHASED_POLICY_BENEFACTOR WHERE INS_ID = " + insID + " AND B_ID = " + benID + "));");

                    polIDItems.Items.Clear();
                    if (benefactorPolicyDT.Rows.Count > 0)
                    {

                        for (int polNo = 0; polNo < benefactorPolicyDT.Rows.Count; polNo++)
                        {
                            polIDItems.Items.Add(benefactorPolicyDT.Rows[polNo][0].ToString());
                        }

                        PolicyGridView.DataSource = benefactorPolicyDT;
                        PolicyGridView.DataBind();
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "No Policies Available for Entered Benefactor!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtBenID.Text = string.Empty;
                        btnAdd.Enabled = false;
                        polIDItems.Items.Clear();
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
                int polID = Convert.ToInt32(polIDItems.SelectedValue);
                int benID = Convert.ToInt32(txtBenID.Text.Trim());

                insIDDT = fn.Fetch("SELECT INS_ID FROM INSURER_BENEFACTOR WHERE B_ID = " + benID);
                int insID = insIDDT.Rows[0].Field<int>(0);
                benefactorPolicyDT = fn.Fetch("SELECT P_P.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Policy_Type AS \"Policy Type\", P_P.Policy_Status AS \"Policy Status\", P_P.Start_Date AS \"Policy Purchase Date\", P_P.End_Date AS \"Policy Maturity Date\", P_P_B.B_ID AS \"Benefactor ID\" FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.INS_ID = " + insID + " AND P_P.POL_ID = P.POL_ID INNER JOIN PURCHASED_POLICY_BENEFACTOR AS P_P_B ON P_P_B.INS_ID = " + insID + " AND P_P_B.POL_ID = P_P.POL_ID AND P_P_B.B_ID != " + benID + ";");

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
                    string insertPurchasedPolicyBenefactorQuery = "INSERT INTO PURCHASED_POLICY_BENEFACTOR(INS_ID, POL_ID, B_ID) VALUES (" + insID + ", " + polID + ", " + benID + ");";

                    fn.Query(insertPurchasedPolicyBenefactorQuery);

                    lblMsg.Visible = true;
                    lblMsg.Text = "Policy Successfully Added For Benefactor!";
                    lblMsg.CssClass = "alert alert-success";

                    polIDItems.Items.Clear();
                    txtBenID.Text = string.Empty;
                    PolicyGridView.DataSource = null;
                    PolicyGridView.DataBind();
                    btnAdd.Enabled = false;
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "This Policy Cannot be Added for Entered Benefactor!";
                    lblMsg.CssClass = "alert alert-danger";
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