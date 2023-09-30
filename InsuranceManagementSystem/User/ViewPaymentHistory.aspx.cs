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
    public partial class ViewPaymentHistory : System.Web.UI.Page
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
            try
            {
                int insID = CurrentSession.currentSession.SessionID;

                DataTable dt = fn.Fetch("SELECT P.PAY_ID AS \"Payment ID\", P.Amount AS \"Payment Amount\", POL.POL_ID AS \"Policy ID\", POL.Policy_Name AS \"Policy Name\", P.Due_Date AS \"Due Date\", P.Date_Paid AS \"Date Paid\", P.Transaction_Status AS \"Transaction Status\" FROM PAYMENT_DETAILS AS P, PAYMENT_RECORD AS PR, POLICY AS POL WHERE P.PAY_ID = PR.PAY_ID AND PR.POL_ID = POL.POL_ID AND PR.INS_ID = " + insID + ";");

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    lblMsg.Text = "No Payment History Found!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}