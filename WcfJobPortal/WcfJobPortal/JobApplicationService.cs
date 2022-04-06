using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    public class JobApplicationService : IJobApplicationService
    {
        public DataSet GetJobApplicationsOfApplicant(int jobApplicantId)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT C.name as Company,JC.name as JobPost,J.salary,J.vacancy,J.duration FROM Job J INNER JOIN JobApplication JA ON J.Id=jobId  INNER JOIN JobCategory JC ON J.categoryId=JC.Id INNER JOIN Company C ON C.Id=J.companyId where jobApplicantId=" + jobApplicantId,
                @"Data Source = (localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "JobApplications");
            return ds;
        }

        public DataSet GetJobApplicationsOfJobCategory(int jobId)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT JA.name,JA.email,JA.phone FROM JobApplicant JA INNER JOIN JobApplication J ON JA.Id=J.jobApplicantId where J.jobId="+jobId,
                @"Data Source = (localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "JobApplications");
            return ds;
        }
        public int ApplyJob(JobApplication ja)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    int jobId = ja.JobId;
                    int jobApplicantId = ja.JobApplicantId;
                    string Verify = "SELECT * FROM JobApplication where jobId='" + jobId + "' and jobApplicantId='" + jobApplicantId + "'";
                    SqlCommand cmd = new SqlCommand(Verify, cnn);
                    cnn.Open();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (id > 0)
                        return 0;
                    string ToInsert = "INSERT INTO JobApplication(jobId,jobApplicantId) VALUES('" + jobId + "','" + jobApplicantId + "')";
                    cmd = new SqlCommand(ToInsert, cnn);
                    int inserted = (int)cmd.ExecuteNonQuery();
                    if (inserted == 1)
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }
    }
}
