using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
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
      var apiCallTask = LocationApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Location> locationList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse.ToString());

      return locationList;
    }

    public static Location GetDetails(int id)
    {
      var apiCallTask = LocationApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Location location = JsonConvert.DeserializeObject<Location>(jsonResponse.ToString());

      return location;
    }

    public static void Post(Location location)
    {
      string jsonLocation = JsonConvert.SerializeObject(location);
      var apiCallTask = LocationApiHelper.Post(jsonLocation);
    }

    public static void Put(Location location)
    {
      string jsonLocation = JsonConvert.SerializeObject(location);
      var apiCallTask = LocationApiHelper.Put(location.LocationId, jsonLocation);
    }

    public static void Delete(int id)
    {
      var apiCallTask = LocationApiHelper.Delete(id);
    }
  }
}