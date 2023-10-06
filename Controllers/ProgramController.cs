using CapitalPlacementProject.Dtos;
using CapitalPlacementProject.Models;
using CapitalPlacementProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapitalPlacementProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly ProgramRepository _programRepository;

        public ProgramController(ProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            try
            {
                var programs = await _programRepository.GetAllProgramsAsync();
                return Ok(programs);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(Guid id)
        {
            try
            {
                var program = await _programRepository.GetProgramByIdAsync(id);

                if (program == null)
                {
                    return NotFound($"Program with ID {id} not found");
                }

                return Ok(program);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramDto programDto)
        {
            try
            {
                // Ensure the DTO is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Map the DTO to the model
                var programModel = new ProgramModel
                {
                    Id = Guid.NewGuid(),
                    ProgramTitle = programDto.ProgramTitle,
                    Summary = programDto.Summary,
                    ProgramDescription = programDto.ProgramDescription,
                    ApplicantSkills = programDto.ApplicantSkills,
                    Benefits = programDto.Benefits,
                    ApplicationCriteria = programDto.ApplicationCriteria,
                    ProgramType = programDto.ProgramType,
                    ProgramStart = programDto.ProgramStart,
                    ApplicationOpen = programDto.ApplicationOpen,
                    ApplicationClose = programDto.ApplicationClose,
                    Duration = programDto.Duration,
                    FullyRemote = programDto.FullyRemote,
                    MinQualifications = programDto.MinQualifications,
                    MaxApplications = programDto.MaxApplications
                };

                // Create the program
                await _programRepository.CreateProgramAsync(programModel);

                // Assuming you have a method to get the program by ID
                var createdProgram = await _programRepository.GetProgramByIdAsync(programModel.Id);

                // Return the created program in the response
                return CreatedAtAction(nameof(GetProgramById), new { id = createdProgram.Id }, createdProgram);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] UpdateProgramDto updatedProgramDto)
        {
            try
            {
                await _programRepository.UpdateProgramAsync(id, updatedProgramDto);

                // Retrieve the updated program details and return in the response
                var updatedProgram = await _programRepository.GetProgramByIdAsync(id);

                return Ok(updatedProgram);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            try
            {
                await _programRepository.DeleteProgramAsync(id);

                // Return a success message in the response
                return Ok($"Program with ID {id} has been deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
