using Core.Application.Interfaces.File;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FileSystem
{
    public class FileService : IFileService
    {

        private readonly string address;
        public FileService(string address)
        {
            this.address = address;
        }
        public void DeleteFile(string PicturePath)
        {
                if (File.Exists(PicturePath))
                {
                    File.Delete(PicturePath);
                }     
        }

        public async Task<string> SaveFile(IFormFile File)
        {
            var splittedFileName = Path.GetFileName(File.FileName).Split('.');
            string spletedfileName = splittedFileName[0];
            string spletedfileFormat = "." + splittedFileName[splittedFileName.Length - 1];
            string hash = CreateMD5(DateTime.Now.ToString());

            string filename = spletedfileName + "_" + hash + spletedfileFormat;
            var fullfilePath = Path.Combine(address, filename);
   
            if (File.Length > 0)
            {

                using (var stream = new FileStream(fullfilePath, FileMode.CreateNew))
                {
                    await File.CopyToAsync(stream);
                }
            }
            return fullfilePath;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
