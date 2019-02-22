using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsClubModel
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int SportId { get; set; }
        public int FieldId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ReservationType { get; set; }
        public decimal Price { get; set; }
    }
}
