using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantRoulette.Models;
using System.Collections.Generic;

namespace RestaurantRoulette.Controllers
{
  public class FavoriteController : Controller
  {
    [HttpGet("/users/{id}/regular")]
    public ActionResult Regular(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      User foundUser = RestaurantRoulette.Models.User.Find(id);
      List<Favorite> allRestaurantList = new List<Favorite>{ };
      allRestaurantList = foundUser.AllRestaurantSortList();
      int selectedRestListCount = allRestaurantList.Count;
      int result;
      Random rnd = new Random();
      result = rnd.Next(1, selectedRestListCount);

      model.Add("user", foundUser);
      model.Add("regRollRest", allRestaurantList[result]);
      return View("Show", model);

    }

    [HttpGet("/users/{id}/fav")]
    public ActionResult favRoll(int id)
    {
      User foundUser = RestaurantRoulette.Models.User.Find(id);
      List<Favorite> allFavoriteList = new List<Favorite>{ };
      allFavoriteList = foundUser.GetUserFavorite();
      int favoriteRestListCount = allFavoriteList.Count;
      int result;
      Random rnd = new Random();
      result = rnd.Next(1, favoriteRestListCount);
      return View("show", allFavoriteList[result]);
    }

    [HttpGet("/users/{id}/favorites/result")]
    public ActionResult Show()
    {
      return View();
    }

  }
}
