using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTutorials.EfModels;
using WebApiTutorials.ResultModels;

namespace WebApiTutorials.Services.Reviews
{
    /// <summary>
    /// Reviews repository
    /// </summary>
    public interface IReview
    {
        Task<string> CreateReview(Review review);
        Task<string> DeleteReview(int id);
        Task<IEnumerable<object>> GetAll(int professorId);
        Task<IEnumerable<object>> GetReviews(int userId);
        Task<IEnumerable<object>> GetReviewOnCourse(int courseId, int professorId);
        Task<IEnumerable<object>> GetReviewCountPerCourse(int professorId);
    }
}