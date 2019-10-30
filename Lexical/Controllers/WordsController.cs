using System;
using System.Collections.Generic;
using System.Linq;
using Lexical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lexical.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase {
        private LexicalContext _db;

        public WordsController (LexicalContext db) {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Word>> Get (int wordId, string name, double rating, string wordList, int page) {
            var query = _db.Words.AsQueryable ();
            if (wordId != 0) {
                query = query.Where (w => w.WordId == wordId);
            }
            if (name != null) {
                query = query.Where (w => w.Name == name);
            }
            if (rating != 0) {
                query = query.Where (w => w.Rating == rating);
            }
            if (wordList != null) {
                wordList = wordList.ToLower ();
                string[] array = wordList.Split (",");
                query = query.Where (w => array.Contains (w.Name));
            }
            if (page != 0) {
                int WORDS_PER_PAGE = 30;
                int NUMBER_OF_WORDS = _db.Words.ToList ().Count;
                int MAX_PAGE = (int) Math.Ceiling ((double) NUMBER_OF_WORDS / (double) WORDS_PER_PAGE);
                Console.WriteLine (MAX_PAGE);
                if (page <= MAX_PAGE) {
                    int MIN_RANGE = ((page - 1) * WORDS_PER_PAGE) + 1;
                    int RANGE = WORDS_PER_PAGE - 1;
                    if (MIN_RANGE + RANGE > NUMBER_OF_WORDS && MIN_RANGE < NUMBER_OF_WORDS) {
                        RANGE = (NUMBER_OF_WORDS - MIN_RANGE) + 1;
                    }
                    int[] RANGE_ARRAY = Enumerable.Range (MIN_RANGE, RANGE).ToArray ();
                    query = query.Where (w => RANGE_ARRAY.Contains (w.WordId));
                }
            }
            return query.ToList ();
        }

        [HttpPost]
        public void Post ([FromBody] Word word) {

            Console.WriteLine("Post");
            List<string> words = _db.Words.Select (w => w.Name).ToList ();
            if (words.Contains (word.Name)) {
                int wordId = _db.Words.FirstOrDefault (w => w.Name == word.Name).WordId;
                word.WordId = wordId;
                _db.Entry (word).State = EntityState.Modified;
                _db.SaveChanges ();
            } else {
                _db.Words.Add (word);
                _db.SaveChanges ();
            }
        }

        [HttpGet ("{id}")]
        public ActionResult<Word> Get (int id) {
            return _db.Words.FirstOrDefault (entry => entry.WordId == id);
        }

        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] Word word) {
            word.WordId = id;
            _db.Entry (word).State = EntityState.Modified;
            _db.SaveChanges ();
        }

        [HttpDelete ("{id}")]
        public void Delete (int id) {
            var wordToDelete = _db.Words.FirstOrDefault (entry => entry.WordId == id);
            _db.Words.Remove (wordToDelete);
            _db.SaveChanges ();
        }

    }

}