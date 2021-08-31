using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FizzBuzz()
        {
            FizzBuzzModel model = new();
            model.InputBuzz = 5;
            model.InputFizz = 9;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzz(FizzBuzzModel fb)
        {
            bool fizz;
            bool buzz;

            for(int i = 1; i <= 100; i++)
            {
                fizz = (i % fb.InputFizz == 0);
                buzz = (i % fb.InputBuzz == 0);
                if (fizz && buzz)
                {
                    fb.Result.Add("FizzBuzz");
                }else if (buzz)
                {
                    fb.Result.Add("Buzz");
                }
                else if (fizz)
                {
                    fb.Result.Add("Fizz");
                }
                else
                {
                    fb.Result.Add(i.ToString());
                }
            }

            return View(fb);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
