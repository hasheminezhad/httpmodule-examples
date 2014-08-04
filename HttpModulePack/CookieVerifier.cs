using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace HttpModulePack
{
    class CookieVerifier : IHttpModule
    {
        public void Dispose(){}

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;

            for (int i = application.Response.Cookies.Count - 1; i >= 0; i--)
            {
                HttpCookie cookie = application.Response.Cookies[i];
                cookie.Value = CalculateSignature(cookie.Value) + cookie.Value;
            }
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;

            for (int i = application.Request.Cookies.Count - 1; i >= 0; i--)
            {
                HttpCookie cookie = application.Request.Cookies[i];

                bool isValid = false;
                if (cookie.Value.Length >= 40)
                {
                    string value = cookie.Value.Substring(40);
                    string signature = cookie.Value.Substring(0, 40);
                    isValid = CalculateSignature(value) == signature;
                    cookie.Value = value;
                }

                if (!isValid) application.Request.Cookies.Remove(cookie.Name);
            }
        }

        string CalculateSignature(string value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(
                MachineKey.Encode(Encoding.UTF8.GetBytes(value), MachineKeyProtection.Validation),
                "sha1");
        }
    }
}
