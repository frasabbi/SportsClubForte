using AutoMapper;
using SportsClubModel;
using SportsClubWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            this.CreateMap<User, UserDTO>()
                .ReverseMap();

            this.CreateMap<Field, FieldDTO>()
                .ReverseMap();

            this.CreateMap<Reservation, ReservationsDTO>()
                .ReverseMap()
                .ForMember(r => r.Challenge, opt => opt.Ignore());

            //Challenge?

        }
    }
}
