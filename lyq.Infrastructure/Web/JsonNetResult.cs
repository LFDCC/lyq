using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Web;
using System.Web.Mvc;

namespace lyq.Infrastructure.Web
{
    public class JsonNetResult : JsonResult
    {
        public JsonSerializerSettings Settings { get; private set; }
        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy-MM-dd HH:mm:ss",//默认日期格式
                ContractResolver = new CamelCasePropertyNamesContractResolver()//json中属性开头字母小写的驼峰命名
            };
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet
            && string.Equals(context.HttpContext.Request.HttpMethod, "GET",
           StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JSON GET is not allowed");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" :ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data == null)
            {
                return;
            }
            var scriptSerializer = JsonSerializer.Create(Settings);
            scriptSerializer.Serialize(response.Output, Data);
        }
    }
}
