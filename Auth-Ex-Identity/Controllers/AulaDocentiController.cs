using Microsoft.AspNetCore.Mvc;

namespace Auth_Ex_Identity.Controllers
{
    public class AulaDocentiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
