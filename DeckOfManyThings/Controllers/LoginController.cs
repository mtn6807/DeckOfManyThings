using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckOfManyThings.Models;
using DeckOfManyThings.Application;

namespace DeckOfManyThings.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("/login")]
        public string Login(string username)
        {
            Response.Cookies.Append("name", username);
            Casino casino = Program.activeGames["casino"];
            Response.Redirect("/home");
            return "redirecting...";
        }
    }
}

