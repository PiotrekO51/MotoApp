namespace MotoApp.Entities
{
    public class BusinesPartner : EntityBase
    {
      
        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {Name}";

    }
}


