using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTutorials.EfModels;
using WebApiTutorials.ResultModels;

namespace WebApiTutorials.Services.Professors
{
    /// <summary>
    /// Professor repository
    /// </summary>
    public interface IProfessor
    {
        Task<IEnumerable<ProfessorResult>> GetAll();
        Task<IEnumerable<ProfessorResult>> GetOne(int id);
    }
}