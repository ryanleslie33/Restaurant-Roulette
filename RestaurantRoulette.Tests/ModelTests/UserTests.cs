using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dice.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Dice.Tests
{
  [TestClass]
  public class UserTest : IDisposable
  {
    public void Dispose()
    {
      User.ClearAll();
    }

    public UserTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Dice_Tests;";
    }

    [TestMethod]
    public void UserConstructor_CreatesInstanceOfUser_User()
    {
      User newUser = new User("Tavish", 1, 1);

      Assert.AreEqual(typeof(User), newUser.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string name = "Bob.";
      User newUser = new User(name, 1 , 1);

      //Act
      string result = newUser.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_UsersEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = User.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      //Arrange
      string name01 = "Tavish";
      string name02 = "Ryan";
      User newUser1 = new User(name01, 1, 1);
      newUser1.Save();
      User newUser2 = new User(name02, 1, 1);
      newUser2.Save();
      List<User> newList = new List<User> { newUser1, newUser2 };

      //Act
      List<User> result = User.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToUser_Id()
    {
      //Arrange
      User testUser = new User("Bob", 1, 1);
      testUser.Save();
      User testUser1 = new User("Bernard", 1, 2);
      testUser1.Save();

      //Act
      User savedUser = User.GetAll()[1];

      int result = savedUser.GetId();
      int testId = testUser1.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_User()
    {
      //Arrange, Act
      User firstUser = new User("Bob", 1, 1);
      User secondUser = new User("Bob", 1, 1);

      //Assert
      Assert.AreEqual(firstUser, secondUser);
    }

    [TestMethod]
    public void Find_ReturnsCorrectUserFromDatabase_User()
    {
      //Arrange
      User testUser = new User("Bob", 0, 0);
      testUser.Save();

      //Act
      User foundUser = User.Find(testUser.GetId());

      //Assert
      Assert.AreEqual(testUser, foundUser);
    }

    [TestMethod]
    public void Edit_UpdatesUserInDatabase_String()
    {
      //Arrange
      User testUser = new User("Bob", 1, 1);
      testUser.Save();
      string secondDescription = "Bob";

      //Act
      testUser.Edit(secondDescription, 3, 2);
      string result = User.Find(testUser.GetId()).GetName();

      //Assert
      Assert.AreEqual(secondDescription, result);
    }


  }
}
