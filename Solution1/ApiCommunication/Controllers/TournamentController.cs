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
    [Route("api/tournament")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly IApplicationTournament _applicationTournament;

        public TournamentController(IApplicationTournament applicationTournament)
        {
            _applicationTournament = applicationTournament;
        }


        [HttpPost]
        [Route("returnchampion")]
        public string ReturnChampion([FromBody] List<PlayerDto> players)
        {
          

            var champion = _applicationTournament.ReturnChampion(players);

            string retorno = JsonConvert.SerializeObject(champion, Formatting.Indented);

            return retorno;
        }
    }
}