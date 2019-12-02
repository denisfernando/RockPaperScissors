using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.Models;

namespace Site.Controllers
{
    [Route("tournament")]
    public class TournamentController : Controller
    {
        public string BaseUrl
        {
            get
            {
                return "https://localhost:44300/api/tournament/";
            }
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("run")]
        [HttpPost]
        public JsonResult TournamentRun([FromBody] List<Player> Players)
        {
            string json = JsonConvert.SerializeObject(Players, Formatting.Indented);
            string action = "returnchampion/";
            
          
            
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().PostAsync(BaseUrl + action, 
                new StringContent(JsonConvert.SerializeObject(Players),Encoding.UTF8,"application/json")).Result;

            string jsonRetorno = response.Content.ReadAsStringAsync().Result;

            Player playerWin = JsonConvert.DeserializeObject<Player>(jsonRetorno);


            var settings = new JsonSerializerSettings();

            return Json(playerWin, settings);


        }
    }
}