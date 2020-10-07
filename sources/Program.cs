using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace military_wfh
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument pdf = PdfReader.Open("template.pdf");
            PdfPage page = pdf.Pages[0];

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            XGraphics g = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Malgun Gothic", 9);

            g.DrawString("이름", font, XBrushes.Black, new XPoint(170, 147));
            g.DrawString("1111/01/01", font, XBrushes.Black, new XPoint(310, 147));
            g.DrawString("1111/01/01", font, XBrushes.Black, new XPoint(455, 147));
            g.DrawString("서울지방병무청", font, XBrushes.Black, new XPoint(250, 173));
            g.DrawString("010-0000-0000", font, XBrushes.Black, new XPoint(280, 245));
            g.DrawString("20/20/20~20/20/20", font, XBrushes.Black, new XPoint(485, 245), XStringFormats.BaseLineCenter);
            g.DrawString("주소주소주소주소주소주소주소주소주소주소", font, XBrushes.Black, new XPoint(170, 280));

            g.DrawString("6/10", font, XBrushes.Black, new XPoint(108, 365), XStringFormats.BaseLineCenter);
            g.DrawString("6/10", font, XBrushes.Black, new XPoint(108, 410), XStringFormats.BaseLineCenter);
            g.DrawString("6/10", font, XBrushes.Black, new XPoint(108, 451), XStringFormats.BaseLineCenter);
            g.DrawString("6/10", font, XBrushes.Black, new XPoint(108, 491), XStringFormats.BaseLineCenter);
            g.DrawString("6/10", font, XBrushes.Black, new XPoint(108, 529), XStringFormats.BaseLineCenter);

            var pivots = new double[] { 352, 397, 439, 479, 518 };

            for (int i = 0; i < 5; i++)
            {
                g.DrawString("10:00", font, XBrushes.Black, new XPoint(222, pivots[i]));
                g.DrawString("24:00", font, XBrushes.Black, new XPoint(222, pivots[i] + 18.5));
            }

            g.DrawString("업무수행", font, XBrushes.Black, new XPoint(437, 365), XStringFormats.BaseLineCenter);
            g.DrawString("업무수행", font, XBrushes.Black, new XPoint(437, 410), XStringFormats.BaseLineCenter);
            g.DrawString("업무수행", font, XBrushes.Black, new XPoint(437, 451), XStringFormats.BaseLineCenter);
            g.DrawString("업무수행", font, XBrushes.Black, new XPoint(437, 491), XStringFormats.BaseLineCenter);
            g.DrawString("업무수행", font, XBrushes.Black, new XPoint(437, 529), XStringFormats.BaseLineCenter);

            g.DrawString("06", font, XBrushes.Black, new XPoint(415, 633), XStringFormats.BaseLineRight);
            g.DrawString("12", font, XBrushes.Black, new XPoint(445, 633), XStringFormats.BaseLineRight);

            g.DrawString("이름", font, XBrushes.Black, new XPoint(380, 657), XStringFormats.BaseLineCenter);
            g.DrawString("대표이사명", font, XBrushes.Black, new XPoint(380, 681), XStringFormats.BaseLineCenter);

            pdf.Save("test.pdf");
        }
    }
}
