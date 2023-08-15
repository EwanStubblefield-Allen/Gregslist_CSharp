
namespace gregslist_csharp.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepository;

  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }

  internal Car CreateCar(Car carData)
  {
    int carId = _carsRepository.CreateCar(carData);

    Car car = GetCarById(carId);

    return car;
  }

  internal Car GetCarById(int carId)
  {
    Car car = _carsRepository.GetCarById(carId);

    if (car == null)
    {
      throw new Exception($"{carId} is not a valid ID");
    }


    return car;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _carsRepository.GetCars();
    return cars;
  }

  internal Car RemoveCar(int carId)
  {
    Car car = GetCarById(carId);
    _carsRepository.RemoveCar(carId);
    return car;
  }

  internal Car UpdateCar(int carId, Car carData)
  {
    Car originalCar = GetCarById(carId);

    originalCar.Make = carData.Make ?? originalCar.Make;
    originalCar.Model = carData.Model ?? originalCar.Model;
    originalCar.Color = carData.Color ?? originalCar.Color;

    // NOTE we have to make these nullable in our class model for this to work
    originalCar.Price = carData.Price ?? originalCar.Price;
    originalCar.Year = carData.Year ?? originalCar.Year;
    originalCar.OwnedByGrandma = carData.OwnedByGrandma ?? originalCar.OwnedByGrandma;

    Car car = _carsRepository.UpdateCar(originalCar);

    return car;
  }
}
