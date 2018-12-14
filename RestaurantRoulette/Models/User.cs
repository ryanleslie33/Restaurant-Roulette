using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Dice.Models
{
  public class User
  {

    private string _name;
    private int _id;
    private int _distance;
    private int _price;
    private List<Restaurant> _favorites;

    public User(string name, int distance, int price, int id = 0)
    {
      _name = name;
      _id = id;
      _distance = distance;
      _price = price;
      _favorites = new List<Restaurant>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetPrice()
    {
      return _price;
    }

    public int GetDistance()
    {
      return _distance;
    }

    public override bool Equals(System.Object otherUser)
    {
      if (!(otherUser is User))
      {
        return false;
      }
      else
      {
        User newUser = (User)otherUser;
        bool idEquality = this.GetId().Equals(newUser.GetId());
        bool nameEquality = this.GetName().Equals(newUser.GetName());
        bool distanceEquality = this.GetDistance().Equals(newUser.GetDistance());
        bool priceEquality = this.GetPrice().Equals(newUser.GetPrice());
        return (idEquality && nameEquality && distanceEquality && priceEquality);
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM User; DELETE FROM User_Restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO User (name, distance, price) VALUES (@name, @distance, @price);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      MySqlParameter distance = new MySqlParameter();
      distance.ParameterName = "@distance";
      distance.Value = this._distance;
      cmd.Parameters.Add(distance);
      MySqlParameter price = new MySqlParameter();
      price.ParameterName = "@price";
      price.Value = this._price;
      cmd.Parameters.Add(price);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<User> GetAll()
    {
      List<User> allUsers = new List<User> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM User;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int UserId = rdr.GetInt32(0);
        string UserName = rdr.GetString(1);
        int UserDistance = rdr.GetInt32(2);
        int UserPrice = rdr.GetInt32(3);
        User newUser = new User(UserName, UserDistance, UserPrice, UserId);
        allUsers.Add(newUser);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allUsers;
    }

    public void Edit(string newName, int newDistance, int newPrice)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE User SET name = @newName WHERE id = @searchId; UPDATE User SET distance = @newDistance WHERE id = @searchId; UPDATE User SET price = @newPrice WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      MySqlParameter distance = new MySqlParameter();
      distance.ParameterName = "@newDistance";
      distance.Value = newDistance;
      cmd.Parameters.Add(distance);
      MySqlParameter price = new MySqlParameter();
      price.ParameterName = "@newPrice";
      price.Value = newPrice;
      cmd.Parameters.Add(price);
      cmd.ExecuteNonQuery();
      _name = newName;
      _distance = newDistance;
      _price = newPrice;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static User Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM User WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int userId = 0;
      string userName = "";
      int userPrice = 0;
      int userDistance = 0;

      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userDistance = rdr.GetInt32(2);
        userPrice = rdr.GetInt32(3);
      }

      User newUser = new User(userName, userDistance, userPrice, userId);

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return newUser;
    }

  }
}
