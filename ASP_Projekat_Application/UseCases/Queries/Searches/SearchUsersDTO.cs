namespace ASP_Projekat_Application.UseCases.Queries.Searches
{
    public class SearchUsersDTO
    {
        public string? keyword { get; set; }
        public bool? HasComments { get; set; }
        public bool? HasBlogs { get; set; }
    }
}
