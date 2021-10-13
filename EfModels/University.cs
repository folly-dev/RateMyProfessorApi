using System.ComponentModel.DataAnnotations;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Professor university
    /// </summary>
    public class University
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string UniversityName { get; set; }
    }
}