using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchitectureRecognition.Services.Data.Abstract
{
    public interface IRecognitionResultRepository
    {
        void AddRecognitionResult(Entities.RecognitionResult recognitionResult);

        Task<List<Entities.RecognitionResult>> GetAllRecognitionResultsAync(string userId);

        Task<Entities.RecognitionResult> FindByIdAsync(int id);

        void Update(Entities.RecognitionResult recognitionResult);

        void Delete(Entities.RecognitionResult recognitionResult);
    }
}
