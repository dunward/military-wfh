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
            MilitaryPdfInfo info = new MilitaryPdfInfo(obj);

            PdfGenerator generator = new PdfGenerator(info);
            generator.SaveGeneratePdfFile();
        }
    }
}
