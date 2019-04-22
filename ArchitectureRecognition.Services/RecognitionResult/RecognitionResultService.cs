using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ArchitectureRecognition.Services.Data.Abstract;

namespace ArchitectureRecognition.Services.RecognitionResult
{
    public sealed class RecognitionResultService : IRecognitionResultService
    {
        private readonly IRecognitionResultRepository _recognitionResultRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecognitionResultService(IRecognitionResultRepository recognitionResultRepository,
            IUnitOfWork unitOfWork)
        {
            _recognitionResultRepository = recognitionResultRepository ?? throw new ArgumentNullException(nameof(recognitionResultRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Data.Entities.RecognitionResult> AddRecognitionResultAsync(Data.Entities.RecognitionResult recognitionResult)
        {
            if (recognitionResult == null)
            {
                throw new ArgumentNullException(nameof(RecognitionResult));
            }

            _recognitionResultRepository.AddRecognitionResult(recognitionResult);
            await _unitOfWork.SaveAsync();
            return recognitionResult;
        }


        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be >= 0", nameof(id));
            }

            Data.Entities.RecognitionResult recognitionResult = await _recognitionResultRepository.FindByIdAsync(id);

            if (recognitionResult == null)
            {
                throw new ArgumentException("not fount", nameof(id));
            }

            _recognitionResultRepository.Delete(recognitionResult);
            await _unitOfWork.SaveAsync();
        }


        public async Task<List<Data.Entities.RecognitionResult>> GetAllAsync(string userId)
        {
            return await _recognitionResultRepository.GetAllRecognitionResultsAync(userId);
        }

        public async Task<Data.Entities.RecognitionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            return await _recognitionResultRepository.FindByIdAsync(id);
        }


        public async Task UpdateRecognitionResultAsync(int id, Data.Entities.RecognitionResult recognitionResult)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            if (recognitionResult == null)
            {
                throw new ArgumentNullException(nameof(RecognitionResult));
            }

            Data.Entities.RecognitionResult entity = await _recognitionResultRepository.FindByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("not found", nameof(id));
            }

            entity.Title = recognitionResult.Title;
            entity.Description = recognitionResult.Description;
            entity.Date = recognitionResult.Date;
            //entity.ImageId = recognitionResult.ImageId;
            entity.ImageDate = recognitionResult.ImageDate;
            entity.ImageName = recognitionResult.ImageName;
            //entity.Image = recognitionResult.Image;
            entity.Style = recognitionResult.Style;


            await _unitOfWork.SaveAsync();
        }
    }
}
