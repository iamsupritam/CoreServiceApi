using System.ComponentModel.DataAnnotations;

namespace CoreServiceApi.DataTransferModels
{
    public class UserCreateDto
    {

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