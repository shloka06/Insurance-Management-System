using InsuranceManagementSystem.Agent_Classes;
using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class GetInsurerDetails : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        Insurer insurer = new Insurer();
        public int InsID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected bool GetInsurerID()
        {
            if (searchInsID.Text.Equals(string.Empty))
                return false;

            InsID = Convert.ToInt32(searchInsID.Text.Trim());
            return true;
        }

        public bool GetInsDetails(int insID)
        {
            DataTable insDetailsDT = fn.Fetch("EXEC InsurerDetails @insID = " + insID + ";");

            if (insDetailsDT.Rows.Count < 1)
            {
                ClearForm();
                return false;
            }
            else
            {
                txtInsID.Text = insDetailsDT.Rows[0].Field<int>(0).ToString();
                txtInsName.Text = insDetailsDT.Rows[0].Field<string>(1);
                txtDOB.Text = insDetailsDT.Rows[0].Field<DateTime>(2).ToLongDateString();
                txtAddr.Text = insDetailsDT.Rows[0].Field<string>(3);
                return true;
            }
        }

        protected void FillPhoneNum(int insID)
        {
            DataTable phNoDT = fn.Fetch("SELECT PhNo AS \"Phone Numbers\" FROM INSURER_PHNO WHERE INS_ID = " + insID + ";");
            PhoneNumGridView.DataSource = phNoDT;
            PhoneNumGridView.DataBind();
        }

        protected void FillBenefactorTable(int insID)
        {
            DataTable benForInsDT = fn.Fetch("EXEC BenefactorsForInsurer @insID = " + insID + ";");
            BenefactorGridView.DataSource = benForInsDT;
            BenefactorGridView.DataBind();
        }

        protected void FillPolicyTable(int insID)
        {
            DataTable purPolDT = fn.Fetch("EXEC PurchasedPolicyForInsurer @insID = " + insID + ";");
            PolicyGridView.DataSource = purPolDT;
            PolicyGridView.DataBind();
        }

        protected void ClearForm()
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

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (!GetInsurerID())
            {
                ClearForm();
                return;
            }

            bool insSuccess = GetInsDetails(InsID);
            if(!insSuccess)
            {
                ClearForm();
                return;
            }

            FillPhoneNum(InsID);
            FillBenefactorTable(InsID);
            FillPolicyTable(InsID);
        }
    }
}