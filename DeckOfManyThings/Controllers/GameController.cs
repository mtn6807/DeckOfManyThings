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
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            String user = Request.Cookies["name"];
            Casino casino = Program.activeGames["casino"];
            Table table = casino.getTable(user);
            ViewBag.User = user;
            ViewBag.DeckSize = table.cardsLeft();
            ViewBag.Hand = table.getPlayer(user).getHand();
            return View();
        }

        [HttpGet("/game/{id}")]
        public IActionResult Index(string id)
        {
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];
            if (!casino.userExists(user)) { casino.joinTable(id, user); }
            return View();
        }


        [HttpPost("/game/create")]
        public string Create()
        {
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];
            if (!casino.userExists(user)){ casino.addTable(user); }
            Response.Redirect("/game");
            return "redirecting...";
        }

        [HttpPost("/game/quit")]
        public string Quit()
        {
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];
            casino.removeUser(user);
            Response.Redirect("/home");
            return "redirecting...";
        }

        [HttpPost("/game/draw")]
        public string Draw(int numofcards)
        {
            if (numofcards < 1) { numofcards = 1; }
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];
            Table table = casino.getTable(user);
            table.dealCards(numofcards,table.getPlayer(user));
            Response.Redirect("/game");
            return "redirecting...";
        }

        [HttpPost("/game/shuffle")]
        public string Shuffle()
        {
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];
            Table table = casino.getTable(user);
            table.shuffle();
            Response.Redirect("/game");
            return "redirecting...";
        }
    }
}
