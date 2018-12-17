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
    [HttpGet("/user/new")]
    public ActionResult New()
    {
      return View();
    }

    // Posts Login Details from existing User and returns that user's details from DB
    // [HttpPost("/user/login")]
    // public ActionResult Login(string userName, string userPass)
    // {
    //   User foundUser = User.FindWithUserNameAndPassword(userName, userPass);
    //   RedirectToAction("Show", foundUser);
    // }

    //Posts Registration Details for new User
    [HttpGet("/user")]
    public ActionResult Create(string userName, string userPassword)
    {
      User newUser = new User(userName, userPassword);
      newUser.Save();
      return View("Show", newUser);
    }

    [HttpGet("/user")]
    public ActionResult Show()
    {
      return View();
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
