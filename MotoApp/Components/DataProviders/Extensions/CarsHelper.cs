using MotoApp.Data.Entities;
using System.Drawing;
using System.Runtime.CompilerServices;
namespace MotoApp.Components.DataProviders.Extensions;

public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
    {
        return query.Where(c => c.Color == color);
    }
}
