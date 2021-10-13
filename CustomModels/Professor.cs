namespace WebApiTutorials.CustomModels
{
    public class Professor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public int SuffixId { get; set; }
        public int DepartmentId { get; set; }
        public int UniversityId { get; set; }
        public int CourseId { get; set; }
        public int PictureId { get; set; }
    }
}