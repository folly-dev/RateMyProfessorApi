namespace WebApiTutorials.ResultModels
{
    public class otherProf
    {
        public int Id { get; set; }
        public decimal AverageRating { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int UniversityId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}