using System;
class Program
{
    static void Main(string[] args)
    {
        // юзер
        User Misha = new User();
        // замовлення
        sweets order1 = new sweets();
        // оформлення 
        Misha.ordering(order1);
        // перехід до іншого розділу
        baking plus_bake = new baking();
        // переключаемося
        newOrder changing_ = new sweet_to_bake(plus_bake);
        // продовжуємо замовлення
        Misha.ordering(changing_);
        Misha.end(changing_);

        Console.Read();
    }
}
interface newOrder
{
    void newOrdering();
    void ending();
}
// класс роботи з солодощами
class sweets : newOrder
{
    public void newOrdering()
    {
        Console.WriteLine("Замовлення по солодощам...");
    }
    public void ending()
    {
        Console.WriteLine("Кiнець.");
    }
}
class User
{
    public void ordering(newOrder changing)
    {
        changing.newOrdering();
    }
    public void end(newOrder changing)
    {
        changing.ending();
    }
}
// інтерфейс роботи з випічкою
interface toBaking
{
    void plusBake();
}
// класс для додавання випічки в замовлення
class baking : toBaking
{
    public void plusBake()
    {
        Console.WriteLine("Замовлення випiчки...");
    }
    public void endOrder()
    {
        Console.WriteLine("Кiнець.");
    }
}
// Адаптер 
class sweet_to_bake : newOrder
{
    baking withBake;
    public sweet_to_bake(baking c)
    {
        withBake = c;
    }

    public void newOrdering()
    {
        withBake.plusBake();
    }
    public void ending()
    {
        withBake.endOrder();
    }
}