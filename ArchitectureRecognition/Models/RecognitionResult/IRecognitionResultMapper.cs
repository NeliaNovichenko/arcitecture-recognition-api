namespace ArchitectureRecognition.Models.RecognitionResult
{
    public interface IRecognitionResultMapper
    {
        RecognitionResultDto MapToDto(Services.Data.Entities.RecognitionResult task);
        Services.Data.Entities.RecognitionResult MapToEntity(RecognitionResultDto dto, string userId);
    }
}
