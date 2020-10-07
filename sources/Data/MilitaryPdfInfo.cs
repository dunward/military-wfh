using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace military_wfh
{
    public class MilitaryPdfInfo
    {
        public Solider Solider { get; }
        public string CeoName { get; }

        public MilitaryPdfInfo(JObject jsonObject)
        {
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

            CeoName = jsonObject["ceoName"].ToString();
        }
    }
}
