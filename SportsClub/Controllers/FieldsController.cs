﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SportsClubModel;
using SportsClubModel.Interfaces;
using SportsClubWeb.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public FieldsController(IFieldUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<FieldDTO[]>> Get(bool includeTalks = false)
        {
            try
            {
                var results = await UnitOfWork.GetAllFieldsAsync();
                if (!results.Any()) return NotFound();

                return Mapper.Map<FieldDTO[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        public async Task<ActionResult<FieldDTO>> Post(FieldDTO dto)
        {
            try
            {
                var existing = await UnitOfWork.GetFieldByIdAsync(dto.FieldId);
                if (existing != null)
                {
                    return BadRequest("Moniker in Use");
                }

                //var location = linkGenerator.GetPathByAction("Get",
                //  "Camps",
                //  new { moniker = model.Moniker });

                //if (string.IsNullOrWhiteSpace(location))
                //{
                //    return BadRequest("Could not use current moniker");
                //}

                // Create a new Field
                var field = Mapper.Map<Field>(dto);
                await UnitOfWork.AddFieldAsync(field);
                return Created($"/api/fields/{field.FieldId}", Mapper.Map<FieldDTO>(field));

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut("{fieldId}")]
        public async Task<ActionResult<FieldDTO>> Put(int fieldId, FieldDTO dto)
        {
            try
            {
                var oldField = await UnitOfWork.GetFieldByIdAsync(fieldId);
                if (oldField == null)
                {
                    return NotFound($"Could not find field with moniker of {fieldId}");
                }

                Mapper.Map(dto, oldField);

                if (await UnitOfWork.SaveChangesAsync())
                {
                    return Mapper.Map<FieldDTO>(oldField);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{FieldId}")]
        public async Task<IActionResult> Delete(int fieldId)
        {
            try
            {
                var oldField = await UnitOfWork.GetFieldByIdAsync(fieldId);
                if (oldField == null) return NotFound();

                await UnitOfWork.RemoveFieldAsync(oldField.FieldId);

                if (await UnitOfWork.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the camp");
        }

    }
}
