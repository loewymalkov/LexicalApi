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
        public ActionResult <IEnumerable<Word>> Get (string descriptions, int rating)
        {
            var query = _db.Words.AsQueryable();
            if(descriptions != null)
            {
                query = query.Where(entry => entry.Description == descriptions);
            }
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Word word)
        {
        _db.Words.Add(word);
        _db.SaveChanges();
        }
    }

}