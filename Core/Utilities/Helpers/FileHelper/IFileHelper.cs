using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root);
        void   Delete(string filePath); 
        string Update(IFormFile file, string filepath, string root); 
        // root is a file directory. (file index)
    }
}
