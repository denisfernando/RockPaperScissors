using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Game
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public int WrongNumberOfPlayersError;
        public int NoSuchStrategyError;

        public Game(Player p1, Player p2)
        {
            this.Player1 = p1;
            this.Player2 = p2;
            WrongNumberOfPlayersError = 0;
            NoSuchStrategyError = 0;
        }
        public Game(){
            Player1 = null;
            Player2 = null;
            WrongNumberOfPlayersError = 0;
            NoSuchStrategyError = 0;
        }

        public bool CheckFull()
        {
            return Player1 != null && Player2 != null;
        }

        //Verifica se A Estratégia é diferente de "R", "P" ou "S"
        public bool CheckActions()
        {
            List<string> actionsAccept = new List<string>();
            actionsAccept.Add("R");
            actionsAccept.Add("P");
            actionsAccept.Add("S");

            return actionsAccept.Contains(Player1.Action.ToUpper()) && actionsAccept.Contains(Player2.Action.ToUpper());
        }

        //ADiciona o jogador para o duelo obs: só adiciona se o duelo não estiver completo, 
        //ou seja, se pelo menos um player não existir
        public void Add(Player p)
        {
            if (Player1 == null)
                this.Player1 = p;
            else
                if (Player2 == null)
                this.Player2 = p;
        }

        //Retorna o vencedor do duelo
        public Player Battle()
        {
            //Se há exatamente 2 jogadores
            if (Player1 != null && Player2 != null)
            {
                //Se os movimentos são Válidos
                if (CheckActions())
                {
                    //Se são Iguais, Player 1 Vence
                    if (Player1.Action.Trim().ToUpper().Equals(Player2.Action.Trim().ToUpper()))
                        return Player1;
                    //Player 1 Vence
                    if (Player1.Action.Trim().ToUpper().Equals("S") && Player2.Action.Trim().ToUpper().Equals("P") ||
                        Player1.Action.Trim().ToUpper().Equals("R") && Player2.Action.Trim().ToUpper().Equals("S") ||
                        Player1.Action.Trim().ToUpper().Equals("P") && Player2.Action.Trim().ToUpper().Equals("R"))
                        return Player1;
                    else //Player2 Vence
                        return Player2;
                }
                else
                    NoSuchStrategyError++;

            }
            else
                WrongNumberOfPlayersError++;


            return null;

        }

        #region Setters
        public void SetPlayer1(Player p1)
        {
            Player1 = p1;
        }
        public void SetPlayer2(Player p2)
        {
            Player2 = p2;
        }
        #endregion
    }
}
