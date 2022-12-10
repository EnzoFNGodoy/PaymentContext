namespace PaymentContext.Shared.Entities;

public class Entity
{
    public Entity(Guid id, DateTime? updatedAt)
    {
        Id = id;
        CreatedAt = DateTime.Now;
        UpdatedAt = updatedAt ?? CreatedAt;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}