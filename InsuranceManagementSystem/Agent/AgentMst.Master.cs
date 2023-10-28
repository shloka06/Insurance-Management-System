using System;

namespace InsuranceManagementSystem.Agent
{
    public partial class AgentMst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            CurrentSession.currentSession.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}