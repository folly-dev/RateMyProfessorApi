using System.ComponentModel.DataAnnotations;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Create user class
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}