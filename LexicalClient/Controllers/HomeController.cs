using Microsoft.AspNetCore.Mvc;
using LexicalClient.Models;

namespace LexicalClient.Controllers
{
  public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allWords = Word.GetWords();
            return View(allWords);
        }
    }
}