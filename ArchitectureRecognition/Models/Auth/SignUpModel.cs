using System.ComponentModel.DataAnnotations;

namespace ArchitectureRecognition.Models.Auth
{
    public sealed class SignUpModel
    {
        [Required]
        public SignInModel SignInModel { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
