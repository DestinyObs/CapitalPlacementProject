using CapitalPlacementProject.Models;

namespace CapitalPlacementProject.Interfaces
{
    public interface IProgramRepo
    {
        Task<List<ProgramModel>> GetAllProgramsAsync();
        Task<ProgramModel> GetProgramByIdAsync(string programId);
        Task<ProgramModel> CreateProgramAsync(ProgramModel program);
        Task<ProgramModel> UpdateProgramAsync(string programId, ProgramModel program);
        Task<bool> DeleteProgramAsync(string programId);
    }
}
