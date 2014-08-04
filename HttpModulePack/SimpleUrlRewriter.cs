using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpModulePack
{
    class SimpleUrlRewriter : IHttpModule
    {

        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application.Request.Path.Equals("/fake.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                application.Server.Transfer("Default.aspx?msg=This+is+Fake.aspx!");
            }
        }
    }
}
