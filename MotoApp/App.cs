
using MotoApp.Repositories;
using MotoApp.DataProviders;
using MotoApp.Entities;

namespace MotoApp;
public class App : IApp
{
    private readonly IRepository<Employee> _employeRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;
    public App(
                IRepository<Employee> employeRepository,
                IRepository<Car> carsRepository,
                ICarsProvider carsProvider)
    {
        _employeRepository = employeRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }
    public void Run()
    {
        Console.WriteLine("Jestem tutaj w App  Run()  Method");

        var employess = new[]
        {
        new Employee { FirstName = "Zuzanna" },
        new Employee { FirstName = "Piotr" },
        new Employee { FirstName = "Paweł" },

        };
        foreach (var employee in employess)
        {
            _employeRepository.Add(employee);
        }

        _employeRepository.Save();

        var items = _employeRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine($"Id : {item.Id}  Imię : {item.FirstName}");
        }

        //cars
        var cars = GenerateSampleCars();
        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        foreach (var car in _carsProvider.GetSpecyficsColumns())
        {
            Console.WriteLine(car);
        }

        foreach (var car in _carsProvider.GetUniqueCarColors())
        {
            Console.WriteLine(car);
        }


        //foreach (var car in _carsProvider.GetMinimumPriceOfAllCars())
        //{
        //    Console.WriteLine(car);
        //}

        foreach (var car in _carsProvider.OrderByColorAndNameDesc())
        { Console.Write(car); }

        Console.WriteLine("Podaj kolor do wylistowania");
        string color = Console.ReadLine();

        foreach (var car in _carsProvider.WhereColorIs(color))
        {
            Console.WriteLine(car);
        }

    }

    public static List<Car> GenerateSampleCars()
    {
        return new List<Car>
        {
            new Car
            {
                Id = 1,
                Name = "Porsche",
                Color = "Balck",
                StandardCost = 123.50M,
                ListPrice = 188.50M,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 2,
                Name = "Porsche",
                Color = "White",
                StandardCost = 111.50M,
                ListPrice = 145.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 3,
                Name = "Volvo",
                Color = "Yellow",
                StandardCost = 177.50M,
                ListPrice = 222.50M,
                Type = "Combi",
            },
            new Car
            {
                Id = 4,
                Name = "Fiat",
                Color = "Red",
                StandardCost = 88.50M,
                ListPrice = 122.50M,
                Type = "PickUp",
            },
            new Car
            {
                Id = 5,
                Name = "Opel",
                Color = "Blue",
                StandardCost = 95.50M,
                ListPrice = 133.50M,
                Type = "Combi",
            },
            new Car
            {
                Id = 6,
                Name = "Opel",
                Color = "Magenta",
                StandardCost = 92.50M,
                ListPrice = 132.50M,
                Type = "Sedan",
            },
             new Car
            {
                Id = 7,
                Name = "Ford",
                Color = "Bluee",
                StandardCost = 111.50M,
                ListPrice = 134.50M,
                Type = "Combi",
            },
            new Car
            {
                Id = 8,
                Name = "Ford",
                Color = "Silver",
                StandardCost = 99.50M,
                ListPrice = 123.50M,
                Type = "Combi",
            },
            new Car
            {
                Id = 9,
                Name = "Ford",
                Color = "Balck",
                StandardCost = 99.50M,
                ListPrice = 136.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 10,
                Name = "Citroen",
                Color = "Balck",
                StandardCost = 101.50M,
                ListPrice = 137.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 11,
                Name = "Renault",
                Color = "Red",
                StandardCost = 89.50M,
                ListPrice = 109.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 12,
                Name = "Porsche",
                Color = "blue",
                StandardCost = 144.50M,
                ListPrice = 166.50M,
                Type = "Combi",
            },
             new Car
            {
                Id = 13,
                Name = "BMW",
                Color = "Blue",
                StandardCost = 155.50M,
                ListPrice = 200.50M,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 14,
                Name = "Mercedes",
                Color = "Red",
                StandardCost = 120.50M,
                ListPrice = 155.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 15,
                Name = "Mercedes",
                Color = "White",
                StandardCost = 144.50M,
                ListPrice = 176.50M,
                Type = "Sedan",
            },
            new Car
            {
                Id = 16,
                Name = "Marcedes",
                Color = "Balck",
                StandardCost = 177.50M,
                ListPrice = 222.50M,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 17,
                Name = "Ferrari",
                Color = "Red",
                StandardCost = 222.50M,
                ListPrice = 288.50M,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 18,
                Name = "Lamborgini",
                Color = "Balck",
                StandardCost = 234.50M,
                ListPrice = 277.50M,
                Type = "Cabrio",
            },
        };
    }
}
