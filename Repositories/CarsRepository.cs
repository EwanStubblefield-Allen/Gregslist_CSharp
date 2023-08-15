
namespace gregslist_csharp.Repositories;

public class CarsRepository
{

  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO cars (make, model, year, price, color, ownedByGrandma)
    VALUES (@Make, @Model, @Year, @Price, @Color, @OwnedByGrandma);
    SELECT LAST_INSERT_ID()
    ;";

    int carId = _db.ExecuteScalar<int>(sql, carData);

    // carData.Id = carId;

    return carId;
  }

  internal Car GetCarById(int carId)
  {
    // string sql = $"SELECT * FROM cars WHERE id = {carId};";
    string sql = $"SELECT * FROM cars WHERE id = @carId;";


    Car car = _db.QueryFirstOrDefault<Car>(sql, new { carId });

    return car;

  }

  internal List<Car> GetCars()
  {
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();

    return cars;

  }

  internal void RemoveCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1;";

    _db.Execute(sql, new { carId });
  }

  internal Car UpdateCar(Car originalCar)
  {
    string sql = @"
    UPDATE cars 
    SET
    make = @Make,
    model = @Model,
    color = @color,
    year = @Year,
    price = @Price,
    ownedByGrandma = @OwnedByGrandma
    WHERE id = @Id
    LIMIT 1;
    SELECT * FROM cars WHERE id = @Id
    ;";

    Car updatedCar = _db.QueryFirstOrDefault<Car>(sql, originalCar);

    return updatedCar;
  }
}
