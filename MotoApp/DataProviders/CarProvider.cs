using MotoApp.DataProviders.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProviders;

public class CarProvider : ICarProvider
{
    private readonly IRepository<Car> _carsRepository;
    public CarProvider(IRepository<Car> carRepository)
    {
        _carsRepository = carRepository;
    }
    public List<Car> FilterCarsPrice(decimal txt)
    {
        var cars = _carsRepository.GetAll();
        var list = new List<Car>();
        decimal minPrice = Convert.ToDecimal(txt);
        foreach (var car in cars)
        {
            if (car.ListPrice <= minPrice)
            {
                list.Add(car);
            }
        }
        return list;
    }
    //Get By & Annonymous 
    public List<string> GetUniqueCarsColors()
    {
        var cars = _carsRepository.GetAll();
        var colors = cars.Select(c => c.Color).Distinct().ToList();
        return colors;
    }
    public decimal GetMinimumPriceOfAllCars()
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(c => c.ListPrice).Min();
    }

    public List<Car> GetSpecyficColumns()
    {
        throw new NotImplementedException();
    }
    public string AnnonymousClass()
    {
        throw new NotImplementedException();
    }
    // Order By
    public List<Car> OrderByName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Name).ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(c => c.Name).ToList();

    }
    public List<Car> OrderByColorAndName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Color)
           .ThenBy(c => c.Name).ToList();

    }
    public List<Car> OrderByColorAndNameDescending()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(c => c.Color).
            ThenBy(c => c.Name).ToList();
    }

    // Where
    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(c => c.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWhenCostIsGreaterThan(decimal cost)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(c => c.ListPrice <= cost).ToList();
    }

    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(c => c.Name.StartsWith(prefix) && c.ListPrice <= cost).ToList();
    }

    public List<Car> WhereColorIs(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.ByColor(prefix).ToList();
    }

    // First Last Single
    public Car FirstByColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.First(c => c.Color == color);
    }
    public Car FirstOrDefaultByColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.FirstOrDefault(c => c.Color == color);
    }

    public Car FirstOrDefaultByColorWithDefault(string color)
    {

        var cars = _carsRepository.GetAll();
        return cars.FirstOrDefault(
            c => c.Color == color,
            new Car { Id = 0, Color = color, Name = "CCOLOR NOT FOND" });
    }

    public Car LastbyColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.LastOrDefault(
            c => c.Color == color,
            new Car { Id = 0, Color = color, Name = "CCOLOR NOT FOND" });
    }

    public Car SingleById(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.Single(c => c.Id == id);
    }

    public Car SingleOrDefault(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.SingleOrDefault(c => c.Id == id,
            new Car { Id = 0, Name = $"nie znaleziono  Id: {id}" });
    }

    // Tak

    public List<Car> TakeCars(int howMany)
    {
        var cares = _carsRepository.GetAll();
        return cares.OrderBy(c => c.Name)
            .Take(howMany)
            .ToList();
    }

    public List<Car> TakeCar(Range range)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(cars => cars.Id)
            .Take(range).ToList();
    }

    public List<Car> TakeCarsWhileNameStartWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Id)
            .TakeWhile(c => c.Name.StartsWith(prefix))
            .ToList();
    }

    // Skip 

    public List<Car> SkipCars(int howMany)
    {
        var cars = _carsRepository.GetAll();
        return cars.Skip(howMany).ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Name)
            .SkipWhile(c => c.Name.StartsWith(prefix))
            .ToList();
    }

    // Distinct

    public List<string> DistinctAllCollors()
    {
        var cars = _carsRepository.GetAll();
        return cars
            .Select(c => c.Color)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<Car> DistinctByColors()
    {
        var cars = _carsRepository.GetAll();
        return cars
            .DistinctBy(c => c.Color)
            .OrderBy(c => c.Color)
            .ToList();
    }
    // Chunk
    public List<Car[]> ChunkCars(int size)
    {
        var cars = _carsRepository.GetAll();
        return cars.Chunk(size).ToList();
    }


}
