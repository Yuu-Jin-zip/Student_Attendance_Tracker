using System;

namespace Student_Attendance_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Attendance Tracker!");

            string studentIdNumber = "2024-00547-BN-0";

            Console.WriteLine("Please enter your Student ID number to login:");
            Console.Write("User Input: ");
            string inputStudentId = Console.ReadLine();

            while (inputStudentId != studentIdNumber)
            {
                Console.WriteLine("Student ID is invalid.");
                Console.WriteLine("Input is invalid. Please try again:");
                Console.Write("User Input: ");
                inputStudentId = Console.ReadLine();
            }

            Console.WriteLine("Student ID is valid.");
            Console.WriteLine("Great Day!");

            Console.WriteLine("Enter 1 to view your attendance record history");
            Console.WriteLine("Enter 2 to check the date today");
            Console.WriteLine("Enter 3 to mark your attendance for today");
            Console.WriteLine("Enter 4 to exit the program");
            Console.Write("User Input: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You have chosen to view your attendance record history.");
                    break;
                case "2":
                    Console.WriteLine($"Today's date is: {DateTime.Now:MM/dd/yyyy}");
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
        }
    }
}