using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAllLocations()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"locations", Method.GET);
      var response = await client.ExecuteTestAsync(request);
      return response.Content;
    }
    public static async Task<string> GetAllExperiences()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"experiences", Method.GET);
      var response = await client.ExecuteTestAsync(request);
      return response.Content;
    }
  }
}