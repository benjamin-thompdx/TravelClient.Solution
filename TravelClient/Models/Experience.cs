using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Experience
  {
    public int ExperienceId { get; set; }
    public string Author { get; set; }
    public string Review { get; set; }
    public int Rating { get; set; }
    public int LocationId { get; set; }

    public static List<Experience> Get()
    {
      var apiCallTask = ExperienceApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Experience> experienceList = JsonConvert.DeserializeObject<List<Experience>>(jsonResponse.ToString());

      return experienceList;
    }

    public static Experience GetDetails(int id)
    {
      var apiCallTask = ExperienceApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Experience experience = JsonConvert.DeserializeObject<Experience>(jsonResponse.ToString());

      return experience;
    }

    public static void Post(Experience experience)
    {
      string jsonExperience = JsonConvert.SerializeObject(experience);
      var apiCallTask = ExperienceApiHelper.Post(jsonExperience);
    }

    public static void Put(Experience experience)
    {
      string jsonExperience = JsonConvert.SerializeObject(experience);
      var apiCallTask = ExperienceApiHelper.Put(experience.ExperienceId, jsonExperience);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ExperienceApiHelper.Delete(id);
    }
  }
}
