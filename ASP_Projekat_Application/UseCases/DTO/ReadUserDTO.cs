namespace ASP_Projekat_Application.UseCases.DTO
{
    public class ReadUserDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? ProfilImage { get; set; }
        public ICollection<ReadUserBlogDTO> Blogs { get; set; }
        public ICollection<ReadUserCommentsDTO> Comments { get; set; }
    }

    public class ReadUserBlogDTO
    {
        public int id { get; set; }
        public string BlogText { get; set; }
    }

    public class ReadUserCommentsDTO
    {
        public string TextComment { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
    }
}
