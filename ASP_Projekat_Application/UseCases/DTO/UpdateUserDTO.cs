﻿namespace ASP_Projekat_Application.UseCases.DTO
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int? ProfileImageId { get; set; }
    }
}
