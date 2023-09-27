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

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int insID = Convert.ToInt32(txtInsID.Text.Trim());
                int polID = Convert.ToInt32(txtBenID.Text.Trim());
                int benID = Convert.ToInt32(txtPolID.Text.Trim());

                DataTable insDT = fn.Fetch("Select * from INSURER where INS_ID = " + insID + ";");
                DataTable polDT = fn.Fetch("Select * from POLICY where POL_ID = " + polID + ";");
                DataTable benDT = fn.Fetch("Select * from BENEFACTOR where B_ID = " + benID + ";");
                DataTable insBenDT = fn.Fetch("Select * from INSURER_BENEFACTOR where INS_ID = " + insID + " and POL_ID = " + polID + ";");
                DataTable insPolBenDT = fn.Fetch("Select * from PURCHASED_POLICY_BENEFACTOR where INS_ID = " + insID + " AND POL_ID = " + polID + "AND B_ID = " + benID + ";");

                if (insDT.Rows.Count == 0)
                {
                    lblMsg.Text = "No Insurer Record Found for Entered ID!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }
                else if (polDT.Rows.Count == 0)
                {
                    lblMsg.Text = "No Policy Record Found for Entered ID!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }
                else if (benDT.Rows.Count == 0)
                {
                    lblMsg.Text = "No Benefactor Record Found for Entered ID!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }
                else if (insBenDT.Rows.Count == 0)
                {
                    lblMsg.Text = "No Benefactor Record Found for Entered Insurer ID!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }
                else if (insPolBenDT.Rows.Count != 0)
                {
                    lblMsg.Text = "Policy Already Exists For Insurer!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }
                else
                {
                    int coverDuration = polDT.Rows[0].Field<int>(7);
                    DateTime startDate = DateTime.Now;
                    string startDay = startDate.Day.ToString();
                    string startMonth = startDate.Month.ToString();
                    int startYear = Convert.ToInt32(startDate.Year);
                    int endYear = startYear + coverDuration;
                    string strEndDate = endYear.ToString() + "-" + startMonth + "-" + startDay;
                    string strStartDate = startYear.ToString() + "-" + startMonth + "-" + startDay;

                    string insertPurchasedPolicyQuery = "INSERT INTO PURCHASED_POLICY(INS_ID, POL_ID, Poliy_Status, Start_Date, End_Date) VALUES (" + insID + ", " + polID + ", 'Ongoing', '" + strStartDate + "', '" + strEndDate + "');";

                    string insertPurchasedPolicyBenefactorQuery = "INSERT INTO PURCHASED_POLICY_BENEFACTOR(INS_ID, POL_ID, B_ID) VALUES (" + insID +", " + polID + ", " + benID + ");";

                    fn.Query(insertPurchasedPolicyQuery);
                    fn.Query(insertPurchasedPolicyBenefactorQuery);
                    lblMsg.Text = "Policy Successfully Added For Insurer!";
                    lblMsg.CssClass = "alert alert-success";
                    txtInsID.Text = string.Empty;
                    txtPolID.Text = string.Empty;
                    txtBenID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}