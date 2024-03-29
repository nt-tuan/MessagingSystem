﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels
{
    public class MessageModel
    {
        public static readonly string ERROR_TYPE = "danger";
        public static readonly string WARNING_TYPE = "warning";
        public static readonly string SUCCESS_TYPE = "success";
        public string Type { get; set; }
        public string Content { get; set; }
        public string Key { get; set; }

        public static MessageModel CreateError(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = ERROR_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }

        public static MessageModel CreateWarning(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = WARNING_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }

        public static MessageModel CreateSuccess(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = SUCCESS_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }
        
    }
}
