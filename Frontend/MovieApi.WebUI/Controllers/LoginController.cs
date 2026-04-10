using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

    }
}
