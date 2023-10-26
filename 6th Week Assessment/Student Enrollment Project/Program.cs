using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment
{
    internal class Program
    {
        static String connectionstring = @"Data Source=ICS-LT-96L96V3\SQLEXPRESS;" +
           "Initial Catalog=StudentEnrollmentDB;Integrated Security=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("****School Gradebook****");
            while (true)
            {
                Console.WriteLine("1. Insert Data of student");
                Console.WriteLine("2. display student data");
                Console.WriteLine("3. Update the studentinfo");
                Console.WriteLine("====================================================");
                Console.WriteLine("4. Insert course details");
                Console.WriteLine("5. Display the Course table");
                Console.WriteLine("6. Update the Courseinfo");
                Console.WriteLine("====================================================");
                Console.WriteLine("7. Insert GradeID of Gradestudents");
                Console.WriteLine("8. Display the grade table");
                Console.WriteLine("9. Update the Student grades");
                Console.WriteLine("10. Top performers list");
                Console.WriteLine("11. Delete the studentId which you want");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter StudentID, StudentName:");
                        //int newid = Convert.ToInt32(Console.ReadLine());
                        string newName = Console.ReadLine();
                        string stdemail = Console.ReadLine();
                        DateTime newdob = Convert.ToDateTime(Console.ReadLine());
                        string saddress = Console.ReadLine();
                        DataAccessLayer.InsertStudents(newName, stdemail, newdob, saddress);
                        break;
                    case "2":
                        DataAccessLayer.GetallStudentInfo();
                        break;
                    case "3":
                        Console.WriteLine("Update the student name of selected studentID:");
                        int toupdateid = Convert.ToInt32(Console.ReadLine());
                        string updatedname = Console.ReadLine();
                        string updatedsaddress = Console.ReadLine();
                        DataAccessLayer.UpdateStudents(connectionstring, toupdateid, updatedname, updatedsaddress);
                        break;
                    case "4":
                        
                        Console.WriteLine("Enter Course details");
                        //int newid = Convert.ToInt32(Console.ReadLine());
                        string coursecode = Console.ReadLine();
                        string instructer = Console.ReadLine();
                        int credthrs = Convert.ToInt32(Console.ReadLine());
                        DataAccessLayer.InsertCourses(coursecode, instructer, credthrs);
                        break;
                    case "5":
                        DataAccessLayer.GetallCoursesInfo();
                        break;
                    case "6":
                        Console.WriteLine("Update Course Details");
                        int courseid = Convert.ToInt32(Console.ReadLine());
                        string instructername = Console.ReadLine();
                        int credithurs = Convert.ToInt32(Console.ReadLine());
                        DataAccessLayer.UpdateCourses(connectionstring,courseid, instructername, credithurs);
                        break;
                    case "7":
                        Console.WriteLine("Enter GradeID,StudentID, Course and Grade of students:");
                      //  int gradeid = Convert.ToInt32(Console.ReadLine());
                        int sid = Convert.ToInt32(Console.ReadLine());
                        string cname = Console.ReadLine();
                        //int newcourseid = Convert.ToInt32(Console.ReadLine());
                        float gpavalue = float.Parse(Console.ReadLine());
                        DataAccessLayer.InsertGrades(sid,cname, gpavalue);
                        break;
                    case "8":
                        DataAccessLayer.GetallGradesInfo();
                        break;
                    case "9":
                        Console.WriteLine("Update the Course and grade of selected studentID:");
                        int toupdatepid = Convert.ToInt32(Console.ReadLine());
                        string newcourses = Console.ReadLine();
                        char updatedgrade = Console.ReadLine()[0];
                        float toupdategpa = float.Parse(Console.ReadLine());
                        DataAccessLayer.updateGrades(connectionstring, toupdatepid, newcourses, updatedgrade, toupdategpa);
                        break;
                    case "10":
                        DataAccessLayer.Gettopperformers();
                        break;
                    case "11":
                        Console.WriteLine("Delete the selected ID rows");
                        int stdidd = Convert.ToInt32(Console.ReadLine());
                        DataAccessLayer.DeleteStudents(stdidd);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
