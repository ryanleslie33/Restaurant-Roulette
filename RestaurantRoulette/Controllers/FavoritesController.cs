using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantRoulette.Models;
using System.Collections.Generic;

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

      Console.WriteLine(selectedRestListCount);

      int result;
      Random rnd = new Random();
      result = rnd.Next(1, selectedRestListCount);

      Console.WriteLine(result);

      model.Add("user", foundUser);
      model.Add("regRollRest", allRestaurantList[result]);
      return View("Show", model);

    }

    [HttpGet("/users/{id}/fav")]
    public ActionResult favRoll(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      User foundUser = RestaurantRoulette.Models.User.Find(id);
      List<Favorite> allFavoriteList = new List<Favorite>{ };
      allFavoriteList = foundUser.GetUserFavorite();
      int favoriteRestListCount = allFavoriteList.Count;
      int result;
      Random rnd = new Random();
      result = rnd.Next(1, favoriteRestListCount);
      Console.WriteLine(result);
      Console.WriteLine(favoriteRestListCount);
      model.Add("user", foundUser);
      model.Add("favRollRest", allFavoriteList[result]);
      return View("FavResult", model);
    }

    [HttpGet("/users/{id}/favorites/result")]
    public ActionResult Show()
    {
      return View();
    }

    [HttpGet("/users/{id}/favorites/fav-result")]
    public ActionResult FavResult()
    {
      return View();
    }

  }
}
