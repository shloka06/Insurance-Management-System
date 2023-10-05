using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class GetInsurerDetails : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (searchInsID.Text.Equals(string.Empty))
                return;
            int insID = Convert.ToInt32(searchInsID.Text.Trim());
            DataTable dt1 = fn.Fetch("SELECT INS_ID , Ins_Name AS \"Insurer Name\", CONVERT(date, DOB) AS \"Date Of Birth\", House_Num + ', ' + Street + ', ' + Area + ', ' + City + ' - ' + CONVERT(nchar, Pincode) as \"Address\" FROM INSURER WHERE INS_ID = " + insID + ";");
            if (dt1.Rows.Count < 1)
            {
                lblMsg.Text = "No Insurer With Entered ID Exists!";
                lblMsg.CssClass = "alert alert-danger";

                searchInsID.Text = string.Empty;

                txtInsID.Text = string.Empty;
                txtInsName.Text = string.Empty;
                txtDOB.Text = string.Empty;
                txtAddr.Text = string.Empty;

                PhoneNumGridView.DataSource = null;
                PhoneNumGridView.DataBind();
 
                BenefactorGridView.DataSource = null;
                BenefactorGridView.DataBind();

                PolicyGridView.DataSource = null;
                PolicyGridView.DataBind();
            }
            else
            {
                txtInsID.Text = dt1.Rows[0].Field<int>(0).ToString();
                txtInsName.Text = dt1.Rows[0].Field<string>(1);
                txtDOB.Text = dt1.Rows[0].Field<DateTime>(2).ToLongDateString();
                txtAddr.Text = dt1.Rows[0].Field<string>(3);

                DataTable dt2 = fn.Fetch("SELECT PhNo AS \"Phone Numbers\" FROM INSURER_PHNO WHERE INS_ID = " + insID + ";");
                PhoneNumGridView.DataSource = dt2;
                PhoneNumGridView.DataBind();

                DataTable dt3 = fn.Fetch("SELECT I_B.B_ID AS \"Benefactor ID\", B.B_Name AS \"Benefactor Name\", CONVERT(date, B.B_DOB) AS \"Date Of Birth\", I_B.Relationship AS \"Relationship with Insurer\" FROM INSURER_BENEFACTOR AS I_B, BENEFACTOR AS B WHERE INS_ID = " + insID + " AND I_B.B_ID = B.B_ID;");
                BenefactorGridView.DataSource = dt3;
                BenefactorGridView.DataBind();

                DataTable dt4 = fn.Fetch("SELECT P_P.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Policy_Type AS \"Policy Type\", P_P.Policy_Status AS \"Policy Status\", P_P.Start_Date AS \"Policy Purchase Date\", P_P.End_Date AS \"Policy Maturity Date\", P_P_B.B_ID AS \"Benefactor ID\" FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.INS_ID = " + insID + " AND P_P.POL_ID = P.POL_ID INNER JOIN PURCHASED_POLICY_BENEFACTOR AS P_P_B ON P_P_B.INS_ID = " + insID + " AND P_P_B.POL_ID = P_P.POL_ID;");
                PolicyGridView.DataSource = dt4;
                PolicyGridView.DataBind();

                searchInsID.Text = string.Empty;
            } 
        }
    }
}