using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class ApplyForJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            WebApplication5.ManageUserReference.ManageUserServiceClient proxy = new ManageUserReference.ManageUserServiceClient("BasicHttpBinding_IManageUserService");
            ManageUserReference.JobApplicant j = new ManageUserReference.JobApplicant();
            j.Name = JName.Text;
            j.Password = Password.Text;
            j.Email = Email.Text;
            j.Phone = Mnumber.Text;
            int added = proxy.AddJobApplicant(j);
            if(added==1)
            {
                Session["newRegistration"] = "1";
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Issue in registering or user already exists.Please try again !!');</script>");
            }
        }
    }
}