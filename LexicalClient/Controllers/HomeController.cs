using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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

        [HttpGet]
        public ActionResult Rating()
        {
            SelectListItem one = new SelectListItem { Text = "🤬", Value = "1" };
            SelectListItem two = new SelectListItem { Text = "🤢", Value = "2" };
            SelectListItem three = new SelectListItem { Text = "😐", Value = "3" };
            SelectListItem four = new SelectListItem { Text = "🙂", Value = "4" };
            SelectListItem five = new SelectListItem { Text = "😍", Value = "5" };
            ViewBag.rating = new List<SelectListItem> { one, two, three, four, five };
            return View();
        }

        [HttpPost]
        public ActionResult Rating(Word word)
        {
            var targetWord = Word.PutWord(word);
            return RedirectToAction("Details", "Home", targetWord);
        }

        public ActionResult Details (Word word)
        {
            return View(word);
        }


    }
}