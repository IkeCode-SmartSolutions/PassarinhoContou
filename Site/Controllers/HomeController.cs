using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using PassarinhoContou.Model;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var httpClient = new HttpClient())
            {
                var request = httpClient.GetAsync("http://localhost:700/api/prefixcategory");
                request.Wait();
                
                var result = request.Result.Content.ReadAsStringAsync().Result;

                var parsed = JsonConvert.DeserializeObject<PrefixCategory[]>(result);
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
