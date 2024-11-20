using Microsoft.AspNetCore.Mvc;

namespace Real_State_System.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
