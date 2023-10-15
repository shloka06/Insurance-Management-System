using InsuranceManagementSystem.Agent_Classes;
using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;


namespace InsuranceManagementSystem.Agent
{
    public partial class AddPolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        Policy policy = new Policy();
        int PolID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected Policy GetPolicyDetails()
        {
            policy.PolicyName = txtPolicy.Text.Trim();
            policy.PolicyType = Request.Form["policyTypeItems"];
            policy.InsuredAmount = Convert.ToInt32(txtInsuredAmt.Text.Trim());
            policy.PaymentSchedule = Request.Form["paymentSchedItems"];
            policy.PaymentAmount = Convert.ToInt32(txtPaymentAmount.Text.Trim());
            policy.PaymentDuration = Convert.ToInt32(txtPaymentDuration.Text.Trim());
            policy.CoverDuration = Convert.ToInt32(txtCoverDuration.Text.Trim());
            return policy;
        }

        public bool DoesPolicyExist(int polID)
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT * FROM POLICY WHERE Policy_Name='" + polID + "' ");
                if (dt.Rows.Count == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public bool InsertPolicyRecord(Policy policy)
        {
            try
            {
                string query = "INSERT INTO POLICY (Policy_Name, Policy_Type, Insured_Amount, Payment_Schedule, Payment_Amount, Payment_Duration, Cover_Duration) VALUES ('" + policy.PolicyName + "', '" + policy.PolicyType + "', " + policy.InsuredAmount + ", '" + policy.PaymentSchedule + "', " + policy.PaymentAmount + ", " + policy.PaymentDuration + ", " + policy.CoverDuration + ")";
                fn.Query(query);
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public void ClearForm()
        {
            txtPolicy.Text = string.Empty;
            txtInsuredAmt.Text = string.Empty;
            txtPaymentAmount.Text = string.Empty;
            txtPaymentDuration.Text = string.Empty;
            txtCoverDuration.Text = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PolID = Convert.ToInt32(txtPolicy.Text.Trim());
            bool policyFound = DoesPolicyExist(PolID);
            bool polSuccess = false;

            if (!policyFound)
            {
                policy = GetPolicyDetails();
                polSuccess = InsertPolicyRecord(policy);
            }
            else
            {
                lblMsg.Text = "Policy With Entered Name Already Exists";
                lblMsg.CssClass = "alert alert-danger";
                ClearForm();
            }

            if (polSuccess)
            {
                lblMsg.Text = "Inserted Successfully!";
                lblMsg.CssClass = "alert alert-success";
                ClearForm();
            }  
        }
    }
}