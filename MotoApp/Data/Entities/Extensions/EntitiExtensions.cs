using System.Text.Json;
using MotoApp.Data.Entities;
namespace MotoApp.Data.Entities.Extensions;

public static class EntitiExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : class, IEntiti, new()
    {
        var jason = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(jason);
    }
}
