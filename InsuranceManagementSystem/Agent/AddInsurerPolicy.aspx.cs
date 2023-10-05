using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class AddInsurerPolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
            btnAdd.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int insID = Convert.ToInt32(txtInsID.Text.Trim());
                int polID = Convert.ToInt32(polIDItems.SelectedValue);
                int benID = Convert.ToInt32(benIDItems.SelectedValue);

                DataTable polDT = fn.Fetch("Select * from POLICY where POL_ID = " + polID + ";");

                int coverDuration = polDT.Rows[0].Field<int>(7);
                DateTime startDate = DateTime.Now;
                string startDay = startDate.Day.ToString();
                string startMonth = startDate.Month.ToString();
                int startYear = Convert.ToInt32(startDate.Year);
                int endYear = startYear + coverDuration;
                string strEndDate = endYear.ToString() + "-" + startMonth + "-" + startDay;
                string strStartDate = startYear.ToString() + "-" + startMonth + "-" + startDay;

                string insertPurchasedPolicyQuery = "INSERT INTO PURCHASED_POLICY(INS_ID, POL_ID, Policy_Status, Start_Date, End_Date) VALUES (" + insID + ", " + polID + ", 'Ongoing', '" + strStartDate + "', '" + strEndDate + "');";

                string insertPurchasedPolicyBenefactorQuery = "INSERT INTO PURCHASED_POLICY_BENEFACTOR(INS_ID, POL_ID, B_ID) VALUES (" + insID + ", " + polID + ", " + benID + ");";

                fn.Query(insertPurchasedPolicyQuery);
                fn.Query(insertPurchasedPolicyBenefactorQuery);

                lblMsg.Visible = true;
                lblMsg.Text = "Policy Successfully Added For Insurer!";
                lblMsg.CssClass = "alert alert-success";

                txtInsID.Text = string.Empty;

                BenefactorGridView.DataSource = null;
                BenefactorGridView.DataBind();

                PolicyGridView.DataSource = null;
                PolicyGridView.DataBind();

                benIDItems.Items.Clear();
                polIDItems.Items.Clear();

                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnGetBen_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            try
            {
                int insID = Convert.ToInt32(txtInsID.Text.Trim());
                DataTable insDT = fn.Fetch("Select * from INSURER where INS_ID = " + insID + ";");

                if (insDT.Rows.Count == 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "No Insurer Record Found for Entered ID!";
                    lblMsg.CssClass = "alert alert-danger";

                    BenefactorGridView.DataSource = null;
                    BenefactorGridView.DataBind();

                    PolicyGridView.DataSource = null;
                    PolicyGridView.DataBind();

                    benIDItems.Items.Clear();
                    polIDItems.Items.Clear();

                    btnAdd.Enabled = false;
                    return;
                }

                DataTable benefactorList = fn.Fetch("SELECT I_B.B_ID AS \"Benefactor ID\", B.B_Name AS \"Benefactor Name\", CONVERT(date, B.B_DOB) AS \"Date Of Birth\", I_B.Relationship AS \"Relationship with Insurer\" FROM INSURER_BENEFACTOR AS I_B, BENEFACTOR AS B WHERE INS_ID = " + insID + " AND I_B.B_ID = B.B_ID;");
                benIDItems.Items.Clear();
                for (int benNo = 0; benNo < benefactorList.Rows.Count; benNo++)
                {
                    benIDItems.Items.Add(benefactorList.Rows[benNo][0].ToString());
                }
                BenefactorGridView.DataSource = benefactorList;
                BenefactorGridView.DataBind();

                DataTable policyList = fn.Fetch("SELECT * FROM POLICY WHERE POL_ID NOT IN (SELECT POL_ID FROM PURCHASED_POLICY WHERE INS_ID = " + insID + ");");
                polIDItems.Items.Clear();
                for (int polNo = 0; polNo < policyList.Rows.Count; polNo++)
                {
                    polIDItems.Items.Add(policyList.Rows[polNo][0].ToString());
                }
                PolicyGridView.DataSource = policyList;
                PolicyGridView.DataBind();

                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}