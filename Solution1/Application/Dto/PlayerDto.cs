using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class PlayerDto
    {
        public string Name { get;  set; }
        public string Action { get; set; }


        public static explicit operator PlayerDto(Player p)
        {
            return new PlayerDto()
            {
                Name = p.Name,
                Action = p.Action
            };
        }
    }
}
