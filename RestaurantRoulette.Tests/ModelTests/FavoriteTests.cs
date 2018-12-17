using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantRoulette.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class FavoriteTest : IDisposable

  {
    public FavoriteTest()
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

    [TestMethod]
    public void Delete_DeletesfavoriteAssociationsFromDatabase_ItemList()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(2, 25, "hello");
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();

      //Act
      testFavorite.AddUser(testUser);
      testFavorite.Delete();
      List<Favorite> resultUserFavorites = testUser.GetUserFavorite();
      List<Favorite> testUserFavorites = new List<Favorite>{};

      //Assert
      CollectionAssert.AreEqual(testUserFavorites, resultUserFavorites);
    }

    [TestMethod]
    public void AddUser_AddsUserToFavorite_User()
    {
      //Arrange
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(2, 25, "hello");

      //Act
      testFavorite.AddUser(testUser);
      List<User> result = testFavorite.GetUser();
      List<User> testList = new List<User>{testUser};

      //Assert
      int resultId = 0;
      int testListId = 0;
      Console.WriteLine("---------------Add User--------");
      foreach(var test in testList)
      {
        testListId = test.GetUserId();
        Console.WriteLine(test.GetUserId());
        Console.WriteLine(test.GetName());
        Console.WriteLine((test.GetPassword()));
      }
      Console.WriteLine("---------------------------");
      foreach(var resultUser in result)
      {
        resultId = resultUser.GetUserId();
        Console.WriteLine(resultUser.GetUserId());
        Console.WriteLine(resultUser.GetName());
        Console.WriteLine((resultUser.GetPassword()));
      }
      Assert.AreEqual(testListId, resultId);
    }

    [TestMethod]
    public void GetUsers_ReturnsAllFavoritesUsers_UsersList()
    {
      //Arrange
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();
      User firstUser = new User("test-user", "password");
      firstUser.Save();
      firstUser.Edit(2, 25, "hello");
      User secondUser = new User("test-user1", "password1");
      secondUser.Save();
      secondUser.Edit(1, 25, "hi");

      //Act
      testFavorite.AddUser(firstUser);
      List<User> result = testFavorite.GetUser();
      List<User> testList = new List<User>{firstUser};
      //Assert

      int resultId = 0;
      int testListId = 0;
      Console.WriteLine("---------------Add User--------");
      foreach(var test in testList)
      {
        testListId = test.GetUserId();
        Console.WriteLine(test.GetUserId());
        Console.WriteLine(test.GetName());
        Console.WriteLine((test.GetPassword()));
      }
      Console.WriteLine("---------------------------");
      foreach(var resultUser in result)
      {
        resultId = resultUser.GetUserId();
        Console.WriteLine(resultUser.GetUserId());
        Console.WriteLine(resultUser.GetName());
        Console.WriteLine((resultUser.GetPassword()));
      }
      Assert.AreEqual(testListId, resultId);
      //CollectionAssert.AreEqual(testList, result); --- Ask Lina Why CollectionAssert is not working for List<User> and List<Favorite>
    }
  }
}
