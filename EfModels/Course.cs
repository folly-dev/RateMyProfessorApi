using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Professor's course class
    /// </summary>
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        public int ProfessorId { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}