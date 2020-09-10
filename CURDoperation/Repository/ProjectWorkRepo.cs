using CURDoperation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CURDoperation.Repository
{
    public class ProjectWorkRepo
    {

        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public bool InsertProject(ProjectWork obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddProjectWork", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectID", Convert.ToInt32(obj.ProjectID));
            com.Parameters.AddWithValue("@Work", obj.Work);
            com.Parameters.AddWithValue("@IsCompleted", (obj.IsCompleted));


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }



        }

        public List<Project> GetProject()
        {
            List<Project> prj = new List<Project>();
            connection();
            SqlCommand com = new SqlCommand("GetProject", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            prj = (from DataRow dr in dt.Rows

                   select new Project()
                   {
                       Id = Convert.ToInt32(dr["Id"]),
                       ProjectID = Convert.ToInt32(dr["ProjectID"]),
                       ProjectName = Convert.ToString(dr["ProjectName"]),
                       IsActive = Convert.ToBoolean(dr["IsActive"]),
                       DevelopementStartDate = Convert.ToDateTime(dr["DevelopementStartDate"]),
                       Projectlogo = Convert.ToString(dr["ProjectLogo"])
                   }).ToList();


            return prj;
        }

        public List<ProjectWork> GetProjectWork()
        {
            List<ProjectWork> prj = new List<ProjectWork>();
            connection();
            SqlCommand com = new SqlCommand("GetProjectWork", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            prj = (from DataRow dr in dt.Rows

                   select new ProjectWork()
                   {
                       //Id = Convert.ToInt32(dr["Id"]),
                       ProjectWorkID = Convert.ToInt32(dr["ProjectWorkID"]),
                       ProjectID = Convert.ToString(dr["ProjectID"]),
                       Work = Convert.ToString(dr["Work"]),
                       IsCompleted = Convert.ToBoolean(dr["IsCompleted"])
                   }).ToList();


            return prj;
        }
    }
}