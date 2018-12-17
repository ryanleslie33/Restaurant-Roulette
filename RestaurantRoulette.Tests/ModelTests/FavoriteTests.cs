using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantRoulette.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class FavoriteTest : IDisposable //This should be FavoriteTest not RestuarantRouletteTest

  {
    public FavoriteTest()
    //This should be FavoriteTest not RestuarantTest
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=RestaurantRoulette_Tests;";
    }

    public void Dispose()
    {
      Favorite.ClearAll();
    }


    [TestMethod]
    public void FavoriteConstructor_CreatesInstanceOfFavorite_Favorite()
    {
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      Assert.AreEqual(typeof(Favorite), newFavorite.GetType());
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      // Arrange, Act
      Favorite firstFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      Favorite secondFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      // Assert
      Assert.AreEqual(firstFavorite, secondFavorite);
    }

    [TestMethod]
    public void GetId_returnsfavoriteRestaurantId_int()
    {
      //Arrange
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai",1);
      //Act
      int result = newFavorite.GetId();
      Console.WriteLine(result);
      //Assert
      Assert.AreEqual(1,result);
    }

    [TestMethod]
    public void GetName_returnsfavoriteRestaurantName_string()
    {
      //Arrange
      string name = "Pok Pok";
      Favorite newFavorite = new Favorite(name, "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai", 1);
      //Act
      string result = newFavorite.GetName();
      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAddress_returnsfavoriteRestaurantAddress_string()
    {
      //Arrange
      string address = "3226 SE Division Street 97202";
      Favorite newFavorite = new Favorite("Pok Pok", address, "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai",1);
      //Act
      string result = newFavorite.GetAddress();
      //Assert
      Assert.AreEqual(address,result);
    }

    [TestMethod]
    public void GetLatitude_ReturnsFavoriteRestaurantLatitude_double()
    {
      //Arrange
      double latitude = 45.5046;
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", latitude, -122.632, 35, "Thai",1);
      //Act
      double result = newFavorite.GetLatitude();
      //Assert
      Assert.AreEqual(latitude, result);
    }

    [TestMethod]
    public void GetLongitude_returnsfavoriteRestaurantLongitude_double()
    {
      //Arrange
      double longitude = -122.632;
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, longitude, 35, "Thai",1);
      //Act
      double result = newFavorite.GetLongitude();
      //Assert
      Assert.AreEqual(longitude, result);
    }

    [TestMethod]
    public void GetCostForTwo_returnsfavoriteRestaurantCost_int()
    {
      //Arrange
      int cost = 35;
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai",1);
      //Act
      double result = newFavorite.GetCostForTwo();
      //Assert
      Assert.AreEqual(cost, result);
    }

    [TestMethod]
    public void GetFavCusine_returnsfavoriteRestaurantCost_int()
    {
      //Arrange
      string cusine = "Thai";
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai",1);
      //Act
      string result = newFavorite.GetFavCusine();
      //Assert
      Assert.AreEqual(cusine, result);
    }

    [TestMethod]
    public void GetMenuUrl_returnsfavoriteRestaurantCost_int()
    {
      //Arrange
      string MenuUrl = "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop";
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", MenuUrl, "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai",1);
      //Act
      string result = newFavorite.GetMenuUrl();
      //Assert
      Assert.AreEqual(MenuUrl, result);
    }

    [TestMethod]
    public void GetPageUrl_returnsfavoriteRestaurantCost_int()
    {
      //Arrange
      string pageUrl = "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop";
      Favorite newFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop",
      pageUrl, 45.5046, -122.632, 35, "Thai",1);
      //Act
      string result = newFavorite.GetPageUrl();
      //Assert
      Assert.AreEqual(pageUrl, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_FavoriteList()
    {
      //Arrange
      List<Favorite> newList = new List<Favorite> { };
      //Act
      List<Favorite> result = Favorite.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsFavorites_FavoriteList()
    {
      //Arrange
      Favorite newFavorite1 = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5046, -122.632, 35, "Thai");

      //Act
      List<Favorite> testList = new List<Favorite> {newFavorite1};
      List<Favorite> result = Favorite.GetAll();
      int resultId = 0;
      int testListId = 0;
      Console.WriteLine(testList.GetType());
      Console.WriteLine(result.GetType());
      foreach(var favorite in result)
      {
        resultId = favorite.GetId();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine((favorite.GetAddress()));
      }
      Console.WriteLine("---------------------------");
      foreach(var favorite in testList)
      {
        testListId = favorite.GetId();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine(favorite.GetAddress());

      }
      //Assert
      Assert.AreEqual(resultId, testListId);
  }

    [TestMethod]
    public void Save_SavesToDatabase_FavoriteList()
    {
      //Arrange
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop",
      "https://www.zomato.com/portland/pok-pok-richmond/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5046, -122.632, 35, "Thai",0);
      //Act
      testFavorite.Save();
      List<Favorite> result = Favorite.GetAll();
      List<Favorite> testList = new List<Favorite>{testFavorite};
      //Assert
      int resultId = 0;
      int testListId = 0;
      foreach(var favorite in result)
      {
        resultId = favorite.GetId();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine((favorite.GetAddress()));
      }
      Console.WriteLine("---------------------------");
      foreach(var favorite in testList)
      {
        testListId = favorite.GetId();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine(favorite.GetAddress());
      }
      Assert.AreEqual(resultId, testListId);
    }

    // [TestMethod]
    // public void GetFavRollResult_ReturnsChosenFavorite_Favorite()
    // {
    //   Favorite firstFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
    //   Favorite secondFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
    //
    //   firstFavorite.Save();
    //   int firstId = firstFavorite.GetId();
    //   secondFavorite.Save();
    //   int secondId = secondFavorite.GetId();
    //
    //   Favorite resultFavRes = Favorite.GetFavRollResult();
    //   Console.WriteLine(firstId);
    //   Console.WriteLine(secondId);
    //   Console.WriteLine(resultFavRes.GetId());
    //
    //   // bool firstFav = (firstId == resultFavRes.GetId());
    //   // bool secondFav = (secondId == resultFavRes.GetId());
    //   // return (firstFav || secondFav);
    //   if(firstId == resultFavRes.GetId())
    //   {
    //     Assert.IsTrue(true);
    //   }
    //   else if(secondId == resultFavRes.GetId())
    //   {
    //     Assert.IsTrue(true);
    //   }
    // }
  }
}
