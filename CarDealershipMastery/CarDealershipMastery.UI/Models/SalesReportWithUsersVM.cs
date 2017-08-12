using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace CarDealershipMastery.UI.Models
{
    public class SalesReportWithUsersVM
    {
        public List<SalesReportVM> AllSalesReport { get; set; }
        public List<AppUser> AllUsers { get; set; }

        public SalesReportWithUsersVM()
        {
            AllUsers = new List<AppUser>();
            AllSalesReport = new List<SalesReportVM>();
        }

        //public void SetAllUsers(IEnumerable<AppUser> setList)
        //{
        //    foreach (var item in setList)
        //    {
        //        AllUsers.Add(new SelectListItem()
        //        {
        //            Value = item.UserName.ToString(),
        //            Text = item.UserName
        //        });
        //    }
        //}

    }
}