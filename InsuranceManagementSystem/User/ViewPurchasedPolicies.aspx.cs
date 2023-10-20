using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.User
{
    public partial class ViewPurchasedPolicies : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "User" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
            GetPurchasedPolicies();
        }

        protected void GetPurchasedPolicies()
        {
            int insID = CurrentSession.currentSession.SessionID;
            string getPoliciesQuery = "DECLARE @result int; EXEC PurchasedPoliciesForUser @insID = " + insID + ", @count = @result OUTPUT;";

            DataTable policyData = fn.Fetch(getPoliciesQuery);

            purchasedPolicyData.DataSource = policyData;
            purchasedPolicyData.DataBind();
        }
    }
}