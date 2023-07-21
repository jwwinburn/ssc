using System;
using System.ComponentModel.DataAnnotations;

namespace ServerSideApiAttempt1.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        //public int UserTypeId { get; set; }
        public int Zipcode { get; set; }

    }
}
