using System;

class Program
{
    static void Main(string[] args)
    {
        database data = new database();
        User misha = new User();
        misha.PrintData(data);
        Console.Read();
    }
}

class User
{
    public void PrintData(database database)
    {
        DataIterator iterator = database.CreateNumerator();
        while (iterator.ToNextRecord())
        {
            record_of_products current = iterator.Next();
            Console.WriteLine(current.Name);
        }
    }
}

interface DataIterator
{
    bool ToNextRecord();
    record_of_products Next();
}
interface sweet_shop
{
    DataIterator CreateNumerator();
    int Count { get; }
    record_of_products this[int index] { get; }
}
class record_of_products
{
    public string Name { get; set; }
}

class database : sweet_shop
{
    private record_of_products[] diffTypes;
    public database()
    {
        diffTypes = new record_of_products[]
        {
            new record_of_products {Name="Барбарисок: 30000 шт"},
            new record_of_products {Name="Дюшес: 20000 шт"},
            new record_of_products {Name="Пироги: 1000 шт"}
        };
    }
    public int Count
    {
        get { return diffTypes.Length; }
    }

    public record_of_products this[int index]
    {
        get { return diffTypes[index]; }
    }
    public DataIterator CreateNumerator()
    {
        return new databaseNumerator(this);
    }
}
class databaseNumerator : DataIterator
{
    sweet_shop all_records;
    int index = 0;
    public databaseNumerator(sweet_shop a)
    {
        all_records = a;
    }
    public bool ToNextRecord()
    {
        return index < all_records.Count;
    }

    public record_of_products Next()
    {
        return all_records[index++];
    }
}