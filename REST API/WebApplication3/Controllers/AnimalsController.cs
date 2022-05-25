using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        private IDatabaseService _dbService;

        public AnimalsController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetAnimals([FromQuery] string orderBy)
        {
            if (_dbService.ValidateValue(orderBy))
            {
                return Ok(_dbService.GetAnimals(orderBy));
            }
            else { return StatusCode(400, "wrong parameter value"); }
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            _dbService.AddAnimal(animal);
            return StatusCode(200, "Animal added");
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {

            _dbService.DeleteAnimal(idAnimal);
            return StatusCode(200, "Animal deleted");
        }

        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal(int idAnimal, [FromBody] Animal animal)
        {
            _dbService.UpdateAnimal(idAnimal, animal);
            return StatusCode(200, "Animal updated");
        }
    }
}
