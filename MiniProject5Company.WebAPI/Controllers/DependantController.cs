using Microsoft.AspNetCore.Mvc;
using MiniProject5Company.Domain.Entities;
using MiniProject5Company.Domain.Interfaces;
using MiniProject5Company.Infrastructure.Data.Repository;

namespace MiniProject5Company.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DependantController : ControllerBase
    {
        private readonly IDependantRepository _dependantRepository;

        public DependantController(IDependantRepository dependantRepository)
        {
            _dependantRepository = dependantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependant>>> GetAllDependant()
        {
            var dependant = await _dependantRepository.GetAllDependant();
            return Ok(dependant);
        }

        [HttpGet("{dependantno}")]
        public async Task<ActionResult<Dependant>> GetEmployeeById(int dependantno)
        {
            var dependant = await _dependantRepository.GetDependantById(dependantno);
            if (dependant == null)
            {
                return NotFound();
            }
            return Ok(dependant);
        }

        [HttpPost]
        public async Task<ActionResult<Dependant>> AddDepartment(Dependant dependant)
        {
            var createddependant = await _dependantRepository.AddDependant(dependant);
            return Ok(createddependant);
        }

        [HttpPut("{dependantno}")]
        public async Task<IActionResult> UpdateEmployee(int dependantno, Dependant dependant)
        {
            if (dependantno != dependant.Dependantno) return BadRequest();

            var updatedDepartment = await _dependantRepository.UpdateDependant(dependant);
            return Ok(updatedDepartment);
        }

        [HttpDelete("{dependantno}")]
        public async Task<ActionResult<bool>> DeleteBook(int deptNo)
        {
            var deleted = await _dependantRepository.DeleteDependant(deptNo);
            if (!deleted) return NotFound();
            return Ok("department has been deleted !");
        }
    }
}
