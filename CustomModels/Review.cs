

namespace WebApiTutorials.CustomModels
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Quality { get; set; }
        public int Difficulty { get; set; }
        public string ForCredit { get; set; }
        public string Attendance { get; set; }
        public string Retake { get; set; }
        public string Textbook { get; set; }
        public int GradeId { get; set; }
        public int ProfessorId { get; set; }
        public int UserId { get; set; }

    }
}