using System;
using System.Collections.Generic;
using System.Text;

namespace military_wfh
{
    public class WorkInfo
    {
        public string Date { get; }
        public string StartTime { get; }
        public string EndTime { get; }
        public string Description { get; }

        public WorkInfo(string date, string startTime, string endTime, string description)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }
    }
}