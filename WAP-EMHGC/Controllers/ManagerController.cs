using Microsoft.AspNetCore.Mvc;

namespace WAP_EMHGC.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
