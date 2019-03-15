using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsClubModel;
using SportsClubModel.Interfaces;
using SportsClubWeb.DTO;

namespace SportsClubWeb.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public ReservationsController(IReservationUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationsDTO[]>> Get()
        {
            try
            {
                var results = await UnitOfWork.GetAllReservationsAsync();

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
                var results = await UnitOfWork.GetReservationsByFieldAsync(fieldId);

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("user")]
        public async Task<ActionResult<ReservationsDTO[]>> GetByUser(int userId)
        {
            try
            {
                var results = await UnitOfWork.GetReservationsByUserIdAsync(userId);

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
                var results = await UnitOfWork.GetReservationsByDateAsync(start, end);

                return Mapper.Map<ReservationsDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpDelete("{reservationid}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            try
            {
                var result = await UnitOfWork.GetReservationByReservationIdAsync(reservationId);
                if (result == null) return NotFound();

                await UnitOfWork.RemoveReservationAsync(reservationId);

                if(await UnitOfWork.SaveChangesAsync())
                {
                    return Ok();
                }
                
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest("Failed to delete the reservation");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationsDTO>> ModifyReservation(int reservationId,ReservationsDTO reservationsDTO)
        {
            try
            {
                var result = await UnitOfWork.GetReservationByReservationIdAsync(reservationId);
                if (result == null) return NotFound($"Could not found resevation with this id{reservationId}");

                Mapper.Map(reservationsDTO, result);

                if(await UnitOfWork.SaveChangesAsync())
                {
                    return Mapper.Map<ReservationsDTO>(result);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult<ReservationsDTO>> Post(ReservationsDTO reservationsDTO)
        {
            try
            {
                var exist = await UnitOfWork.GetReservationByReservationIdAsync(reservationsDTO.ReservationId);
                if (exist != null) return BadRequest("Id già in uso");

                var newres = Mapper.Map<Reservation>(reservationsDTO);
                await UnitOfWork.AddReservationAsync(newres);
                if (await UnitOfWork.SaveChangesAsync())
                    return Created($"/api/reservations/{reservationsDTO.ReservationId}", Mapper.Map<ReservationsDTO>(newres));

            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

    }
}