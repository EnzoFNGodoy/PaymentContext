namespace PaymentContext.Domain.Entities;

public sealed class Subscription
{
    private IList<Payment> _payments;

    public Subscription(DateTime? expirationDate)
    {
        CreatedAt = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpirationDate = expirationDate;
        IsActive = true;

        _payments = new List<Payment>();
    }

    public DateTime CreatedAt { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public bool IsActive { get; private set; }

    public IReadOnlyCollection<Payment> Payments { get => _payments.ToArray(); }

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Activate()
    {
        IsActive = true;
        LastUpdateDate = DateTime.Now;
    }

    public void Deactivate()
    {
        IsActive = false;
        LastUpdateDate = DateTime.Now;
    }
}