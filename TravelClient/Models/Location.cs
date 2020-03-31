using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelRating.Models
{
  public class Location
  {
    public Location()
    {
      this.Experiences = new HashSet<Experience>();
    }

    public int LocationId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    
    public virtual ICollection<Experience> Experiences { get; set; }

    public static List<Location> GetLocations()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Location> locationList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse.ToString());

      return locationList;
    }

    public static void Post(Location location)
    {
      string jsonLocation = JsonConvert.SerializeObject(location);
      var apiCallTask = ApiHelper.Post(jsonLocation);
    }

    public static void Put(Location location)
    {
      string jsonLocation = JsonConvert.SerializeObject(location);
      var apiCallTask = ApiHelper.Put(location.LocationId, jsonLocation);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}