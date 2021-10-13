using Microsoft.AspNetCore.Mvc;
using WebApiTutorials.EfModels;
using System.Collections.Generic;
using System.Linq;
using WebApiTutorials.Services.Professors;
using System.Threading.Tasks;

namespace WebApiTutorials.Controllers
{
    /// <summary>
    /// Class to handle professor's data
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private IProfessor _Repository;
        public ProfessorController(IProfessor repository)
        {
            _Repository = repository;
        }

        /// <summary>
        /// Gets all the professors and reviews
        /// </summary>
        /// <returns>a list of professors data</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _Repository.GetAll();
            if (result != null) return Ok(result);
            return NotFound("No Data");
        }

        /// <summary>
        /// Gets a single professor by the Id
        /// </summary>
        /// <param name="id">the id of the professor to look for</param>
        /// <returns>a professor</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var result = await _Repository.GetOne(id);
            if (result != null) return Ok(result);
            return NotFound();
        }
    }
}