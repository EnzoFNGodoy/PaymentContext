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
        foreach (var sub in Subscriptions)
            sub.Deactivate();

        _subscriptions.Add(subscription);
    }
}