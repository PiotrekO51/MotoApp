using System.Text;
namespace MotoApp.Entities;

public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; } 
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }  
    public string Type { get; set; }

    //Calculated Properties
    public int ? NameLenght { get; set; }
    public decimal? TotalSales { get; set; }

    #region ToString Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);
        sb.AppendLine($"Id: {Id}    Nazwa: {Name}");
        sb.AppendLine($"Kolor: {Color}     Typ: {Type}");
        sb.AppendLine($"Cena standardowa: {StandardCost}    Cena sprzedaży: {ListPrice}");
        if(NameLenght.HasValue)
        {
            sb.AppendLine($"Długość nazwy: {NameLenght}");
        }
        if (TotalSales.HasValue)
        {
            sb.AppendLine($"Całkowita sprzedaż: {TotalSales}");
        }
        return sb.ToString();
    }
    public string ToString2() => $"{Name}.{Color}.{Type}.{StandardCost}.{ListPrice}";
    #endregion
}
