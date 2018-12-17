using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantRoulette.Controllers;
using RestaurantRoulette.Models;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class UserControllerTest
  {
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

  }
}
