using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class User
  {
    public User()
    {
      this.Experiences = new HashSet<Experience>();
    }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; }

    public static List<User> GetUsers()
    {
      var apiCallTask = UserApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonResponse.ToString());

      return userList;
    }

    public static User GetDetails(int id)
    {
      var apiCallTask = UserApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      User user = JsonConvert.DeserializeObject<User>(jsonResponse.ToString());

      return user;
    }

    public static void Post(User user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = UserApiHelper.Post(jsonUser);
    }

    public static void Put(User user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = UserApiHelper.Put(user.UserId, jsonUser);
    }

    public static void Delete(int id)
    {
      var apiCallTask = UserApiHelper.Delete(id);
    }
  }
}