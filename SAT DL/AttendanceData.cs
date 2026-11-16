using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Student_Attendance_Data
{
    public class AttendanceData
    {
        private readonly string _filePath = "attendance.json";

        private readonly List<string> _studentIds = new List<string>
        {
            "2024-00547-BN-0"
        };

        private readonly List<DateTime> _attendanceDates;

        public AttendanceData()
        {
            _attendanceDates = Load();
        }

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
            Save();
        }

        public List<DateTime> GetAttendanceHistory()
        {
            return new List<DateTime>(_attendanceDates);
        }

        private List<DateTime> Load()
        {
            if (!File.Exists(_filePath))
                return new List<DateTime>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<DateTime>>(json) ?? new List<DateTime>();
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(_attendanceDates,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}