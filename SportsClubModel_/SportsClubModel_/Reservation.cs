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
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public ReservationsType ReservationType { get; set; }
        public decimal Price { get; set; }
        public bool IsChallenge { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        
        public enum ReservationsType { Single = 2, Double = 4, _5vs5 = 10, _7vs7 = 14 };

        public Reservation() { }

        //Time Start e time end di che tipo devono essere?
        public Reservation(int userId, int fieldId, DateTime date, string timeStart,
            string timeEnd, ReservationsType type, bool isChallenge)
        {
            UserId = userId;
            Sport = ToSport(Field.GetType().Name);
            FieldId = fieldId;
            Date = date.Date;
            TimeStart = DateTime.Parse(timeStart) ;
            TimeEnd = DateTime.Parse(timeEnd);
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

                ChallengeId = Challenge.ChallengeId;
            }

            var t = IsTypeValid(type, Sport);

            if(t!= null)
            {
                ReservationType = (ReservationsType)t;
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
        public ReservationsType? IsTypeValid(ReservationsType type,string sport)
        {
            if (sport == "Soccer" && (type == ReservationsType._5vs5 || type == ReservationsType._7vs7))
            {
                return type;
            }
            else if (sport == "Paddle" && type == ReservationsType.Double)
            {
                return type;
            }
            else if (sport == "Tennis" && (type == ReservationsType.Single || type == ReservationsType.Double))
            {
                return type;
            }
            else
            {
                 var ex =new TypeNotValidException("Il tipo non è valido per lo sport selezionato");
                throw ex;
            }
        }

    }
}
public class TypeNotValidException : Exception
{
    public TypeNotValidException()
    {

    }
    public TypeNotValidException(string message):base(message)
    {

    }
}