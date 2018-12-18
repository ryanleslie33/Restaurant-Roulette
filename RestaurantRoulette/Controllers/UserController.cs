using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantRoulette.Models;


namespace RestaurantRoulette.Controllers
{
  public class UserController : Controller
  {
    //Offers Login Form for existing User
    [HttpGet("/users/login")]
    public ActionResult Index()
    {
      return View();
    }

    //Offers Register for New User
    [HttpGet("/users/new")]
    public ActionResult New()
    {
      return View();
    }

    //Posts Registration Details for new User
    [HttpPost("/users")]
    public ActionResult Create(string userName, string userPassword)
    {
      User newUser = new User(userName, userPassword);
      newUser.Save();
      RestaurantRoulette.Models.User newFoundUser = RestaurantRoulette.Models.User.Find(newUser.GetId());
      return View("Show", newFoundUser);
    }

    [HttpGet("/users/{userName}/{userPassword}")]
    public ActionResult Show(string userName, string userPassword)
    {
      RestaurantRoulette.Models.User foundUser = RestaurantRoulette.Models.User.FindWithUserNameAndPassword(userName, userPassword);
      return View(foundUser);
    }


    // [HttpPost("/user/edit")]
    // public ActionResult Edit(int price, int distance)
    // {
    //   User newUser = new User(price,distance);
    //   newUser.Edit();
    //   newUser.Save();
    //   RedirectToAction("Show", newUser);
    // }
  }
}
