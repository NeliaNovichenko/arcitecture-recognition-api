using System;
using ArchitectureRecognition.Services.Data.Entities;

namespace ArchitectureRecognition.Models.RecognitionResult
{
    public sealed class RecognitionResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public DateTime ImageDate { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        
        public Style Style { get; set; }
    }
}
