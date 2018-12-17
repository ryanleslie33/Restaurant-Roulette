using Microsoft.AspNetCore.Mvc;

namespace RestaurantRoulette.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
