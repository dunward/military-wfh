using Newtonsoft.Json.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata;

namespace military_wfh
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = JObject.Parse(File.ReadAllText(@"data.json"));
            MilitaryPdfInfo pdfInfo = new MilitaryPdfInfo(obj);

            PdfDocument pdf = PdfReader.Open("template.pdf");
            PdfPage page = pdf.Pages[0];


            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            XGraphics g = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Malgun Gothic", 9);

            g.DrawString(pdfInfo.Solider.Name, font, XBrushes.Black, new XPoint(170, 147));
            g.DrawString(pdfInfo.Solider.Birth, font, XBrushes.Black, new XPoint(310, 147));
            g.DrawString(pdfInfo.Solider.StartDate, font, XBrushes.Black, new XPoint(455, 147));
            g.DrawString(pdfInfo.Solider.Division, font, XBrushes.Black, new XPoint(250, 173));
            g.DrawString(pdfInfo.Solider.PhoneNumber, font, XBrushes.Black, new XPoint(280, 245));
            g.DrawString(pdfInfo.Solider.WorkingDate, font, XBrushes.Black, new XPoint(485, 245), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.Address, font, XBrushes.Black, new XPoint(170, 280));

            g.DrawString(pdfInfo.Solider.WorkInfos[0].Date, font, XBrushes.Black, new XPoint(108, 365), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[1].Date, font, XBrushes.Black, new XPoint(108, 410), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[2].Date, font, XBrushes.Black, new XPoint(108, 451), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[3].Date, font, XBrushes.Black, new XPoint(108, 491), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[4].Date, font, XBrushes.Black, new XPoint(108, 529), XStringFormats.BaseLineCenter);

            var pivots = new double[] { 352, 397, 439, 479, 518 };

            for (int i = 0; i < 5; i++)
            {
                g.DrawString(pdfInfo.Solider.WorkInfos[i].StartTime, font, XBrushes.Black, new XPoint(222, pivots[i]));
                g.DrawString(pdfInfo.Solider.WorkInfos[i].EndTime, font, XBrushes.Black, new XPoint(222, pivots[i] + 18.5));
            }

            g.DrawString(pdfInfo.Solider.WorkInfos[0].Description, font, XBrushes.Black, new XPoint(437, 365), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[1].Description, font, XBrushes.Black, new XPoint(437, 410), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[2].Description, font, XBrushes.Black, new XPoint(437, 451), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[3].Description, font, XBrushes.Black, new XPoint(437, 491), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.Solider.WorkInfos[4].Description, font, XBrushes.Black, new XPoint(437, 529), XStringFormats.BaseLineCenter);

            g.DrawString(DateTime.Now.Month.ToString(), font, XBrushes.Black, new XPoint(415, 633), XStringFormats.BaseLineRight);
            g.DrawString(DateTime.Now.Day.ToString(), font, XBrushes.Black, new XPoint(445, 633), XStringFormats.BaseLineRight);

            g.DrawString(pdfInfo.Solider.Name, font, XBrushes.Black, new XPoint(380, 657), XStringFormats.BaseLineCenter);
            g.DrawString(pdfInfo.CeoName, font, XBrushes.Black, new XPoint(380, 681), XStringFormats.BaseLineCenter);

            pdf.Save("test.pdf");
        }
    }
}
