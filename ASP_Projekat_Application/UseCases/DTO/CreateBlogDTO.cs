namespace ASP_Projekat_Application.UseCases.DTO
{
    public class CreateBlogDTO
    {
        public int UserId { get; set; }
        public string BlogText{ get; set; }
        public ICollection<BlogImageDTO> BlogImages { get; set; }
        public ICollection<BlogTagDTO> BlogTags { get; set; }

    }

    public class BlogImageDTO
    {
        public int ImageId{ get; set; }
    }
    public class BlogTagDTO
    {
        public int TagId { get; set; }
    }
}
