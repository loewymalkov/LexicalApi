using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LexicalClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LexicalClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var client = new RestClient ("http://localhost:5000/api/words");
            // var request = new RestRequest ("resource/{id}", Method.POST);
            // var word = new {Name = "dude", Rating=5, RatingCount = 0};
            // request.AddJsonBody(word);
            // var response = client.Get(request);

            // Console.WriteLine(response.ToString());

            CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                  WebHost.CreateDefaultBuilder(args)
                      .UseStartup<Startup>();
    }
}

