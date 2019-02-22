using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel
{
    public abstract class Sport
    {
        [Key]
        public int SportId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }
}
