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
      // User.ClearAll();
    }

    public RestuarantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Dice_Tests;";
    }
  }
}
