using System;

namespace ArchitectureRecognition.Models.RecognitionResult
{
    public sealed class RecognitionResultMapper : IRecognitionResultMapper
    {
        public RecognitionResultDto MapToDto(Services.Data.Entities.RecognitionResult recognitionResult)
        {
            return new RecognitionResultDto
            {
                Id = recognitionResult.Id,
                Title = recognitionResult.Title,
                Description = recognitionResult.Description,
                Date = recognitionResult.Date,
                ImageDate = recognitionResult.ImageDate,
                ImageName = recognitionResult.ImageName,
                ImagePath = recognitionResult.ImagePath,
                Style = recognitionResult.Style
            };
        }

        public Services.Data.Entities.RecognitionResult MapToEntity(
            RecognitionResultDto dto, 
            string userId
            )
        {
            return new Services.Data.Entities.RecognitionResult
            {
                Id = dto.Id.HasValue ? dto.Id.Value : 0,
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date.HasValue ? dto.Date.Value : new DateTime(),
                ImageDate = dto.ImageDate.HasValue ? dto.ImageDate.Value : new DateTime(),
                ImageName = dto.ImageName,
                ImagePath = dto.ImagePath,
                Style = dto.Style.HasValue ? dto.Style.Value : 0,
                AuthUserId = userId
            };
        }
    }
}
