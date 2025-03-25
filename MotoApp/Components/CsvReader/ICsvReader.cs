using MotoApp.Components.CsvReader.Models;
namespace MotoApp.Components.CsvReader;

public interface ICsvReader
{
    List<Car1> ProcessCars(string filePath);
    List<Manufacturer> ProcessManufacturer(string filePath);
   
    void CsvCarsReader();
    void CsvProducerReader();
    void JoinCarManufacturer();
    void GroupJoinMethod();
    void XmlCreator();
    void XmlQuery();
}
