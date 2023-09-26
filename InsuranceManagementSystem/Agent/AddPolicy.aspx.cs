using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class AddPolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("Select * from POLICY where Policy_Name='" + txtPolicy.Text.Trim() + "' ");
                if (dt.Rows.Count == 0)
                {
                    string polName = txtPolicy.Text.Trim();
                    string polType = Request.Form["policyTypeItems"];
                    int insdAmt = Convert.ToInt32(txtInsuredAmt.Text.Trim());
                    string paySched = Request.Form["paymentSchedItems"];
                    int payAmt = Convert.ToInt32(txtPaymentAmount.Text.Trim());
                    int payDurn = Convert.ToInt32(txtPaymentDuration.Text.Trim());
                    int covDurn = Convert.ToInt32(txtCoverDuration.Text.Trim());


                    string query = "INSERT INTO POLICY (Policy_Name, Policy_Type, Insured_Amount, Payment_Schedule, Payment_Amount, Payment_Duration, Cover_Duration) VALUES ('" + polName + "', '" + polType + "', " + insdAmt + ", '" + paySched + "', " + payAmt + ", " + payDurn + ", " + covDurn + ")";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    txtPolicy.Text = string.Empty;
                    txtInsuredAmt.Text = string.Empty;
                    txtPaymentAmount.Text = string.Empty;
                    txtPaymentDuration.Text = string.Empty;
                    txtCoverDuration.Text = string.Empty;
                }
                else
                {
                    lblMsg.Text = "Policy With Entered Name Already Exists";
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