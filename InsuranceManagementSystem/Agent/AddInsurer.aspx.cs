using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class AddInsurer : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string insFName = txtInsurerFName.Text.Trim();
                string insLName = txtInsurerLName.Text.Trim();
                string insName = insFName + " " + insLName;
                DateTime insDOB = Convert.ToDateTime(Request["txtInsurerDOB"]);
                int day = insDOB.Date.Day;
                int month = insDOB.Date.Month;
                int year = insDOB.Date.Year;
                string insDOBStr = year.ToString() + "-" + month.ToString() + "-" + day.ToString();
                string houseNum = txtHouseNum.Text.Trim();
                string street = txtStreet.Text.Trim();
                string area = txtArea.Text.Trim();
                string city = txtCity.Text.Trim();
                string pincode = txtPincode.Text.Trim();
                string username = insFName + year.ToString().Substring(2, 2);
                string password = "Pass123";

                string insertInsurerQuery = "INSERT INTO INSURER (Ins_Name, DOB, House_Num, Street, Area, City, Pincode, Username, Password)\r\nVALUES\r\n('" + insName + "', '" + insDOBStr + "', '" + houseNum + "', '" + street + "', '" + area + "', '" + city + "', " + pincode + ", '" + username + "', '" + password + "');";

                fn.Query(insertInsurerQuery);

                string getInsurerIDQuery = "SELECT INS_ID FROM INSURER WHERE Username = '" + username + "';";
                int insID = fn.Fetch(getInsurerIDQuery).Rows[0].Field<int>(0);

                string phNo1 = txtPhNo1.Text.Trim();
                string insertInsurerPhNoQuery = "INSERT INTO INSURER_PHNO VALUES (" + insID + ", '" + phNo1 + "')";
                
                string phNo2 = txtPhNo2.Text.Trim();
                if (phNo2 != string.Empty)
                {
                    insertInsurerPhNoQuery = insertInsurerPhNoQuery + ", (" + insID + ", '" + phNo2 + "')";
                }

                string phNo3 = txtPhNo3.Text.Trim();
                if (phNo3 != string.Empty)
                {
                    insertInsurerPhNoQuery = insertInsurerPhNoQuery + ", (" + insID + ", '" + phNo3 + "')";
                }

                fn.Query(insertInsurerPhNoQuery);


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
                txtInsurerFName.Text = string.Empty;
                txtInsurerLName.Text = string.Empty;
                txtPhNo1.Text = string.Empty;
                txtPhNo2.Text = string.Empty;
                txtPhNo3.Text = string.Empty;
                txtHouseNum.Text = string.Empty;
                txtStreet.Text = string.Empty;
                txtArea.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtPincode.Text = string.Empty;
                txtBenefactorFName.Text = string.Empty;
                txtBenefactorLName.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}