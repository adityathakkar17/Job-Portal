using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    public class JobService : IJobService
    {
        public int AddJob(Job j)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    int companyId = j.CompanyId;
                    int categoryId = j.CategoryId;
                    int duration = j.Duration;
                    int vacancy = j.Vacancy;
                    int salary = j.Salary;
                    string Verify= "SELECT * FROM Job where companyId='" + companyId + "' and categoryId='" + categoryId + "'";
                    SqlCommand cmd = new SqlCommand(Verify, cnn);
                    cnn.Open();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (id>0)
                        return 0;

                    string ToInsert = "INSERT INTO Job(duration,vacancy,salary,companyId,categoryId) VALUES('" + duration + "','" + vacancy + "','" + salary + "','"+ companyId + "','"+ categoryId +"')";
                    cmd = new SqlCommand(ToInsert, cnn);

                    int inserted = (int)cmd.ExecuteNonQuery();
                    if (inserted == 1)
                    {
                        return 1;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public int AddJobCategory(string jobCategory)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    string Verify = "SELECT * FROM JobCategory where name='" + jobCategory +"'";
                    SqlCommand cmd = new SqlCommand(Verify, cnn);
                    cnn.Open();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (id > 0)
                        return 0;

                    string ToInsert = "INSERT INTO JobCategory(name) VALUES('" +  jobCategory + "')";
                    cmd = new SqlCommand(ToInsert, cnn);

                    int inserted = (int)cmd.ExecuteNonQuery();
                    if (inserted == 1)
                    {
                        return 1;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public int DeleteJob(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (con)
                {
                    string toDelete = "DELETE FROM Job where Id='" + id + "'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(toDelete, con);
                    int deleted = (int)cmd.ExecuteNonQuery();
                    con.Close();
                    if (deleted == 1)
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public DataSet GetAllJobs()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM JobCategory ", @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Job");
            return ds;
        }

        public DataSet GetJobs(int categoryId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT J.Id,name,location,email,duration,vacancy,salary FROM Company C INNER JOIN Job J ON C.Id=J.companyId WHERE categoryId ="+categoryId, @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Job");
            return ds;
        }
        public DataSet GetJobsofCompany(int companyId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT J.Id, name,duration,vacancy,salary FROM Job J INNER JOIN JobCategory JC on J.categoryId=JC.Id WHERE companyId=" + companyId, @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Job");
            return ds;
        }
        public int UpdateJob(Job j)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    SqlCommand cmd = new SqlCommand("update Job set duration = @duration,vacancy=@vacancy,salary=@salary WHERE Id = @Id", cnn);
                    cmd.Parameters.AddWithValue("@duration", j.Duration);
                    cmd.Parameters.AddWithValue("@vacancy", j.Vacancy);
                    cmd.Parameters.AddWithValue("@salary", j.Salary);
                    cmd.Parameters.AddWithValue("@Id", j.JobId);
                    cnn.Open();
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
            return 0;
        }
    }
}
