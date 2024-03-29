﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using DataModelLib.Page;

namespace Webservice
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError().GetBaseException();
            if (Request.UrlReferrer != null)
                LogHelper.StoreError(ex.Message, ex.StackTrace, Request.Url + " ::[From]:: " + Request.UrlReferrer);
            else
                LogHelper.StoreError(ex.Message, ex.StackTrace, Request.Url + " ::[From]:: Unknown");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

    }
}