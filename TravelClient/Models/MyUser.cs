using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
// using System.Security.Claims;

namespace TravelClient.Models
{
  public class MyUser
  {
    public MyUser()
    {
      this.Experiences = new HashSet<Experience>();
    }
    public int MyUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MyUsername { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string Password2 { get; set; }
    public string Token { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; }

    public static List<MyUser> GetMyUsers()
    {
      var apiCallTask = MyUserApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<MyUser> myUserList = JsonConvert.DeserializeObject<List<MyUser>>(jsonResponse.ToString());

      return myUserList;
    }

    public static MyUser GetDetails(int id)
    {
      var apiCallTask = MyUserApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      MyUser myUser = JsonConvert.DeserializeObject<MyUser>(jsonResponse.ToString());

      return myUser;
    }

    public static void Post(MyUser myUser)
    {
      string jsonMyUser = JsonConvert.SerializeObject(myUser);
      var apiCallTask = MyUserApiHelper.Post(jsonMyUser);
    }

    public static void Put(MyUser myUser)
    {
      string jsonMyUser = JsonConvert.SerializeObject(myUser);
      var apiCallTask = MyUserApiHelper.Put(myUser.MyUserId, jsonMyUser);
    }

    public static void Delete(int id)
    {
      var apiCallTask = MyUserApiHelper.Delete(id);
    }
  }
}