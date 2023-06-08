namespace ASP_Projekat_Application.UseCases.DTO
{
    public class ReadCommentDTO
    {
        public string UserName { get; set; }
        public DateTime CreateAt { get; set; }
        public string Text { get; set; }
        public ICollection<SubCommentsDTO>? ChildComments { get; set; }
    }
    public class SubCommentsDTO
    {
        public string TextSubComment { get; set; }
    }

    
}
