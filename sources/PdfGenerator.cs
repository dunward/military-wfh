using System;
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
            font = new XFont("나눔고딕", 9);
        }

        public void SaveGeneratePdfFile()
        {
            DrawSoldierInformation();
            DrawWorkInfoTables();
            DrawBottomTable();

            document.Save($"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.pdf");
        }

        private void DrawSoldierInformation()
        {
            graphics.DrawString(info.Solider.Name, font, XBrushes.Black, new XPoint(170, 147));
            graphics.DrawString(info.Solider.Birth, font, XBrushes.Black, new XPoint(310, 147));
            graphics.DrawString(info.Solider.StartDate, font, XBrushes.Black, new XPoint(455, 147));
            graphics.DrawString(info.Solider.Division, font, XBrushes.Black, new XPoint(250, 173));
            graphics.DrawString(info.Solider.PhoneNumber, font, XBrushes.Black, new XPoint(280, 245));
            graphics.DrawString(info.Solider.WorkingDate, font, XBrushes.Black, new XPoint(485, 245), XStringFormats.BaseLineCenter);
            graphics.DrawString(info.Solider.Address, font, XBrushes.Black, new XPoint(170, 280));
        }

        private void DrawWorkInfoTables()
        {
            for (int i = 0; i < 5; i++)
            {
                graphics.DrawString(info.Solider.WorkInfos[i].Date, font, XBrushes.Black, new XPoint(108, datePivots[i]), XStringFormats.BaseLineCenter);
                graphics.DrawString(info.Solider.WorkInfos[i].StartTime, font, XBrushes.Black, new XPoint(222, timePivots[i]));
                graphics.DrawString(info.Solider.WorkInfos[i].EndTime, font, XBrushes.Black, new XPoint(222, timePivots[i] + 18.5));
                graphics.DrawString(info.Solider.WorkInfos[i].Description, font, XBrushes.Black, new XPoint(437, descriptionPivots[i]), XStringFormats.BaseLineCenter);
            }
        }

        private void DrawBottomTable()
        {
            graphics.DrawString(DateTime.Now.Month.ToString(), font, XBrushes.Black, new XPoint(415, 633), XStringFormats.BaseLineRight);
            graphics.DrawString(DateTime.Now.Day.ToString(), font, XBrushes.Black, new XPoint(445, 633), XStringFormats.BaseLineRight);

            graphics.DrawString(info.Solider.Name, font, XBrushes.Black, new XPoint(380, 657), XStringFormats.BaseLineCenter);
            graphics.DrawString(info.CeoName, font, XBrushes.Black, new XPoint(380, 681), XStringFormats.BaseLineCenter);
        }
    }
}
