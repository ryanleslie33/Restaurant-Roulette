using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantRoulette.Models;

namespace RestaurantRoulette.Controllers
{
  public class UserController : Controller
  {
    //Offers Login Form for existing User
    [HttpGet("/user/login")]
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

    //Posts Login Details from existing User and returns that user's details from DB
    [HttpPost("/users")]
    public ActionResult Login(string userName, string userPass)
    {
      User foundUser = User.FindWithUserNameAndPassword(userName, userPass);
      return View("Show", foundUser);
    }

    //Posts Registration Details for new User
    [HttpPost("/users/login")]
    public ActionResult Create(string userName, string userPass)
    {
      User newUser = new User(userName, userPass);
      newUser.Save();
      return View("Show", newUser);
    }

  }
}
