using System.ComponentModel.DataAnnotations;

namespace Auth_Ex_Identity.Models.Dto
{
    public class RegisterDto
    {
        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }

        [Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }

        public required string Name { get; set; }
        public required string Surname { get; set; }

        public required string UserName { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }

        public required DateOnly BirthDate { get; set; }

        public required string Gender { get; set; }
    }
}
