namespace WebApiTutorials.ResultModels
{
    public class ProfessorReviewResponse
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public int ProfessorId { get; set; }
    }
}