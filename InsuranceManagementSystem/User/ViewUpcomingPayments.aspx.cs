using System;
using System.Data;
using System.Globalization;
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
            GetPaymentSchedule();
        }

        protected void GetPaymentSchedule()
        {
            int insID = CurrentSession.currentSession.SessionID;
            CultureInfo culture = new CultureInfo("en-IN");

            DataTable paySchedDT = new DataTable();
            paySchedDT.Columns.Add("Policy ID", typeof(int));
            paySchedDT.Columns.Add("Policy Name", typeof(string));
            paySchedDT.Columns.Add("Payment Amount", typeof(int));
            paySchedDT.Columns.Add("Due Date", typeof(DateTime));

            DataTable purchasedPolDT = fn.Fetch("SELECT * FROM PURCHASED_POLICY WHERE INS_ID = " + insID + ";");

            for (int polNo = 0; polNo < purchasedPolDT.Rows.Count; polNo++)
            {
                int polID = Convert.ToInt32(purchasedPolDT.Rows[polNo]["POL_ID"]);
                string polStatus = purchasedPolDT.Rows[polNo]["Policy_Status"].ToString();
                bool proceed = false;

                switch (polStatus)
                {
                    case "Ongoing":
                        proceed = true;
                        break;

                    case "Claim Submitted":
                        lblMsg.Text = "No Upcoming Payments - Claim has been Submitted for this Policy!";
                        lblMsg.CssClass = "alert alert-danger";
                        break;

                    case "Expired":
                        lblMsg.Text = "This Policy has Expired!";
                        lblMsg.CssClass = "alert alert-danger";
                        break;

                    case "Paid Out":
                        lblMsg.Text = "This Policy has been Paid Out!";
                        lblMsg.CssClass = "alert alert-danger";
                        break;

                    case "Cancelled":
                        lblMsg.Text = "This Policy has been Cancelled!";
                        lblMsg.CssClass = "alert alert-danger";
                        break;

                    default:
                        lblMsg.Text = "No Payment Record for this Policy!";
                        lblMsg.CssClass = "alert alert-danger";
                        break;
                }

                if (!proceed)
                {
                    return;
                }

                DataTable policyDT = fn.Fetch("EXEC PurchasedPolicyDetailsForUser @polID = " + polID + ", @insID = " + insID + ";");

                DateTime today = DateTime.Now;
                DateTime startDate = Convert.ToDateTime(policyDT.Rows[0]["Start_Date"]);
                DateTime endDate = Convert.ToDateTime(policyDT.Rows[0]["End_Date"]);
                int payAmt = Convert.ToInt32(policyDT.Rows[0]["Payment_Amount"]);
                string paySchedule = policyDT.Rows[0]["Payment_Schedule"].ToString();
                string polName = policyDT.Rows[0]["Policy_Name"].ToString();
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

                int nextDay = startDay, nextMonth = startMonth, nextYear = startYear;

                for (int i = 0; i < 10; i++)
                {
                    if (nextYear < endYear)
                    {
                        String sNextDate = startDay + "/" + nextMonth + "/" + nextYear;
                        DateTime nextDate = Convert.ToDateTime(sNextDate, culture);
                        paySchedDT.Rows.Add(polID, polName, payAmt, nextDate);

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
            }
            paySchedDT.DefaultView.Sort = "Due Date ASC";
            PaymentsGridView.DataSource = paySchedDT;
            PaymentsGridView.DataBind();
        }
    }
}