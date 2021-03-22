using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace military_wfh
{
    public class Solider
    {
        public string Name { get; }
        public string Birth { get; }
        public string StartDate { get; }
        public string Division { get; }
        public string PhoneNumber { get; }
        public string WorkingDate { get; }
        public string Address { get; }
        public List<WorkInfo> WorkInfos { get; }

        public Solider(string name, string birth, string startDate, string division, string phoneNumber, string workingDate, string address, JArray workInfos)
        {
            Name = name;
            Birth = birth;
            StartDate = startDate;
            Division = division;
            PhoneNumber = phoneNumber;
            WorkingDate = workingDate;
            Address = address;
            WorkInfos = GenerateWorkInformation(workInfos);
        }

        private List<WorkInfo> GenerateWorkInformation(JArray workInfos)
        {
            var infos = new List<WorkInfo>();

            foreach(var info in workInfos)
            {
                infos.Add(new WorkInfo(
                    info["date"].ToString(),
                    info["startTime"].ToString(),
                    info["endTime"].ToString(),
                    info["description"].ToString()
                    ));
            }

            return infos;
        }
    }
}
