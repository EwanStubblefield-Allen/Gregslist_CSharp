using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_csharp.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<House> GetHouses()
    {
      string sql = "SELECT * FROM houses;";
      List<House> houses = _db.Query<House>(sql).ToList();
      return houses;
    }

    internal House GetHouseById(int houseId)
    {
      string sql = "SELECT * FROM houses WHERE id = @houseId;";
      House house = _db.QueryFirstOrDefault<House>(sql, new { houseId });
      return house;
    }

    internal int CreateHouse(House houseData)
    {
      string sql = @"
      INSERT INTO
        houses( bedrooms, bathrooms, year, price, description )
        VALUES ( @Bedrooms, @Bathrooms, @Year, @Price, @Description );
        SELECT LAST_INSERT_ID()
      ;";
      int houseId = _db.ExecuteScalar<int>(sql, houseData);
      return houseId;
    }

    internal House UpdateHouse(House houseData)
    {
      string sql = @"
      UPDATE houses SET
      bedrooms = @Bedrooms,
      bathrooms = @Bathrooms,
      year = @Year,
      price = @Price,
      description = @Description
      WHERE id = @Id LIMIT 1;
      SELECT * FROM houses WHERE id = @Id
      ;";
      House house = _db.QueryFirstOrDefault<House>(sql, houseData);
      return house;
    }

    internal void RemoveHouse(int houseId)
    {
      string sql = "DELETE FROM houses WHERE id = @houseId;";
      _db.Execute(sql, new { houseId });
    }
  }
}