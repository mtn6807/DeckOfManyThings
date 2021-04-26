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
        [HttpGet]
        public IActionResult Index()
        {
            String user = Request.Cookies["name"];
            Casino casino = Program.activeGames["casino"];
            ViewBag.User = user;
            ViewBag.Tables = casino.getTables();
            ViewBag.numActive = casino.getTables().Count;
            return View();
        }
    }
}
