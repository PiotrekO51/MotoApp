using Microsoft.Extensions.DependencyInjection;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.DataProviders;
using MotoApp;



var servis = new ServiceCollection();
servis.AddSingleton<IApp, App>();
servis.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
servis.AddSingleton<IRepository<Car>, ListRepository<Car>>();
servis.AddSingleton<ICarsProvider, CarsProvider>();

var servisProvider = servis.BuildServiceProvider();
var app = servisProvider.GetService<IApp>();
app.Run();




//using MotoApp.Data;
//using MotoApp.Entities;
//using MotoApp.Repositories;
//using MotoApp.Repositories.Extensions;

//var itemAdded = new Action<Employee>(EmployeeAdded);
//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;


//static void EmployeeRepositoryOnItemAdded(object?sender, Employee e)
//{
//    Console.WriteLine($"Dodano Pracownika => {e.FirstName} z {sender?.GetType().Name} ");   
//}

//void EmployeeRepository_ItemAdded(object? sender, Employee e)
//{
//    throw new NotImplementedException();
//}

//AddEmployes(employeeRepository);
//WriteOllToConsole(employeeRepository);

//static void EmployeeAdded(object item)
//{
//    var employee = (Employee)item;
//    Console.WriteLine($"{employee.FirstName} Dodano");
//}
//static void AddEmployes( IRepository<Employee> employeeRepository)
//{

//    var employee = new[]
//    {
//        new Employee { FirstName = "Piotr" },
//        new Employee{ FirstName = "Adam" },
//        new Employee { FirstName = "Zuza" },
//         new Employee { FirstName = "BUC" }
//    };

//    employeeRepository.AddBatch(employee);
//    "string".AddBatch(employee);

//    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
//    //employeeRepository.Add(new Employee { FirstName = "Adam" });
//    //employeeRepository.Add(new Employee { FirstName = "Zuza" });
//    //employeeRepository.Save();
//}

////static void AddBatch<T>(IRepository<T> repository, T[] items)
////    where T : class, IEntity
////{
////    foreach (var item in items)
////    {
////        repository.Add(item);
////    }
////    repository.Save();
////}

//static void WriteOllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}