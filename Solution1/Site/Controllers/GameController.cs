using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Site.Models;

namespace Site.Controllers
{
    [Route("game/battle")]
    public class GameController : Controller
    {
        public string BaseUrl
        {
            get
            {
                return "https://localhost:44300/api/game/";
            }
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("play")]
        [HttpPost]
        public JsonResult Battle([FromBody] List<Player> Players)
        {
            string json = JsonConvert.SerializeObject(Players, Formatting.Indented);
            string action = "returnwinner";
            
           
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().PostAsync(BaseUrl + action,
                new StringContent(JsonConvert.SerializeObject(Players), Encoding.UTF8, "application/json")).Result;

            string jsonRetorno = response.Content.ReadAsStringAsync().Result;

            Player playerWin = JsonConvert.DeserializeObject<Player>(jsonRetorno);


            var settings = new JsonSerializerSettings();

            return Json(playerWin, settings);


        }
    }
}