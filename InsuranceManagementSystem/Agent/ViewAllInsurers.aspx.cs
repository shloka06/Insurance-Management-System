using System;
using System.Data;
using static InsuranceManagementSystem.Models.CommonFn;

namespace InsuranceManagementSystem.Agent
{
    public partial class ViewAllInsurers : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GetClass();
            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("SELECT INS_ID AS \"Insurer ID\", Ins_Name AS \"Insurer Name\", TRY_CONVERT(date, DOB) AS \"Date Of Birth\", House_Num + ', ' + Street + ', ' + Area + ', ' + City + ' - ' + CONVERT(nchar, Pincode) as \"Address\" FROM INSURER;");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}