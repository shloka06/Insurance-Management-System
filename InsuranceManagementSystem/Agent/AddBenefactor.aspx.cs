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
    public partial class AddBenefactor : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int insID = Convert.ToInt32(txtInsID.Text.Trim());
                DataTable dt = fn.Fetch("Select * from INSURER where INS_ID = " + insID + ";");
                if (dt.Rows.Count != 0)
                {
                    DataTable dt1 = fn.Fetch("Select * from INSURER_BENEFACTOR where INS_ID = " + insID + ";");
                    if (dt1.Rows.Count < 5)
                    {
                        string benFName = txtBenefactorFName.Text.Trim();
                        string benLName = txtBenefactorLName.Text.Trim();
                        string benName = benFName + " " + benLName;
                        DateTime benDOB = Convert.ToDateTime(Request["txtBenefactorDOB"]);
                        int benDay = benDOB.Date.Day;
                        int benMonth = benDOB.Date.Month;
                        int benYear = benDOB.Date.Year;
                        string benDOBStr = benYear.ToString() + "-" + benMonth.ToString() + "-" + benDay.ToString();
                        string reln = Request.Form["relationshipItems"];

                        string insertBenefactorQuery = "INSERT INTO BENEFACTOR VALUES ('" + benName + "', '" + benDOBStr + "');";
                        fn.Query(insertBenefactorQuery);
                        string getBenefactorIDQuery = "SELECT B_ID FROM BENEFACTOR WHERE B_Name = '" + benName + "';";
                        int benID = fn.Fetch(getBenefactorIDQuery).Rows[0].Field<int>(0);

                        string insertInsurerBenefactorQuery = "INSERT INTO INSURER_BENEFACTOR(INS_ID, B_ID, Relationship) VALUES (" + insID + ", " + benID + ", '" + reln + "');";
                        fn.Query(insertInsurerBenefactorQuery);

                        lblMsg.Text = "Inserted Successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        txtInsID.Text = string.Empty;
                        txtBenefactorFName.Text = string.Empty;
                        txtBenefactorLName.Text = string.Empty;
                    }
                    else
                    {
                        lblMsg.Text = "Insurer Already has Max. No. of Benefactors Added!";
                        lblMsg.CssClass = "alert alert-danger";
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "No Insurer Record Exists for Entered ID";
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