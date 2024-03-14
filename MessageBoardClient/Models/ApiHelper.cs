using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll(string group, string earlierDateTime, string laterDateTime)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{group}?earlierDateTime={earlierDateTime}&laterDateTime={laterDateTime}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string userName, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}/{userName}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PutAsync(request);
    }

    public static async void Delete(int id, string userName)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}/{userName}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}