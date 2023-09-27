using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ViewPaymentHistory : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT P.PAY_ID AS \"Payment ID\", P.Amount AS \"Payment Amount\", P.Due_Date AS \"Due Date\", P.Date_Paid AS \"Date Paid\", P.Transaction_Status AS \"Transaction Status\", I.INS_ID AS \"Insurer ID\", I.Ins_Name AS \"Insurer Name\", POL.POL_ID AS \"Policy ID\", POL.Policy_Name AS \"Policy Name\" FROM PAYMENT_DETAILS AS P, PAYMENT_RECORD AS PR, INSURER AS I, POLICY AS POL WHERE P.Transaction_Status='Paid' AND P.PAY_ID = PR.PAY_ID AND PR.INS_ID = I.INS_ID AND PR.POL_ID = POL.POL_ID;");

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