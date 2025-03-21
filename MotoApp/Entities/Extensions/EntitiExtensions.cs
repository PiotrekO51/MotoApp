using System.Text.Json;
namespace MotoApp.Entities.Extensions;

public static class EntitiExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : class, IEntiti, new()
    {
        var jason = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(jason);
    }
}
