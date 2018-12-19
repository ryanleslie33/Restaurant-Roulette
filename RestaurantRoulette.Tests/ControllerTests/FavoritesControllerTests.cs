using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantRoulette.Controllers;
using RestaurantRoulette.Models;
using System;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class FavoriteControllerTest : IDisposable
  {
    public void Dispose()
    {
      Favorite.ClearAll();
      User.ClearAll();
    }

    public FavoriteControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=RestaurantRoulette_Tests;";
    }

    // [TestMethod]
    // public void Index_ReturnsCorrectView_True()
    // {
    //   //Arrange
    //   FavoriteController controller = new FavoriteController();
    //
    //   //Act
    //   ActionResult indexView = controller.Index();
    //
    //   //Assert
    //   Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    // }


    // [TestMethod]
    // public void Regular_ReturnsCorrectView_True()
    // {
    //   FavoriteController Controller = new FavoriteController();
    //   User testUser = new User("test-user", "password");
    //   testUser.Save();
    //   Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
    //   //List<Favorite> allRestaurantList = {newFavorite};
    //
    //   //Act
    //   ActionResult regularView = Controller.Regular(testUser.GetId());
    //
    //   //Assert
    //   Assert.IsInstanceOfType(regularView, typeof(ViewResult));
    // }
    //
    // [TestMethod]
    // public void Show_HasCorrectModelType_StylistList()
    // {
    //   //Arrange
    //   UserController controller = new UserController();
    //   User testUser = new User("test-user", "password");
    //   testUser.Save();
    //   ViewResult showView = new UserController().Show(testUser.GetName(), testUser.GetPassword()) as ViewResult;
    //
    //   //Act
    //   var result = showView.ViewData.Model;
    //
    //   //Assert
    //   Console.WriteLine("Controller Test");
    //   User foundUser = RestaurantRoulette.Models.User.FindWithUserNameAndPassword(testUser.GetName(), testUser.GetPassword());
    //   Console.WriteLine(foundUser.GetName());
    //   Console.WriteLine(foundUser.GetPassword());
    //
    //   Assert.IsInstanceOfType(result, typeof(User));
    // }
  }
}
