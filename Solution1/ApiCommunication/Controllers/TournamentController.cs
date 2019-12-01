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
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly IApplicationTournament _applicationTournament;

        public TournamentController(IApplicationTournament applicationTournament)
        {
            _applicationTournament = applicationTournament;
        }


        [HttpGet]
        [Route("returnchampion/{json}")]
        public string ReturnChampion(string json)
        {
            List<PlayerDto> players = JsonConvert.DeserializeObject<List<PlayerDto>>(json);

            var champion = _applicationTournament.ReturnChampion(players);

            string retorno = JsonConvert.SerializeObject(champion, Formatting.Indented);

            return retorno;
        }
    }
}