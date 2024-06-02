using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployes(employeeRepository);

WriteOllToConsole(employeeRepository);

static void AddEmployes(IRepository<Employee> employeeRepository)
{

    var employee = new[]
    {
        new Employee { FirstName = "Piotr" },
        new Employee{ FirstName = "Adam" },
        new Employee { FirstName = "Zuza" }
    };

    AddBatch(employeeRepository, employee);


    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
    //employeeRepository.Add(new Employee { FirstName = "Adam" });
    //employeeRepository.Add(new Employee { FirstName = "Zuza" });
    //employeeRepository.Save();
}

static void AddBatch<T>(IRepository<T> repository, T[] items)
    where T : class, IEntity
{
    foreach (var item in items)
    {
        repository.Add(item);
    }
    repository.Save();
}

static void WriteOllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}