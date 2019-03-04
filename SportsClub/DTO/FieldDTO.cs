﻿using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.DTO
{
    public class FieldDTO
    {
        public int FieldId { get; set; }
        public string Name { get; set; }
        public Surfaces Surface { get; set; }
        public decimal Price { get; set; }
        public int Players { get; set; }
    }
    public enum Sports { Tennis, Paddle, Soccer }
    public enum Surfaces { Clay, Grass, Concrete }
}