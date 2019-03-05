using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DB_Layer
{
    public class EFFieldRepository : IFieldRepository
    {
        private ApplicationDbContext context;

        public EFFieldRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Field> Fields => context.Fields;

        public void AddField(Field field)
        {
            context.Add(field);
        }

        public Field GetFieldById(int fieldId)
        {
            return context.Fields.SingleOrDefault(r => r.FieldId == fieldId);
        }

        public void RemoveField(int fieldId)
        {
            var field = context.Fields.Where(x => x.FieldId == fieldId).First();
            context.Remove(field);
        }
    }
}
