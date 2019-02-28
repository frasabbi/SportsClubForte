using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel
{
    public class SoccerField : Field
    {
        public SoccerField() { }

        public SoccerField(string name, Surfaces surface, decimal price)
        {
            Name = name;
            Surface = surface;
            Price = price;
        }
    }
}
