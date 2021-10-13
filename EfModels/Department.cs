using System.ComponentModel.DataAnnotations;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// professor's department
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string DepartmentName { get; set; }
    }
}