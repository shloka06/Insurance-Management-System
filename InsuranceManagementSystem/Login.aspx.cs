using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Value.Trim();
            string password = inputPassword.Value.Trim();

            DataTable agents = fn.Fetch("SELECT A_ID FROM AGENT WHERE Username = '" + username + "' AND Password = '" + password + "';");
            DataTable users = fn.Fetch("SELECT INS_ID FROM INSURER WHERE Username = '" + username + "' AND Password = '" + password + "';");

            if (agents.Rows.Count > 0)
            {
                CurrentSession.currentSession.SessionName = "Agent";
                CurrentSession.currentSession.SessionID = Convert.ToInt32(agents.Rows[0][0]);

                Response.Redirect("Agent/AgentHome.aspx");
            }
            else if (users.Rows.Count > 0)
            {
                CurrentSession.currentSession.SessionName = "User";
                CurrentSession.currentSession.SessionID = Convert.ToInt32(users.Rows[0][0]);

                Response.Redirect("User/UserHome.aspx");
            }
            else
            {
                lblMsg.Text = "Incorrect Username or Password!";
                lblMsg.CssClass = "alert alert-danger";
            }
        }
    }
}