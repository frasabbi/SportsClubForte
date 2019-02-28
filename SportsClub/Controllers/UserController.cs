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
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unit, IMapper mapper)
        {
            unitOfWork = unit;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<UserDTO[]>> Get()
        {
            //User nicoletta = new User(firstName:"Nicoletta", lastName:"Magi", birthdate:new DateTime(1991 / 11 / 5), address:"Via Paleocapa");
            try
            {
                var results = await unitOfWork.UserRepository.GetAllUsersAsync();
                if (!results.Any()) return NotFound();

                return Mapper.Map<UserDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{token}")]
        public async Task<ActionResult<UserDTO[]>> GetString(string token)
        {
            try
            {
                var results = await unitOfWork.UserRepository.GetAllUsersByLastNameAsync(token);
                if (!results.Any()) return NotFound();

                return _mapper.Map<UserDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("Date")]
        public async Task<ActionResult<UserDTO[]>> GetInADate(DateTime start, DateTime end)
        {
            try
            {
                var results = await unitOfWork.UserRepository.GetUsersByDateOfBirthRange(start, end);
                if (!results.Any()) return NotFound();

                return Mapper.Map<UserDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        //[HttpGet("{wins}")]
        //public async Task<ActionResult<UserDTO[]>> GetBestWinner()
        //{
        //    try
        //    {
        //        var results = await unitOfWork.UserRepository.GetBestWinner();
        //        if (!results.Any()) return NotFound();

        //        return Mapper.Map<UserDTO[]>(results);
        //    }
        //    catch (Exception)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
        //    }
        //}
    }
}