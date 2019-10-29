
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace LexicalClient.Models
{
    public class Word
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public static List<Word> GetWords(string apiKey)
        {
            var apiCallTask = ApiHelper.ApiCall(apiKey);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Word> wordList = JsonConvert.DeserializeObject<List<Word>>(jsonResponse["words"].ToString());

            return wordList;
        }
    }
}

    
