using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTutorials.EfModels;
using WebApiTutorials.RequestModels;
using WebApiTutorials.Services.Users;

namespace WebApiTutorials.Controllers
{
    /// <summary>
    /// user authentication controller class
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _Repository;
        public UserController(IUser repository)
        {
            _Repository = repository;
        }

        /// <summary>
        /// Method that handles the Sign up
        /// </summary>
        /// <param name="firstName">user's firstname</param>
        /// <param name="lastName">user's lastname</param>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <returns>a response object when Sign up is successfull, unsuccessfull message otherwise</returns>
        [HttpPost("CreateAccount")]
        public async Task<ActionResult> CreateAccount([FromBody] CreateUserRequest createUser)
        {
            var user = new User
            {
                Lname = createUser.LastName,
                Fname = createUser.FirstName,
                Email = createUser.Email,
                Password = createUser.Password
            };
            var response = await _Repository.CreateAccount(user);
            if (response != null) return Ok(response);
            return BadRequest("Email already exists. or invalid email or password format");
        }

        /// <summary>
        /// Method that handles the Sign in 
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <returns>a response object when Sign in is successfull, unsuccessful message otherwise</returns>
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUserRequest login)
        {

            var userLogin = new Login
            {
                Email = login.Email,
                Password = login.Password
            };
            var response = _Repository.Login(userLogin);
            if (response != null) return Ok(response);
            return BadRequest("Email or Password is wrong");
        }
    }
}