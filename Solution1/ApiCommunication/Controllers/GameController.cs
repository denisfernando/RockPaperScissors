using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCommunication.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IApplicationGame _applicationGame;

        public GameController(IApplicationGame applicationGame)
        {
            _applicationGame = applicationGame;
        }

        [HttpPost]
        [Route("returnwinner")]
        public string ReturnWinner([FromBody] List<PlayerDto> players)
        {

            var Winner = _applicationGame.ReturnWiner(players);

            string retorno = JsonConvert.SerializeObject(Winner, Formatting.Indented);

            return retorno;
        }
    }
}