using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class TournamentDto
    {
        public List<GroupDto> Championship { get; set; }
        public TournamentDto()
        {
            Championship = new List<GroupDto>();
        }
        public static explicit operator TournamentDto(Tournament t)
        {
            TournamentDto tdto = new TournamentDto();

            foreach (Group g in t.Championship)
                tdto.Championship.Add((GroupDto)g);

            return tdto;
        }
    }
}
