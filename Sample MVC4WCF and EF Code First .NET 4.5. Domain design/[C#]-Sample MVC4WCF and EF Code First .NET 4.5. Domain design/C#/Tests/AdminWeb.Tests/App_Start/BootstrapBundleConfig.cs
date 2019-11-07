#region File Attributes

// AdminWeb  Project: AdminWeb.Tests
// File:  BootstrapBundleConfig.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

using AdminWeb.Tests.App_Start;

using WebActivatorEx;

#endregion

[assembly: PostApplicationStartMethod(typeof (BootstrapBundleConfig), "RegisterBundles")]

namespace AdminWeb.Tests.App_Start {
    #region

    using System.Web.Optimization;

    #endregion

    public class BootstrapBundleConfig {

        public static void RegisterBundles()
        {
            // Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap*"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css",
                                                                                   "~/Content/bootstrap-responsive.css"));
        }

    }
}