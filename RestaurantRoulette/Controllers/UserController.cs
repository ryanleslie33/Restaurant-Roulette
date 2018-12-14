using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Dice.Models;

namespace User.Controllers
{
  public class UserController : Controller
  {

    [HttpGet("/user/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/user")]
    public ActionResult Index()
    {
      List<User> allUsers = User.GetAll()

      return View(allUsers);
    }

    [HttpPost("/user")]
    public ActionResult Create(string name, string password) 
    {
      User newUser = new User(name, password);

      newUser.Save(); 

      User newUserId = newUser.GetId();

      return RedirectToAction ("Show", newUserId);
    }

    [HttpGet("/user/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();

      User selectedUser = User.GetAll(id);

      model.Add(selectedUser);

      return View(model);
    }

    [HttpGet("/user/{id}/edit")]
    public ActionResult Edit(int id)
    {
      User user = User.Find(id);

      return View(user);
    }

    

  }
}
