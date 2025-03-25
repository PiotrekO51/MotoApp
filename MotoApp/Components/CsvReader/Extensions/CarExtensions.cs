using MotoApp.Components.CsvReader.Models;
using System.Globalization;
namespace MotoApp.Components.CsvReader.Extensions;

public static class CarExtensions
{

    public static IEnumerable<Car1> ToCar(this IEnumerable<string> sources)
    {
        foreach (var line in sources)
        {
            var columns = line.Split(',');
            {
                yield return new Car1
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displeasement = double.Parse(columns[3],CultureInfo.InvariantCulture),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    HighWay = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7]),   
                };
                
            }
        }
    }

}
