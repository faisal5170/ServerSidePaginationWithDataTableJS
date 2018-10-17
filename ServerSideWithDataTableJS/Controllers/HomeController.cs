using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerSideWithDataTableJS.Models;

namespace ServerSideWithDataTableJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly HeroDBEntities _db = new HeroDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetData()
        {
            var result = new JsonResult();
            try
            {
                // Initialization.   
                var search = Request.Form.GetValues("search[value]")?[0];
                var draw = Request.Form.GetValues("draw")?[0];
                var order = Request.Form.GetValues("order[0][column]")?[0];
                var orderDir = Request.Form.GetValues("order[0][dir]")?[0];
                var startRec = Request.Form.GetValues("start") != null ? Convert.ToInt32(Request.Form.GetValues("start")?[0]) : 0;
                var pageSize = Request.Form.GetValues("length") != null ? Convert.ToInt32(Request.Form.GetValues("length")?[0]) : 10;
                // Loading.   
                var data = _db.Transactions.ToList();
                // Total record count.   
                var totalRecords = data.Count;
                // Verification.   
                if (!string.IsNullOrEmpty(search) &&
                    !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search   
                    data = data.Where(p => p.HeroOrderID.ToString().ToLower().Contains(search.ToLower()) ||
                        p.Email.ToString().ToLower().Contains(search.ToLower()) ||
                        p.ID.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                // Sorting.   
                if (orderDir != null && order != null)
                {
                    data = this.SortByColumnWithOrder(order, orderDir, data);
                }
                // Filter record count.   
                var recFilter = data.Count;
                // Apply pagination.   
                data = data.Skip(startRec).Take(pageSize).ToList();
                // Loading drop down lists.   
                result = this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = totalRecords,
                    recordsFiltered = recFilter,
                    data
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info   
                Console.Write(ex);
            }
            // Return info.   
            return result;
        }

        private List<Transaction> SortByColumnWithOrder(string order, string orderDir, List<Transaction> data)
        {
            // Initialization.   
            List<Transaction> lst = new List<Transaction>();
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ID).ToList() : data.OrderBy(p => p.ID).ToList();
                        break;
                    case "1":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.HeroOrderID).ToList() : data.OrderBy(p => p.HeroOrderID).ToList();
                        break;
                    case "2":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Email).ToList() : data.OrderBy(p => p.Email).ToList();
                        break;
                    default:
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ID).ToList() : data.OrderBy(p => p.ID).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                // info.   
                Console.Write(ex);
            }
            // info.   
            return lst;
        }
    }
}