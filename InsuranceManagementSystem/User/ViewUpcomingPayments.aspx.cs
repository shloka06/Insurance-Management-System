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
    public partial class ViewUpcomingPayments : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "User" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnGetPayments_Click(object sender, EventArgs e)
        {
            int insID = CurrentSession.currentSession.SessionID;
            int polID = Convert.ToInt32(txtPolID.Text.Trim());

            DataTable purchasedPolDT = fn.Fetch("SELECT * FROM PURCHASED_POLICY WHERE POL_ID = " + polID + " AND INS_ID = " + insID + ";");

            if (purchasedPolDT.Rows.Count == 0)
            {
                lblMsg.Text = "You Have Not Purchased this Policy!";
                lblMsg.CssClass = "alert alert-danger";
                txtPolID.Text = string.Empty;
            }
            else
            {
                bool proceed = false;
                
                string polStatus = purchasedPolDT.Rows[0]["Policy_Status"].ToString();
                switch (polStatus)
                {
                    case "Ongoing":
                        proceed = true;
                        break;
                    
                    case "Claim Submitted":
                        lblMsg.Text = "No Upcoming Payments - Claim has been Submitted for this Policy!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        break;
                    
                    case "Expired":
                        lblMsg.Text = "This Policy has Expired!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        break;
                    
                    case "Paid Out":
                        lblMsg.Text = "This Policy has been Paid Out!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        break;
                    
                    case "Cancelled":
                        lblMsg.Text = "This Policy has been Cancelled!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        break;

                    default:
                        lblMsg.Text = "No Payment Record for this Policy!";
                        lblMsg.CssClass = "alert alert-danger";
                        txtPolID.Text = string.Empty;
                        break;
                }

                if (!proceed)
                {
                    return;
                }

                DataTable policyDT = fn.Fetch("SELECT * FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.POL_ID = P.POL_ID WHERE P_P.POL_ID = " + polID + " AND P_P.INS_ID = " + insID + "; ");

                DateTime today = DateTime.Now;
                DateTime startDate = Convert.ToDateTime(policyDT.Rows[0]["Start_Date"]);
                DateTime endDate = Convert.ToDateTime(policyDT.Rows[0]["End_Date"]);
                int payAmt = Convert.ToInt32(policyDT.Rows[0]["Payment_Amount"]);
                string paySchedule = policyDT.Rows[0]["Payment_Schedule"].ToString();
                int addMonths = 0, addYears = 0;

                switch (paySchedule)
                {
                    case "Monthly":
                        addMonths = 1;
                        break;
                    case "Quarterly":
                        addMonths = 3;
                        break;
                    case "Semi-Annual":
                        addMonths = 6;
                        break;
                    case "Annual":
                        addYears = 1;
                        break;
                }

                int todayDay = today.Day;
                int startDay = startDate.Day, endDay = endDate.Day, startMonth = today.Month, endMonth = endDate.Month, startYear = today.Year, endYear = endDate.Year;

                if (todayDay > startDay)
                {
                    if (startMonth != 12)
                        startMonth++;
                    else
                    {
                        startMonth = 1;
                        startYear++;
                    }
                }

                DataTable paySchedDT = new DataTable();
                paySchedDT.Columns.Add("Payment Amount", typeof(int));
                paySchedDT.Columns.Add("Due Date", typeof(string));


                int nextDay = startDay, nextMonth = startMonth, nextYear = startYear;

                for (int i = 0; i < 10; i++)
                {
                    if (nextYear < endYear)
                    {
                        paySchedDT.Rows.Add(payAmt, startDay + "-" + nextMonth + "-" + nextYear);

                        nextMonth = nextMonth + addMonths;
                        nextYear = nextYear + addYears;

                        if (nextMonth > 12)
                        {
                            nextMonth = nextMonth - 12;
                            nextYear = nextYear + 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                PaymentsGridView.DataSource = paySchedDT;
                PaymentsGridView.DataBind();

            }
        }
    }
}