
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medico.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

      
      
    }
}