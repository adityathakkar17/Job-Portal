using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class CompanyRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBtn(object sender, EventArgs e)
        {
            WebApplication5.ManageUserReference.ManageUserServiceClient proxy = new ManageUserReference.ManageUserServiceClient("BasicHttpBinding_IManageUserService");
            ManageUserReference.Company c = new ManageUserReference.Company();
            c.Name = CName.Text;
            c.Password = Password.Text;
            c.Email = Username.Text;
            c.Location = Location.Text;
            int added = proxy.AddCompany(c);
            if (added == 1)
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