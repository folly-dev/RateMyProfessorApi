using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiTutorials.Services.Courses
{
    public interface ICourse
    {
        Task<IEnumerable<object>> GetCoursesWithReviewCount(int professorId);
    }
}