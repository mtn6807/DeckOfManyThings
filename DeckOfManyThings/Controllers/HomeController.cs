using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckOfManyThings.Application;

namespace DeckOfManyThings.Controllers
{
    public class HomeController : Controller
    {
        /*
         * GET /home route controller.
         *  gets username and casino to display all usable tables which can 
         *  be joined.
         * 
         *  @return the view model for the home page.
         */
        [HttpGet]
        public IActionResult Index()
        {
            // Gets username from cookie and casino from the applicaiton.
            String user = Request.Cookies["name"];
            Casino casino = Program.activeGames["casino"];

            // Builds and returns the view model.
            ViewBag.User = user;
            ViewBag.Tables = casino.getTables();
            ViewBag.numActive = casino.getTables().Count;
            return View();
        }
    }
}
