using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public sealed class Student : Entity
{
    private readonly IList<Subscription> _subscriptions;

    public Student(Name name, Document document, Email email,
        Address? address = null)
    {
        Name = name;
        Document = document;
        Email = email;
        Address = address;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email);
    }

    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address? Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.ToArray(); }

    public void AddSubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;
        foreach (var sub in Subscriptions)
        {
            if (sub.IsActive)
                hasSubscriptionActive = true;
        }

        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa.")
            .AreNotEquals(0, subscription.Payments.Count, "Esta assinatura não possui pagamentos")
        );

        if (IsValid)
            _subscriptions.Add(subscription);
    }
}