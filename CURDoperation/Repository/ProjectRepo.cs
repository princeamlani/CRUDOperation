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
    public class ProjectRepo
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public bool InsertProject(Project obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddProject", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectID", obj.ProjectID);
            com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);
            com.Parameters.AddWithValue("@IsActive", (obj.IsActive));
            com.Parameters.AddWithValue("@DevelopmentStartDate", obj.DevelopementStartDate);
            com.Parameters.AddWithValue("@ProjectLogo", obj.file.FileName);

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
        public bool EditProject(Project obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateProject", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectID", obj.ProjectID);
            com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);
            com.Parameters.AddWithValue("@IsActive", (obj.IsActive));
            com.Parameters.AddWithValue("@DevelopmentStartDate", obj.DevelopementStartDate);
            com.Parameters.AddWithValue("@ProjectLogo", obj.Projectlogo);

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
        public bool DeleteProject(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteProject", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProjectID", id);

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
    }
}

