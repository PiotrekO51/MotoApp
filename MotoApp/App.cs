using Microsoft.IdentityModel.Tokens;
using MotoApp.CarRepoOperations;
using MotoApp.DataProviders;
using MotoApp.MenuData;
using MotoApp.UserCommunications;

namespace MotoApp;

public class App : IApp
{
    private readonly ICommunication _communication;
    private readonly IMenu _menu;


    public App(ICommunication communication, IMenu menu)
    {
        _communication = communication;
       
        _menu = menu;

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
                "x - Wyszukiwanie i flitrowanie\n" +
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
                case "x":
                    Close = false;
                    break;
            }
        }

    }
    
}
