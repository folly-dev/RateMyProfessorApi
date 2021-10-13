using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiTutorials.DataAccess;
using WebApiTutorials.EfModels;


namespace WebApiTutorials.Services.Users
{


    /// <summary>
    /// Class that handles the user authentication
    /// </summary>
    public class UserService : IUser
    {
        private readonly Regex EmailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        readonly Regex HasNumber = new Regex(@"[0-9]+");
        readonly Regex HasUpperCase = new Regex(@"[A-Z]+");
        readonly Regex HasMinChar = new Regex(@".{8,}");
        readonly Regex HasLowerChar = new Regex(@"[a-z]+");
        readonly Regex HasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        private readonly AppDbContext _Db;
        public UserService(AppDbContext db)
        {
            _Db = db;
        }
        /// <summary>
        /// Method to Sign a user up
        /// </summary>
        /// <param name="user">user object to save to the database</param>
        /// <returns>the Id of the user created</returns>
        public async Task<UserResponse> CreateAccount(User user)
        {
            int result;
            var isEmailValid = EmailValidator.IsMatch(user.Email);
            var isPasswordValid = HasNumber.IsMatch(user.Password) && HasUpperCase.IsMatch(user.Password)
                                            && HasMinChar.IsMatch(user.Password) && HasLowerChar.IsMatch(user.Password)
                                            && HasSymbols.IsMatch(user.Password);
            if (isEmailValid && isPasswordValid)
            {
                result = _Db.User.Count(x => x.Email == user.Email);
                if (result == 0)
                {
                    var hashedPass = PassEncryptor(user.Password);
                    user.Password = hashedPass;
                    _Db.User.Add(user);
                    await _Db.SaveChangesAsync();
                    return new UserResponse
                    {
                        Id = user.Id,
                        Lname = user.Lname,
                        Fname = user.Fname
                    };
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Method to Sign a user In
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <returns>a success message to </returns>
        public UserResponse Login(Login login)
        {
            var user = _Db.User.FirstOrDefault(u => u.Email == login.Email);
            if (user.Email.Any())
            {
                var hashedPassword = PassEncryptor(login.Password);
                if (hashedPassword == user.Password)
                {
                    return new UserResponse
                    {
                        Id = user.Id,
                        Lname = user.Lname,
                        Fname = user.Fname
                    };
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Method that return the hashed value of the password
        /// </summary>
        /// <param name="password">the password to be hashed</param>
        /// <returns>the string representation of the hashed password</returns>
        public string PassEncryptor(string password)
        {
            using var encryptMethod = SHA256.Create();
            var encryptedPass = encryptMethod.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(encryptedPass).Replace("-", "").ToLower();
        }
    }
}