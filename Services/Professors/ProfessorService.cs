using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTutorials.DataAccess;
using WebApiTutorials.EfModels;
using WebApiTutorials.ResultModels;
using WebApiTutorials.Services.Professors;

namespace WebApiTutorials.Services
{
    /// <summary>
    /// Class to retrieve professor data
    /// </summary>
    public class ProfessorService : IProfessor
    {
        private readonly AppDbContext _Db;
        public ProfessorService(AppDbContext db)
        {
            _Db = db;
        }

        /// <summary>
        /// Method to retrieve a list of professors
        /// </summary>
        /// <returns>a list of professor</returns>
        public async Task<IEnumerable<ProfessorResult>> GetAll()
        {
            return await _Db.Professor
                            .Select(p => new ProfessorResult
                            {
                                Id = p.Id,
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                Profession = p.Profession,
                                University = p.university.UniversityName,
                                Department = p.department.DepartmentName,
                                Suffix = p.suffix.SuffixInitial,
                                ReviewsCount = p.Reviews.Count(),
                                AverageRating = p.Reviews
                                                .Select(x => x.Quality).Average().ToString("#.#"),
                                Review = p.Reviews
                                        .Select(r => new ProfessorReviewResponse
                                        {
                                            ReviewText = r.ReviewText,
                                            Lname = r.User.Lname,
                                            Fname = r.User.Fname,
                                            Id = r.Id,
                                            ProfessorId = r.ProfessorId
                                        })
                                        .FirstOrDefault(),
                            })
                            .ToListAsync();
        }

        /// <summary>
        /// method to return a professor by the Id
        /// </summary>
        /// <param name="id">Id to use for the lookup</param>
        /// <returns>a professor</returns>
        public async Task<IEnumerable<ProfessorResult>> GetOne(int id)
        {
            var prof = _Db.Professor.Select(p => new ProfessorResult
            {
                UniversityId = p.university.Id,
                DepartmentId = p.department.Id,
                Id = p.Id
            }).Where(p => p.Id == id).FirstOrDefault();

            /// Getting the list of grades
            var grades = _Db.Grade.Select(g => new
            {
                id = g.Id,
                letterGrade = g.GradeLetter
            }).ToList();

            /// Selecting similar professors
            var otherProfs = _Db.Professor.Select(p => new otherProf
            {
                Firstname = p.FirstName,
                Lastname = p.LastName,
                Id = p.Id,
                UniversityId = p.university.Id,
                AverageRating = p.Reviews.Select(r => r.Quality).Average(),
                DepartmentId = p.department.Id
            }).Where(p => p.Id != prof.Id && p.UniversityId == prof.UniversityId && p.DepartmentId == prof.DepartmentId).ToList();

            /// Computing the percentage of retake
            var q = _Db.Review.ToList();
            decimal total = q.Count(r => r.ProfessorId == id);
            decimal TotalYes = q.Count(r => r.Retake == "yes" && r.ProfessorId == id);
            var resultPercent = ((TotalYes / total) * 100);
            var Percent = string.Format(resultPercent % 1 == 0 ? "{0:0.0}" : "{0:0.0}", resultPercent);
            return await _Db.Professor
                        .Select(p => new ProfessorResult
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Profession = p.Profession,
                            University = p.university.UniversityName,
                            Department = p.department.DepartmentName,
                            Suffix = p.suffix.SuffixInitial,
                            Grade = grades,
                            AverageRating = p.Reviews
                                               .Select(x => x.Quality).Average().ToString("#.#"),
                            ReviewsCount = p.Reviews.Count(),
                            RetakePercentage = Percent,
                            AverageDifficulty = p.Reviews
                                                .Select(x => (x.Difficulty)).Average().ToString("0.#"),
                            BestReview = p.Reviews.Select(r => new ReviewResponse
                            {
                                Review = r.ReviewText,
                                Course = r.course.CourseName,
                                Quality = r.Quality

                            }).Where(r => r.Quality > 3).FirstOrDefault(),
                            otherProfessors = otherProfs,
                        })

                        .Where(p => p.Id == id)
                        .ToListAsync();
        }
    }
}