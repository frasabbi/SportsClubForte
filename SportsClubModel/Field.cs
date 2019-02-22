using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel
{
    public abstract class Field
    {
        [Key]
        public int FieldId { get; set; }
        public string Name { get; set; }
        public Sport Sport { get; set; }
        public string Surface { get; set; }
        public decimal Price { get; set; }
    }
}
