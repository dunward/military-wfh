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
        public string Address { get; }

        public Solider(string name, string birth, string startDate, string division, string phoneNumber, string address)
        {
            Name = name;
            Birth = birth;
            StartDate = startDate;
            Division = division;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
