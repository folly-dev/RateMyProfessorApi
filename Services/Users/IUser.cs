using System.Threading.Tasks;
using WebApiTutorials.EfModels;

namespace WebApiTutorials.Services.Users
{
    /// <summary>
    /// User authentication repository
    /// </summary>
    public interface IUser
    {
        Task<UserResponse> CreateAccount(User user);
        UserResponse Login(Login login);
    }
}