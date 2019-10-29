using Microsoft.AspNetCore.Mvc;
using LexicalClient.Models;

namespace LexicalClient.Controllers
{
  public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allWords = Word.GetWords("[YOUR-API-KEY-HERE]");
            return View(allWords);
        }
    }
}