using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Text;

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

        // TODO: Autometric Generate Work Information
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

        public override string ToString()
        {
            return $"Name : {Name}\n" +
                $"Birth : {Birth}\n" +
                $"StartDate : {StartDate}\n" +
                $"Division : {Division}\n" +
                $"PhoneNumber : {PhoneNumber}\n" +
                $"WorkingDate : {WorkingDate}\n" +
                $"Address : {Address}\n";
        }
    }
}
