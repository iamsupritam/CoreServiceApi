using System.ComponentModel.DataAnnotations;

namespace CoreServiceApi.DataTransferModels
{
    public class UserReadDto
    {
        public int Id{get;set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName{get;set;}
    }
}