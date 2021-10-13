using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTutorials.Services.Courses;

namespace WebApiTutorials.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _Repository;

        public CourseController(ICourse repository)
        {
            _Repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProfessorId"></param>
        /// <returns></returns>
        [HttpGet("{professorId}")]
        public async Task<ActionResult> GetCoursesWithReviewCount(int professorId)
        {
            var response = await _Repository.GetCoursesWithReviewCount(professorId);
            return Ok(response);
        }
    }
}