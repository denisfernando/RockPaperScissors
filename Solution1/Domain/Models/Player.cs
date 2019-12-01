using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Player
    {
        public string Name { get; private set; }
        public string Action { get; private set; }


        public Player(string nome, string acao)
        {
            this.Name = nome;
            this.Action = acao;
        }
        public Player(){}


        #region Setters
        public void SetName(string nome)
        {
            this.Name = nome;
        }

        public void SetAction(string acao)
        {
            this.Action = acao;
        }
        #endregion

    }


}
