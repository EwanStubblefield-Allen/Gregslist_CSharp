
namespace gregslist_csharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{

  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }

  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{carId}")]
  public ActionResult<string> RemoveCar(int carId)
  {
    try
    {
      Car car = _carsService.RemoveCar(carId);

      return Ok($"{car.Make} {car.Model} was deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{carId}")]
  public ActionResult<Car> UpdateCar(int carId, [FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.UpdateCar(carId, carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
