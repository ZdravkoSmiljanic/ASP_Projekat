using Microsoft.AspNetCore.Http;

namespace ASP_Projekat_Application.UseCases.DTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public IFormFile? ImageId { get; set; }
        public string? ImageFileName { get; set; }
    }
}
