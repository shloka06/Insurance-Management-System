using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int InsID = CurrentSession.currentSession.SessionID;
            string getPoliciesQuery = "SELECT P_P.POL_ID AS \"Policy ID\", P.Policy_Name AS \"Policy Name\", P.Policy_Type AS \"Policy Type\", P.Insured_Amount AS \"Insured Amount\", P_P.Policy_Status AS \"Policy Status\", P_P.Start_Date AS \"Start Date\", P_P.End_Date AS \"End Date\", P.Payment_Schedule AS \"Payment Schedule\", P.Payment_Amount AS \"Payment Amount\", P.Payment_Duration AS \"Payment Duration\", P.Cover_Duration AS \"Cover Duration\", B.B_ID AS \"Benefactor ID\", B.B_Name AS \"Benefactor Name\" FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.POL_ID = P.POL_ID INNER JOIN PURCHASED_POLICY_BENEFACTOR AS P_P_B ON P_P.POL_ID = P_P_B.POL_ID INNER JOIN BENEFACTOR AS B ON P_P_B.B_ID = B.B_ID WHERE P_P.INS_ID = " + InsID + " AND P_P_B.INS_ID = " + InsID + ";";

            DataTable policyData = fn.Fetch(getPoliciesQuery);

            purchasedPolicyData.DataSource = policyData;
            purchasedPolicyData.DataBind();
        }
    }
}