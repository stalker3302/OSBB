using System;

class Program
{
    static void Main(string[] args)
    {
        Manager_of_cond mediator = new Manager_of_cond();
        employees from_cookers = new cookers_system(mediator);
        employees from_delivers = new delivery_system(mediator);
        employees from_sellers = new sell_system(mediator);
        mediator.cookers = from_cookers;
        mediator.delivers = from_delivers;
        mediator.sellers = from_sellers;
        from_cookers.Send("Партiя солодощiв виготовлена");
        from_delivers.Send("Партiя доставлена в магазини");
        from_sellers.Send("Партiя продана, треба ще.");

        Console.Read();
    }
}

abstract class Mediator
{
    public abstract void Send(string msg, employees employees);
}
abstract class employees
{
    protected Mediator mediator;

    public employees(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
// класс кухарів
class cookers_system : employees
{
    public cookers_system(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Повiдомлення кухарям: " + message);
    }
}
// клас доставки
class delivery_system : employees
{
    public delivery_system(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Повiдомлення доставцi: " + message);
    }
}
// клас продавців
class sell_system : employees
{
    public sell_system(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Повiдомлення продавцям: " + message);
    }
}

class Manager_of_cond : Mediator
{
    public employees cookers { get; set; }
    public employees delivers { get; set; }
    public employees sellers { get; set; }
    public override void Send(string msg, employees employees)
    {
        // якщо повідомлення від кухаря - робота виконана, тоді інформуємо доставку
        if (cookers == employees)
            delivers.Notify(msg);
        // якщо від доставки - значить доставлено, інформуємо продавців
        else if (delivers == employees)
            sellers.Notify(msg);
        // якщо від продавців - значить продано, інформуємо кухарів про нові необхідні партії.
        else if (sellers == employees)
            cookers.Notify(msg);
    }
}