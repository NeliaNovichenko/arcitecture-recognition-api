using System.Collections.Generic;

namespace ArchitectureRecognition.Services.Data.Entities
{
    public sealed class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<RecognitionResult> RecognitionResults { get; set; }
    }
}
