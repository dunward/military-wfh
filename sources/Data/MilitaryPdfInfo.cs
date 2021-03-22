using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace military_wfh
{
    public class MilitaryPdfInfo
    {
        private readonly JObject jsonObject;

        public Solider Solider { get; }
        public string FontName { get; }
        public string CeoName { get; }
        public DateTime startDate { get; }
        public DateTime lastDate { get; }
        public string Description { get; }
        public string StartTime { get; }
        public string EndTime { get; }
        public string SpecialMondayDescription { get; }
        public string SpecialFridayDescription { get; }
        public List<DateTime> restDates = new List<DateTime>();

        public MilitaryPdfInfo(JObject jsonObject)
        {
            this.jsonObject = jsonObject;

            FontName = jsonObject["fontName"].ToString();
            CeoName = jsonObject["ceoName"].ToString();
            startDate = DateUtil.ConvertToDateTime(jsonObject["wfhStartDate"].ToString());
            lastDate = DateUtil.ConvertToDateTime(jsonObject["wfhLastDate"].ToString());
            StartTime = jsonObject["wfhWorkingStartTime"].ToString();
            EndTime = jsonObject["wfhWorkingEndTime"].ToString();
            Description = jsonObject["description"].ToString();
            SpecialMondayDescription = jsonObject["specialMondayDescription"].ToString();
            SpecialFridayDescription = jsonObject["specialFridayDescription"].ToString();
            InitializeRestDates(jsonObject.Value<JArray>("restDates"));

            Solider = new Solider(
                jsonObject["name"].ToString(),
                jsonObject["birth"].ToString(),
                jsonObject["startDate"].ToString(),
                jsonObject["division"].ToString(),
                jsonObject["phoneNumber"].ToString(),
                jsonObject["address"].ToString()
                );
        }

        private void InitializeRestDates(JArray restDatesJson)
        {
            foreach(var restDate in restDatesJson)
            {
                restDates.Add(DateUtil.ConvertToDateTime(restDate.ToString()));
            }
        }
    }
}
