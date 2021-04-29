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
        /*
         * GET /game route controller.
         *  gets username from the cookie. Pulls in the application tier class
         *  @casino. Createss a new table via the @casino class. Builds the view
         *  model from the tables data.
         * 
         *  @return the view model for the game page.
         */
        [HttpGet]
        public IActionResult Index()
        {
            // Pull user from cookie
            String user = Request.Cookies["name"];

            // Grabs casino from application and gets table from casino
            Casino casino = Program.activeGames["casino"];
            Table table = casino.getTable(user);

            // Build view model.
            ViewBag.User = user;
            ViewBag.DeckSize = table.cardsLeft();
            ViewBag.Hand = table.getPlayer(user).getHand();

            return View();
        }

        /*
         * GET /game/{id} route controller.
         *  Gets username from the cookie. Pulls in the application tier class
         *  @casino. Gets the user's table from the casino via the {id} param. 
         *  Builds the view model from the tables data.
         *  
         *  @param id - the id of the table being joined.
         *  @return a view model of the game page.
         */
        [HttpGet("/game/{id}")]
        public IActionResult Index(string id)
        {
            // Pull user from cookie
            String user = Request.Cookies["name"];
            
            // Grabs casino from application, joins the table specified by {id} 
            Casino casino = Program.activeGames["casino"];
            if (!casino.userExists(user)) { casino.joinTable(id, user); }

            // Pulls table from casino.
            Table table = casino.getTable(user);

            // Renders the view model.
            ViewBag.User = user;
            ViewBag.DeckSize = table.cardsLeft();
            ViewBag.Hand = table.getPlayer(user).getHand();

            return View();
        }

        /*
         * POST /game/create route controller.
         *  Creates a new table in the casino. Then redirects to the /game 
         *  route where the new table will be rendered.
         * 
         *  @return a redirect string.
         */
        [HttpPost("/game/create")]
        public string Create()
        {
            // Get's @casino class from application and username via cookies
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];

            // Creates a new table and adds the user if it doesn't already exist
            if (!casino.userExists(user)){ casino.addTable(user); }

            // Redirect to the /game route.
            Response.Redirect("/game");
            return "redirecting...";
        }

        /*
         * POST /game/quit route controller.
         *  Removes the user from their table and redirects them to the home 
         *  page.
         *  
         *  @return a redirect string.
         */
        [HttpPost("/game/quit")]
        public string Quit()
        {
            // Gets @casino class from application and username via cookies
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];

            // Removes user from table
            casino.removeUser(user);

            // Redirects to the home page
            Response.Redirect("/home");
            return "redirecting...";
        }

        /*
         * POST /game/draw route controller.
         *  Will deal a number of cards from the table's deck to the user which 
         *  calls the route. 
         * 
         *  @param a number of cards to draw.
         *  @return a redirect string.
         */
        [HttpPost("/game/draw")]
        public string Draw(int numofcards)
        {
            // if numofcards param is below 1 deal 1 card.
            if (numofcards < 1) { numofcards = 1; }

            // Gets @casino class from application and username via cookies
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];

            // Gets the table from the casino and deals the player {numofcards}
            Table table = casino.getTable(user);
            table.dealCards(numofcards,table.getPlayer(user));

            // Redirects to the /game route
            Response.Redirect("/game");
            return "redirecting...";
        }

        /*
         * POST /game/shuffle route controller.
         *  Shuffles the deck of the table the user is at.
         * 
         *  @return a redirect string.
         */
        [HttpPost("/game/shuffle")]
        public string Shuffle()
        {
            // Gets @casino class from application and username via cookies
            Casino casino = Program.activeGames["casino"];
            String user = Request.Cookies["name"];

            // Gets the tablel and shuffles the deck
            Table table = casino.getTable(user);
            table.shuffle();

            // Redirect to /game
            Response.Redirect("/game");
            return "redirecting...";
        }
    }
}
