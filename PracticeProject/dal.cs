using PracticeProject.Models;
using System.Data;
using System.Data.SqlClient;

namespace PracticeProject
{
    public class dal
    {
        SqlConnection cn = new SqlConnection("Server=.;Database=dbPractice;User ID=sa;Password=Pakistan1234;Trusted_Connection=True;");
        List<StudentDetail> students = new List<StudentDetail>();
        StudentDetail std = new StudentDetail();
        public List<StudentDetail> SPGetStudentList()
        {
           
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sql = new SqlCommand("GetStudentDetails", cn);
                sql.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                adapter.Fill(ds);
                cn.Open();
                sql.ExecuteNonQuery();
                cn.Close();

             
            
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    students.Add(new StudentDetail
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        RollNumber = Convert.ToString(dr["Roll_Number"]),
                        Country = Convert.ToString(dr["Country"])


                    });
                }

                return students;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public StudentDetail GetStudentById(int id)
        {
            
            DataSet ds = new DataSet();
            try    
            {
                SqlCommand sql = new SqlCommand("GetStudentById", cn);
                sql.Parameters.AddWithValue("@id",id);
                sql.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                adapter.Fill(ds);
                cn.Open();
                sql.ExecuteNonQuery();
                cn.Close();

             
                StudentDetail students = new StudentDetail();
              
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    students.Id = Convert.ToInt32(dr["ID"]);
                    students.Name = Convert.ToString(dr["Name"]);
                    students.RollNumber = Convert.ToString(dr["Roll_Number"]);
                    students.Country = Convert.ToString(dr["Country"]);


                }

                return students;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public bool DeleteStudentById(string id)
        {
            
            try    
            {
                SqlCommand sql = new SqlCommand("DeleteStudent", cn);
                sql.Parameters.AddWithValue("@id",id);
                sql.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sql.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public bool InsertStudent(StudentDetail std)
        {
            
            try    
            {
                SqlCommand sql = new SqlCommand("InsertStudent", cn);
                sql.Parameters.AddWithValue("@Name", std.Name);
                sql.Parameters.AddWithValue("@Roll_Number", std.RollNumber);
                sql.Parameters.AddWithValue("@Country", std.Country);
                sql.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sql.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception)
            {

                throw;
            }



        }
        public bool UpdateStudent(StudentDetail std)
        {
            
            try    
            {
                SqlCommand sql = new SqlCommand("UpdateStudent", cn);
                sql.Parameters.AddWithValue("@id", std.Id);
                sql.Parameters.AddWithValue("@Name", std.Name);
                sql.Parameters.AddWithValue("@Roll_Number", std.RollNumber);
                sql.Parameters.AddWithValue("@Country", std.Country);
                sql.CommandType = CommandType.StoredProcedure;
                cn.Open();
                sql.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
