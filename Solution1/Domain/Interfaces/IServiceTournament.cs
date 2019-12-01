using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IServiceTournament
    {
        Player ReturnChampion(List<Player> pl);


    }
}
