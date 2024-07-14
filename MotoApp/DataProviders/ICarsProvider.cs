using MotoApp.Entities;
using System.Collections.Generic;

namespace MotoApp.DataProviders;

public interface ICarsProvider
{
    //select
    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();

    List<Car> GetSpecyficsColumns();

    string AnonymousClass();

    // Order by

    List<Car> OrderByName();

    List<Car> OrderByNameDescending();

    List<Car> OrderByColorAndName();

    List<Car> OrderByColorAndNameDesc();

    //where

    List<Car> WhereStartsWith(string prefix);

    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<Car> WhereColorIs(string prefix);
}
