using CapitalPlacementProject.Data;
using CapitalPlacementProject.Dtos;
using CapitalPlacementProject.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalPlacementProject.Repositories
{
    public class ProgramRepository
    {
        private readonly Container _container;

        public ProgramRepository(CapitalPlacementDbContext dbContext)
        {
            _container = dbContext.ProgramContainer;
        }

        public async Task<IEnumerable<ProgramModel>> GetAllProgramsAsync()
        {
            var query = _container.GetItemQueryIterator<ProgramModel>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<ProgramModel>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<ProgramModel> GetProgramByIdAsync(Guid id)
        {
            var response = await _container.ReadItemAsync<ProgramModel>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
        }

        public async Task<ProgramModel> CreateProgramAsync(ProgramModel programDto)
        {
            return await _container.CreateItemAsync(programDto);

        }



        public async Task UpdateProgramAsync(Guid id, UpdateProgramDto updatedProgramDto)
        {
            var existingProgram = await _container.ReadItemAsync<ProgramModel>(id.ToString(), new PartitionKey(id.ToString()));
            var programToUpdate = existingProgram.Resource;

            MapDtoToModel(updatedProgramDto, programToUpdate);

            await _container.ReplaceItemAsync(programToUpdate, id.ToString(), new PartitionKey(id.ToString()));
        }

        public async Task DeleteProgramAsync(Guid id)
        {
            await _container.DeleteItemAsync<ProgramModel>(id.ToString(), new PartitionKey(id.ToString()));
        }

        private ProgramModel MapDtoToModel(CreateProgramDto programDto)
        {
            return new ProgramModel
            {
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
                // Map other properties...
            };
        }

        // Helper method to map DTO to an existing Model
        private void MapDtoToModel(UpdateProgramDto updatedProgramDto, ProgramModel existingProgram)
        {
            existingProgram.ProgramTitle = updatedProgramDto.ProgramTitle;
            existingProgram.Summary = updatedProgramDto.Summary;
            existingProgram.ProgramDescription = updatedProgramDto.ProgramDescription;
            existingProgram.ApplicantSkills = updatedProgramDto.ApplicantSkills;
            existingProgram.Benefits = updatedProgramDto.Benefits;
            existingProgram.ApplicationCriteria = updatedProgramDto.ApplicationCriteria;
            existingProgram.ProgramType = updatedProgramDto.ProgramType;
            existingProgram.ProgramStart = updatedProgramDto.ProgramStart;
            existingProgram.ApplicationOpen = updatedProgramDto.ApplicationOpen;
            existingProgram.ApplicationClose = updatedProgramDto.ApplicationClose;
            existingProgram.Duration = updatedProgramDto.Duration;
            existingProgram.FullyRemote = updatedProgramDto.FullyRemote;
            existingProgram.MinQualifications = updatedProgramDto.MinQualifications;
            existingProgram.MaxApplications = updatedProgramDto.MaxApplications;
            // Map other properties...
        }
    }
}
