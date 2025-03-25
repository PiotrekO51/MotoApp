namespace MotoApp.Data.Entities;

public class EntityBase : IEntiti
{
    public int? Id { get; set; }

    public virtual string ToString2()
    {
        throw new NotImplementedException();
    }
}
