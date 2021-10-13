using System.Collections.Generic;

namespace WebApiTutorials.ResultModels
{
    public class SingleProfReviewResponse
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public int ProfessorId { get; set; }

    }
}