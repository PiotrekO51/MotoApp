using MotoApp;
using Microsoft.Extensions.DependencyInjection;
using MotoApp.UserCommunications;
using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.CarRepoOperations;
using MotoApp.MenuData;
using MotoApp.DataProviders;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IMenu, Menu>();
services.AddSingleton<ICarProvider, CarProvider>();
services.AddSingleton<ICarOperation, CarOperation>();
services.AddSingleton<ICommunication, Communication>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.RUN();