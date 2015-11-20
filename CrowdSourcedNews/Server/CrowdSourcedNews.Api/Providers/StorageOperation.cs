using System;
using System.Collections.Generic;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;

namespace CrowdSourcedNews.Api.Providers
{
    public class StorageOperation
    {
        private const string DefaultDirectoryMime = "application/vnd.google-apps.folder";
        private const string DefaultMime = "application/unknown";
        private const string NonExistingFile = "File does not exist";
        private const string DownloadUnsuccessful = "Unsuccessful file download ";
        private const string UploadUnsuccessful = "File upload error: ";
        internal const string ParentFolder = "WebNews";


        public static File CreateDirectory(DriveService service, string title, string description, string parent)
        {
            File NewsDirectory = null;
            File body = new File
            {
                Title = title,
                Description = description,
                MimeType = DefaultDirectoryMime
            };

            try
            {
                FilesResource.InsertRequest request = service.Files.Insert(body);
                NewsDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return NewsDirectory;
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = DefaultMime;
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public static File UploadFile(DriveService service, string uploadFile, string parent)
        {
            if (System.IO.File.Exists(uploadFile))
            {
                File body = new File
                {
                    Title = System.IO.Path.GetFileName(uploadFile),
                    MimeType = GetMimeType(uploadFile),
                    Parents = new List<ParentReference>() { new ParentReference() { Id = parent } }
                };

                byte[] byteArr = System.IO.File.ReadAllBytes(uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArr);

                try
                {
                    FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, GetMimeType(uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine(UploadUnsuccessful + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine(NonExistingFile);
                return null;
            }
        }

        public static File UploadFile(DriveService service, byte[] byteArr, string parent)
        {
            File body = new File
            {
                Title = "NewImage",
                MimeType = "image/jpg",
                Parents = new List<ParentReference>() { new ParentReference() { Id = parent } }
            };

            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArr);
            try
            {
                FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "image/jpg");
                request.Upload();
                return request.ResponseBody;
            }
            catch (Exception e)
            {
                Console.WriteLine(UploadUnsuccessful + e.Message);
                return null;
            }
        }

        public static Boolean DownloadFile(DriveService service, File fileName, string destinationDirectory)
        {
            if (!String.IsNullOrEmpty(fileName.DownloadUrl))
            {
                try
                {
                    var request = service.HttpClient.GetByteArrayAsync(fileName.DownloadUrl);
                    byte[] content = request.Result;
                    System.IO.File.WriteAllBytes(destinationDirectory, content);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(DownloadUnsuccessful + e.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine(NonExistingFile);
                return false;
            }
        }

        public static IList<File> GetFiles(DriveService service, string search)
        {
            IList<File> Files = new List<File>();

            try
            {
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = search;
                }
                FileList filesFeed = list.Execute();

                while (filesFeed.Items != null)
                {
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }

                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }
                    list.PageToken = filesFeed.NextPageToken;
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Files;
        }
    }
}
