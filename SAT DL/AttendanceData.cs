using System;
using System.Collections.Generic;

namespace Student_Attendance_Data
{
    public class AttendanceData
    {
        private readonly List<string> _studentIds = new List<string>
        {
            "2024-00547-BN-0"
        };

        private readonly List<DateTime> _attendanceDates = new List<DateTime>();

        public bool StudentIdExists(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
                return false;

            foreach (string id in _studentIds)
            {
                if (id.Equals(studentId.Trim(), StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public bool HasAttendanceOn(DateTime date)
        {
            foreach (DateTime d in _attendanceDates)
            {
                if (d.Date == date.Date)
                    return true;
            }

            return false;
        }

        public void SaveAttendance(DateTime date)
        {
            _attendanceDates.Add(date.Date);
        }

        public List<DateTime> GetAttendanceHistory()
        {
            return new List<DateTime>(_attendanceDates);
        }
    }
}