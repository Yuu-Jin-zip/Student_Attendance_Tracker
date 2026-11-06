using System;
namespace Student_Attendance_Tracker
{
    class ClassSession
    {
        public DayOfWeek Day;
        public string Time = "";
        public string Subject = "";
    }

    class AttendanceRecord
    {
        public string Date = "";
        public string Subject = "";
        public string Status = ""; // "Present" or "Absent"
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Attendance Tracker");

            AuthenticationLogic auth = new AuthenticationLogic();

            List<ClassSession> schedule = new List<ClassSession>
            {
                new ClassSession { Day = DayOfWeek.Monday,    Time = "8:00 AM - 11:00 AM", Subject = "Subject 1" },
                new ClassSession { Day = DayOfWeek.Tuesday,   Time = "1:00 PM - 4:00 PM",  Subject = "Subject 2" },
                new ClassSession { Day = DayOfWeek.Wednesday, Time = "8:00 AM - 11:00 AM", Subject = "Subject 3" },
                new ClassSession { Day = DayOfWeek.Thursday,  Time = "1:00 PM - 4:00 PM",  Subject = "Subject 4" },
                new ClassSession { Day = DayOfWeek.Friday,    Time = "9:00 AM - 12:00 PM", Subject = "Subject 5" }
            };

            List<AttendanceRecord> records = new List<AttendanceRecord>
            {
                new AttendanceRecord { Date = "10/21/2026", Subject = "Subject 3", Status = "Present" },
                new AttendanceRecord { Date = "10/22/2026", Subject = "Subject 4", Status = "Absent" }
            };

            DisplayOptions();
            string choice = Console.ReadLine() ?? "";

            while (choice != "x")
            {
                if (choice == "1")
                {
                    ProcessFacultyModule(auth, schedule, records);
                }
                else if (choice == "2")
                {
                    ProcessStudentModule(auth, schedule, records);
                }
                else
                {
                    Console.WriteLine("Incorrect input...");
                }

                DisplayOptions();
                choice = Console.ReadLine() ?? "";
            }

            Console.WriteLine("Thank you for using the Student Attendance Tracker. Goodbye!");
        }

            Console.WriteLine(" Please Enter your Student ID number to Login: ");
            Console.Write("User Input: ");
            string studentidNumber = "2024-00547-BN-0";
            string inputStudentId = Console.ReadLine();

            string result = inputStudentId == studentidNumber ? "Student ID is valid." : "Student ID is invalid.";

            while (inputStudentId != studentidNumber)
            {
                Console.WriteLine(result);
                Console.WriteLine(" Input is Invalid Please Try Again : ");
                Console.Write("User Input: ");
                inputStudentId = Console.ReadLine();
            }

            if (result == studentidNumber)
            {
                Console.WriteLine("Great Day!");

                Console.WriteLine("Enter 1 to view your attendance record history");
                Console.WriteLine("Enter 2 to check the date today");
                Console.WriteLine("Enter 3 to mark your attendance for today");
                Console.WriteLine("Enter 4 to exit the program");
            }

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You have chosen to view your attendance record history.");
                    break;
                case "2":
                    Console.WriteLine($"Today's date is: {DateTime.Now.ToString("MM/dd/yyyy")}");
                    break;
                case "3":
                    Console.WriteLine("You have chosen to mark your attendance for today.");
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine("Enter 1 - to view your attendance record history: ");
            Console.WriteLine("Enter 2 - to check the date today");
            Console.WriteLine("Enter 3 - to mark your attendance for today");

            Console.WriteLine("Enter 4 - to exit the program");
            Console.Write("User Input: ");
            result= Console.ReadLine();
        }
            

    }
}

