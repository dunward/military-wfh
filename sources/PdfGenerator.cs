using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace military_wfh
{
    public class PdfGenerator
    {
        private MilitaryPdfInfo info;

        private PdfDocument document;
        private PdfPage page;

        private XGraphics graphics;
        private XFont font;

        private readonly double[] datePivots = { 365, 410, 451, 491, 529 };
        private readonly double[] timePivots = { 352, 397, 439, 479, 518 };
        private readonly double[] descriptionPivots = { 365, 410, 451, 491, 529 };

        public PdfGenerator(MilitaryPdfInfo info)
        {
            this.info = info;

            document = PdfReader.Open("template.pdf");
            page = document.Pages[0];

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            graphics = XGraphics.FromPdfPage(page);
            font = new XFont(info.FontName, 9);
        }

        private void Clear()
        {
            document = PdfReader.Open("template.pdf");
            page = document.Pages[0];
            graphics = XGraphics.FromPdfPage(page);
        }

        public void GeneratePdfFiles()
        {
            var startDate = info.startDate.AddDays(-1);
            var lastDate = info.lastDate;

            while (startDate != lastDate)
            {
                List<DateTime> weekDays = new List<DateTime>();

                while (true)
                {
                    startDate = startDate.AddDays(1);

                    if(DateUtil.IsWeekDay(startDate))
                        weekDays.Add(startDate);

                    if (startDate == lastDate) break;
                    if (startDate.DayOfWeek == DayOfWeek.Sunday) break;
                }

                SaveGeneratePdfFile(weekDays);
            }
        }

        private void SaveGeneratePdfFile(List<DateTime> weekDays)
        {
            DrawSoldierInformation(weekDays);
            DrawWorkInfoTables(weekDays);
            DrawBottomTable(weekDays[^1]);

            document.Save($"From {weekDays[0]:yyyy-MM-dd} To {weekDays[^1]:yyyy-MM-dd}.pdf");
            Console.WriteLine($"Generate 'From {weekDays[0]:yyyy-MM-dd} To {weekDays[^1]:yyyy-MM-dd}.pdf'");
            Clear();
        }

        private void DrawSoldierInformation(List<DateTime> weekDays)
        {
            graphics.DrawString(info.Solider.Name, font, XBrushes.Black, new XPoint(170, 147));
            graphics.DrawString(info.Solider.Birth, font, XBrushes.Black, new XPoint(310, 147));
            graphics.DrawString(info.Solider.StartDate, font, XBrushes.Black, new XPoint(455, 147));
            graphics.DrawString(info.Solider.Division, font, XBrushes.Black, new XPoint(250, 173));
            graphics.DrawString(info.Solider.PhoneNumber, font, XBrushes.Black, new XPoint(280, 245));
            graphics.DrawString($"{weekDays[0]:yyyy/MM/dd}~{weekDays[^1]:yyyy/MM/dd}", font, XBrushes.Black, new XPoint(485, 245), XStringFormats.BaseLineCenter);
            graphics.DrawString(info.Solider.Address, font, XBrushes.Black, new XPoint(170, 280));
        }

        private void DrawWorkInfoTables(List<DateTime> weekDays)
        {
            for (int i = 0; i < weekDays.Count; i++)
            {
                graphics.DrawString($"{weekDays[i]:MM/dd}", font, XBrushes.Black, new XPoint(108, datePivots[(int)weekDays[i].DayOfWeek - 1]), XStringFormats.BaseLineCenter);

                if(info.restDates.Any(date => date == weekDays[i]))
                {
                    graphics.DrawString("연차", font, XBrushes.Black, new XPoint(437, descriptionPivots[(int)weekDays[i].DayOfWeek - 1]),  XStringFormats.BaseLineCenter);
                }
                else
                {
                    graphics.DrawString(info.StartTime, font, XBrushes.Black, new XPoint(222, timePivots[(int)weekDays[i].DayOfWeek - 1]));
                    graphics.DrawString(info.EndTime, font, XBrushes.Black, new XPoint(222, timePivots[(int)weekDays[i].DayOfWeek - 1] + 18.5));
                    graphics.DrawString(GetDescriptionText(weekDays[i].DayOfWeek), font, XBrushes.Black, new XPoint(437, descriptionPivots[(int)weekDays[i].DayOfWeek - 1]), XStringFormats.BaseLineCenter);
                }
            }
        }

        private string GetDescriptionText(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return string.IsNullOrEmpty(info.SpecialMondayDescription) ? info.Description : info.SpecialMondayDescription;

                case DayOfWeek.Friday:
                    return string.IsNullOrEmpty(info.SpecialFridayDescription) ? info.Description : info.SpecialFridayDescription;

                default:
                    return info.Description;
            }
        }

        private void DrawBottomTable(DateTime date)
        {
            graphics.DrawString(date.Year.ToString(), font, XBrushes.Black, new XPoint(385, 633), XStringFormats.BaseLineRight);
            graphics.DrawString(date.Month.ToString(), font, XBrushes.Black, new XPoint(415, 633), XStringFormats.BaseLineRight);
            graphics.DrawString(date.Day.ToString(), font, XBrushes.Black, new XPoint(445, 633), XStringFormats.BaseLineRight);

            graphics.DrawString(info.Solider.Name, font, XBrushes.Black, new XPoint(380, 657), XStringFormats.BaseLineCenter);
            graphics.DrawString(info.CeoName, font, XBrushes.Black, new XPoint(380, 681), XStringFormats.BaseLineCenter);
        }
    }
}
