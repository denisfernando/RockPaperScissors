using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ServiceGame : IServiceGame
    {
        public static int WrongNumberOfPlayersError = 0;
        public static int NoSuchStrategyError = 0;

        public Player ReturnWinner(List<Player> players)
        {
            Game game = new Game();
            //Verifica se a quantidade de players para o duelo está correta
            if (players.Count == 2)
            {
                //Se sim, monta o duelo
                game.Add(players[0]);
                game.Add(players[1]);
                //Verifica se as ações são válidas
                if (game.CheckActions())//Se são, retorna o vencedor do duelo
                    return rps_game_winner(game);
                else//Se não são incremenda o NoSuchStrategyError
                    NoSuchStrategyError++;
            }
            else//Se a quantidade de jogadores != 2 
                WrongNumberOfPlayersError++;

            return null;

        }

        public Player rps_game_winner(Game g)
        {
            return g.Battle();
        }
    }
}
