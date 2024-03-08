using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  public class GroupApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/groups", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}