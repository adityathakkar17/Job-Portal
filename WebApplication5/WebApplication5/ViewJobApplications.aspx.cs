using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class ViewJobApplications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack && Session["role"] != null && Session["role"].ToString() == "JobApplicant")
            {
                JobApplicationReference.JobApplicationServiceClient proxy = new JobApplicationReference.JobApplicationServiceClient();
                DataSet ds = proxy.GetJobApplicationsOfApplicant(Convert.ToInt32(Session["JobApplicantId"]));
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            
        }
    }
}