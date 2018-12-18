using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantRoulette.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantRoulette.Tests
{
  [TestClass]
  public class UserTest : IDisposable
  {

    public UserTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=RestaurantRoulette_Tests;";
    }

    public void Dispose()
    {
      User.ClearAll();
      Favorite.ClearAll();
    }


    [TestMethod]
    public void UserConstructor_CreatesInstanceOfUser_User()
    {
      User newUser = new User("test-user", "password", 1, 1, "hello");

      Assert.AreEqual(typeof(User), newUser.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "test-user";
      User newUser = new User(name, "password", 1, 1, "hello");

      //Act
      string result = newUser.GetName();

      //Assert
      Assert.AreEqual(result, name);
    }

    [TestMethod]
    public void GetPassword_ReturnsPassword_String()
    {
      //Arrange
      string password = "password";
      User newUser = new User("test-user", password, 1, 1, "hello");

      //Act
      string result = newUser.GetPassword();

      //Assert
      Assert.AreEqual(result, password);
    }

    [TestMethod]
    public void GetDistance_ReturnsDistance_Integer()
    {
      //Arrange
      int distance = 1;
      User newUser = new User("test-user", "password", distance, 1, "hello");

      //Act
      int result = newUser.GetDistance();

      //Assert
      Assert.AreEqual(result, distance);
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_Integer()
    {
      //Arrange
      int price = 1;
      User newUser = new User("test-user", "password", 1, price, "hello");

      //Act
      int result = newUser.GetPrice();

      //Assert
      Assert.AreEqual(result, price);
    }

    [TestMethod]
    public void GetBio_ReturnsBio_String()
    {
      //Arrange
      string bio = "hello";
      User newUser = new User("test-user", "password", 1, 1, bio);

      //Act
      string result = newUser.GetBio();

      //Assert
      Assert.AreEqual(result, bio);
    }

    [TestMethod]
    public void GetId_ReturnsUserId_Int()
    {
      //Arrange
      User newUser = new User("test-user", "password", 1, 1, "hello");

      //Act
      int result = newUser.GetId();

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreSame_User()
    {
      //Arrange, Act
      User firstUser = new User("test-user", "password", 1, 1, "hello");
      User secondUser = new User("test-user", "password", 1, 1, "hello");

      //Assert
      Assert.AreEqual(firstUser, secondUser);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToUser_Id()
    {
      //Arrange
      User testUser = new User("test-user", "password", 1, 1, "hello");
      Console.WriteLine("Save Test");
      testUser.Save();
      int testId = testUser.GetId();

      //Act
      User savedUser = User.GetAll()[0];

      int resultId = savedUser.GetId();
      string resultName = savedUser.GetName();
      string resultPass = savedUser.GetPassword();


      //Assert
      Assert.AreEqual("test-user", resultName);
      Assert.AreEqual("password", resultPass);
      Assert.AreEqual(testId, resultId);
    }

    [TestMethod]
    public void Edit_UpdatesUserInDatabase_User()
    {
      //Arrange
      User testUser = new User("test-user", "password", 1, 1, "hello");
      testUser.Save();
      int updateDistance = 2;
      int updatePrice = 2;
      string updateBio = "hi";

      //Act
      testUser.Edit(updateDistance, updatePrice, updateBio);
      int resultDistance = User.Find(testUser.GetId()).GetDistance();
      int resultPrice = User.Find(testUser.GetId()).GetPrice();
      string resultBio = User.Find(testUser.GetId()).GetBio();

      //Assert
      Assert.AreEqual(resultDistance, updateDistance);
      Assert.AreEqual(resultPrice, updatePrice);
      Assert.AreEqual(resultBio, updateBio);
    }

    [TestMethod]
    public void Find_ReturnsUserInDatabase_User()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(1, 1, "hello");

      //Act
      User foundUser = User.Find(testUser.GetId());

      //Assert
      Assert.AreEqual(testUser, foundUser);
    }

    [TestMethod]
    public void FindWithUserNameAndPassword_ReturnsUserInDatabaseAfterLogin_User()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(1, 1, "hello");

      //Act
      User foundUser = User.FindWithUserNameAndPassword(testUser.GetName(), testUser.GetPassword());

      //Assert
      Console.WriteLine("------find by name and password ----");
      Console.WriteLine("name: " + foundUser.GetName() + " id: " + foundUser.GetId() + " pass: " + foundUser.GetPassword());
      Assert.AreEqual(testUser, foundUser);
    }

    [TestMethod]
    public void GetUserFavorite_ReturnsAllUserFavorites_FavoriteList()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(1, 1, "hello");
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();
      Favorite testFavorite2 = new Favorite("Mother's Bistro & Bar", "212 SW Stark St, Portland 97204", "https://www.zomato.com/portland/mothers-bistro-bar-portland/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/mothers-bistro-bar-portland/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.52, -122.674, 75, "American, Breakfast");
      testFavorite2.Save();

      //Act
      testUser.AddFavoriteToUser(testFavorite);
      testUser.AddFavoriteToUser(testFavorite2);
      List<Favorite> savedFavorites = testUser.GetUserFavorite();
      List<Favorite> testList = new List<Favorite> {testFavorite, testFavorite2};

      //Assert
      CollectionAssert.AreEqual(testList, savedFavorites);
    }

    [TestMethod]
    public void AddFavoriteToUser_AddsFavoriteToUser_FavoriteList()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(1, 1, "hello");
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();
      Favorite testFavorite2 = new Favorite("Mother's Bistro & Bar", "212 SW Stark St, Portland 97204", "https://www.zomato.com/portland/mothers-bistro-bar-portland/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/mothers-bistro-bar-portland/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.52, -122.674, 75, "American, Breakfast");
      testFavorite2.Save();

      //Act
      testUser.AddFavoriteToUser(testFavorite);
      testUser.AddFavoriteToUser(testFavorite2);
      List<Favorite> result = testUser.GetUserFavorite();
      List<Favorite> testList = new List<Favorite>{testFavorite, testFavorite2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


    [TestMethod]
    public void Delete_DeletesUserAssociationsFromDatabase_UserList()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(1, 1, "hello");
      Favorite testFavorite = new Favorite("Pok Pok", "3226 SE Division Street 97202", "https://www.zomato.com/portland/pok-pok-richmond/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pok-pok-richmond/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5046, -122.632, 35, "Thai");
      testFavorite.Save();

      //Act
      testUser.AddFavoriteToUser(testFavorite);
      testUser.Delete();
      List<User> resultFavoriteUsers = testFavorite.GetUser();
      List<User> testFavoriteUsers = new List<User> {};

      //Assert
      CollectionAssert.AreEqual(testFavoriteUsers, resultFavoriteUsers);
    }

    [TestMethod]
    public void AllRestaurantSortList_ReturnsAllRestaurantsInUserCriteria_FavoriteList()
    {
      //Arrange
      User testUser = new User("test-user", "password");
      testUser.Save();
      testUser.Edit(2, 25, "hello");
      Favorite testFavorite = new Favorite("Voodoo Doughnut", "22 SW 3rd Avenue, Portland 97204", "https://www.zomato.com/portland/voodoo-doughnut-chinatown-old-town/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/voodoo-doughnut-chinatown-old-town/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5227, -122.673, 20, "Cuban");

      Favorite testFavorite2 = new Favorite("Pambiche", "2811 NE Glisan Street 97232", "https://www.zomato.com/portland/pambiche-kerns/menu?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1&openSwipeBox=menu&showMinimal=1#tabtop", "https://www.zomato.com/portland/pambiche-kerns/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1", 45.5266, -122.637, 25, "Cuban");


      //Act

      List<Favorite> result = testUser.AllRestaurantSortList();
      List<Favorite> testList = new List<Favorite>{testFavorite, testFavorite2};

      Console.WriteLine("---------Sort List---------------");
      Console.WriteLine(result.Count);
      Console.WriteLine(testList.Count);
      //Assert
      Console.WriteLine(testList.GetType());
      Console.WriteLine(result.GetType());
      string resultName = "";
      string testName = "";
      foreach(var favorite in result)
      {

        resultName = favorite.GetName();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine((favorite.GetAddress()));
      }
      Console.WriteLine("---------------------------");
      foreach(var favorite in testList)
      {
        testName = favorite.GetName();
        Console.WriteLine(favorite.GetName());
        Console.WriteLine(favorite.GetAddress());

      }
      Assert.AreEqual(resultName, testName);
      // CollectionAssert.AreEqual(testList, result);
    }
  }
}
