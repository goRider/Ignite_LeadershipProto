using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ignite_Leadership.Controllers
{
    public class IgniteUserApplicationController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetNoApps()
        {
            return View("~/Views/Manager/GetNoApps.cshtml");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View("~/Views/Manager/Index.cshtml");
        }

        /// <summary>
        /// This is the view for Managers
        /// </summary>
        /// <returns></returns>
        public IActionResult DetailApp()
        {
            return View("~/Views/Manager/Index.cshtml");
        }

        /// <summary>
        /// This is the HR View for all apps
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllEndorsedApps()
        {
            return View("~/Views/HR/MyApps.cshtml");
        }
    }
}
