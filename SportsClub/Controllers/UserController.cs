using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsClubModel;
using SportsClubWeb.DTO;

namespace SportsClubWeb.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper Mapper;
        private readonly LinkGenerator LinkGenerator;

        public UserController(IUnitOfWork unit, IMapper mapper)
        {
            unitOfWork = unit;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO[]>> Get()
        {
            //User nicoletta = new User(firstName:"Nicoletta", lastName:"Magi", birthdate:new DateTime(1991 / 11 / 5), address:"Via Paleocapa");
            try
            {
                var results = await unitOfWork.GetAllUsersAsync();
                if (!results.Any()) return NotFound();

                return AutoMapper.Mapper.Map<UserDTO[]>(results);
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
                var results = unitOfWork.UserRepository.GetAllUsersByLastNameAsync(token);
                if (!results.Any()) return NotFound();

                return Mapper.Map<UserDTO[]>(results);
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
                var results = unitOfWork.UserRepository.GetUsersByDateOfBirthRange(start, end);
                if (!results.Any()) return NotFound();

                return AutoMapper.Mapper.Map<UserDTO[]>(results);
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                var oldUser = unitOfWork.UserRepository.GetUserById(userId);
                if (oldUser == null)
                {
                    return NotFound();
                }

                await unitOfWork.RemoveUserAsync(userId);
                if (await unitOfWork.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the user");
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO dto)
        {
            try
            {
                var existing = unitOfWork.UserRepository.GetUserById(dto.UserId);
                if (existing != null)
                {
                    return BadRequest("User already exists");
                }

                //Link Generator

                var user = Mapper.Map<User>(dto);

                //Da risolvere
                await unitOfWork.AddUserAsync(user);
                
                return Created($"/api/User/{user.UserId}", Mapper.Map<UserDTO>(user));
                
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDTO>> Put(int userId, UserDTO dto)
        {
            try
            {
                var oldUser = unitOfWork.UserRepository.GetUserById(userId);
                if (oldUser == null)
                {
                    return NotFound($"Could not find user with id: {userId}");
                }
                Mapper.Map(dto, oldUser);

                if (await unitOfWork.SaveChangesAsync())
                {
                    return Mapper.Map<UserDTO>(oldUser);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }
    }
}
