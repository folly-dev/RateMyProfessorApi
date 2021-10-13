using System.Linq;
using System.Threading.Tasks;
using WebApiTutorials.EfModels;
using WebApiTutorials.DataAccess;
using System.Collections.Generic;
using WebApiTutorials.ResultModels;
using Microsoft.EntityFrameworkCore;

namespace WebApiTutorials.Services.Reviews
{
    /// <summary>
    /// Class to post, delete, and update a review in the DB
    /// </summary>
    public class ReviewService : IReview
    {
        private readonly AppDbContext _Db;
        public ReviewService(AppDbContext db)
        {
            _Db = db;
        }

        /// <summary>
        /// Method to create a review
        /// </summary>
        /// <param name="review">review to be created</param>
        /// <returns>Success message</returns>
        public async Task<string> CreateReview(Review review)
        {
            var result = _Db.Review.Add(review);
            await _Db.SaveChangesAsync();
            if (result != null)
            {
                return $"Review is successfully created : {review.Id}";
            }
            return "Something failed. Please retry!";
        }

        /// <summary>
        /// Method to delete a review
        /// </summary>
        /// <param name="id">Id of the review to be deleted</param>
        /// <returns>Success message</returns>
        public async Task<string> DeleteReview(int id)
        {
            var reviewToDelete = _Db.Review.FirstOrDefault(r => r.Id == id);
            if (reviewToDelete != null)
            {
                _Db.Review.Remove(reviewToDelete);
                await _Db.SaveChangesAsync();
                return "Review Successfully deleted";
            }
            return null;
        }

        public async Task<IEnumerable<object>> GetAll(int professorId)
        {
            return await _Db.Review.Select(r => new
            {
                Attendance = r.Attendance,
                ReviewText = r.ReviewText,
                Retake = r.Retake,
                Textbook = r.Textbook,
                ForCredit = r.ForCredit,
                Grade = r.Grade.GradeLetter,
                Course = r.course.CourseName,
                Quality = r.Quality.ToString("#.#"),
                Difficulty = r.Difficulty.ToString("#.#"),
                ProfessorId = r.ProfessorId
            }).Where(x => x.ProfessorId == professorId).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetReviewCountPerCourse(int professorId)
        {
            return await _Db.Review.Join(_Db.Course, r => r.CourseId, c => c.Id, (r, c) => new
            {
                ProfessorId = r.ProfessorId,
                CourseId = r.course.Id,
                Courses = r.course.CourseName,
                ReviewCountPerCourse = r.ReviewText.Count(),
            }).Where(r => r.ProfessorId == professorId).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetReviewOnCourse(int courseId, int professorId)
        {
            return await _Db.Review.Select(r => new
            {
                Attendance = r.Attendance,
                Retake = r.Retake,
                ReviewText = r.ReviewText,
                Textbook = r.Textbook,
                ForCredit = r.ForCredit,
                Grade = r.Grade.GradeLetter,
                Course = r.course.CourseName,
                Quality = r.Quality.ToString("#.#"),
                Difficulty = r.Difficulty.ToString("#.#"),
                ProfessorId = r.ProfessorId,
                courseId = r.course.Id
            }).Where(x => x.ProfessorId == professorId && x.courseId == courseId).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetReviews(int userId)
        {

            return await _Db.Review.Select(p => new
            {
                FirstName = p.professor.FirstName,
                LastName = p.professor.LastName,
                Course = p.course.CourseName,
                review = p.ReviewText,
                Quality = p.Quality,
                Difficulty = p.Difficulty,
                Id = p.Id,
                userId = p.UserId
            }).Where(p => p.userId == userId).ToListAsync();
        }

    }
}