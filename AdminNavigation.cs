using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA
{
    public class AdminMenu : INavigationProvider
    {

        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }


        public void GetNavigation(NavigationBuilder builder)
        {

    //        builder
    //.AddImageSet("settings")
    //.Add(T("WAA Admin"), "1", layouts => layouts
    //    .Action("Index", "Admin", new { area = "WAA" })
    //    .LinkToFirstChild(false)
    //    .Add(T("Reports"), "1", elements => elements.Action("Reports", "Admin", new { area = "WAA" })));

            builder.AddImageSet("settings").Add(T("WAA Admin"), "-1")
                .Add(T("WAA Admin"), "1", menu => menu.Action("Index", "Admin", new { area = "WAA" }).Permission(Permissions.AccessWaaDashboard));

               

            //builder.Add(T("WAA Admin"), "-1", item => item.Add(T("Reports"), "5", i => i.Action("Index", "Admin", new { area = "WAA" }).Permission(Permissions.AccessWaaDashboard)));

        }



    }
}