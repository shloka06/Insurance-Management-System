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
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int payID = Convert.ToInt32(txtPayID.Text.Trim());
                DataTable dt = fn.Fetch("SELECT * FROM PAYMENT_DETAILS WHERE Transaction_Status = 'Pending' AND PAY_ID = " + payID + ";");
                if (dt.Rows.Count > 0)
                {
                    string updatePayStatusQuery = "UPDATE PAYMENT_DETAILS SET Transaction_Status = 'Paid' WHERE PAY_ID = " + payID + ";";
                    fn.Query(updatePayStatusQuery);

                    lblMsg.Text = "Payment Request Approved!";
                    lblMsg.CssClass = "alert alert-success";
                    txtPayID.Text = string.Empty;
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