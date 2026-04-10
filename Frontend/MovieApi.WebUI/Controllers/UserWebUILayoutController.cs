using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{

    public class UserWebUILayoutController : Controller
    {

        public ActionResult LayoutUI()
        {
            return View();
        }
    }
}
