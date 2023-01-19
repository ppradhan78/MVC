using AspNetCore.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IMemoryCache _memoryCache;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cacheKey = "employeeList";
            CurrentDateTime = DateTime.Now;

            if (!_memoryCache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
            {
                cacheValue = CurrentDateTime;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                _memoryCache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
            }

            CacheCurrentDateTime = cacheValue;
            HttpContext.Session.SetString("View", "Home/Index");
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Page"] = HttpContext.Session.GetString("View");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
