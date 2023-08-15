using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslist_csharp.Services
{
  public class HousesService
  {
    private readonly HousesRepository _housesRepository;

    public HousesService(HousesRepository housesRepository)
    {
      _housesRepository = housesRepository;
    }

    internal List<House> GetHouses()
    {
      List<House> houses = _housesRepository.GetHouses();
      return houses;
    }

    internal House GetHouseById(int houseId)
    {
      House house = _housesRepository.GetHouseById(houseId);
      return house ?? throw new Exception($"[NO HOUSE MATCHES THE ID: {houseId}]");
    }

    internal House CreateHouse(House houseData)
    {
      int houseId = _housesRepository.CreateHouse(houseData);
      House house = GetHouseById(houseId);
      return house;
    }

    internal House UpdateHouse(House houseData)
    {
      House originalHouse = GetHouseById(houseData.Id);
      originalHouse.Bedrooms = houseData.Bedrooms ?? originalHouse.Bedrooms;
      originalHouse.Bathrooms = houseData.Bathrooms ?? originalHouse.Bathrooms;
      originalHouse.Year = houseData.Year ?? originalHouse.Year;
      originalHouse.Price = houseData.Price ?? originalHouse.Price;
      originalHouse.Description = houseData.Description ?? originalHouse.Description;
      House house = _housesRepository.UpdateHouse(originalHouse);
      return house;
    }

    internal void RemoveHouse(int houseId)
    {
      _housesRepository.RemoveHouse(houseId);
    }
  }
}