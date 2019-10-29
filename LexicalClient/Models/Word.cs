using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LexicalClient.Models {
    public class Word {
        public int wordId { get; set; }
        public string name { get; set; }
        public double rating { get; set; }
        public int ratingCount { get; set; }

        public static List<Word> GetWords () {
            var apiCallTask = ApiHelper.ApiCall ();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray> (result);

            List<Word> wordList = new List<Word> ();
            foreach (JObject jo in jsonResponse) {
                Word newWord = JsonConvert.DeserializeObject<Word> (jo.ToString ());
                wordList.Add (newWord);
            }

            return wordList;
        }
    }
}