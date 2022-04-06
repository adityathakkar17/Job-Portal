using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class AddJobCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].Equals("Admin"))
            {
                if (!IsPostBack)
                {
                    BindGV1();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            int inserted = proxy.AddJobCategory(JobCategory.Text);
            if (inserted == 1)
            {
                Response.Write("<script>alert('New Job Category added successfully');</script>");
            }
            else if (inserted == 0)
            {
                Response.Write("<script>alert('Job with similar category already exists.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please try again.');</script>");
            }
            BindGV1();
        }
        public void BindGV1()
        {
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            if (Session["AdminId"] != null)
            {
                DataSet ds = proxy.GetAllJobs();
                GridView1.DataSource = ds;
                GridView1.DataBind();
                JobCategory.Text = "";
            }

        }
    }
}