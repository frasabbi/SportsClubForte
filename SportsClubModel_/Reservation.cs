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
        public User User { get; set; }
        public string Sport { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public DateTime Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public ReservationsType ReservationType { get; set; }
        public decimal Price { get; set; }
        public Challenge Challenge { get; set; }
        public bool IsChallenge { get => Challenge == null ? false : true; }

        //Gestire il fatto che tennis può essere solo single e double
        //Calcio può essere solo 5v5 e 7v7
        //Paddle può essere solo double
        public enum ReservationsType { Single = 2, Double = 4, _5vs5 = 10, _7vs7 = 14 };

        public Reservation() { }

        public Reservation(int userId, int fieldId, DateTime date, DateTime timeStart,
            DateTime timeEnd, ReservationsType type, bool isChallenge)
        {
            UserId = userId;
            Sport = ToSport(Field.GetType().Name);
            FieldId = fieldId;
            Date = date.Date;
            TimeStart = timeStart.ToShortTimeString();
            TimeEnd = timeEnd.ToShortTimeString();
            ReservationType = type;

            if(type == ReservationsType.Single || type == ReservationsType._5vs5 || type == ReservationsType._7vs7)
            {
                Price = Field.Price;
            }
            else if(type == ReservationsType.Double)
            {
                Price = Field.Price * 1.5m;
            }

            if (isChallenge == true)
            {
                int numOfPlayers = (int)ReservationType;

                Challenge = new Challenge(UserId, numOfPlayers);
            }
            

        }

        public string ToSport(string courtName)
        {
            string sport = null;

            if (courtName.Contains("Court"))
            {
                sport = courtName.Replace("Court", "");
            }
            else if (courtName.Contains("Field"))
            {
                sport = courtName.Replace("Field", "");
            }
            return sport;
        }

    }
}
