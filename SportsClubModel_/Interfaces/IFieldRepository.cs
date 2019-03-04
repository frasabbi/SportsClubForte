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
        Task<Field> GetFieldById(int fieldId);
        void RemoveField(int fieldId);
    }
}
