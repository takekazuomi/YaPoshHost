﻿using System;
using System.Web;
using System.Web.Routing;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapOwinPath("/");
        }
    }
}