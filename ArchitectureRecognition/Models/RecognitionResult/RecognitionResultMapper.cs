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

        public Services.Data.Entities.RecognitionResult MapToEntity(RecognitionResultDto dto, string userId)
        {
            return new Services.Data.Entities.RecognitionResult
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                ImageDate = dto.ImageDate,
                ImageName = dto.ImageName,
                ImagePath = dto.ImagePath,
                Style = dto.Style,
                UserId = userId
            };
        }
    }
}
