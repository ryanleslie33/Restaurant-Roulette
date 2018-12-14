using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Dice;

namespace Dice.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
