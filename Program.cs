using AttendanceBusinessLogic;

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

        static void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Enter 1 - for Faculty Login");
            Console.WriteLine("Enter 2 - for Student Login");
            Console.WriteLine("Enter x - to exit");
            Console.Write("User Input: ");
        }

        static void ProcessFacultyModule(AuthenticationLogic auth, List<ClassSession> schedule, List<AttendanceRecord> records)
        {
            Console.Write("Enter faculty number: ");
            if (!auth.IsFacultyNumberCorrect(Console.ReadLine() ?? ""))
            {
                Console.WriteLine("Invalid faculty number.");
                return;
            }

            Console.Write("Enter the student number you want to mark: ");
            if (!auth.IsStudentNumberCorrect(Console.ReadLine() ?? ""))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {schedule[i].Subject}");
            }

            Console.Write("Enter subject number: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > schedule.Count)
            {
                Console.WriteLine("Invalid subject number.");
                return;
            }

            Console.Write("Enter P for Present or A for Absent: ");
            string status = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (status != "P" && status != "A")
            {
                Console.WriteLine("Invalid status.");
                return;
            }

            records.Add(new AttendanceRecord
            {
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Subject = schedule[n - 1].Subject,
                Status = status == "P" ? "Present" : "Absent"
            });

            Console.WriteLine("Attendance recorded.");
        }

        static void ProcessStudentModule(AuthenticationLogic auth, List<ClassSession> schedule, List<AttendanceRecord> records)
        {
            Console.Write("Enter your student number: ");
            if (!auth.IsStudentNumberCorrect(Console.ReadLine() ?? ""))
            {
                Console.WriteLine("Invalid student number.");
                return;
            }

            Console.WriteLine("Welcome!!");

            bool inModule = true;
            while (inModule)
            {
                Console.WriteLine();
                Console.WriteLine("Type 1 - to view your attendance record history");
                Console.WriteLine("Type 2 - to check the date today and your classes");
                Console.WriteLine("Type 3 - to view your class schedule");
                Console.WriteLine("Type 4 - to go back");
                Console.Write("Enter your option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAttendance(schedule, records);
                        break;
                    case "2":
                        ShowToday(schedule);
                        break;
                    case "3":
                        foreach (ClassSession c in schedule)
                        {
                            Console.WriteLine($"{c.Day,-10} | {c.Time,-20} | {c.Subject}");
                        }
                        break;
                    case "4":
                        inModule = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input...");
                        break;
                }
            }
        }

        static void ShowToday(List<ClassSession> schedule)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Today's date is: {now:MM/dd/yyyy} ({now.DayOfWeek})");

            bool hasClass = false;
            foreach (ClassSession c in schedule)
            {
                if (c.Day == now.DayOfWeek)
                {
                    Console.WriteLine($"Class today: {c.Subject} ({c.Time})");
                    hasClass = true;
                }
            }

            if (!hasClass)
            {
                Console.WriteLine("You have no class today.");
            }
        }

        static void ShowAttendance(List<ClassSession> schedule, List<AttendanceRecord> records)
        {
            if (records.Count == 0)
            {
                Console.WriteLine("No attendance records yet.");
                return;
            }

            int presents = 0;
            foreach (AttendanceRecord r in records)
            {
                Console.WriteLine($"{r.Date} | {r.Subject,-10} | {r.Status}");
                if (r.Status == "Present")
                {
                    presents++;
                }
            }

            int total = records.Count;
            Console.WriteLine();
            Console.WriteLine($"Overall: {presents} present out of {total} ({(double)presents / total * 100:F1}%)");
            Console.WriteLine($"Absences: {total - presents}");

            Console.WriteLine("\nPer subject:");
            foreach (ClassSession c in schedule)
            {
                int subjTotal = records.FindAll(r => r.Subject == c.Subject).Count;
                int subjPresent = records.FindAll(r => r.Subject == c.Subject && r.Status == "Present").Count;

                if (subjTotal > 0)
                {
                    Console.WriteLine($"{c.Subject}: {subjPresent} out of {subjTotal} present");
                }
            }
        }
    }
}