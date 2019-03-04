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

        public async Task<Field> GetFieldById(int fieldId)
        {
            var field = await context.Fields.Where(r => r.FieldId == fieldId).SingleAsync();
            return field;
        }

        public void RemoveField(int fieldId)
        {
            var field = context.Fields.Where(x => x.FieldId == fieldId).First();
            context.Remove(field);
        }
    }
}
