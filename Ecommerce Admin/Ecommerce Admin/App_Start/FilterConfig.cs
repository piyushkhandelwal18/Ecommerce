﻿using System.Web;
using System.Web.Mvc;

namespace Ecommerce_Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
