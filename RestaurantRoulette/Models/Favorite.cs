using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace RestaurantRoulette.Models
{
  public class Favorite
  {
    private int _favoriteResId;
    private string _favoriteResName;
    private string _favoriteAddress;
    private double _favoriteLat;
    private double _favoriteLong;
    private int _favoriteCost;
    private string _favoriteCusine;
    private string _favoriteMenuUrl;
    private string _favoritePageUrl;

    public Favorite(string favName, string favAddress, string favMenuUrl, string favPageUrl, double favLatitude, double favLongitude, int favCost, string favCusine, int favId = 0)
    {
      _favoriteResId = favId;
      _favoriteResName = favName;
      _favoriteAddress = favAddress;
      _favoriteLat = favLatitude;
      _favoriteLong = favLongitude;
      _favoriteCost = favCost;
      _favoriteCusine = favCusine;
      _favoriteMenuUrl = favMenuUrl;
      _favoritePageUrl = favPageUrl;
    }

    public int GetId()
    {
      return _favoriteResId;
    }

    public string GetName()
    {
      return _favoriteResName;
    }

    public string GetAddress()
    {
      return _favoriteAddress;
    }

    public double GetLatitude()
    {
      return _favoriteLat;
    }

    public double GetLongitude()
    {
      return _favoriteLong;
    }

    public int GetCostForTwo()
    {
      return _favoriteCost;
    }

    public string GetFavCusine()
    {
      return _favoriteCusine;
    }

    public string GetMenuUrl()
    {
      return _favoriteMenuUrl;
    }

    public string GetPageUrl()
    {
      return _favoritePageUrl;
    }

    public override bool Equals(System.Object otherFavorite)
    {
      if (!(otherFavorite is Favorite))
      {
        return false;
      }
      else
      {
        Favorite newFavorite = (Favorite) otherFavorite;
        bool idEquality = (this.GetId() == newFavorite.GetId());
        bool nameEquality = (this.GetName() == newFavorite.GetName());
        bool addressEquality = this.GetAddress() == newFavorite.GetAddress();
        bool latitudeEquality = (this.GetLatitude() == newFavorite.GetLatitude());
        bool longitudeEquality = (this.GetLongitude() == newFavorite.GetLongitude());
        bool costEquality = (this.GetCostForTwo() == newFavorite.GetCostForTwo());
        bool cusineEquality = (this.GetFavCusine() == newFavorite.GetFavCusine());
        bool menuUrlEquality = (this.GetMenuUrl() == newFavorite.GetMenuUrl());
        bool pageUrlEquality = (this.GetPageUrl() == newFavorite.GetPageUrl());
        return (idEquality && nameEquality && addressEquality && latitudeEquality && longitudeEquality && costEquality && cusineEquality && menuUrlEquality && pageUrlEquality);
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
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM favorites;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Favorite> GetAll()
    {
      List<Favorite> allFavorites = new List<Favorite> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM favorites;";
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

        Favorite newFavorite = new Favorite( favoriteName, favoriteAddress,  favoriteMenuUrl, favoritePageUrl, favoriteLatitude, favoriteLongitude, favoriteCost, favoriteCusine,favoriteId);
        allFavorites.Add(newFavorite);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allFavorites;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO favorites (fav_res_name, fav_address, fav_lat, fav_long, fav_cost_for_2, fav_cuisine, fav_menu_url, fav_page_url) VALUES (@favoriteRestaurantName, @favoriteAddress, @favoriteLatitude, @favoriteLongitude, @favoriteCostFor2, @favoriteCusine, @favoriteMenuUrl, @favoritePageUrl);";

      MySqlParameter favRName = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteRestaurantName", this._favoriteResName);

      MySqlParameter favRAddress = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteAddress", this._favoriteAddress);

      MySqlParameter favRLatitude = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteLatitude", this._favoriteLat);

      MySqlParameter favRLongitude = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteLongitude", this._favoriteLong);

      MySqlParameter favRCost = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteCostFor2", this._favoriteCost);

      MySqlParameter favRCusine = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteCusine", this._favoriteCusine);

      MySqlParameter favRMenuUrl = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoriteMenuUrl", this._favoriteMenuUrl);

      MySqlParameter favRPageUrl = new MySqlParameter();
      cmd.Parameters.AddWithValue("@favoritePageUrl", this._favoritePageUrl);

      cmd.ExecuteNonQuery();
      _favoriteResId = (int) cmd.LastInsertedId;

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
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM favorites WHERE id = @favResId; DELETE FROM users_favorites WHERE restaurant_id = @favResId;";
      cmd.Parameters.AddWithValue("@favResId", this.GetId());
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddUser(User newUser)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users_favorites (user_id, restaurant_id) VALUES (@userId, @restaurantId);";
      cmd.Parameters.AddWithValue("@userId", newUser.GetId());
      cmd.Parameters.AddWithValue("@restaurantId", this.GetId());
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<User> GetUser()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT users.* FROM favorites
      JOIN users_favorites ON (favorites.id = users_favorites.restaurant_id)
      JOIN users ON (users_favorites.user_id = users.id)
      WHERE favorites.id = @favId;";
      cmd.Parameters.AddWithValue("@favId", this.GetId());
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<User> users = new List<User> {};
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
        User foundUser = new User(userName, userPassword, userDistance, userPrice, userBio, userId);
        users.Add(foundUser);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return users;
    }
  }
}
