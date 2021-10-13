namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Class that returns a response object after login
    /// </summary>
    public class UserResponse
    {
        public int Id { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
    }
}