using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ArchitectureRecognition.Models.RecognitionResult
{
    public class SaveRecognitionDto
    {
        public string resultDto { get; set; }
        public IFormFile file { get; set; }
    }
}
