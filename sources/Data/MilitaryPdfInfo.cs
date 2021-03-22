using Newtonsoft.Json.Linq;
using System;

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

        public MilitaryPdfInfo(JObject jsonObject)
        {
            this.jsonObject = jsonObject;

            FontName = jsonObject["fontName"].ToString();
            CeoName = jsonObject["ceoName"].ToString();
            startDate = DateUtil.ConvertToDateTime(jsonObject["wfhStartDate"].ToString());
            lastDate = DateUtil.ConvertToDateTime(jsonObject["wfhLastDate"].ToString());
            Description = jsonObject["wfhWorkingDescription"].ToString();

            Solider = new Solider(
                jsonObject["name"].ToString(),
                jsonObject["birth"].ToString(),
                jsonObject["startDate"].ToString(),
                jsonObject["division"].ToString(),
                jsonObject["phoneNumber"].ToString(),
                jsonObject["workingDate"].ToString(),
                jsonObject["address"].ToString(),
                jsonObject.Value<JArray>("workInfos")
                );
        }
    }
}
