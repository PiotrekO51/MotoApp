namespace MotoApp.Entities;

public class Employee
{
    public int ? Id { get; set; }
    public string? FirstName { get; set; }
    public string? Surname { get; set; }

    public override string ToString() => $" Imię: {FirstName}";
}
    

