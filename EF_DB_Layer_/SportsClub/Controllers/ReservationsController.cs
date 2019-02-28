using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsClubModel;
using SportsClubWeb.DTO;

namespace SportsClubWeb.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public ReservationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationsDTO[]>> Get()
        {
            try
            {
                var results = await UnitOfWork.ReservationRepository.GetAllReservationsAsync();

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("field")]
        public async Task<ActionResult<ReservationsDTO[]>> GetByField(int fieldId)
        {
            try
            {
                var results = await UnitOfWork.ReservationRepository.GetReservationsByField(fieldId);

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        //La soluzione è cambiare il nome della funzione?
        [HttpGet("user")]
        public async Task<ActionResult<ReservationsDTO[]>> GetByUser(int userId)
        {
            try
            {
                var results = await UnitOfWork.ReservationRepository.GetReservationsByUserId(userId);

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("date")]
        public async Task<ActionResult<ReservationsDTO[]>> GetInADate(DateTime start, DateTime end)
        {
            try
            {
                var results = await UnitOfWork.ReservationRepository.GetReservationsByDate(start, end);

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}