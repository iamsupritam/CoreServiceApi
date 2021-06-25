using System.ComponentModel.DataAnnotations;

namespace CoreServiceApi.Models
{
    public class User
    {
        [Key]
        public int Id{get;set;}

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName{get;set;}

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}