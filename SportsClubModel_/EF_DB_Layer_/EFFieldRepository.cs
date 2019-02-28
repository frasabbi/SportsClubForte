using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
