using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Professor's review
    /// </summary>
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]

        [Column(TypeName = "decimal(18, 1)")]
        public decimal Quality { get; set; }

        [Column(TypeName = "decimal(18, 1)")]
        public decimal Difficulty { get; set; }
        public string ForCredit { get; set; }
        public string Attendance { get; set; }
        public string Retake { get; set; }
        public string Textbook { get; set; }
        public int GradeId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual User User { get; set; }
        public virtual Course course { get; set; }
        public virtual Professor professor { get; set; }
    }
}