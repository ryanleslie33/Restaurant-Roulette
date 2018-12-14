using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Dice.Models;

namespace Restaurant.Controllers
{
  public class RestaurantController : Controller
  {
    [httpGet("/favorite")]
    public ActionResult Index()
    {
      List<Restaurant> favorites = User.GetFavorites();

      return View(favorites);
    }
  }
}
