
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;


namespace LexicalClient.Models
{
    public class Word
    {
        public int wordId {get;set;}
        public string name { get; set; }
        public double rating { get; set; }
        public int ratingCount {get;set;}

        public static List<Word> GetWords(string apiKey)
        {
            var apiCallTask = ApiHelper.ApiCall();
            var result = apiCallTask.Result;
            Console.WriteLine(result, "result");
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Word> wordList = JsonConvert.DeserializeObject<List<Word>>(jsonResponse["words"].ToString());

            return wordList;
        }
    }
}

    
