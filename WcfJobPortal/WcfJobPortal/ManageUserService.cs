using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    public class ManageUserService : IManageUserService
    {
        public int AddCompany(Company c)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    string name = c.Name;
                    string email = c.Email;
                    string password = c.Password;
                    string location = c.Location;
                    string ToInsert = "INSERT INTO Company(name,email,password,location) VALUES('" + name + "','" + email + "','" + password + "','" + location + "')";
                    SqlCommand cmd = new SqlCommand(ToInsert, cnn);
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

        public int AddJobApplicant(JobApplicant c)
        {
            SqlConnection cnn = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (cnn)
                {
                    string name = c.Name;
                    string email = c.Email;
                    string password = c.Password;
                    string phone = c.Phone;
                    string ToInsert = "INSERT INTO JobApplicant(name,email,password,phone) VALUES('" + name + "','" + email + "','" + password + "','" + phone + "')";
                    SqlCommand cmd = new SqlCommand(ToInsert, cnn);
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

        public int DeleteCompany(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (con)
                {
                    string toDelete = "DELETE FROM Company where Id='" + id + "'";
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

        public int DeleteJobApplicant(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            try
            {
                using (con)
                {
                    string toDelete = "DELETE FROM JobApplicant where Id='" + id + "'";
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

        public User LogIn(string email, string password, int role)
        {
            User u = new User();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=jobportal;Integrated Security=True");
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            SqlDataReader dr;
            switch (role)
            {
                case 0:
                    cmd.CommandText = "SELECT email,Id FROM Admin where password='" + password + "' and email='" + email + "'";
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        u.Email = dr.GetString(0);
                        u.UserId = dr.GetInt32(1);
                        u.Role = 0;
                    }
                    if (u.Email == "")
                    {
                        u.UserId = -1;
                    }
                    dr.Close();
                    break;
                case 1:
                    cmd.CommandText = "SELECT name,email,Id FROM Company where password='" + password + "' and email='" + email + "'";
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        u.Name = dr.GetString(0);
                        u.Email = dr.GetString(1);
                        u.UserId = dr.GetInt32(2);
                        u.Role = 1;
                    }
                    if (u.Name == "")
                    {
                        u.UserId = -1;
                    }
                    dr.Close();
                    break;
                case 2:
                    cmd.CommandText = "SELECT name,email,Id FROM JobApplicant where password='" + password + "' and email='" + email + "'";
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        u.Name = dr.GetString(0);
                        u.Email = dr.GetString(1);
                        u.UserId = dr.GetInt32(2);
                        u.Role = 2;
                    }
                    if (u.Name == "")
                    {
                        u.UserId = -1;
                    }
                    dr.Close();
                    break;
                default:
                    break;
            }
            con.Close();
            return u; 
        }
    }
}
