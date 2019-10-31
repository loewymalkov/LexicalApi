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
            List<Word> wordList = JsonConvert.DeserializeObject<List<Word>>(jsonResponse.ToString());
            return wordList;
        }

        public static Word PutWord(Word word)
        {
            var apiCallTask = ApiHelper.ApiCallWordList(word.name);
            var result = apiCallTask.Result;
            JArray jresponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Word> wordResponse = JsonConvert.DeserializeObject<List<Word>>(jresponse.ToString());
            Word targetWord = wordResponse[0];
            if (targetWord.ratingCount != 0)
            {
                double number_ratings = (double)targetWord.ratingCount;
                targetWord.rating = ((number_ratings * targetWord.rating) + word.rating) / (number_ratings + 1);
                targetWord.ratingCount +=1;

            }
            else
            {
                targetWord.rating = word.rating;
                targetWord.ratingCount = 1;
            }
            var apiPutTask = ApiHelper.ApiPut(targetWord.wordId, targetWord);
            return targetWord;
        }
    }
}