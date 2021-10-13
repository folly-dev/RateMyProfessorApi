namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Class that receives the login inputs
    /// </summary>
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}