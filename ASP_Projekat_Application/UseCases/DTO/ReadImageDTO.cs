namespace ASP_Projekat_Application.UseCases.DTO
{
    public class ReadImageDTO
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ImageSize { get; set; }
        public bool? IsActive { get; set; }
    }
}
