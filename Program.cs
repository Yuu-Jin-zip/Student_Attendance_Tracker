using System;
namespace Student_Attendance_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Attendance Tracker!");

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

