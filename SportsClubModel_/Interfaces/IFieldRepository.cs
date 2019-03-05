using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubModel
{
    public interface IFieldRepository
    {
        IQueryable<Field> Fields { get; }
        void AddField(Field field);
        void RemoveField(int fieldId);
        Field GetFieldById(int fieldId);
    }
}
