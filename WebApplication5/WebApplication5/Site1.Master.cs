using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"]!=null)
            {
                Login.Visible = false;
                logout1.Visible = true;
                if (Session["role"].Equals("Company"))
                {
                    CompanyHome.Visible = true;
                    CSignup.Visible = false;
                }
                else if (Session["role"].Equals("JobApplicant"))
                {
                    JobApplications.Visible = true;
                    JSignup.Visible = false;
                }
                else if (Session["role"].Equals("Admin"))
                    AdminHome.Visible = true;
            }
            
        }
        
        protected void logout1_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Session["CompanyId"] = null;
            Session["CompanyId"] = null;
            logout1.Visible = false;
            Login.Visible = true;
            CSignup.Visible = true;
            JSignup.Visible = true;
            CompanyHome.Visible = false;
            JobApplications.Visible = false;
            AdminHome.Visible = false;
            Response.Redirect("~/Home.aspx");
        }
    }
}