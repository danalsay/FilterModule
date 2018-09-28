using System;
using System.Web;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterModule
{
    class AuthorizeLocal : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(OnBeginRequest);
        }


        private void OnBeginRequest(Object s, EventArgs e)
        {
            HttpApplication app = s as HttpApplication;
            HttpRequest req = app.Request;
            HttpContext context = app.Context;

            if (!req.IsLocal)    // Is the request from a Local Source?
            {
                context.Response.Close(); // close the response: ends request
            }

            /* Optional Test Code - to view locally create an html page TestModule.html in target site */
            string Identity = Thread.CurrentPrincipal.Identity.Name;
            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);
            string fileName = VirtualPathUtility.GetFileName(filePath);

            if (fileName.ToLower().Equals("testmodule.html"))
            {
                try
                {
                    app.Context.Response.Write("app: " + app.ToString());
                    context.Response.Write("<br/>server: " + app.Server.ToString());
                    context.Response.Write("<br/>Thread.CurrentPrincipal.Identity.Name: " + Thread.CurrentPrincipal.Identity.Name);
                    context.Response.Write("<br/>HttpRequest: " + req.Url.ToString());
                    context.Response.Write("<br/>req.UserHostName: " + req.UserHostName);
                    context.Response.Write("<br/>req.UserHostAddress: " + req.UserHostAddress);
                    context.Response.Write("<br/>filePath: " + filePath);
                    context.Response.Write("<br/>fileName: " + fileName);
                    context.Response.Write("<br/>fileExtension: " + fileExtension);
                    context.Response.Write("<br/>req.IsLocal: " + req.IsLocal.ToString());
                    context.Response.Write("<br/>req.LogonUserIdentity: " + req.LogonUserIdentity);
                    context.Response.Write("<br/>req.UserHostName : " + req.UserHostName);
                    context.Response.Write("<br/>req.AnonymousID " + req.AnonymousID);
                    context.Response.Write("<br/>req.IsAuthenticated : " + req.IsAuthenticated);
                }
                catch (Exception Ex)
                {
                    context.Response.Write("<br/> " + Ex.ToString());
                }
            }

            //if (_eventHandler != null)
            //    _eventHandler(this, null);
        }

        public void Dispose()
        {

        }

    }
}

