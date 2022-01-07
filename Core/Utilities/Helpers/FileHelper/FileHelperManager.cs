using Core.Utilities.Helpers.GuidHelperr;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    //adding,deleting and uploading operations are done here
    //should read upload method first
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath) //filepath came from CarImageManeger
        {
            if (File.Exists(filePath)) 
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filepath, string root)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;

                using(FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null; 
        }
    }
}
