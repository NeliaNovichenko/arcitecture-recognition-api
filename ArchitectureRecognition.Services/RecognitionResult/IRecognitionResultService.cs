using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureRecognition.Services.RecognitionResult
{
    public interface IRecognitionResultService
    {
        Task<Data.Entities.RecognitionResult> AddRecognitionResultAsync(Data.Entities.RecognitionResult recognitionResult);

        System.Threading.Tasks.Task UpdateRecognitionResultAsync(int id, Data.Entities.RecognitionResult recognitionResult);

        Task<List<Data.Entities.RecognitionResult>> GetAllAsync(string userId);

        Task<Data.Entities.RecognitionResult> GetByIdAsync(int id);

        System.Threading.Tasks.Task DeleteAsync(int id);
    }
}
