using MotoApp.Repositories;
using MotoApp.DataProviders.Extensions;
using MotoApp.Entities;
using MotoApp.Repositories;
using System.Text;

namespace MotoApp.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;
        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<string> GetUniqueCarColors()
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

        public List<Car> GetSpecyficsColumns()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new Car
            {
                Id = car.Id,
                Name = car.Name,
                Type = car.Type,
                Color = car.Color,
                ListPrice = car.ListPrice

            }).ToList();
            return list;
        }
        public string AnonymousClass()
        {
            var cars = _carsRepository.GetAll();
            var list = cars.Select(car => new
            {
                Identifier = car.Id,
                ProductName = car.Name,
                ProductType = car.Type
            });

            StringBuilder sb = new(1048);
            foreach (var car in list)
            {
                sb.Append($"Product Id: {car.Identifier} ");
                sb.Append($" Product Name: {car.ProductName}");
                sb.Append($" Product Type: {car.ProductType}");
            }
            return sb.ToString();
        }

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
                        .ThenBy(c => c.Name)
                        .ToList();
        }

        public List<Car> OrderByColorAndNameDesc()
        {
            var cars = _carsRepository.GetAll();
            return cars.OrderByDescending(c => c.ListPrice)
                       .ThenByDescending(c => c.Name)
                       .ToList();

        }

        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(c => c.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
        {
            var cars = _carsRepository.GetAll();
            return cars.Where(c => c.Name.StartsWith(prefix) && c.StandardCost > cost).ToList();
        }

        public List<Car> WhereColorIs(string prefix)
        {
            var cars = _carsRepository.GetAll();
            return cars.ByColor(prefix).ToList();
        }
    }
}