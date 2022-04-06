using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class ManagePost : System.Web.UI.Page
    {
        public void BindGV1()
        {
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            if(Session["CompanyId"]!=null)
            {
                DataSet ds1 = proxy.GetJobsofCompany(Convert.ToInt32(Session["CompanyId"]));
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].Equals("Company"))
            {
                if (!IsPostBack)
                {
                    JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
                    DataSet ds = proxy.GetAllJobs();
                    DropDownList1.DataSource = ds.Tables["Job"];
                    DropDownList1.Items.Clear();
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();
                    DataSet ds1 = proxy.GetJobsofCompany(Convert.ToInt32(Session["CompanyId"]));
                    GridView1.DataSource = ds1;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            JobReference.Job j = new JobReference.Job();
            j.CategoryId=Convert.ToInt32(DropDownList1.SelectedItem.Value);
            j.CompanyId = Convert.ToInt32(Session["CompanyId"]);
            j.Duration = Convert.ToInt32(Duration.Text);
            j.Vacancy= Convert.ToInt32(Vacancy.Text);
            j.Salary = Convert.ToInt32(Salary.Text);
            int inserted = proxy.AddJob(j);
            if(inserted==1)
            {
                Response.Write("<script>alert('New Job Post added successfully');</script>"); 
            }
            else if(inserted==0)
            {
                Response.Write("<script>alert('Job with similar post already exists.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please try again.');</script>");
            }
            BindGV1();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGV1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label Id = (Label)row.FindControl("lblId");
            TextBox duration = (TextBox)row.FindControl("txtduration");
            TextBox vacancy = (TextBox)row.FindControl("txtvacancy");
            TextBox salary = (TextBox)row.FindControl("txtsalary");
            JobReference.Job j = new JobReference.Job();
            j.JobId = Convert.ToInt32(Id.Text);
            j.Duration = Convert.ToInt32(duration.Text);
            j.Vacancy = Convert.ToInt32(vacancy.Text);
            j.Salary = Convert.ToInt32(salary.Text);
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            int updated = proxy.UpdateJob(j);
            if (updated==1)
            {
                Response.Write("<script>alert('Job Post updated successfully');</script>");
            }
            else 
            {
                Response.Write("<script>alert('Please try again');</script>");
            }
            GridView1.EditIndex = -1;
            BindGV1();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Response.Write("<script>alert('Updation cancel!')</script>");
            BindGV1();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            int index = e.RowIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label Id = (Label)row.FindControl("lblId");
            int deleted=proxy.DeleteJob(Convert.ToInt32(Id.Text));
            if(deleted==1)
            {
                Response.Write("<script>alert('Job Post deleted successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please try again');</script>");
            }
            BindGV1();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGV1();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Label jobId = (Label)row.FindControl("lblId");
                JobApplicationReference.JobApplicationServiceClient proxy = new JobApplicationReference.JobApplicationServiceClient("BasicHttpBinding_IJobApplicationService");
                DataSet ds = proxy.GetJobApplicationsOfJobCategory(Convert.ToInt32(jobId.Text));
                GridView2.DataSource = ds.Tables["JobApplications"];
                GridView2.DataBind();
                proxy.Close();
            }
        }
    }
}