using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using Microsoft.SharePoint.Client;
using File = Microsoft.SharePoint.Client.File;
using System.Configuration;
using System.Collections.Generic;

namespace CommitToProdTime
{
    public class WriteToFile
    {
        readonly string userName = "saleborg@volvocars.com";
        readonly string password = "3VitHund!";
        readonly string site = @"https://collaboration.volvocars.net/sites/dspa/";
        readonly string fileLocation = @"https://collaboration.volvocars.net/sites/dspa/Common%20Services/KPI_Leadtimes/";
        readonly string fileName = "commitToProd.csv";


        internal void Write(IDictionary<string, TimeSpan> deployTimes)
        {
            string filePath = DownloadFilesFromSharePoint();
            
            string[] valueArrayString = new string[deployTimes.Count+1];

            valueArrayString[0] = DateTime.Now.ToString();


            var keys = deployTimes.Keys;
            string[] keysArray = new string[keys.Count+1];
            int j = 1;
            var format = new StringBuilder();
            format.Append("{0};");
            keysArray[0] = "Date";
            foreach (var key in keys)
            {
                keysArray[j] = key;
                deployTimes.TryGetValue(key, out TimeSpan time);
                valueArrayString[j] = time.ToString();
                format.Append("{" + j + "};");
                j++;
            }
            format.Remove(format.Length - 1, 1);
            if (filePath.Equals(""))
            {
                filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    string headfing = string.Format(format.ToString(), keysArray);
                 //   string headfing = string.Format(format.ToString(), "Date", keysArray[0], keysArray[1], keysArray[2], keysArray[3],
                 //       keysArray[4], keysArray[5], keysArray[6], keysArray[7], keysArray[8], keysArray[9], keysArray[10], keysArray[11], 
                 //       keysArray[12], keysArray[13], keysArray[14], keysArray[15], keysArray[16], keysArray[17], keysArray[18], 
                 //       keysArray[19], keysArray[20], keysArray[21], keysArray[22]);
                    byte[] array = Encoding.ASCII.GetBytes(headfing + System.Environment.NewLine);
                    for (int i = 0; i < array.Length; i++)
                    {
                        fs.WriteByte(array[i]);
                    }

                }
            }
            var csv = new StringBuilder();
            string line = string.Format(format.ToString(), valueArrayString);
            //string line = string.Format(format.ToString(), DateTime.Now, 
            //    valueArray[0], valueArray[1], valueArray[2], valueArray[3], valueArray[4], valueArray[5], valueArray[6],
            //    valueArray[7], valueArray[8], valueArray[9], valueArray[10], valueArray[11],
            //            valueArray[12], valueArray[13], valueArray[14], valueArray[15], valueArray[16], valueArray[17], valueArray[18],
            //            valueArray[19], valueArray[20], valueArray[21], valueArray[22]);
            csv.AppendLine(line);
            System.IO.File.AppendAllText(filePath, line + System.Environment.NewLine);


            uploadDocument(filePath);

            System.IO.File.Delete(filePath);
        }


        public void uploadDocument(string filePath)
        {
            Console.WriteLine("Start Uploading of Document");
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            using (var clientContext = new ClientContext(site))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                Web web = clientContext.Web;
                clientContext.Load(web, a => a.ServerRelativeUrl);
                clientContext.ExecuteQuery();
                List documentsList = clientContext.Web.Lists.GetByTitle("Common Services");

                var fileCreationInformation = new FileCreationInformation();
                //Assign to content byte[] i.e. documentStream

                fileCreationInformation.Content = System.IO.File.ReadAllBytes(filePath);
                //Allow owerwrite of document

                fileCreationInformation.Overwrite = true;
                //Upload URL

                fileCreationInformation.Url = fileLocation + fileName;

                File uploadFile = documentsList.RootFolder.Files.Add(fileCreationInformation);

                //Update the metadata for a field having name "DocType"
                uploadFile.ListItemAllFields["Title"] = "UploadedviaCSOM";

                uploadFile.ListItemAllFields.Update();
                clientContext.ExecuteQuery();

            }
            Console.WriteLine("Uploading of Document Completed");
        }


        public string DownloadFilesFromSharePoint()
        {

            Console.WriteLine("Downloading Files Started");
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);

            }
            
            using (var clientContext = new ClientContext(site))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                Web web = clientContext.Web;
                clientContext.Load(web, a => a.ServerRelativeUrl);
                clientContext.ExecuteQuery();

                FileCollection files = clientContext.Web.GetFolderByServerRelativeUrl(fileLocation).Files;

                clientContext.Load(files);
                clientContext.ExecuteQuery();
                foreach (File file in files)
                {
                    if (file.Name.Equals(fileName))
                    {
                        FileInformation fileInfo = File.OpenBinaryDirect(clientContext, file.ServerRelativeUrl);
                        clientContext.ExecuteQuery();

                        var filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                        FileStream fileStream = new FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);

                        fileInfo.Stream.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        Console.WriteLine("Downloading Files Completed");
                        return filePath;
                    }

                }
            }
            Console.WriteLine("Downloading Files Completed");
            return "";


        }
    }
}