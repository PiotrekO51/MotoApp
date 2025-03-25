using Microsoft.IdentityModel.Tokens;
using MotoApp.CarRepoOperations;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using MotoApp.Components.DataProviders.Extensions;
using MotoApp.MenuData;
using MotoApp.UserCommunications;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace MotoApp;

public class App : IApp
{
    private readonly ICommunication _communication;
    private readonly IMenu _menu;
    private readonly ICsvReader _csvReader;
    private readonly ICarOperation _carOperation;

    public App(ICommunication communication, IMenu menu, ICsvReader csvReader, ICarOperation carOperation)
    {
        _communication = communication;
        _csvReader = csvReader;
        _menu = menu;
        _carOperation = carOperation;
    }

    public void RUN()
    {
        _communication.AddCarToList();
        Console.WriteLine("Witamy w programie informacyjnym o samochodach \n" +
            "");
        Thread.Sleep(1000);
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MENU WYBORU \n" +
                "Wybierz ID  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Baza samochodów\n" +
                "2 - Wprowadzanie samochodów\n" +
                "3 - Kwerenda/Filtrowanie\n" +
                "4 - Odczyt bazy Samochodów CSV \n" +
                "5 - Odczyt dodatkowej bazy producentów \n" +
                "6 - Metoda Join \n" +
                "7 - Metoda GroupJoin\n" +
                "8 - XmlCreator\n" +
                "9 - XmlQuery\n" +
                "x - Wyszukiwanie i flitrowanie \n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _communication.CarsList();
                    break;
                case "2":
                    _communication.AddCarsToBase();
                    break;
                case "3":
                    _menu.SearchBySpecificProperties();
                    break;
                case "4":
                    _csvReader.CsvCarsReader();
                    break;
                case "5":
                    _csvReader.CsvProducerReader();
                    break;
                case "6":
                    _csvReader.JoinCarManufacturer();
                    break;
                case "7":
                    _csvReader.GroupJoinMethod();
                    break;
                case "8":
                    _csvReader.XmlCreator();
                    break;
                case "9":
                    _csvReader.XmlQuery();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }
    }
}
