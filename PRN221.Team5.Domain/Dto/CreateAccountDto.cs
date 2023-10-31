using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Domain.Dto
{
    public class CreateAccountDto
    {

        [Required]
        public string Username { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
