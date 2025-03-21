using Microsoft.EntityFrameworkCore;
using MotoApp.CarRepoOperations;
using MotoApp.DataProviders;

namespace MotoApp.MenuData
{
    public class Menu : IMenu
    {
        private readonly ICarOperation _carOperation;
        private readonly ICarProvider _carProvider;
        public Menu(ICarOperation carOperation, ICarProvider carProvider)
        {
            _carOperation = carOperation;
            _carProvider = carProvider;
        }

        public void SearchBySpecificProperties()
        {
            bool Close = true;
            while (Close)
            {
                Console.Clear();
                Console.SetCursorPosition(5, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("MENU  WWYBORU PO WŁASNOŚCIACH POJAZDU \n" +
                    "Wybierz odpowiednie ID  lub -x-  w celu opuszczenia menu czynność \n" +
                    "\n" +
                    "1 - Szukanie metodą Select                          2 - Metody OrderBy \n" +
                    "3 - Metody Where                                    4 - Metody Firs  Single Last\n" +
                    "5 - Metody Take                                     6 - Metody Distinct  Chunk  \n" +
                    "x - WYJSCIE Z PROGRAMU ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        _carOperation.GetByMetods();
                        break;
                    case "2":
                        _carOperation.OrderByMethods();
                        break;
                    case "3":
                        _carOperation.WhereMethods();
                        break;
                    case "4":
                        _carOperation.FirstSingleMethods();
                        break;
                    case "5":
                        _carOperation.TakeMethods();
                        break;
                    case "6":
                        _carOperation.SkiPDistinctChunkMethods();
                        break;
                    case "x":
                        Close = false;
                        break;
                }
            }
        }
    }
}
