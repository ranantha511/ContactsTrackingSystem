using Microsoft.AspNetCore.Mvc;

namespace ContactTrackingSystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
