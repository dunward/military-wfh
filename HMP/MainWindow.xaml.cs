using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Docs.v1;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string[] Scopes = { DriveService.Scope.Drive, DocsService.Scope.Documents };
        static string ApplicationName = "Google Sheets API .NET QuickStart";

        public MainWindow()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            var credential = GetUserCredential();

            var service = new DocsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            string documentId = "1WK2kHrNyha5TwcZ6GANDqBKAIkCGXapBWCvXc7MlLmA";
            DocumentsResource.GetRequest request = service.Documents.Get(documentId);
            var doc = request.Execute();
            MessageBox.Show(doc.Body.Content[0].ToString());


            //var service = new DriveService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName,
            //});

            //Google.Apis.Drive.v3.Data.File copiedFile = new Google.Apis.Drive.v3.Data.File();
            ////This will be the body of the request so probably you would want to modify this
            //copiedFile.Name = "Name of the new file2";

            //string originFileId = "1WK2kHrNyha5TwcZ6GANDqBKAIkCGXapBWCvXc7MlLmA";

            //FilesResource.CopyRequest copyRequest = service.Files.Copy(copiedFile, originFileId);
            //// You can change more parameter of the request here

            //FilesResource.GetRequest getRequest = service.Files.Get(originFileId);
            //var origin = getRequest.Execute();
            //FilesResource.ExportRequest exportRequest = service.Files.Export(origin.Id, origin.MimeType);

            //string qwe = exportRequest.Execute();
            //MessageBox.Show(qwe);

            //var test = copyRequest.Execute();
            //MessageBox.Show(test.ContentHints.IndexableText);
        }

        private UserCredential GetUserCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }
    }
}
