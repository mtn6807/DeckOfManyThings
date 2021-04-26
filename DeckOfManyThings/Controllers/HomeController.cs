using DeckOfManyThings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DeckOfManyThings.Application;

namespace DeckOfManyThings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Deck deck = Program.activeGames["mainDeck"].getDeck();
            ViewBag.DeckSize = deck.cardsLeft();
            //todo display hand seperate into sessions;
            return View();
        }

        [Route("/{a}")]
        [HttpGet]
        public IActionResult Index(String a)
        {
            ViewBag.Test = a;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
