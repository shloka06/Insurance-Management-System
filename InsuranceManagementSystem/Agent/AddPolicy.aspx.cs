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
                    
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}