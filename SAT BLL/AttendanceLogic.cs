using System;
using System.Collections.Generic;
using Student_Attendance_Data;

namespace Student_Attendance_Business
{
    public class AttendanceLogic
    {
        private readonly AttendanceData _data;

        public AttendanceLogic(AttendanceData data)
        {
            _data = data;
        }

        public bool Login(string studentId)
        {
            return _data.StudentIdExists(studentId);
        }

        public bool MarkAttendanceToday()
        {
            DateTime today = DateTime.Today;

            if (_data.HasAttendanceOn(today))
                return false; // already marked today

            _data.SaveAttendance(today);
            return true;
        }

        public string GetTodayDate()
        {
            return DateTime.Today.ToString("MM/dd/yyyy");
        }

        public List<string> GetAttendanceHistory()
        {
            var history = new List<string>();

            foreach (DateTime date in _data.GetAttendanceHistory())
            {
                history.Add(date.ToString("MM/dd/yyyy"));
            }

            return history;
        }
    }
}