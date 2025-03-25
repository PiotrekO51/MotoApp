using MotoApp;
using Microsoft.Extensions.DependencyInjection;
using MotoApp.UserCommunications;
using MotoApp.CarRepoOperations;
using MotoApp.MenuData;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IMenu, Menu>();
services.AddSingleton<ICarProvider, CarProvider>();
services.AddSingleton<ICarOperation, CarOperation>();
services.AddSingleton<ICommunication, Communication>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICsvReader, CsvReader>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.RUN();