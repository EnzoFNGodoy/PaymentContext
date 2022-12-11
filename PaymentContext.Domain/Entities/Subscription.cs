using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public sealed class Subscription : Entity
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
        AddNotifications(new Contract<Subscription>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaymentDate, "Subscription.Payments", "A data do pagamento deve ser futura")
        );

        if (IsValid)
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