using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApiTutorials.EfModels;

namespace WebApiTutorials.EfModels
{
    /// <summary>
    /// Create a professor class
    /// </summary>
    public class Professor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual Suffix suffix { get; set; }
        public virtual Department department { get; set; }
        public virtual University university { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual Picture picture { get; set; }
    }
}