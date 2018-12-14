using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;

namespace RestaurantRoulette.Models
{
  public class Favorite
  {
    private int _favoriteResId;
    private string _favoriteResName;
    private string _favoriteAddress;
    private float _favoriteLat;
    private float _favoriteLong;
    private int _favoriteCost;
    private string _favoriteCusine;
    private string _favoriteMenuUrl;
    private string _favoritePageUrl;
    //private Image _favoriteImage;

    public Favorite(string favName, string favAddress, string favMenuUrl, string favPageUrl, int favId = 0, float favLatitude = 0, float favLongitude = 0, int favCost = 0, string favCusine = "")
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
      //_favoriteImage = favImage;
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

    public float GetLatitude()
    {
      return _favoriteLat;
    }

    public float GetLongitude()
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

    // public blob GetImage()
    // {
    //   return _favoriteImage;
    // }
    //
    // public void SetImage(blob newImage)
    // {
    //   _favoriteImage = newImage;
    // }

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
        //bool imageEquality = (this.GetImage() == newFavorite.GetImage());
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
        string favoriteAddress = rdr.GetInt32(2);
        float favoriteLatitude = rdr.GetFloat(3);
        float favoriteLongitude = rdr.GetFloat(4);
        int favoriteCost = rdr.GetInt32(5);
        string favoriteCusine = rdr.GetString(6);
        string favoriteMenuUrl = rdr.GetString(7);
        string favoritePageUrl = rdr.GetString(8);
        //favoriteImage = rdr.GetBlob(9)
        //Image favoriteImage = rdr.
        Favorite newFavorite = new Favorite( favoriteName, favoriteAddress, favoriteLatitude, favoriteLongitude, favoriteCost, favoriteCusine, favoriteMenuUrl, favoritePageUrl, favoriteId = 0);
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
      cmd.CommandText = @"INSERT INTO favorites (fav_res_name, fav_address, fav_lat, fav_long, fav_cost_for_2, fav_cusine, fav_menu_url, fav_page_url) VALUES (@favoriteRestaurantName, @favoriteAddress, @favoriteLatitude, @favoriteLongitude, @favoriteCostFor2, @favoriteCusine, @favoriteMenuUrl, @favoritePageUrl);";


      MySqlParameter rollResult = new MySqlParameter();
      cmd.Parameters.AddWithValue("@rollresult", result);

      MySqlParameter description = new MySqlParameter();
      cmd.Parameters.AddWithValue("@ItemDescription", this._description);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      //To fail Saves to database method - declare method and keep it empty
      //To fail Save AssignsId test -
      //do not add the "_id = (int) cmd.LastInsertedId;" line
    }


    public int DiceRoll()
    {
      int result;
      Random rnd = new Random();
      result = rnd.Next(1,7);
      return result;
    }

