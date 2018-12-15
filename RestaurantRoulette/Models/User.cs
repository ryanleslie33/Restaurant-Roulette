using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace RestaurantRoulette.Models
{
  public class User
  {

    private string _name;
    private int _distance;
    private int _price;
    private string _bio;
    private int _id;
    private List<Favorite> _favorites;
    // private float _lat; //hardcoded for now
    // private float _long;
    // private string _password; // will add when login logic is sorted out


    public User(string name, int distance, int price, string bio, int id = 0)
    {
      _name = name;
      _distance = distance;
      _price = price;
      _bio = bio;
      _id = id;
      _favorites = new List<Favorite>{};
      // _password = password;
    }

    public string GetName()
    {
      return _name;
    }


    public int GetDistance()
    {
      return _distance;
    }

    public int GetPrice()
    {
      return _price;
    }

    public string GetBio()
    {
      return _bio;
    }

    public int GetUserId()
    {
      return _id;
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
        bool idEquality = this.GetUserId().Equals(newUser.GetUserId());
        bool nameEquality = this.GetName().Equals(newUser.GetName());
        bool distanceEquality = this.GetDistance().Equals(newUser.GetDistance());
        bool priceEquality = this.GetPrice().Equals(newUser.GetPrice());
        bool bioEquality = this.GetBio().Equals(newUser.GetBio());
        return (idEquality && nameEquality && distanceEquality && priceEquality && bioEquality);
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
    //Method will save new user into database. However need to verify the new user form view. We have a different view for the user info edit but nothing for a new user.
    //One thought is to just create and save a user with only name property. Then have user change their details on the edit page.
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users (name, distance, price, bio) VALUES (@name, @distance, @price, @bio);";
      MySqlParameter name = new MySqlParameter();
      cmd.Parameters.AddWithValue("@name", this._name);
      MySqlParameter distance = new MySqlParameter();
      cmd.Parameters.AddWithValue("@distance", this._distance);
      MySqlParameter price = new MySqlParameter();
      cmd.Parameters.AddWithValue("@price", this._price);
      MySqlParameter bio = new MySqlParameter();
      cmd.Parameters.AddWithValue("@bio", this._bio);
      cmd.ExecuteNonQuery();

      _id = (int) cmd.LastInsertedId;
      Console.WriteLine(_id);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    //check if Edit requires a name edit or not; It should ideally edit only price, distance and the bio. We can skip name property edit in this project to keep things simpler.
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

    //Find method is need to complete Edit. After Editing the user info, find will retriev it from the database
    public static User Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM users WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchId", id);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      int userId = 0;
      string userName = "";
      int userPrice = 0;
      int userDistance = 0;
      string userBio = "";

      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userDistance = rdr.GetInt32(2);
        userPrice = rdr.GetInt32(3);
        userBio = rdr.GetString(4);
      }

      User foundUser = new User(userName, userDistance, userPrice, userBio, userId);

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return foundUser;
    }
  }
}
//
//     public static List<User> GetAll()
//     {
//       List<User> allUsers = new List<User> {};
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"SELECT * FROM users;";
//       var rdr = cmd.ExecuteReader() as MySqlDataReader;
//       while(rdr.Read())
//       {
//         int userId = rdr.GetInt32(0);
//         string userName = rdr.GetString(1);
//         int userDistance = rdr.GetInt32(2);
//         int userPrice = rdr.GetInt32(3);
//         string userBio = rdr.GetString(4);
//         // Byte[] userImageByteArray = rdr.Read(5)(Byte[]) rdr[0];
//         User newUser = new User(userName, userDistance, userPrice, userImage, userBio, userId);
//         allUsers.Add(newUser);
//       }
//       conn.Close();
//       if (conn != null)
//       {
//         conn.Dispose();
//       }
//       return allUsers;
//     }
//
//
//   }
// }
