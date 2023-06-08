namespace ASP_Projekat_Application.UseCases.DTO
{
    public class ReadBlogDTO
    {
        public string TextContent { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ReadBlogComments>? ReadBlogComments { get; set; }
        public ICollection<ReadBlogReactions>? ReadBlogReactions { get; set; }
    }

    public class ReadBlogComments
    {
        public string TextComment { get; set; }
        public int? ParentId { get; set; }
    }

    public class ReadBlogReactions
    {
        public string UserReacted { get; set; }
        public string ReactionName { get; set; }
    }
}
