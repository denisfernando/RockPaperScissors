using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class GroupDto
    {
        public GameDto Game1 { get;  set; }
        public GameDto Game2 { get;  set; }
        public PlayerDto WinnerGame1 { get;  set; }
        public PlayerDto WinnerGame2 { get;  set; }

        public static explicit operator GroupDto(Group g)
        {
            return new GroupDto()
            {
                Game1 = (GameDto)g.Game1,
                Game2 = (GameDto)g.Game2,
                WinnerGame1 = (PlayerDto)g.WinnerGame1,
                WinnerGame2 = (PlayerDto)g.WinnerGame2
            };
        }
    }
}
