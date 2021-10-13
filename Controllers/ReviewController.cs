using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTutorials.EfModels;
using WebApiTutorials.RequestModels;
using WebApiTutorials.Services.Reviews;

namespace WebApiTutorials.Controllers
{
    /// <summary>
    /// Class that controls the review data
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _Repository;
        public ReviewController(IReview repository)
        {
            _Repository = repository;
        }

        /// <summary>
        /// Method to create a review
        /// </summary>
        /// <param name="review">review</param>
        /// <param name="rating">rating</param>
        /// <param name="professorId">professor reviewed</param>
        /// <param name="userId">user who reviewed the professor</param>
        /// <returns>Success message, otherwise error message</returns>
        [HttpPost("{professorId:int}/{userId:int}")]
        public async Task<ActionResult> PostReview(int professorId, int userId, [FromBody] PostReviewRequest review)
        {
            var reviews = new Review
            {
                ReviewText = review.Review,
                Attendance = review.Attendance,
                ForCredit = review.ForCredit,
                Retake = review.Retake,
                Textbook = review.Textbook,
                Quality = review.Quality,
                Difficulty = review.Difficulty,
                CourseId = review.CourseId,
                ProfessorId = review.ProfId,
                UserId = review.UserId,
                GradeId = review.GradeId
            };

            var response = await _Repository.CreateReview(reviews);
            if (response != null) return Ok(response);
            return BadRequest("Create review failed!");
        }

        /// <summary>
        /// Method to update a review
        /// </summary>
        /// <param name="id">Id of the review to be updated</param>
        /// <returns>Successufull update message, otherwise error message</returns>
        [HttpPut("{reviewId}")]
        /* public async Task<ActionResult> PatchReview(int reviewId, [FromBody] PatchReviewRequest review)
        {
            var Updatedreview = new Review
            {
                Id = reviewId,
                ReviewText = review.ReviewText,
                Quality = review.Quality,
                Attendance = review.Attendance,
                Retake = review.Retake,
                Textbook = review.Textbook,
                CourseId = review.CourseId,
                GradeId = review.GradeId,
                Difficulty = review.Difficulty
            };
            var response = await _Repository.UpdateReview(Updatedreview);
            if (response != null) return Ok(response);
            return BadRequest("Update review failed");
        } */

        [HttpGet("{professorId:int}")]
        public async Task<ActionResult> GetAll(int professorId)
        {
            var response = await _Repository.GetAll(professorId);
            if (response != null) return Ok(response);
            return NotFound("Something Failed, Please Refresh the page");
        }

        [HttpGet("{courseId:int}/{professorId:int}")]
        public async Task<ActionResult> GetQueriedReview(int courseId, int professorId)
        {
            var response = await _Repository.GetReviewOnCourse(courseId, professorId);
            if (response != null) return Ok(response);
            return NotFound("Something Failed, Please Refresh the page");
        }

        /// <summary>
        /// Method to delete a review
        /// </summary>
        /// <param name="id">Id of the review to be deleted</param>
        /// <returns>Successufull delete message, otherwise error message</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var response = await _Repository.DeleteReview(id);
            if (response != null) return Ok(response);
            return BadRequest("Delete review failed");
        }

        /// <summary>
        /// Method to retrieve a list of reviews based on the user Id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>a list all the reviews by a specific user</returns>
        [HttpGet("/profile/{userId}")]
        public async Task<ActionResult> GetAllReviewsOnUserProfile(int userId)
        {
            var response = await _Repository.GetReviews(userId);
            return Ok(response);
        }


    }
}