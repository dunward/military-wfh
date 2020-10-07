using System.IO;
using Newtonsoft.Json.Linq;

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
