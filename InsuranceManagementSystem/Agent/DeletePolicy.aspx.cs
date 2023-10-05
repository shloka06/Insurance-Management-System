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
    public partial class DeletePolicy : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }

            populateDeletablePolicies();
        }

        protected void populateDeletablePolicies()
        {
            policyIDItems.Items.Clear();

            DataTable purchasedPolIDs = fn.Fetch("SELECT POL_ID FROM POLICY WHERE POL_ID NOT IN (SELECT DISTINCT POL_ID FROM PURCHASED_POLICY);");

            if (purchasedPolIDs.Rows.Count != 0)
            {
                for (int polNo = 0; polNo < purchasedPolIDs.Rows.Count; polNo++)
                {
                    policyIDItems.Items.Add(purchasedPolIDs.Rows[polNo][0].ToString());
                }
            }
            else
            {
                policyIDItems.Enabled = false;
                lblMsg.Text = "All Policies have Active Insurers - Nothing can be Deleted at the Moment!!";
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int polID = Convert.ToInt32(policyIDItems.SelectedValue);
                string query = "DELETE FROM POLICY WHERE POL_ID ='" + polID + "'";
                fn.Query(query);
                populateDeletablePolicies();
                lblMsg.Text = "Deleted Successfully!";
                lblMsg.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}