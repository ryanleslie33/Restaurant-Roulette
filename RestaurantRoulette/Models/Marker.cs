using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace RestaurantRoulette.Models
{
  public class Marker
  {

    private string _name;
    private double _lat;
    private double _long;

    public Marker (string name, double lat, double longitude)
    {
      _name = name;
      _lat = lat;
      _long = longitude;
    }

    public string GetMarkerName()
    {
      return _name;
    }

    public double GetMarkerLatitude()
    {
      return _lat;
    }

    public double GetMarkerLongitude()
    {
      return _long;
    }

    public static List<Marker> GetAllRestaurantMarkers(List<Favorite> restaurants)
    {
      List<Marker> allMarkers = new List<Marker> { };
      string regName = "";
      double regLat = 0;
      double regLong = 0;
      foreach(var rest in restaurants)
      {
        regName = rest.GetName();
        regLat = rest.GetLatitude();
        regLong = rest.GetLongitude();
        Marker newMarker = new Marker(regName, regLat, regLong);
        allMarkers.Add(newMarker);
      }


      return allMarkers;
    }

  }
}
