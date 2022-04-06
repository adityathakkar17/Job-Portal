using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["newRegistration"]!=null && Session["newRegistration"].Equals("1"))
                {
                    Response.Write("<script>alert('Successfully registered. Please Login to continue !!');</script>");
                    Session["newRegistration"] =null;
                }
            }
        }

        protected void LoginCompanyBtn_Click(object sender, EventArgs e)
        {
            WebApplication5.ManageUserReference.ManageUserServiceClient proxy = new ManageUserReference.ManageUserServiceClient("BasicHttpBinding_IManageUserService");
            ManageUserReference.User u = proxy.LogIn(mail.Text, password.Text,1);
            if(u.UserId==-1)
            {
                Response.Write("<script>alert('Invalid credentials or User does not exist !!');</script>");
            }
            else
            {
                Session["CompanyId"] = u.UserId;
                Session["role"] = "Company";
                Response.Redirect("~/ManagePost.aspx");
            }
        }

        protected void LoginJobApplicantBtn_Click(object sender, EventArgs e)
        {
            WebApplication5.ManageUserReference.ManageUserServiceClient proxy = new ManageUserReference.ManageUserServiceClient("BasicHttpBinding_IManageUserService");
            ManageUserReference.User u = proxy.LogIn(mail.Text, password.Text,2);
            if (u.UserId == -1)
            {
                Response.Write("<script>alert('Invalid credentials or User does not exist !!');</script>");
            }
            else
            {
                Session["JobApplicantId"] = u.UserId;
                Session["role"] = "JobApplicant";
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void LoginAdminBtn_Click(object sender, EventArgs e)
        {
            WebApplication5.ManageUserReference.ManageUserServiceClient proxy = new ManageUserReference.ManageUserServiceClient("BasicHttpBinding_IManageUserService");
            ManageUserReference.User u = proxy.LogIn(mail.Text, password.Text, 0);
            if (u.UserId == -1)
            {
                Response.Write("<script>alert('Invalid credentials or User does not exist !!');</script>");
            }
            else
            {
                Session["AdminId"] = u.UserId;
                Session["role"] = "Admin";
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}