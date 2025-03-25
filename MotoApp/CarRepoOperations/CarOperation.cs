

using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MotoApp.CarRepoOperations;

public class CarOperation : ICarOperation
{
    private readonly IRepository<Car> _carRepository;
    private readonly ICarProvider _carProvider;
  

    public CarOperation(ICarProvider carProvider, IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
        _carProvider = carProvider;
     
    }

    public void GetByMetods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie matodą Select  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukaj wszytkie unikalne kolory \n" +
                "2 - Wysukaj po cenie maksymalnej\n" +
                "3 - Pokaż najtańszy samochód\n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    GetUniqueCarsColors();
                    break;
                case "2":
                    GetCarsBellowPrice();
                    break;
                case "3":
                    GetMinimumPriceOfAllCars();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }
    }
    public void OrderByMethods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  metodami OrderBY  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukaj po nazwie od A do Z \n" +
                "2 - Wysukaj po nazwie od Z do A\n" +
                "3 - Wyszukaj po koloże w kolejności z nazwami\n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    OrderByNameM();
                    break;
                case "2":
                    OrderByNameDescendingM();
                    break;
                case "3":
                    OrderByColorAndNameM();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }
    }

    public void WhereMethods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  metodami Wher  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukiwanie po początku nazwy marki \n" +
                "2 - Wysukiwanie po cenie max \n" +
                "3 - Wyszukiwanie po wybranym kolorze\n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    WhereStartsWithM();
                    break;
                case "2":
                    WhereStartsWithAndCostIsGreaterThanM();
                    break;
                case "3":
                    WhereColorIsM();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }
    }

    public void FirstSingleMethods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  metodami Firsti Single  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukiwanie po określonym kolorze z Default \n" +
                "2 - Wysukiwanie po określonym kolorze z Default od końca koloru \n" +
                "3 - Wyszukiwanie po wybranym ID z Default \n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    FirstByColorM();
                    break;
                case "2":
                    LastMethodsM();
                    break;
                case "3":
                    SingleOrDefaultM();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }

    }

    public void TakeMethods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  metodami Take  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukiwanie po ilości początkowej - Take - \n" +
                "2 - Wysukiwanie po zaktrsie - Range - \n" +
                "3 - Wyszukiwanie po początku nazwy - StartsWith - \n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    TakeCarsM();
                    break;
                case "2":
                    TakeCarRange();
                    break;
                case "3":
                    TakeCarsWhilrNameStartWitch();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }
    }

    public void SkiPDistinctChunkMethods()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  metodami Distinct Chunk  \n" +
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukiwanie wszystkich kolorów \n" +
                "2 - Wyszukiwanie pojazdów po koloracch \n" +
                "3 - Metoda - CHUNK - Dielenie na paczki   \n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    DistinctAllColorsM();
                    break;
                case "2":
                    DistinctByCollorsM();
                    break;
                case "3":
                    ChunkM();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }

    }

    public void AdditionalFunctions()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wyszukiwanie  Funkcja dodatkowe  \n " +
                ""+
                "Wybierz ID metody poszukiwań  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Wyszukiwanie po kolumnach specyficznych \n" +
                "2 - Klasa tymczasowa anonimowa \n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    GetSpecyficColumnsM();
                    break;
                case "2":
                    AnnonymousClass();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }

    }


    // Get By 
    void GetUniqueCarsColors()
    {
        var carsColors = _carProvider.GetUniqueCarsColors();
        foreach (var car in carsColors)
        {
            Console.WriteLine(car);
        }
        Console.ReadLine();

    }
    void GetCarsBellowPrice()
    {
        Console.WriteLine("Podaj minimalną cenę samochodu");
        string cost = Console.ReadLine();
        decimal cost1 = Convert.ToDecimal(cost);
        var cars = _carProvider.WhereStartsWhenCostIsGreaterThan(cost1);
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
        Console.WriteLine($"\n" +
            $"Znaleziono {cars.Count} pojazdów\n" +
            $"");
        var min = cars.Select(c => c.ListPrice).Min();
        var max = cars.Select(c => c.ListPrice).Max();
        Console.WriteLine($"Cena Najdroższego to {max}\n" +
            $"");
        Console.WriteLine($"Cena najtańszeg to {min}");

        Console.ReadLine();
    }

    void GetMinimumPriceOfAllCars()
    {
        var minProce = _carProvider.GetMinimumPriceOfAllCars();
        Console.WriteLine($"Najniższa cena samochodu wynosi: {minProce} zł\n" +
            $"");
        Console.ReadLine();
    }
    // OrderByName
    void OrderByNameM()
    {
        var cars = _carProvider.OrderByName();
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
        Console.ReadLine();
    }
    void OrderByNameDescendingM()
    {
        var cars = _carProvider.OrderByNameDescending();
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
        Console.ReadLine();
    }

    void OrderByColorAndNameM()
    {

        var cars = _carProvider.OrderByColorAndName();
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
        Console.ReadLine();

    }

    void WhereStartsWithM()
    {
        Console.WriteLine("Podaj początek nazwy Marki");
        string pref = Console.ReadLine();
        string prefix = char.ToUpper(pref[0]) + pref.Substring(1);
        var cars = _carProvider.WhereStartsWith(prefix);
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());

        }
        Console.ReadLine();
    }

    void WhereStartsWithAndCostIsGreaterThanM()
    {
        Console.WriteLine("Podaj początek nazwy Marki");
        string pref = Console.ReadLine();
        string prefix = char.ToUpper(pref[0]) + pref.Substring(1);
        Console.WriteLine("Podaj max cenę po jakiej chcesz kupić");
        while (true)
        {
            decimal cost1 = 0;
            string cost = Console.ReadLine();
            if (cost != null)
            {
                decimal.TryParse(cost, out cost1);
            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }
            var cars = _carProvider.WhereStartsWithAndCostIsGreaterThan(prefix, cost1);
            if (cars.Count() > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car.ToString());

                }
            }
            else { Console.WriteLine("Brak pojazdów poniżej podanej ceny"); Thread.Sleep(750); break; }
            Console.ReadLine();
        }
    }

    void WhereColorIsM()
    {
        Console.WriteLine("Podaj nazwę coloru");
        string pref = Console.ReadLine();
        string prefix = char.ToUpper(pref[0]) + pref.Substring(1);
        // Console.WriteLine("Podaj max cenę po jakiej chcesz kupić");
        var cars = _carProvider.WhereColorIs(prefix);
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());

        }
        Console.ReadLine();
    }


    // First  Single Last Single
    public void FirstByColorM()
    {
        Console.WriteLine("Podaj nazwę coloru");
        string pref = Console.ReadLine();
        string prefix = char.ToUpper(pref[0]) + pref.Substring(1);
        var cars = _carProvider.FirstOrDefaultByColorWithDefault(prefix);
        Console.WriteLine(cars.ToString());
        Console.ReadLine();
    }

    public void LastMethodsM()
    {
        Console.WriteLine("Podaj nazwę coloru");
        string pref = Console.ReadLine();
        string prefix = char.ToUpper(pref[0]) + pref.Substring(1);
        var cars = _carProvider.LastbyColor(prefix);
        Console.WriteLine(cars.ToString());
        Console.ReadLine();
    }

    public void SingleOrDefaultM()
    {
        while (true)
        {
            int cost1 = 0;
            Console.WriteLine("Podaj Id do wyświetlenia");
            string cost = Console.ReadLine();
            if (cost != null)
            {
                int.TryParse(cost, out cost1);
            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }
            var cars = _carProvider.SingleOrDefault(cost1);
            if (cars != null)
            {
                Console.WriteLine(cars.ToString());
            }
            Console.ReadLine();
            break;
        }

    }

    public void TakeCarsM()
    {
        while (true)
        {
            int quantiti = 0;
            Console.WriteLine("Podaj ilość samochodów do pobrania z początku listy ");
            string quantiti1 = Console.ReadLine();
            if (quantiti1 != null)
            {
                int.TryParse(quantiti1, out quantiti);
            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }
            var cars = _carProvider.TakeCars(quantiti);
            if (cars.Count() >= 1) { Console.WriteLine(cars.ToString()); }
            Console.ReadLine();
            break;

        }

    }

    public void TakeCarRange()
    {
        while (true)
        {
            int rangeUpp = 0;
            int rangeDown = 0;
            Console.WriteLine("Podaj dolną wartość zakresu");
            string ra = Console.ReadLine();
            Console.WriteLine("Podaj górną wartość zakresu");
            string ra2 = Console.ReadLine();
            if (ra != null && ra2 != null)
            {
                int.TryParse(ra, out rangeUpp);
                int.TryParse(ra2, out rangeDown);
            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }
            var cars = _carProvider.TakeCar((rangeUpp - 1)..rangeDown);
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
            Console.ReadLine();
            break;
        }

    }


    public void TakeCarsWhilrNameStartWitch()
    {
        while (true)
        {

            Console.WriteLine("Podaj prefix pojazdu");
            string prefix = Console.ReadLine();
            string prefix1 = char.ToUpper(prefix[0]) + prefix.Substring(1);
            if (prefix != null)
            {
                var cars = _carProvider.TakeCarsWhileNameStartWith(prefix);
                foreach (var car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
                Console.ReadLine();
            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }

            break;
        }
    }

    void DistinctAllColorsM()
    {
        var cars = _carProvider.DistinctAllCollors();
        foreach (var c in cars)
        {
            Console.WriteLine(c.ToString());
        }
        Console.ReadLine();
    }

    void DistinctByCollorsM()
    {
        Console.Clear();
        var cars = _carProvider.DistinctByColors();
        Console.WriteLine($"Znaleziono {cars.Count} pojazdów w kolejnosci kolorów \n" +
            $"");
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
        Console.ReadLine();
    }

    void ChunkM()
    {
        while (true)
        {
            int rangeUpp = 0;
            int count = 0;
            Console.WriteLine("Podaj długość paczki");
            string ra = Console.ReadLine();
          
            if (ra != null  )
            {
                int.TryParse(ra, out rangeUpp);

            }
            else { Console.WriteLine("Błedana wartość"); Thread.Sleep(750); }
            var cars = _carProvider.ChunkCars(rangeUpp);
            foreach (var car in cars)
            {
                count++;
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"Paczka nr: {count}\n" +
                    $"");
                foreach (var c in car)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(c.ToString());
                }
                
            }
            Console.ReadLine();
            break;
        }
    }

    void GetSpecyficColumnsM()
    {
        var cars = _carProvider.GetSpecyficColumns();
        foreach (var car in cars) 
        {
            Console.WriteLine(car); 
        }
        Console.ReadLine();
    }
    void AnnonymousClass()
    {
        var cars = _carProvider.AnnonymousClass();
        foreach (var c in cars)
        {
            Console.WriteLine(c);
        }
        Console.ReadLine();
    }
}
