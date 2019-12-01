using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("battle")]
        public JsonResult Battle([FromBody] Game game)
        {
            return Json(game.Player1);
        }
    }
}