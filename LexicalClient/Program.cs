using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LexicalClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApiTest {
  class Program {
    static void Main () {
      var client = new RestClient ("http://localhost:5000/api/words");
      var request = new RestRequest ("resource/{id}", Method.POST);
      var word = new {Name = "dude", Rating=5, RatingCount = 0};
      request.AddJsonBody(word);
      var response = client.Get(request);

      Console.WriteLine(response.ToString());
    }
  }
} 