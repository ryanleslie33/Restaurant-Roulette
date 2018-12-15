using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dice.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Dice.Tests
{
  [TestClass]
  public class RestuarantTest : IDisposable
  {

    public void Dispose()
    {
      Favorite.ClearAll();
    }

    public RestuarantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=RestaurantRoulette_Tests;";
    }

// public Favorite(string favName, string favAddress, string favMenuUrl, string favPageUrl, int favId = 0, float favLatitude = 0, float favLongitude = 0, int favCost = 0, string favCusine = "")

    public void GetFavRollResult_selectsARestaurantFromFavorites_Favorite
    {
      //Arrange
      Favorite newFavorite1 = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 1, 45.5046, -122.632, 35, "Thai");

      // Favorite newFavorite2 = new Favorite("Gravy", "3957 N Mississippi Avenue, Portland 97227", "https://www.zomato.com/portland/gravy-boise-eliot/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/gravy-boise-eliot/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 2, 45.5517, -122.676, 35, "American");

      newFavorite1.Save();
      newFavorite2.Save();
      //Act
      List<Favorite> result =newFavorite1.GetFavRollResult();
      List<Favorite> expectedResult = new List<Favorite> {newFavorite1};

      //Assert
      CollectionAssert.AreEqual(expectedResult, result);

    }
  }
}
