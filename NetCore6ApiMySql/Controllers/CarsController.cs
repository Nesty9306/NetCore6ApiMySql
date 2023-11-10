using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6ApiMySql.Data.Repositories;
using NetCore6ApiMySql.Model;

namespace NetCore6ApiMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository) {
          _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _carRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _carRepository.InsertCar(car);

            return Created("created", created);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _carRepository.UpdateCar(car);

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCard(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });

            return NoContent();
        }
    }
}
