using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.User
{
    public partial class UserMst : System.Web.UI.MasterPage
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "User" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }

            int insID = CurrentSession.currentSession.SessionID;
            DataTable dt = fn.Fetch("SELECT Ins_Name FROM INSURER WHERE INS_ID = " + insID + ";");
            userName.InnerText = dt.Rows[0][0].ToString();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            CurrentSession.currentSession.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}