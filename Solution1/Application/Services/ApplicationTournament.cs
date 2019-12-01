using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ApplicationTournament : IApplicationTournament
    {
        private readonly IServiceTournament _serviceTournament;
        public ApplicationTournament(IServiceTournament serviceTournament)
        {
            _serviceTournament = serviceTournament;
        }
        public PlayerDto ReturnChampion(List<PlayerDto> players)
        {
            List<Player> pl = new List<Player>();
            foreach (var p in players)
                pl.Add(new Player(p.Name, p.Action));
            return (PlayerDto)_serviceTournament.ReturnChampion(pl);
        }
    }
}
