using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantRoulette.Controllers;
using RestaurantRoulette.Models;
using System;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class UserControllerTest : IDisposable
  {
    public void Dispose()
    {
      User.ClearAll();
    }

    public UserControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=RestaurantRoulette_Tests;";
    }

    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      //Arrange
      UserController controller = new UserController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }


    [TestMethod]
    public void Show_ReturnsCorrectView_True()
    {
      UserController controller = new UserController();
      User testUser = new User("test-user", "password");
      testUser.Save();

      //Act
      ActionResult show = controller.Show(testUser.GetName(), testUser.GetPassword());

      //Assert
      Assert.IsInstanceOfType(show, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_StylistList()
    {
      //Arrange
      UserController controller = new UserController();
      User testUser = new User("test-user", "password");
      testUser.Save();
      ViewResult showView = new UserController().Show(testUser.GetName(), testUser.GetPassword()) as ViewResult;

      //Act
      var result = showView.ViewData.Model;

      //Assert
      Console.WriteLine("Controller Test");
      User foundUser = RestaurantRoulette.Models.User.FindWithUserNameAndPassword(testUser.GetName(), testUser.GetPassword());
      Console.WriteLine(foundUser.GetName());
      Console.WriteLine(foundUser.GetPassword());

      Assert.IsInstanceOfType(result, typeof(User));
    }
  }
}
