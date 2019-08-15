using DmcSupport.Data;
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
        public static List<Category> Categories { get; set; }
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
        public static async Task init(ApplicationDbContext context)
        {
            Categories = await context.Categories.Include(u => u.Pages).Where(u => u.Level == 0).ToListAsync();
            foreach(var item in Categories)
            {
                await LoadCategory(item, context);
            }
        }

        static async Task LoadCategory(Category cate, ApplicationDbContext context)
        {
            cate.Categories = new List<Category>();
            cate.Categories = await context.Categories.Include(u => u.Pages).Where(u => u.ParentId == cate.Id).ToListAsync();
            foreach(var item in cate.Categories)
            {
                await LoadCategory(item, context);
            }
        }
        public static async Task<List<Category>> GetCategories(ApplicationDbContext context)
        {
            if(Categories == null)
            {
                await init(context);
            }
            return Categories;
        }

        public static async Task<List<Category>> GetCategoriesExcept(ApplicationDbContext context, Category except)
        {
            var cates = await GetCategories(context);
            var list = new List<Category>();
            for(var i=0; i<cates.Count; i++)
            {
                getCategoryListsExcept(context, list, cates[i], except);
            }
            return list;
        }

        static void getCategoryListsExcept(ApplicationDbContext context, List<Category> categories, Category category, Category except)
        {
            if(category.Id == except.Id)
            {
                return;
            }
            categories.Add(category);
            if (category.Categories == null)
                return;
            var sub = category.Categories.ToList();
            for(var i=0; i<sub.Count; i++)
            {
                getCategoryListsExcept(context, categories, sub[i], except);
            }
        }

        public static async Task<Category> GetCategory(ApplicationDbContext context, int id)
        {
            var cates = await GetCategories(context);
            return GetCategory(context, cates, id);
        }

        public static Category GetCategory(ApplicationDbContext context,List<Category> cates , int id)
        {
            if (cates == null)
                return null;
            for (var i = 0; i < cates.Count; i++)
            {
                if (cates[i].Id == id)
                    return cates[i];
            }
            for (var i = 0; i < cates.Count; i++)
            {
                var r = GetCategory(context, cates[i].Categories.ToList(), id);
                if (r != null)
                    return r;
            }
            return null;
        }
    }
}
