using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ApplicationGame : IApplicationGame
    {
        private readonly IServiceGame _serviceGame;
        public ApplicationGame(IServiceGame serviceGame)
        {
            _serviceGame = serviceGame;
        }
        public PlayerDto ReturnWiner(List<PlayerDto> players)
        {
            List<Player> pl = new List<Player>();
            foreach (var p in players)
                pl.Add(new Player(p.Name, p.Action));
            return (PlayerDto)_serviceGame.ReturnWinner(pl);
        }
    }
}
