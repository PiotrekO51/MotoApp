using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MotoApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    

    public List<Car1> ProcessCars(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Car1>();

        }
        var cars = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToCar();
        return cars.ToList();
    }
    public List<Manufacturer> ProcessManufacturer(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }

        var manufacturer = File.ReadAllLines(filePath)
            .Where(x => x.Length > 1)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacturer
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2])
                };
            });
        return manufacturer.ToList();
    }

    public void CsvCarsReader()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        foreach (var car in cars)
        {
            Console.WriteLine($"Rok {car.Year}");
            Console.WriteLine($"\t     Nazwa: {car.Name}");
            Console.WriteLine($"\t producent: {car.Manufacturer}");
        }

        //var groups = cars
        //    .GroupBy(c => c.Manufacturer)
        //    .Select(c => new
        //    {
        //        Name = c.Key,
        //        Max = c.Max(c => c.Combined),
        //        Average = c.Average(c => c.Combined),
        //    })
        //    .OrderBy(c => c.Average);
        //foreach (var car in groups)
        //{
        //    Console.WriteLine($"{car.Name}");
        //    Console.WriteLine($"\t {car.Max}");
        //    Console.WriteLine($"\t {car.Average}");
        //}

        Console.ReadLine();
    }

    public void CsvProducerReader()
    {
        var manufacturers = ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        foreach (var manu in manufacturers)
        {
            Console.WriteLine($"{manu.Name}");
        }
        Console.ReadLine();
    }

    public void JoinCarManufacturer()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var carsInCountry = cars.Join(
            manufacturers,
            c => new { c.Manufacturer, c.Year, },
            m => new { Manufacturer = m.Name, m.Year },
            (cars, manufacturers) =>
            new
            {
                manufacturers.Country,
                cars.Manufacturer,
                cars.Year,
                cars.Name,
                cars.Combined,
            })
            .OrderByDescending(x => x.Combined)
            .ThenBy(x => x.Name);
        foreach (var car in carsInCountry)
        {
            Console.WriteLine($" Country:{car.Country}");
            Console.WriteLine($"\t           Year:{car.Year}");
            Console.WriteLine($"\t   Manufacturer:{car.Manufacturer}");
            Console.WriteLine($"\t           Name:{car.Name}");
            Console.WriteLine($"\t       Combined:{car.Combined}");
        }
        Console.ReadLine();
    }
    public void GroupJoinMethod()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var groups = manufacturers.GroupJoin(
            cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {
                Manufacturer = m,
                Cars = g,
            })
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var group in groups)
        {
            Console.WriteLine($"Producent : {group.Manufacturer.Name}");
            Console.WriteLine($"\t     Cars: {group.Cars.Count()}");
            Console.WriteLine($"\t      Max: {group.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t      Min: {group.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t  Average: {group.Cars.Average(x => x.Combined):N2}");
            Console.WriteLine();
        }
        Console.ReadLine();
    }
    public void XmlCreator()
    {
        var manufacturers = ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        var cars = ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();
        var tooXml = new XElement("Manufacturer", manufacturers.Select(m =>
            new XElement("Manufacturer",
            new XAttribute("Name", m.Name), new XAttribute("Country", m.Country),
         new XElement("Cars",
            new XAttribute("Country", m.Country),
            new XAttribute("CombinedSum",
            cars.Where(c => c.Manufacturer == m.Name).Sum(c => c.Combined)),
            cars.Where(c => c.Manufacturer == m.Name)
            .Select(c =>
            new XElement("Car",
            new XAttribute("Name", m.Name),
            new XAttribute("Combined", c.Combined)))))));

        document.Add(tooXml);
        document.Save("Resources\\Files\\fuelManufacturers.csv");
    }
    public void XmlQuery()
    {
        var document = XDocument.Load("Resources\\Files\\fuelManufacturers.csv");

        Console.WriteLine(document);

        Console.ReadLine();
    }
}
