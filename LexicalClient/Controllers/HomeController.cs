using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LexicalClient.Models;

namespace LexicalClient.Controllers
{
  public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            var allWords = Word.GetWords();
            return View(allWords);
        }
    }
}