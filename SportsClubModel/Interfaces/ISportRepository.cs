using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsClubModel
{
    public interface ISportRepository
    {
        IQueryable<Sport> Sports { get; }
        void AddSport(Sport sport);
    }
}
