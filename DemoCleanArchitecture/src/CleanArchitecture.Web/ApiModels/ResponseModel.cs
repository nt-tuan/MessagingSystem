using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
    public class ResponseModel
    {
        private readonly string WARNING_TYPE = "warning";
        private readonly string ERROR_TYPE = "error";
        private readonly string INFO_TYPE = "info";
        public string message { get; set; }
        public string type { get; set; }
        dynamic result { get; set; }
        public ResponseModel()
        {

        }

        public ResponseModel(string mes)
        {
            message = mes;
        }

        public ResponseModel(string mes, dynamic re) : this(mes)
        {
            result = re;
        }

        public ResponseModel(dynamic re) : this()
        {
            result = re;
        }

        public static ResponseModel CreateWarning(string mes)
        {
            var r = new ResponseModel(mes);
            r.type = r.WARNING_TYPE;
            return r;
        }

        public static ResponseModel CreateError(string mes)
        {
            var r = new ResponseModel(mes);
            r.type = r.ERROR_TYPE;
            return r;
        }

        public static ResponseModel CreateInfo(string mes)
        {
            var r = new ResponseModel();
            r.type = r.INFO_TYPE;
            return r;
        }
    }
}
