﻿using BrandValues.Models;
using System;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace BrandValues
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			EnsureAuthIndexes.Exist();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //http://msdn.microsoft.com/en-us/library/system.web.helpers.antiforgeryconfig.suppressidentityheuristicchecks(v=vs.111).aspx
            //Identity.IsAuthenticated is true but Identity.Name is not set.
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

            MvcHandler.DisableMvcResponseHeader = true;

            //IE6 & IE7 identifier
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("IE6")
            {
                ContextCondition = (
                context => context.GetOverriddenUserAgent().IndexOf("MSIE 6.", StringComparison.OrdinalIgnoreCase) >= 0) 
            });

            DisplayModeProvider.Instance.Modes.Add(new DefaultDisplayMode("IE6")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("MSIE 7.", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        #if !DEBUG
        protected void Application_BeginRequest()
        {
            //http://martin-brennan.github.io/aws/2013/04/08/force-https-asp-net-aws-load-balancer/
            string protocol = Request.Headers["X-Forwarded-Proto"];
            if (protocol != "https") {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl);
            };
        }
        #endif



    }
}