    public List<Client> GetFavRollResult()
    {
      List<Favorite> favRestaurantList = new List<Favorite> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      Favorite newFavorite = new Favorite();
      int id = cmd.LastInsertedId();

      int result;
      Random rnd = new Random();
      result = rnd.Next(1, id+1);

      cmd.CommandText = @"SELECT * FROM favorites WHERE fav_res_id = @rollresult;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        MySqlParameter rollResult = new MySqlParameter();
        cmd.Parameters.AddWithValue("@rollresult", result);
        // rollResult.ParameterName = "@rollresult";
        // rollesult.Value = result;
        //cmd.Parameters.Add(rollresult);
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        int favId;
        string favRestaurantName = "";
        string favRestaurantAddress = "";
        //float favLatitude ;
        //float favLongitude;
        //int favCost;
        //string favCusine;
        string favUrl = "";
        string favMenuUrl = "";
        while (rdr.Read())
        {
          favId = rdr.GetInt32(0);
          favRestaurantName = rdr.GetString(1);
          favRestaurantAddress = rdr.GetString(2);
          //favLatitude = rdr.GetFloat(3);
          //favLongitude = rdr.GetFloat(4);
          //favCost = rdr.GetInt32(5);
          //favCusine = rdr.GetString(6);
          favUrl = rdr.GetString(8);
          favMenuUrl = rdr.GetString(7);
        }
        Favorite newFavorite = new Favorite(favRestaurantName, favRestaurantAddress, favMenuUrl, favUrl);
        favRestaurantList.Add(newFavorite);
      }
      conn.close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return favRestaurantList;
    }

    public void Retrieve()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT fav_res_name, fav_address, fav_lat, fav_long, fav_cusine, fav_menu_url, fav_page_url FROM restaurant_data WHERE "
    }

    public void Insert()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO favorites (favoriteId, favoriteName, favoriteAddress, favoriteLatitude, favoriteLongitude, favoriteCost, favoriteCusine, favoriteMenuUrl, favoritePageUrl) VALUES (@Id, @name, @address, @latitude, @longitude, @cost, @cusine, @menuUrl, @pageUrl);";
      MySqlParameter fav_id = new MySqlParameter();
      MySqlParameter fav_name = new MySqlParameter();
      MySqlParameter fav_address = new MySqlParameter();
      MySqlParameter fav_latitude = new MySqlParameter();
      MySqlParameter fav_longitude = new MySqlParameter();
      MySqlParameter fav_cost = new MySqlParameter();
      MySqlParameter fav_cusine = new MySqlParameter();
      MySqlParameter fav_menu_url = new MySqlParameter();
      MySqlParameter fav_page_url = new MySqlParameter();

      //cmd.Parameters.AddWithValue("@Id", this._favoriteResId);
      cmd.Parameters.AddWithValue("@name", this._favoriteResName);
      cmd.Parameters.AddWithValue("@address", _favoriteAddress);
      cmd.Parameters.AddWithValue("@latitude", this._favoriteLat);
      cmd.Parameters.AddWithValue("@longitude", this._favoriteLong);
      cmd.Parameters.AddWithValue("@cost", this._favoriteCost);
      cmd.Parameters.AddWithValue("@cusine", this._favoriteCusine);
      cmd.Parameters.AddWithValue("@menuUrl", this._favoriteMenuUrl);
      cmd.Parameters.AddWithValue("@pageUrl", this._favoritePageUrl);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public void Edit(string newName)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE favorites SET fave_res_name = @new_fav_res_name, fav_address = @new_fav_address, fav_lat = @new_fav_lat, fav_long = @new_fav_long, fav_cost_for_2 = @new_fav_cost_for_2, fav_cusine = @new_fav_cusine, fav_menu_url = @new_fav_menu_url, fav_page_url = @new_fav_page_url
    //   WHERE fav_res_id = @searchId;";
    //
    //   MySqlParameter fav_id = new MySqlParameter();
    //   MySqlParameter fav_name = new MySqlParameter();
    //   MySqlParameter fav_address = new MySqlParameter();
    //   MySqlParameter fav_latitude = new MySqlParameter();
    //   MySqlParameter fav_longitude = new MySqlParameter();
    //   MySqlParameter fav_cost = new MySqlParameter();
    //   MySqlParameter fav_cusine = new MySqlParameter();
    //   MySqlParameter fav_menu_url = new MySqlParameter();
    //   MySqlParameter fav_page_url = new MySqlParameter();
    //
    //   //cmd.Parameters.AddWithValue("@Id", this._favoriteResId);
    //   cmd.Parameters.AddWithValue("@name", this._favoriteResName);
    //   cmd.Parameters.AddWithValue("@address", _favoriteAddress);
    //   cmd.Parameters.AddWithValue("@latitude", this._favoriteLat);
    //   cmd.Parameters.AddWithValue("@longitude", this._favoriteLong);
    //   cmd.Parameters.AddWithValue("@cost", this._favoriteCost);
    //   cmd.Parameters.AddWithValue("@cusine", this._favoriteCusine);
    //   cmd.Parameters.AddWithValue("@menuUrl", this._favoriteMenuUrl);
    //   cmd.Parameters.AddWithValue("@pageUrl", this._favoritePageUrl);
    //
    //
    //   MySqlParameter searchId = new MySqlParameter();
    //   cmd.Parameters.AddWithValue("@searchId", this._id);
    //   MySqlParameter description = new MySqlParameter();
    //   cmd.Parameters.AddWithValue("@newClient", newName);
    //   cmd.ExecuteNonQuery();
    //   _name = newName;
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

  }
}
