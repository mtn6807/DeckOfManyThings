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
        /*
         * GET /login route controller.
         *  returns the default view model for the login page
         *  @return the view model for the login page.
         */
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        /*
         * POST /login route controller.
         *  get's the username from the post body and returns the cookie to 
         *  the client. Then redirects to the home page.
         */
        [HttpPost("/login")]
        public string Login(string username)
        {
            // builds and returns cookie.
            Response.Cookies.Append("name", username);

            // redirects home.
            Response.Redirect("/home");
            return "redirecting...";
        }
    }
}

