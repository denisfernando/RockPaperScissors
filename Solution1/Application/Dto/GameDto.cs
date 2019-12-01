using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class GameDto
    {
        public PlayerDto Player1 { get; private set; }
        public PlayerDto Player2 { get; private set; }

        public static explicit operator GameDto(Game g)
        {
            return new GameDto()
            {
                Player1 = (PlayerDto)g.Player1,
                Player2 = (PlayerDto)g.Player2
            };
        }
    }
}
