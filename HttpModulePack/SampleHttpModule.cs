using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpModulePack
{
    class SampleHttpModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            if (application.Context.Handler is System.Web.UI.Page)
            {
                application.Response.Write("<hr />This works!");
            }
        }
    }
}
