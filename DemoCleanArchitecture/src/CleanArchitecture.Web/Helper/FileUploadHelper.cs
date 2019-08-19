using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper
{
    public class FileUploadHelper
    {
        static FileUploadHelper _instance;
        public static FileUploadHelper Instance { get; set; }
        public static void FirstLoad(IHostingEnvironment ihe)
        {
            Instance = new FileUploadHelper(ihe);
        }

        IHostingEnvironment iHostingEnvironment;

        FileUploadHelper(IHostingEnvironment ihe)
        {
            iHostingEnvironment = ihe;
            init();
        }

        void init()
        {

        }

    }
}
