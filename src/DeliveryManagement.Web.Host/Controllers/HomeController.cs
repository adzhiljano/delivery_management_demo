using Microsoft.AspNetCore.Mvc;

namespace DeliveryManagement.Web.Host.Controllers
{
    public class HomeController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
        return View("~/wwwroot/index.html");
    }
  }
}
