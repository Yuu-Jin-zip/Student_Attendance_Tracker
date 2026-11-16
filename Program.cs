using System;
using Student_Attendance_Business;
using Student_Attendance_Data;

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
            AttendanceData data = new AttendanceData();
            AttendanceLogic logic = new AttendanceLogic(data);

            Console.WriteLine("Welcome to the Student Attendance Tracker!");
            Console.WriteLine("Please enter your Student ID number to login:");
            Console.Write("User Input: ");
            string inputStudentId = Console.ReadLine() ?? "";

            while (!logic.Login(inputStudentId))
            {
                Console.WriteLine("Student ID is invalid.");
                Console.WriteLine("Input is invalid. Please try again:");
                Console.Write("User Input: ");
                inputStudentId = Console.ReadLine() ?? "";
            }

            Console.WriteLine("Student ID is valid.");
            Console.WriteLine("Great Day!");

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 to view your attendance record history");
                Console.WriteLine("Enter 2 to check the date today");
                Console.WriteLine("Enter 3 to mark your attendance for today");
                Console.WriteLine("Enter 4 to exit the program");
                Console.Write("User Input: ");

                switch (Console.ReadLine() ?? "")
                {
                    case "1":
                        Console.WriteLine("Attendance record history:");
                        foreach (string date in logic.GetAttendanceHistory())
                        {
                            Console.WriteLine(date);
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Today's date is: {logic.GetTodayDate()}");
                        break;

                    case "3":
                        Console.WriteLine(logic.MarkAttendanceToday()
                            ? "Your attendance for today has been marked."
                            : "Your attendance for today is already marked.");
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}