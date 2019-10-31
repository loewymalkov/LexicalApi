using System.Threading.Tasks;
using RestSharp;

namespace LexicalClient.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall()
        {
            RestClient client = new RestClient("http://localhost:5000/api/words");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallWordList(string words)
        {
            RestClient client = new RestClient("http://localhost:5000/api/words");
            RestRequest request = new RestRequest($"?wordList={words}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiPost(Word word)
        {
            RestClient client = new RestClient("http://localhost:5000/api/words");
            RestRequest request = new RestRequest("/", Method.POST);
            request.AddJsonBody(word);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiPut(int id, Word word)
        {
            RestClient client = new RestClient("http://localhost:5000/api/words");
            RestRequest request = new RestRequest($"/{id}", Method.PUT);
            request.AddJsonBody(word);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}