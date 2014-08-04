using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;

namespace HttpModulePack
{
    public class LongRequestTracker : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        public void Dispose() { }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            application.Context.Items["_StartTime"] = DateTime.Now;
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var totalTime = DateTime.Now - (DateTime)application.Context.Items["_StartTime"];
            if (totalTime > TimeSpan.FromSeconds(2))
            {
                File.AppendAllLines(application.Server.MapPath("LongRequest.log"),
                    new string[]
                    {
                        "IP: " + application.Request.UserHostAddress,
                        "UserAgent: "+ application.Request.UserAgent,
                        "Url: "+ application.Request.RawUrl,
                        "Type: "+ application.Request.RequestType,
                        "Process time: "+ totalTime,
                        string.Empty
                    });

                if (application.Context.Handler is Page)
                {
                    application.Response.Write("<script>alert('It took " + totalTime.TotalMilliseconds.ToString("#") + "ms to complete that request')</script>");
                }
            }
        }
    }
}
