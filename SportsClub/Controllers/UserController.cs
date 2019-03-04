using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsClubModel;
using SportsClubWeb.DTO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing;


namespace SportsClubWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        //private readonly LinkGenerator _linkGenerator;
        

        public UserController(IUnitOfWork unit, IMapper mapper /*LinkGenerator linkGenerator*/)
        {
            unitOfWork = unit;
            _mapper = mapper;
            //_linkGenerator = linkGenerator;
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

        public async Task<ActionResult<UserDTO>> Post(UserDTO model)
        {
            try
            {
                var existingUser = await unitOfWork.GetUserAsync(model.UserId);
                if (existingUser != null)
                {
                    return BadRequest("User already exist");
                }

                //var location = _linkGenerator.GetPathByAction("Get",
                //  "Users",
                //  new { user = model.UserId });

                //if (string.IsNullOrWhiteSpace(location))
                //{
                //    return BadRequest("Could not use current user");
                //}

                // Create a new Camp
                var user = _mapper.Map<User>(model);
                //await unitOfWork.AddUser(user);
                if (await unitOfWork.AddUser(user))
                {
                    return Created($"/api/Users/{user.UserId}", _mapper.Map<UserDTO>(user));
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDTO>> Put(int userId, UserDTO model)
        {
            try
            {
                var oldUser = await unitOfWork.GetUserAsync(userId);
                if (oldUser == null) return NotFound($"Could not find user: {userId}");

                _mapper.Map(model, oldUser);

                if (await unitOfWork.SaveChangesAsync())
                {
                    return _mapper.Map<UserDTO>(oldUser);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                var oldUser = await unitOfWork.GetUserAsync(userId);
                if (oldUser == null) return NotFound();

                await unitOfWork.RemoveUser(oldUser.UserId);

                if (await unitOfWork.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete user");
        }
    }
}