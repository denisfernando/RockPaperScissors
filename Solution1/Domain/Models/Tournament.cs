using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Tournament
    {
        public List<Group> Championship { get; private set; }
        public Game Final { get; private set; }

        public Tournament()
        {
            this.Championship = new List<Group>();
            Final = null;
        }

        //Simula o andamento do torneio até a final
        public void Start()
        {
            Group group = new Group();
            Game game = new Game();
            for(int i=0; i<this.Championship.Count; i++)
            {
                //Salvo os vencedores para poder Mostrar na interface o Histórico do torneio
                this.Championship[i].SetWinnerGame1(this.Championship[i].Game1.Battle());
                this.Championship[i].SetWinnerGame2(this.Championship[i].Game2.Battle());

                //Adiciono o Duelo da próxima Rodada
                game.Add(this.Championship[i].WinnerGame1);
                game.Add(this.Championship[i].WinnerGame2);

                //Ultimo Grupo da Lista
                if(i == this.Championship.Count-1)
                {
                    //Se for o ultimo da Lista e não houver um jogo anterior no grupo pra gerar a final, então  já é a final
                    if (group.CheckEmpty())
                        this.Final = game;
                    else
                    {//Se não, completa o grupo, insere na lista e limpa o mesmo
                        group.Add(game);
                        this.Championship.Add(group);
                        group = new Group();
                    }
                }//Se não é o ultimo da lista
                else
                {   //adiciona ao grupo
                    group.Add(game);
                    //Verifica se o grupo ficou completo, se sim, é então adicionado à lista e limpo
                    if (group.CheckFull())
                    {
                        this.Championship.Add(group);
                        group = new Group();
                    }

                }
                
            }
        }

        #region Setters
        public void setFinal(Game g)
        {
            this.Final = g;
        }
        #endregion

    }
}
