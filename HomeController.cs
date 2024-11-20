using Microsoft.AspNetCore.Mvc;

namespace Real_State_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
