using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace RestaurantRoulette.Models
{
  public class User
  {

    private string _name;
    private string _password;
    private int _distance;
    private int _price;
    private string _bio;
    private int _id;
    private List<Favorite> _favorites;


    public User(string name, string password, int distance = 0, int price = 0, string bio = "", int id = 0)
    {
      _name = name;
      _password = password;
      _distance = distance;
      _price = price;
      _bio = bio;
      _id = id;
      _favorites = new List<Favorite>{};
    }

    public string GetName()
    {
      return _name;
    }

    public string GetPassword()
    {
      return _password;
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
        User newUser = (User) otherUser;
        bool idEquality = this.GetUserId().Equals(newUser.GetUserId());
        bool nameEquality = this.GetName().Equals(newUser.GetName());
        bool passwordEquality = this.GetPassword().Equals(newUser.GetPassword());
        bool distanceEquality = this.GetDistance().Equals(newUser.GetDistance());
        bool priceEquality = this.GetPrice().Equals(newUser.GetPrice());
        bool bioEquality = this.GetBio().Equals(newUser.GetBio());
        return (idEquality && nameEquality && passwordEquality && distanceEquality && priceEquality && bioEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
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
    //Method will save new user into database using name prperty for now(after login logic we need to add password as well).
    //Current thinking is to just create and save a user with only name property. Then have user change their details on the edit page.
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users (name, password) VALUES (@newName, @newPass);";
      MySqlParameter addName = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newName", this._name);
      MySqlParameter addPass = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newPass", this._password);
      cmd.ExecuteNonQuery();

      _id = (int) cmd.LastInsertedId;
      Console.WriteLine(_id);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    //GetsAllTheUsers To make Save Tests work
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
        string userPassword = rdr.GetString(2);
        int userDistance = rdr.GetInt32(3);
        int userPrice = rdr.GetInt32(4);
        string userBio = rdr.GetString(5);
        User newUser = new User(userName, userPassword, userDistance, userPrice, userBio, userId);
        allUsers.Add(newUser);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allUsers;
    }


    //check if Edit requires a name edit or not; It should ideally edit only price, distance and the bio. We can skip name property edit in this project to keep things simpler.
    public void Edit(int newDistance, int newPrice, string newBio)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE users SET distance = @newDistance, price = @newPrice, bio = @newBio WHERE id = @searchId;";
      MySqlParameter SearchId = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchId", this._id);
      MySqlParameter editDistance = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newDistance", newDistance);
      MySqlParameter editPrice = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newPrice", newPrice);
      MySqlParameter editBio = new MySqlParameter();
      cmd.Parameters.AddWithValue("@newBio", newBio);

      cmd.ExecuteNonQuery();
      _distance = newDistance;
      _price = newPrice;
      _bio = newBio;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    //Find method is need to complete Edit. After Editing the user info, find will retrieve it from the database
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
      string userPassword = "";
      int userPrice = 0;
      int userDistance = 0;
      string userBio = "";

      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userPassword = rdr.GetString(2);
        userDistance = rdr.GetInt32(3);
        userPrice = rdr.GetInt32(4);
        userBio = rdr.GetString(5);
      }

      User foundUser = new User(userName, userPassword, userDistance, userPrice, userBio, userId);

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return foundUser;
    }

    public static User FindWithUserNameAndPassword(string loginName, string loginPassword)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM users WHERE name = (@searchName) AND password = (@searchPass);";
      MySqlParameter searchWithName = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchName", loginName);
      MySqlParameter searchWithPass = new MySqlParameter();
      cmd.Parameters.AddWithValue("@searchPass", loginPassword);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      int userId = 0;
      string userName = "";
      string userPassword = "";
      int userPrice = 0;
      int userDistance = 0;
      string userBio = "";

      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userPassword = rdr.GetString(2);
        userDistance = rdr.GetInt32(3);
        userPrice = rdr.GetInt32(4);
        userBio = rdr.GetString(5);
      }

      User foundUser = new User(userName, userPassword, userDistance, userPrice, userBio, userId);

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return foundUser;
    }

    public List<Favorite> GetUserFavorite()
    {
      List<Favorite> allFavorites = new List<Favorite> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT favorites.* FROM users JOIN users_favorites ON (users.id = users_favorites.user_id) JOIN favorites ON (users_favorites.restaurant_id = favorites.id) WHERE users.id = @UserId;";
      MySqlParameter userIdParameter = new MySqlParameter();
      cmd.Parameters.AddWithValue("@UserId", this._id);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int favoriteId = rdr.GetInt32(0);
        string favoriteName = rdr.GetString(1);
        string favoriteAddress = rdr.GetString(2);
        double favoriteLatitude = rdr.GetDouble(3);
        double favoriteLongitude = rdr.GetDouble(4);
        int favoriteCost = rdr.GetInt32(5);
        string favoriteCusine = rdr.GetString(6);
        string favoriteMenuUrl = rdr.GetString(7);
        string favoritePageUrl = rdr.GetString(8);

        Favorite newFavorite = new Favorite( favoriteName, favoriteAddress,  favoriteMenuUrl, favoritePageUrl, favoriteLatitude, favoriteLongitude, favoriteCost, favoriteCusine, favoriteId);
        allFavorites.Add(newFavorite);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allFavorites;

      //logic to roll dice to get a random restaurant from selected restaurants based on distance and price
      // int selectedRestListIndex = allFavorites.Count;
      // int result;
      // Random rnd = new Random();
      // result = rnd.Next(0, selectedRestListIndex);
      // return allFavorites(result);
    }

    public void AddFavoriteToUser(Favorite newFavorite)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users_favorites (user_id, restaurant_id) VALUES (@UserId, @FavoriteId);";
      MySqlParameter user_id = new MySqlParameter();
      cmd.Parameters.AddWithValue("@UserId", _id);
      MySqlParameter favorite_id = new MySqlParameter();
      cmd.Parameters.AddWithValue("@FavoriteId", newFavorite.GetId());
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE id = @userId; DELETE FROM users_favorites WHERE user_id = @UserId;", conn);

      MySqlParameter categoryIdParameter = new MySqlParameter();
      cmd.Parameters.AddWithValue("@UserId", this.GetUserId());
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Favorite> AllRestaurantSortList()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      //user location set to Epicodus for demo purposes - (long -122.677, lat 45.521)

      cmd.CommandText = @"SELECT * FROM restaurant_data WHERE (ST_DISTANCE_SPHERE(POINT(restaurant_location_longitude, restaurant_location_latitude), POINT(-122.677, 45.521)) * .000621371) < @selectDistance AND restaurant_average_cost_for_two <= @selectCost;";

      MySqlParameter userSelectDist = new MySqlParameter();
      cmd.Parameters.AddWithValue("@selectDistance", this._distance);
      MySqlParameter userSelectCost = new MySqlParameter();
      cmd.Parameters.AddWithValue("@selectCost", this._price);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Favorite> RestFromAllRestWithinUserRange = new List<Favorite> { };
      string restaurantName = "";
      string restaurantAddress = "";
      string menuUrl = "";
      string pageUrl = "";
      double regLat = 0;
      double regLong = 0;
      int cost = 0;
      string cuisine = "";

      while (rdr.Read())
      {
        restaurantName = rdr.GetString(1);
        restaurantAddress = rdr.GetString(2);
        regLat = rdr.GetDouble(3);
        regLong = rdr.GetDouble(4);
        cost = rdr.GetInt32(5);
        pageUrl = rdr.GetString(6);
        menuUrl = rdr.GetString(7);
        cuisine = rdr.GetString(10);

        Favorite selectedRestaurant = new Favorite(restaurantName, restaurantAddress, menuUrl, pageUrl, regLat, regLong, cost, cuisine);
        RestFromAllRestWithinUserRange.Add(selectedRestaurant);
      }

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }

      //logic to roll dice to get a random restaurant from selected restaurants based on distance and price
      // int selectedRestListIndex = RestFromAllRestWithinUserRange.Count;
      // int result;
      // Random rnd = new Random();
      // result = rnd.Next(0, selectedRestListIndex);
      // return RestFromAllRestWithinUserRange(result);

      return RestFromAllRestWithinUserRange;
      }

  }
}
