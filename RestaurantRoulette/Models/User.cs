using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace RestaurantRoulette.Models
{
  public class User
  {

    private string _name;
    private int _id;
    private int _distance;
    private int _price;
    private string _password;
<<<<<<< HEAD
    //private byte[];
    private string _bio;
    private float _lat;
    private float _long;
    //private List<Restaurant> _favorites;
=======
    // private Byte[];
    private string _bio;
    // private float _lat;
    // private float _long;
    private List<Restaurant> _favorites;
>>>>>>> master

    public User(string name, int distance, int price, int id = 0)
    {
      _name = name;
      _id = id;
      _distance = distance;
      _price = price;
      _password = password;
      //_favorites = new List<Restaurant>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetDistance()
    {
      return _distance;
    }

    public int GetPrice()
    {
      return _price;
    }

    public int GetBio()
    {
      return _bio;
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
      cmd.CommandText = @"DELETE FROM users; DELETE FROM users_favorites; DELETE FROM favorites";
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
      cmd.CommandText = @"INSERT INTO users (name, distance, price) VALUES (@name, @distance, @price);";
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
      cmd.CommandText = @"SELECT * FROM users;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        int userDistance = rdr.GetInt32(2);
        int userPrice = rdr.GetInt32(3);
        string userBio = rdr.GetString(4);
        // Byte[] userImageByteArray = rdr.Read(5)(Byte[]) rdr[0];
        User newUser = new User(userName, userDistance, userPrice, userImage, userBio, userId);
        allUsers.Add(newUser);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allUsers;
    }

    public void Edit(string newName, int newDistance, int newPrice, string newBio)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE users SET name = @newName, distance = @newDistance, price = @newPrice, bio = @newBio WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchId", this._id);
      MySqlParameter name = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newName", newName);
      MySqlParameter distance = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newDistance", newDistance);
      MySqlParameter price = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newPrice", newPrice);
      MySqlParameter bio = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newBio", newBio);

      cmd.ExecuteNonQuery();
      _name = newName;
      _distance = newDistance;
      _price = newPrice;
      _bio = newBio;

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
