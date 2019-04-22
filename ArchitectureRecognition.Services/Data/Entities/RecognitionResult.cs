using System;

namespace ArchitectureRecognition.Services.Data.Entities
{
    public class RecognitionResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }


        public DateTime ImageDate { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public Style Style { get; set; }

    }
}
