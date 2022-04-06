using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                WebApplication5.JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
                DataSet ds = proxy.GetAllJobs();
                //GridView1.DataSource = ds.Tables["Job"];
                DataList1.DataSource= ds.Tables["Job"];
                DataList1.DataBind();
                //GridView1.DataBind();
                proxy.Close();
            }
            
            //if (GridView1.Rows.Count == 0)
            //{
            //    NoSubServices.Text = "No Sub Services of Selected Service Found";
            //}
            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "Id";
            //DropDownList1.DataBind();
            
        }


        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = GridView1.Rows[index];
        //    Label jobBox = (Label)row.FindControl("lblsubsname");
        //    Label jobCategoryId = (Label)row.FindControl("lblsubsId");
        //    Label2.Text = "Jobs Showing for '" + jobBox.Text + " '";
        //    WebApplication5.JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
        //    DataSet ds = proxy.GetJobs(Convert.ToInt32(jobCategoryId.Text));
        //    if (e.CommandName == "Select" && Session["role"]!=null && Session["role"].ToString() == "JobApplicant")
        //    {   
        //        GridView3.DataSource = ds.Tables["Job"];
        //        if(ds.Tables["Job"].Rows.Count==0)
        //            Label2.Text= "No Jobs Found for '" + jobBox.Text + " '";
        //        GridView3.DataBind();
        //        proxy.Close();
        //    }
        //    else if (e.CommandName == "Select" )
        //    {
        //        GridView2.DataSource = ds.Tables["Job"];
        //        if (ds.Tables["Job"].Rows.Count == 0)
        //            Label2.Text = "No Jobs Found for '" + jobBox.Text + " '";
        //        GridView2.DataBind();
        //        proxy.Close();
        //    }
        //}


        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            JobApplicationReference.JobApplicationServiceClient proxy = new JobApplicationReference.JobApplicationServiceClient();
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView3.Rows[index];
            Label jobId = (Label)row.FindControl("lbljobId");
            JobApplicationReference.JobApplication ja = new JobApplicationReference.JobApplication();
            ja.JobApplicantId = Convert.ToInt32(Session["JobApplicantId"]);
            ja.JobId = Convert.ToInt32(jobId.Text);
            int applied = proxy.ApplyJob(ja);
            if (applied==1)
            {
                Response.Write("<script>alert('Job Application successfully');</script>");
            }
            else if(applied==0)
            {
                Response.Write("<script>alert('Job applied already!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Try again!');</script>");
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataListItem item = DataList1.Items[index];
            Label jobBox = (Label)item.FindControl("lbljobname");
            Label jobCategoryId = (Label)item.FindControl("lbljobId");
            Label2.Text = "Jobs Showing for '" + jobBox.Text + " '";
            WebApplication5.JobReference.JobServiceClient proxy = new JobReference.JobServiceClient("BasicHttpBinding_IJobService");
            DataSet ds = proxy.GetJobs(Convert.ToInt32(jobCategoryId.Text));
            if (e.CommandName == "Select" && Session["role"] != null && Session["role"].ToString() == "JobApplicant")
            {
                GridView3.DataSource = ds.Tables["Job"];
                if (ds.Tables["Job"].Rows.Count == 0)
                    Label2.Text = "No Jobs Found for '" + jobBox.Text + " '";
                GridView3.DataBind();
                proxy.Close();
            }
            else if (e.CommandName == "Select")
            {
                GridView2.DataSource = ds.Tables["Job"];
                if (ds.Tables["Job"].Rows.Count == 0)
                    Label2.Text = "No Jobs Found for '" + jobBox.Text + " '";
                GridView2.DataBind();
                proxy.Close();
            }
        }
    }
}