using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new SqlRepository<Employee>( new MotoAppDbContext());
AddEmployes(employeeRepository);
AddManagers(employeeRepository);
WriteOllToConsole(employeeRepository);

static void AddEmployes(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Zuza" });
    employeeRepository.Save();
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Add(new Manager { FirstName = "Marek" });
    managerRepository.Add(new Manager { FirstName = "Paweł" });
    managerRepository.Save();
}

static void WriteOllToConsole(IReadRepository<IEntity>repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}