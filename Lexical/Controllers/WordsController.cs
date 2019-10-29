using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lexical.Models;
using Microsoft.EntityFrameworkCore;

namespace Lexical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController: ControllerBase
    {
        private LexicalContext _db;

        public WordsController(LexicalContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Word>> Get (string names, int rating)
        {
            var query = _db.Words.AsQueryable();
            if(names != null)
            {
                query = query.Where(entry => entry.Name == names);
            }
            if(rating != 0)
            {
                query = query.Where(entry => entry.Rating == rating);
            }
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Word word)
        {
        _db.Words.Add(word);
        _db.SaveChanges();
        }
         
        [HttpGet("{id}")]
        public ActionResult<Word> Get(int id)
        {
        return _db.Words.FirstOrDefault(entry => entry.WordId == id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Word word)
        {
        word.WordId = id;
        _db.Entry(word).State = EntityState.Modified;
        _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        var wordToDelete = _db.Words.FirstOrDefault(entry => entry.WordId == id);
        _db.Words.Remove(wordToDelete);
        _db.SaveChanges();
        }

    }

}