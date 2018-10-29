using System;

namespace TodoConsoleApp
{
    public class TaskModel
    {
        public string Description { get; set; }
        public bool? AllDayTask { get; set; }
        public bool? Important { get; set; }

        private DateTime _startDate;
        private DateTime? _endDate;

        public string StartDate
        {
            get => _startDate.ToString("d");
            set => _startDate = DateParse(value);
        }

        public string EndDate
        {
            get
            {
                if (_endDate != null)
                {
                    return _endDate.Value.ToString("d");
                }
                else return "";
            }

            set => _endDate = DateParse(value);
        }

        public TaskModel(string description, string startDate, string important)
        {
            Description = description;
            StartDate = startDate;
            AllDayTask = true;
            if (important == "true" || important == "false")
            {
                Important = bool.Parse(important);
            }
        }

        public TaskModel(string description, string startDate, string endDate, string important)
        {
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            AllDayTask = false;
            if (important == "true" || important == "false")
            {
                Important = bool.Parse(important);
            }
        }

        private DateTime DateParse(string date)
        {
            string[] dateTable = date.Split('-');
            if (dateTable.Length == 3)
            {
                return new DateTime(int.Parse(dateTable[0]), int.Parse(dateTable[1]), int.Parse(dateTable[2]));
            }
            return new DateTime(0, 0, 0);
        }
    }
}
