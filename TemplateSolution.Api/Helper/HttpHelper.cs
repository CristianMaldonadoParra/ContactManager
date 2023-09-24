//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.IO;
//using System.Linq;
//using System.Net;

//namespace TemplateSolution.Api.Helper
//{
//    public static class HttpHelper
//    {
//        public static string ToQueryString(this NameValueCollection collection)
//        {
//            var url = String.Format("?{0}", String.Join("&", collection.AllKeys
//                .Where(key => collection.GetValues(key) != null)
//                        .SelectMany(key => collection.GetValues(key)
//                            .Select(value => String.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value))))
//                            .ToArray()));

//            return url;
//        }

//        public static string ReturnCustomResponse(dynamic dto)
//        {
//            var obj = new
//            {
//                statusCode = 200,
//                data = dto == null ? new object() : dto,

//            };

//            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
//        }

//        public static string ReturnCustomResponseDatalist(dynamic dto, dynamic filter)
//        {
//            var obj = new
//            {
//                statusCode = 200,
//                dataList = dto == null ? new object() : dto,
//                paginate = new
//                {
//                    totalCount = filter.TotalCount,
//                    pageSize = filter.PageSize,
//                    pageIndex = filter.PageIndex,
//                    pageCount = filter.PageCount,
//                    isPagination = filter.IsPagination
//                }

//            };

//            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
//        }

//        private static string Json(object p, object allowGet)
//        {
//            throw new NotImplementedException();
//        }

//        public static string ReturnCustomException(Exception ex)
//        {
//            var obj = new
//            {
//                statusCode = 400,
//                errorMessage = ex.Message,
//                errorDetail = ex
//            };

//            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
//        }


//        public static string GetContentType(string path)
//        {
//            var types = GetMimeTypes();
//            var ext = Path.GetExtension(path).ToLowerInvariant();
//            return types[ext];
//        }

//        private static Dictionary<string, string> GetMimeTypes()
//        {
//            return new Dictionary<string, string>
//            {
//                {".txt", "text/plain"},
//                {".pdf", "application/pdf"},
//                {".doc", "application/vnd.ms-word"},
//                {".docx", "application/vnd.ms-word"},
//                {".xls", "application/vnd.ms-excel"},
//                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
//                {".png", "image/png"},
//                {".jpg", "image/jpeg"},
//                {".jpeg", "image/jpeg"},
//                {".gif", "image/gif"},
//                {".csv", "text/csv"},
//                {".rar", "application/x-rar-compressed" },
//                {".7z" , "application/x-7z-compressed"},
//                {".zip", "application/zip" },
//                {".mp3", "video/mpeg" },
//                {".mp4", "video/mp4"},
//                {".3gp", "video/3gpp" },
//                {".avi","video/x-msvideo" },
//                {".fvt","video/vnd.fvt" },
//                {".jpgv","video/jpeg" },
//                {".wm","video/x-ms-wm" },
//                {".wmx","video/x-ms-wmx" },
//                {".mpeg","video/mpeg" },
//                {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
//                {".xlt", "application/vnd.ms-excel"},
//                {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
//                {".xlw", "application/vnd.ms-excel"},
//                {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
//                {".one", "application/onenote"},
//                {".ppt", "application/vnd.ms-powerpoint"},
//                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
//                {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
//                {".epub", "application/epub+zip"},
//                {".dot", "application/msword"},
//                {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
//                {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
//                {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
//                {".xml", "application/xml"},
//                {".msg", "application/vnd.ms-outlook"},
//                {".html", "text/html"},
//                {".htm", "text/html"},
//                {".xlsb","application/vnd.ms-excel.sheet.binary.macroEnabled.12" },
//                {".ppsm","application/vnd.ms-powerpoint.slideshow.macroEnabled.12" },
//                {".xlam","application/vnd.ms-excel.addin.macroEnabled.12"}
//            };
//        }
//    }
//}
