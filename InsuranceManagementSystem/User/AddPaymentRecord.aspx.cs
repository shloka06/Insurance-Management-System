using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.User
{
    public partial class AddPaymentRecord : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        static DateTime DueDate = new DateTime();
        static int PaidAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "User" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }

            btnPay.Visible = false;
            PaymentGrid.DataSource = null;
            PaymentGrid.DataBind();

            int insID = CurrentSession.currentSession.SessionID;
            DataTable purchasedPolIDs = fn.Fetch("SELECT POL_ID FROM PURCHASED_POLICY WHERE INS_ID = " + insID + ";");

            if (policyIDItems.Items.Count == 0)
            {
                for (int polNo = 0; polNo < purchasedPolIDs.Rows.Count; polNo++)
                {
                    policyIDItems.Items.Add(purchasedPolIDs.Rows[polNo][0].ToString());

                }
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int insID = CurrentSession.currentSession.SessionID;
            int polID = Convert.ToInt32(policyIDItems.SelectedValue);

            DataTable paySchedDT = new DataTable();
            paySchedDT.Columns.Add("Policy ID", typeof(int));
            paySchedDT.Columns.Add("Policy Name", typeof(string));
            paySchedDT.Columns.Add("Payment Amount", typeof(int));
            paySchedDT.Columns.Add("Due Date", typeof(DateTime));

            CultureInfo culture = new CultureInfo("en-IN");

            DataTable purchasedPolDT = fn.Fetch("SELECT * FROM PURCHASED_POLICY WHERE INS_ID = " + insID + " AND POL_ID = " + polID + ";");


            string polStatus = purchasedPolDT.Rows[0]["Policy_Status"].ToString();
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

            DataTable policyDT = fn.Fetch("SELECT * FROM PURCHASED_POLICY AS P_P INNER JOIN POLICY AS P ON P_P.POL_ID = P.POL_ID WHERE P_P.POL_ID = " + polID + " AND P_P.INS_ID = " + insID + "; ");

            DateTime today = DateTime.Now;
            DateTime startDate = Convert.ToDateTime(policyDT.Rows[0]["Start_Date"]);
            DateTime endDate = Convert.ToDateTime(policyDT.Rows[0]["End_Date"]);
            int payAmt = Convert.ToInt32(policyDT.Rows[0]["Payment_Amount"]);
            string polName = policyDT.Rows[0]["Policy_Name"].ToString();


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


            if (startYear < endYear)
            {
                String sNextDate = startDay + "/" + startMonth + "/" + startYear;
                DateTime nextDate = Convert.ToDateTime(sNextDate, culture);
                DueDate = nextDate;
                PaidAmount = payAmt;
                paySchedDT.Rows.Add(polID, polName, payAmt, nextDate);
            }
            else
            {
                lblMsg.Text = "No Upcoming Payments or this Policy!";
                lblMsg.CssClass = "alert alert-danger";
            }

            PaymentGrid.DataSource = paySchedDT;
            PaymentGrid.DataBind();
            btnPay.Visible = true;
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            int insID = CurrentSession.currentSession.SessionID;
            int polID = Convert.ToInt32(policyIDItems.SelectedValue);
            string dueDateStr = DueDate.Year.ToString() + "-" + DueDate.Month.ToString() + "-" + DueDate.Day.ToString();
            string todayDateStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

            string insertPayDetailsQuery = "INSERT INTO PAYMENT_DETAILS(Amount, Due_Date, Date_Paid, Transaction_Status) VALUES (" + PaidAmount + ", '" + dueDateStr + "' , '" + todayDateStr + "', 'Pending');";
            fn.Query(insertPayDetailsQuery);

            DataTable insertedPayment = fn.Fetch("SELECT IDENT_CURRENT('PAYMENT_DETAILS');");
            int payID = Convert.ToInt32(insertedPayment.Rows[0][0]);

            string insertPayRecQuery = "INSERT INTO PAYMENT_RECORD(PAY_ID, INS_ID, POL_ID) VALUES (" + payID + ", " + insID + ", " + polID + ");";
            fn.Query(insertPayRecQuery);

            lblMsg.Text = "Payment Record Submitted Successfully!";
            lblMsg.CssClass = "alert alert-success";
        }
    }
}