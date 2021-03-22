using System;
using System.Collections.Generic;
using System.Text;

namespace military_wfh
{
    public static class DateUtil
    {
        public static DateTime ConvertToDateTime(string stringDateTime)
        {
            var format = stringDateTime.Split('/');
            int year = int.Parse(format[0]);
            int month = int.Parse(format[1]);
            int day = int.Parse(format[2]);

            return new DateTime(year, month, day);
        }
    }
}
