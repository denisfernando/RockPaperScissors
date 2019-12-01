using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ServiceTournament : IServiceTournament
    {
        public Player ReturnChampion(List<Player> pl)
        {
            //Regras de Negócio
            //Por Não estar usando um torneio estático para fazer uma requisição inicial para o Generate do torneio
            //Ao enviar a Lista de jogadores já será efetuada a Geração do Torneio e o retorno do Vencedor
            Tournament t = Generate(pl);

            t.Start();

            return rps_tournament_winner(t);
        }

        public Tournament Generate(List<Player> players)
        {
            Game game = new Game();
            Group group = new Group();
            Tournament t = new Tournament();
            //Levando em conta que o torneio possui 2^n Jogadores
            foreach(Player p in players)
            {
                game.Add(p);
                //Verifica se a Duelo está completo
                if(game.CheckFull())
                {
                    //Se está, adiciona o jogo ao grupo
                    group.Add(game);
                    //Limpa o jogo
                    game = new Game();
                    //Verifica se o Grupo está completo
                    if (group.CheckFull())
                    {
                        //Se estiver Adiciona à lista do torneio
                        t.Championship.Add(group);
                        //E limpa o grupo
                        group = new Group();
                    }


                }
            }
            return t;
        }

        //Retorna o Campeão do Torneio
        public Player rps_tournament_winner(Tournament t)
        {
            return t.Final.Battle();
        }
    }
}
