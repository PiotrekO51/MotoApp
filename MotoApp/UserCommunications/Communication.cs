using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.DataProviders;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MotoApp.UserCommunications;

public class Communication : ICommunication
{
    public const string FileNameCar = "CarList.txt";
    public const string FileEventCarAdded = "EventCarAdded.txt";
    private readonly IRepository<Car> _carRepository;
    private readonly ICarProvider _carProvider;

    public Communication(IRepository<Car> carRepository, ICarProvider carProvider)
    {
        _carRepository = carRepository;
        _carProvider = carProvider;
    }

    //   DODAWANIE POJAZDÓW DO BAZY GŁÓWNEJ ================================================================================

    public void AddCarsToFile()
    {
        var carRepository = _carRepository.GetAll();

        //File.Delete(FileNameCar);
        foreach (var car in carRepository)
        {
            using (var writer = File.AppendText(FileNameCar))
            {
                if (car != null)
                {
                    writer.WriteLine(car.ToString2());
                }
            }
        }
    }
    public void AddCarToList()
    {
        int carsCount = _carRepository.GetAll().Count();
        if (carsCount == 0)
        {
            if (File.Exists(FileNameCar))
            {
                Console.WriteLine($"Wczytywaie danych z Bazy\n" +
                $"");
                Thread.Sleep(1000);

                using (var reader = File.OpenText(FileNameCar))
                {
                    string line = reader.ReadLine();
                    {
                        while (line != null)
                        {
                            string[] pol = line.Split('.');
                            string p1 = pol[0];
                            string p2 = pol[1];
                            string p3 = pol[2];
                            string p4 = pol[3];
                            decimal p41 = decimal.Parse(p4);
                            string p5 = pol[4];
                            decimal p51 = decimal.Parse(p5);
                            _carRepository.Add(new Car { Name = p1, Color = p2, Type = p3, StandardCost = p41, ListPrice = p51, });
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Plik z danymi samochodów nie istnieje \n" +
                    "\n" +
                    "Wczytuję dane własne\n" +
                    "");
                Thread.Sleep(2000);
                var cars = GenerateSampelCars();
                foreach (var car in cars)
                {
                    _carRepository.Add(car);
                }
                _carRepository.Save();
                AddCarsToFile();
            }
        }
    }

    public void CarsList()
    {
        var communication = _carRepository.GetAll();
        foreach (var car in communication)
        {
            if (car != null)
            {
                Console.WriteLine(car.ToString());
            }
        }
        Console.ReadKey();
    }

    public void AddCarsToBase()
    {
        _carRepository.ItemAdded += EmployeeAdded;

        void EmployeeAdded(object? item, Car e)
        {
            Console.Clear();
            AddCarsToFile($"{e.Name},{e.Color},{e.Type},{DateTime.Now}{item.GetType().Name}", FileEventCarAdded);
        }
        Console.Clear();
        Console.WriteLine("Podaj kolejno dane a następnie wciśnij lub wciśnij x w celu  wyjścia ");
        bool Stop = false;
        while (true)
        {
            string name = InputStringCarsData("Podaj markę pojazdu lub x w celu wyjścia");
            if (name == "X")
            { break; }
            else
            {
                string color = InputStringCarsData("Podaj color pojazdu");
                string type = InputStringCarsData("Podaj typ pojazdu");
                decimal standardCost = InputDecimalCarsData("Podaj cenę zakupu samochodu");
                decimal listPrice = InputDecimalCarsData("Podaj cenę sprzedaży samochodu");
                _carRepository.Add(new Car { Name = name, Color = color, Type = type, StandardCost = standardCost, ListPrice = listPrice });
                _carRepository.Save();
                AddCarsToFile($"{name}.{color}.{type}.{standardCost}.{listPrice}", FileNameCar);
            }
        }
    }

    //  Data addition section
    string InputStringCarsData(string txt)
    {
        Console.Clear();
        string stringData = string.Empty;
        Console.WriteLine(txt);
        string Data = Console.ReadLine();
        if (!string.IsNullOrEmpty(Data))
        {
            string Data2 = char.ToUpper(Data[0]) + Data.Substring(1);
            stringData = Data2;
        }
        else { Console.WriteLine("WRONG DATA"); Thread.Sleep(1000); }
        return stringData;
    }
    decimal InputDecimalCarsData(string txt)
    {
        Console.Clear();
        decimal value = 0;
        Console.WriteLine($"{txt}");
        string data = Console.ReadLine();
        string data1 = data.Replace('.', ',');
        if (!string.IsNullOrEmpty(data1))
        {
            decimal.TryParse(data1, out value);
        }
        else { Console.WriteLine("WRONG DATA"); Thread.Sleep(1000); }
        return value;
    }

    void AddCarsToFile(string txt, string filename)
    {
        if (File.Exists(FileNameCar))
            using (var writer = File.AppendText(filename))
            {
                writer.WriteLine(txt);
            }
    }

    // Obsługa
    
    // AWARYJNA LISTA POJAZDÓW====================================================================================
    public static List<Car> GenerateSampelCars()
    {
        return new List<Car>
        {
            new Car
            {
                Id = 1,
                Name = ("abc_Porsche"),
                Color = "Balck",
                StandardCost = 123.50m,
                ListPrice = 188.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 2,
                Name = "abc_Porsche",
                Color = "White",
                StandardCost = 111.50m,
                ListPrice = 145.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 3,
                Name = "Volvo",
                Color = "Yellow",
                StandardCost = 177.50m,
                ListPrice = 222.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 4,
                Name = "abc_Fiat",
                Color = "Red",
                StandardCost = 88.50m,
                ListPrice = 122.50m,
                Type = "PickUp",
            },
            new Car
            {
                Id = 5,
                Name = "Opel",
                Color = "Blue",
                StandardCost = 95.50m,
                ListPrice = 133.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 6,
                Name = "abc_Opel",
                Color = "Magenta",
                StandardCost = 98.50m,
                ListPrice = 132.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 7,
                Name = "Ford",
                Color = "Blue",
                StandardCost = 111.50m,
                ListPrice = 134.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 8,
                Name = "Ford",
                Color = "Silver",
                StandardCost = 99.50m,
                ListPrice = 123.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 9,
                Name = "Ford",
                Color = "Balck",
                StandardCost = 99.50m,
                ListPrice = 136.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 10,
                Name = "Citroen",
                Color = "Balck",
                StandardCost = 101.50m,
                ListPrice = 137.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 11,
                Name = "abc_Renault",
                Color = "Red",
                StandardCost = 89.50m,
                ListPrice = 109.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 12,
                Name = "abc_Porsche",
                Color = "Blue",
                StandardCost = 144.50m,
                ListPrice = 166.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 13,
                Name = "BMW",
                Color = "Blue",
                StandardCost = 155.50m,
                ListPrice = 200.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 14,
                Name = "Mercedes",
                Color = "Red",
                StandardCost = 120.50m,
                ListPrice = 155.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 15,
                Name = "abc_Mercedes",
                Color = "White",
                StandardCost = 144.50m,
                ListPrice = 176.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 16,
                Name = "Mercedes",
                Color = "Balck",
                StandardCost = 177.50m,
                ListPrice = 222.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 17,
                Name = "Ferrari",
                Color = "Red",
                StandardCost = 222.50m,
                ListPrice = 288.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 18,
                Name = "Lamborgini",
                Color = "Balck",
                StandardCost = 234.50m,
                ListPrice = 277.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 19,
                Name = ("abc_Porsche"),
                Color = "Purple",
                StandardCost = 123.50m,
                ListPrice = 188.50m,
                Type = "Cabrio",
            },

        };
    }

}
