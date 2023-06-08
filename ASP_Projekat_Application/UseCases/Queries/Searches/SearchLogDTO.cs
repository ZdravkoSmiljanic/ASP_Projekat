namespace ASP_Projekat_Application.UseCases.Queries.Searches
{
    public class SearchLogDTO
    {
        public string Keyword { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
