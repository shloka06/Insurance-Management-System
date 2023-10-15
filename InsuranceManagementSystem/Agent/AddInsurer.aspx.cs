using InsuranceManagementSystem.Agent_Classes;
using InsuranceManagementSystem.User;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class AddInsurer : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        Insurer insurer = new Insurer();
        Benefactor benefactor = new Benefactor();
        public int InsID = 0;
        public int BenID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.currentSession.SessionName != "Agent" || CurrentSession.currentSession.SessionID == 0)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected Insurer GetNewInsurerDetails()
        {
            insurer.FirstName = txtInsurerFName.Text.Trim();
            insurer.LastName = txtInsurerLName.Text.Trim();

            DateTime insDOB = Convert.ToDateTime(Request["txtInsurerDOB"]);
            insurer.DOB_Day = insDOB.Date.Day;
            insurer.DOB_Mon = insDOB.Date.Month;
            insurer.DOB_Year = insDOB.Date.Year;

            insurer.HouseNo = txtHouseNum.Text.Trim();
            insurer.Street = txtStreet.Text.Trim();
            insurer.Area = txtArea.Text.Trim();
            insurer.City = txtCity.Text.Trim();
            insurer.Pincode = txtPincode.Text.Trim();

            insurer.PhNo1 = txtPhNo1.Text.Trim();
            insurer.PhNo2 = txtPhNo2.Text.Trim();
            insurer.PhNo3 = txtPhNo3.Text.Trim();

            insurer.Username = insurer.FirstName + insurer.DOB_Year.ToString().Substring(2, 2);
            insurer.Password = "Pass123";

            return insurer;
        }

        public bool AddNewInsurer(Insurer insurer)
        {
            try
            {
                if (insurer != null)
                {
                    string insName = insurer.FirstName + " " + insurer.LastName;
                    string insDOBStr = insurer.DOB_Year.ToString() + "-" + insurer.DOB_Mon.ToString() + "-" + insurer.DOB_Day.ToString();

                    string insertInsurerQuery = "INSERT INTO INSURER (Ins_Name, DOB, House_Num, Street, Area, City, Pincode, Username, Password)\r\nVALUES\r\n('" + insName + "', '" + insDOBStr + "', '" + insurer.HouseNo + "', '" + insurer.Street + "', '" + insurer.Area + "', '" + insurer.City + "', " + insurer.Pincode + ", '" + insurer.Username + "', '" + insurer.Password + "');";

                    fn.Query(insertInsurerQuery);
                    InsID = GetIDForAddedInsurer(insurer.Username);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public int GetIDForAddedInsurer(string username)
        {
            string getInsurerIDQuery = "SELECT INS_ID FROM INSURER WHERE Username = '" + username + "';";
            return fn.Fetch(getInsurerIDQuery).Rows[0].Field<int>(0);
        }

        public bool AddInsurerPhNo(Insurer insurer)
        {
            try
            {
                if (insurer != null)
                {
                    string insertInsurerPhNoQuery = "INSERT INTO INSURER_PHNO VALUES (" + InsID + ", '" + insurer.PhNo1 + "')";

                    if (insurer.PhNo2 != string.Empty)
                    {
                        insertInsurerPhNoQuery = insertInsurerPhNoQuery + ", (" + InsID + ", '" + insurer.PhNo2 + "')";
                    }

                    if (insurer.PhNo3 != string.Empty)
                    {
                        insertInsurerPhNoQuery = insertInsurerPhNoQuery + ", (" + InsID + ", '" + insurer.PhNo3 + "')";
                    }

                    fn.Query(insertInsurerPhNoQuery);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected Benefactor GetBenefactorDetails()
        {
            benefactor.FirstName = txtBenefactorFName.Text.Trim();
            benefactor.LastName = txtBenefactorLName.Text.Trim();

            DateTime benDOB = Convert.ToDateTime(Request["txtBenefactorDOB"]);
            benefactor.DOB_Day = benDOB.Date.Day;
            benefactor.DOB_Mon = benDOB.Date.Month;
            benefactor.DOB_Year = benDOB.Date.Year;

            benefactor.Relationship = Request.Form["relationshipItems"];

            return benefactor;
        }

        public bool AddBenefactorDetails(Benefactor benefactor)
        {
            try
            {
                if (benefactor != null)
                {
                    string benName = benefactor.FirstName + " " + benefactor.LastName;
                    string benDOBStr = benefactor.DOB_Year.ToString() + "-" + benefactor.DOB_Mon.ToString() + "-" + benefactor.DOB_Day.ToString();

                    string insertBenefactorQuery = "INSERT INTO BENEFACTOR VALUES ('" + benName + "', '" + benDOBStr + "');";
                    fn.Query(insertBenefactorQuery);

                    BenID = GetIDForAddedBenefactor(benName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public int GetIDForAddedBenefactor(string benName)
        {
            string getBenefactorIDQuery = "SELECT B_ID FROM BENEFACTOR WHERE B_Name = '" + benName + "';";
            return fn.Fetch(getBenefactorIDQuery).Rows[0].Field<int>(0);
        }

        public bool AddBenefactorForInsurer(Benefactor benefactor)
        {
            if (benefactor != null)
            {
                string insertInsurerBenefactorQuery = "INSERT INTO INSURER_BENEFACTOR(INS_ID, B_ID, Relationship) VALUES (" + InsID + ", " + BenID + ", '" + benefactor.Relationship + "');";
                fn.Query(insertInsurerBenefactorQuery);

                return true;
            }
            return false;
        }

        protected void ClearFormData()
        {
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                insurer = GetNewInsurerDetails();
                bool insSuccess = AddNewInsurer(insurer);
                bool phNoSuccess = AddInsurerPhNo(insurer);

                benefactor = GetBenefactorDetails();
                bool benSuccess = AddBenefactorDetails(benefactor);
                bool insBenSuccess = AddBenefactorForInsurer(benefactor);

                if (insSuccess && phNoSuccess && benSuccess && insBenSuccess)
                {
                    lblMsg.Text = "Insurer Record Inserted Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Insurer could not be Added!";
                    lblMsg.CssClass = "alert alert-danger";
                }

                ClearFormData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}