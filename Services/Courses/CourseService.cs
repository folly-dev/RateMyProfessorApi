using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTutorials.DataAccess;

namespace WebApiTutorials.Services.Courses
{
    public class CourseService : ICourse
    {
        private readonly AppDbContext _Db;
        public CourseService(AppDbContext db)
        {
            _Db = db;
        }

        public async Task<IEnumerable<object>> GetCoursesWithReviewCount(int professorId)
        {



            /* return await _Db.Review.Where(r => r.ProfessorId == professorId).GroupBy(x => x.course.CourseName).Select(x => new
            {
                courseName = x.Key,
                count = x.Count()
            }).ToListAsync(); */
            return await _Db.Course.Select(x => new
            {
                courseName = x.CourseName,
                Count = x.Reviews.Count(),
                professorId = x.ProfessorId,
                CourseId = x.Id
            }).Where(x => x.professorId == professorId).ToListAsync();

            /*  return await _Db.Course.Join(_Db.Review, c => c.Id, r => r.CourseId, (c, r) => new { c }).GroupBy(x => x.c.CourseName).Select(y => new
             {
                 CoursesName = y.Key,
                 count = y.Count()
             }).ToListAsync(); */
        }
    }
}