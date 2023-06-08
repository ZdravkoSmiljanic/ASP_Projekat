namespace ASP_Projekat_Application.UseCases.Queries.Searches
{
    public class SerachBlogDTO:PageSearch
    {
        public string Keyword { get; set; }
        public bool? HasReactions { get; set; }
    }
}
