using System.ComponentModel.DataAnnotations;

namespace ArchitectureRecognition.Models.Auth
{
    public sealed class SignInModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
