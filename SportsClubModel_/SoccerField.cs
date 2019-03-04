using System;
using System.Collections.Generic;
using System.Text;

namespace SportsClubModel
{
    public class SoccerField : Field
    {
        public bool IsSeven { get; set; }

        public SoccerField() { }

        public SoccerField(string name, Surfaces surface, decimal price, bool isSeven)
        {
            Name = name;
            Surface = surface;
            Price = price;
            IsSeven = isSeven;

            if (IsSeven)
            {
                Players = 14;
            }
            else Players = 10;
        }
    }
}
