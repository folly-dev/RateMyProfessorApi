using System.Collections.Generic;
using WebApiTutorials.EfModels;

namespace WebApiTutorials.ResultModels
{
    public class ProfessorResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public int ReviewsCount { get; set; }
        public string AverageRating { get; set; }
        public string RetakePercentage { get; set; }
        public string AverageDifficulty { get; set; }
        public ProfessorReviewResponse Review { get; set; }
        public object BestReview { get; set; }
        public List<Course> CourseResult { get; set; }
        public object Grade { get; set; }
        public object Reviews { get; set; }
        public string Suffix { get; set; }
        public string Department { get; set; }
        public string University { get; set; }
        public object otherProfessors { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
    }
}