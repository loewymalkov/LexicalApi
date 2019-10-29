using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using LexicalClient.Models;


namespace ApiTest
{
  class Program
  {
    static void Main()
    {
      var apiCallTask = ApiHelper.ApiCall();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      
      List<Word> wordList = new List<Word>();
      foreach(JObject jo in jsonResponse)
      {
        Word newWord = JsonConvert.DeserializeObject<Word>(jo.ToString());
        Console.WriteLine(newWord.name);
        
      }
      // List<Word> wordList = JsonConvert.DeserializeObject<List<Word>>(jsonResponse.ToString());
 
      // foreach (Word word in wordList)
      // {
      //   Console.WriteLine($"Name: {word.Name}");
      //   Console.WriteLine($"Rating: {word.Rating}");
      // }
    }
  }
}