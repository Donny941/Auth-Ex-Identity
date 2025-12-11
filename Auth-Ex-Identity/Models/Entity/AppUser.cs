using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Auth_Ex_Identity.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateOnly BirthDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }

        public string Gender { get; set; }

    }
}
