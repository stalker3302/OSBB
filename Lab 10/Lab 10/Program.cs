using System;

class Program
{
    static void Main(string[] args)
    {
        cookers plan_for_today = new sweet_shef("Карамельщик");
        mySweetProduction Sweets = plan_for_today.Create();

        plan_for_today = new bake_shef("Пекар");
        mySweetProduction Bakings = plan_for_today.Create();

        Console.ReadLine();
    }
}
// абстрактний клас конитерської
abstract class cookers
{
    public string Name { get; set; }

    public cookers(string n)
    {
        Name = n;
    }
    // фабричный метод
    abstract public mySweetProduction Create();
}
// робимо цукерки
class sweet_shef : cookers
{
    public sweet_shef(string n) : base(n)
    { }

    public override mySweetProduction Create()
    {
        return new cook_sweet();
    }
}
// випікаем
class bake_shef : cookers
{
    public bake_shef(string n) : base(n)
    { }

    public override mySweetProduction Create()
    {
        return new cook_bake();
    }
}

abstract class mySweetProduction
{ }

class cook_sweet : mySweetProduction
{
    public cook_sweet()
    {
        Console.WriteLine("Виготовлення цукерок успiшно запущено");
    }
}
class cook_bake : mySweetProduction
{
    public cook_bake()
    {
        Console.WriteLine("Випiкання успiшно запущено");
    }
}