using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto;

namespace Application.Interfaces
{
    public interface IApplicationGame
    {
        PlayerDto ReturnWiner(List<PlayerDto> players);
    }
}
