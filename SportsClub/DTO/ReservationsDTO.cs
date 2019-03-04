using SportsClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.DTO
{
    public class ReservationsDTO
    {
        public int ReservationId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }
        public int UserReservations { get; set; }

    }
}
