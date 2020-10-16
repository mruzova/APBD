using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string logpath = "requestsLog.txt";

            if (httpContext.Request!=null)
            {
                string path = httpContext.Request.Path;
                string queryString = httpContext.Request?.QueryString.ToString();
                string method = httpContext.Request.Method.ToString();
                string bodyParameters = "";
                using(StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyParameters = await reader.ReadToEndAsync();
                
                }
                if (!File.Exists(logpath))
                {
                    File.Create(logpath).Dispose();
                }

                StreamWriter sw = File.AppendText(logpath);

                sw.WriteLine("Path: " + path + "; Query String: " + queryString + "; Method: " + method + "; Body Parameters: " + bodyParameters);

                sw.Close();
                //log errors to the file

            }

            await _next(httpContext);

        }

    }
}
