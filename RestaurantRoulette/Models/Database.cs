using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using RestaurantRoulette;

namespace RestaurantRoulette.Models
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
