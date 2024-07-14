//namespace MotoApp2.DataProviders;
//using MotoApp2.Entities;
//using MotoApp2.Repositories;
//using System.Collections.Generic;
//using System.Drawing;

//public class CarsProviderBasic : ICarsProvider
//{
//    private readonly IRepository<Car> _carsRepository;
//    public CarsProviderBasic(IRepository<Car> carsRepository )
//    {
//        _carsRepository = carsRepository;
//    }
//    public List<Car> FilterCars(decimal minPrice)
//    {
//        var cars = _carsRepository.GetAll();
//        var list = new List<Car>();
//        foreach (Car car in cars)
//        {
//            if (car.ListPrice > minPrice)
//            {
//                list.Add(car);
//            }
//        }
//        return list;
//    }

//    public List<string> GetMinimumPriceOfAllCars()
//    {
//        var cars = _carsRepository.GetAll();
//        var list = new List<string>();
//        foreach (Car car in cars)
//        if (!list.Contains (car.Color))
//            {
//                list.Add(car.Color);
//            }
//        return list;
//    }

//    public List<string> GetUniqueCarColors()
//    {
//        throw new NotImplementedException();
//    }
//}
