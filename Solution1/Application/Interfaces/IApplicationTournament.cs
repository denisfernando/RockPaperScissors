using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto;

namespace Application.Interfaces
{
    public interface IApplicationTournament
    {
        PlayerDto ReturnChampion(List<PlayerDto> players);
    }
}
