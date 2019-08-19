using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class UtilityHelper
    {
        public static string DateFormat = "dd/MM/yyyy";
        public static string LongDateFormat = "dd/MM/yyyy hh:mm:ss";

        public static string GetRandomString(int length)
        {
            StringBuilder coupon = new StringBuilder(length);
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rnd = new byte[1];
            int n = 0;
            while (n < length)
            {
                rng.GetBytes(rnd);
                char c = (char)rnd[0];
                if ((Char.IsDigit(c) || Char.IsLetter(c)) && rnd[0] < 127)
                {
                    ++n;
                    coupon.Append(rnd[0]);
                }
            }
            return coupon.ToString();
        }
        public static async Task<Hashtable> UploadImage(IHostingEnvironment _hostingEnvironment, string path, HttpContext HttpContext)
        {
            // Get the file from the POST request
            var theFile = HttpContext.Request.Form.Files.GetFile("file");

            // Building the path to the uploads directory
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Building the path to the uploads directory
            var fileRoute = Path.Combine(webRootPath, path);

            // Get the mime type
            var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

            // Get File Extension
            string extension = System.IO.Path.GetExtension(theFile.FileName);

            // Generate Random name.
            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

            // Build the full path inclunding the file name
            string link = Path.Combine(fileRoute, name);

            // Create directory if it does not exist.
            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            // Basic validation on mime types and file extension
            string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
            string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

            if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
            {
                // Copy contents to memory stream.
                Stream stream;
                stream = new MemoryStream();
                theFile.CopyTo(stream);
                stream.Position = 0;
                String serverPath = link;

                // Save the file
                using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                {
                    await stream.CopyToAsync(writerFileStream);
                    writerFileStream.Dispose();
                }

                // Return the file path as json
                Hashtable imageUrl = new Hashtable();
                imageUrl.Add("location", "/" + path + "/" + name);
                return imageUrl;
            }
            throw new ArgumentException("The image did not pass the validation");
        }
        public static async Task init(AppDbContext context)
        {

        }
    }
}
