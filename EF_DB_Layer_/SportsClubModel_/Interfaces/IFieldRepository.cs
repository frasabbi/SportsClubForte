using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsClubModel
{
    public interface IFieldRepository
    {
        IQueryable<Field> Fields { get; }
        void AddField(Field field);
    }
}
