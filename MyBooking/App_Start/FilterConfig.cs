using MyBooking.Controllers;
using MyBooking.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MyBooking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
