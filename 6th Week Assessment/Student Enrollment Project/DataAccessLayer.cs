using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment
{
    internal class DataAccessLayer
    {
        static String connectionstring = @"Data Source=ICS-LT-96L96V3\SQLEXPRESS;" +
           "Initial Catalog=StudentEnrollmentDB;Integrated Security=True;";



        public static void GetallStudentInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_getstudents";
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3),reader.GetName(4));
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void InsertStudents( string StudentName, string StudentEmail, DateTime DateOfBirth,  string StudentAddress)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "usp_insertStudents";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parmeter1 = new SqlParameter();
                    parmeter1.ParameterName = "@stdname";
                    parmeter1.SqlDbType = SqlDbType.VarChar;
                    parmeter1.Value = StudentName;
                    cmd.Parameters.Add(parmeter1);

                    SqlParameter parmeter2 = new SqlParameter();
                    parmeter2.ParameterName = "@stdemail";
                    parmeter2.SqlDbType = SqlDbType.VarChar;
                    parmeter2.Value = StudentEmail;
                    cmd.Parameters.Add(parmeter2);

                    SqlParameter parmeter4 = new SqlParameter();
                    parmeter4.ParameterName = "@stdob";
                    parmeter4.SqlDbType = SqlDbType.DateTime;
                    parmeter4.Value = DateOfBirth;
                    cmd.Parameters.Add(parmeter4);

                    SqlParameter parmeter3 = new SqlParameter();
                    parmeter3.ParameterName = "@stdadress";
                    parmeter3.SqlDbType = SqlDbType.VarChar;
                    parmeter3.Value = StudentAddress;
                    cmd.Parameters.Add(parmeter3);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int i = adapter.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        Console.WriteLine("New Category Inserted..");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void UpdateStudents(string connectionstring, int StudentId, string StudentName, string StudentAddress)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_updateStudents";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@stdid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = StudentId;
                    command.Parameters.Add(parameter);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@stdname";
                    parameter1.SqlDbType = SqlDbType.VarChar;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = StudentName;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@stdaddress";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = StudentAddress;
                    command.Parameters.Add(parameter2);
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.UpdateCommand = command;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("updated..");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        /// <summary>
        /// COURSES TABLE DISPLAY, UPDATE, DELETE
        /// </summary>


        public static void GetallCoursesInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_getCourses";
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void InsertCourses(string CourseCode,string Instructor, int CreditHours)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "usp_insertCourses";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parmeter = new SqlParameter();
                    parmeter.ParameterName = "@coursecode";
                    parmeter.SqlDbType = SqlDbType.VarChar;
                    parmeter.Value = CourseCode;
                    cmd.Parameters.Add(parmeter);

                    SqlParameter parmeter2 = new SqlParameter();
                    parmeter2.ParameterName = "@inst";
                    parmeter2.SqlDbType = SqlDbType.VarChar;
                    parmeter2.Value = Instructor;
                    cmd.Parameters.Add(parmeter2);

                    SqlParameter parmeter4 = new SqlParameter();
                    parmeter4.ParameterName = "@chrs";
                    parmeter4.SqlDbType = SqlDbType.Int;
                    parmeter4.Value = CreditHours;
                    cmd.Parameters.Add(parmeter4);


                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int i = adapter.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        Console.WriteLine("New Category Inserted..");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void UpdateCourses(string connectionstring, int CourseId, string Instructor, int CreditHours)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_UpdateCourses";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@cid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = CourseId;
                    command.Parameters.Add(parameter);

 
                    
                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@inst";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = Instructor;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@chrs";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = CreditHours;
                    command.Parameters.Add(parameter3);
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.UpdateCommand = command;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("updated..");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        ///GRADES TABLEE <summary>
        /// GRADES TABLEE


        public static char Performancegpa(float GPA)
        {
            char Grads;
            if (GPA > 9)
            {
                Grads = 'A';
            }
            else if (GPA > 8 && GPA <= 9)
            {
                Grads = 'B';
            }
            else if (GPA > 5 && GPA <= 8)
            {
                Grads = 'C';
            }
            else
            {
                Grads = 'D';
            }
            return Grads;
        }


        public static void InsertGrades( int StudentId, string CourseName, float GPA)
        {
            float gpa = GPA;
            try
            {

                char Performancegp = Performancegpa(gpa);
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "usp_insertGrades";
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter parmeter1 = new SqlParameter();
                    parmeter1.ParameterName = "@sid";
                    parmeter1.SqlDbType = SqlDbType.Int;
                    parmeter1.Value = StudentId;
                    cmd.Parameters.Add(parmeter1);

                    SqlParameter parmeter = new SqlParameter();
                    parmeter.ParameterName = "@course";
                    parmeter.SqlDbType = SqlDbType.VarChar;
                    parmeter.Value = CourseName;
                    cmd.Parameters.Add(parmeter);

                    SqlParameter parmeter3 = new SqlParameter();
                    parmeter3.ParameterName = "@grade";
                    parmeter3.SqlDbType = SqlDbType.Char;
                    parmeter3.Value = Performancegp;
                    cmd.Parameters.Add(parmeter3); 

                    SqlParameter parmeter4 = new SqlParameter();
                    parmeter4.ParameterName = "@gpa";
                    parmeter4.SqlDbType = SqlDbType.Float;
                    parmeter4.Value = GPA;
                    cmd.Parameters.Add(parmeter4);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = cmd;
                    int i = adapter.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        Console.WriteLine("New Category Inserted..");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }






        public static void GetallGradesInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_getGrades";
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void updateGrades(string connectionstring, int StudentId, string CourseName, char Grade, float GPA)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_UpdateGrades";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@stdid";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = StudentId;
                    command.Parameters.Add(parameter);

                    SqlParameter parameter1 = new SqlParameter();
                    parameter1.ParameterName = "@gcourse";
                    parameter1.SqlDbType = SqlDbType.VarChar;
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = CourseName;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@grade";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = Grade;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@gpa";
                    parameter3.SqlDbType = SqlDbType.Float;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = GPA;
                    command.Parameters.Add(parameter3);
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adapter.UpdateCommand = command;
                    int i = adapter.UpdateCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("updated..");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void Gettopperformers()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_gettop";
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                    Console.WriteLine("--------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader[0], reader[1].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }




        public static void DeleteStudents(int StudentId)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandText = "deleteStudents";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@stdid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = "StudentId";



                    command.Parameters.Remove(param1);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + rowsAffected);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }




    }
}
