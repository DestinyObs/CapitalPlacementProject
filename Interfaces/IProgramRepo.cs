using CapitalPlacementProject.Dtos;
using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Interfaces
{
    public interface IProgramRepo
    {
        Task<List<ProgramModel>> GetAllProgramsAsync();
        Task<ProgramModel> CreateProgramAsync(ProgramModel programDto);
        Task<ProgramModel> GetProgramByIdAsync(string programId);
        Task<ProgramModel> UpdateProgramAsync(string programId, ProgramModel program);
        Task<bool> DeleteProgramAsync(string programId);
    }
}
