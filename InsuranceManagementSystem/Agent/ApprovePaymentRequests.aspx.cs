using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ApprovePaymentRequests : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                GetPendingPayments();
            }
        }

        protected void GetPendingPayments()
        {
            try
            {
                DataTable pendingPaymentsDT = fn.Fetch("SELECT P.PAY_ID AS \"Payment ID\", P.Amount AS \"Payment Amount\", P.Due_Date AS \"Due Date\", P.Date_Paid AS \"Date Paid\", P.Transaction_Status AS \"Transaction Status\", I.INS_ID AS \"Insurer ID\", I.Ins_Name AS \"Insurer Name\", POL.POL_ID AS \"Policy ID\", POL.Policy_Name AS \"Policy Name\" FROM PAYMENT_DETAILS AS P, PAYMENT_RECORD AS PR, INSURER AS I, POLICY AS POL WHERE P.Transaction_Status='Pending' AND P.PAY_ID = PR.PAY_ID AND PR.INS_ID = I.INS_ID AND PR.POL_ID = POL.POL_ID;");

                payIDItems.Items.Clear();

                if (pendingPaymentsDT.Rows.Count != 0)
                {
                    for (int payNo = 0; payNo < pendingPaymentsDT.Rows.Count; payNo++)
                    {
                        payIDItems.Items.Add(pendingPaymentsDT.Rows[payNo][0].ToString());
                    }
                }
                else
                {
                    lblMsg.Text = "No Pending Payment Records!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int payID = Convert.ToInt32(payIDItems.SelectedValue);
                DataTable dt = fn.Fetch("SELECT * FROM PAYMENT_DETAILS WHERE Transaction_Status = 'Pending' AND PAY_ID = " + payID + ";");
                if (dt.Rows.Count > 0)
                {
                    string updatePayStatusQuery = "UPDATE PAYMENT_DETAILS SET Transaction_Status = 'Paid' WHERE PAY_ID = " + payID + ";";
                    fn.Query(updatePayStatusQuery);

                    lblMsg.Text = "Payment Request Approved!";
                    lblMsg.CssClass = "alert alert-success";
                    GetPendingPayments();
                }
                else
                {
                    lblMsg.Text = "No Pending Payment Record Exists For Entered Payment ID!";
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