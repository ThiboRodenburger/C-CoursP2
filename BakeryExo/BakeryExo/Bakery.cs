using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


public class Bakery
{
    public event Action OnStartProduction = null;
    public event Action OnStopProduction = null;
    public event Action OnBreadSelling = null;
    public event Action OnEndBuyingFlour = null;
    public event Action OnEndSaveBakery = null;

    public event Action OnEndReadBakerySupply = null;

    
   


    public int Bread { get; private set; }
    public int Flour { get; private set; }
    public int Gold { get; private set; }
    public string Name { get; private set; }

    public Bakery() { }
    public Bakery(string _name, int _bread, int _flour, int _gold)
    {
        Name = _name;
        Bread = _bread;
        Flour = _flour;
        Gold = _gold;
    }


    public void StartProduction(string _path)
    {
        CreatBread(_path);
    }

    public void StopProduction()
    {
        Console.WriteLine("Stop");
    }

    public void CreatBread(string _path)
    {
        if (Flour < 1)
        {
            Console.WriteLine("You need more flour to make bread");
            Console.ReadLine();
            OnBreadSelling?.Invoke();
        }
        OnStartProduction?.Invoke();
        Console.WriteLine("Create Bread");
        Bread += 1;
        Flour -= 1;
        Console.ReadLine();
        OnStopProduction?.Invoke();
    }

    public void SellBread(string _path)
    {
        if (Bread > 0)
        {
            Console.WriteLine("You need more bread to sell it");
            Console.ReadLine();
            OnBreadSelling?.Invoke();
        }

        Console.WriteLine("Bread selled");
        Bread -= 1;
        Gold += 5;
        Console.ReadLine();
        OnBreadSelling?.Invoke();
    }

    public void DisplayStock(string _path)
    {
        if (File.Exists(_path))
        {
            string _content = File.ReadAllText(_path);
            Console.WriteLine($"Bakery Content : {_content}");
        }
        else
        {
            Console.WriteLine("Bakery does not exist");
        }

        Console.ReadLine();
        OnEndReadBakerySupply?.Invoke();
    }

    public void BuyFlour(string _path)
    {
        if (Gold < 50)
        {
            Console.WriteLine("You Need more gold to buy flour");
            Console.ReadLine();
            OnEndBuyingFlour?.Invoke();
        }

        Console.WriteLine("You Buy 50kg flour");
        Flour += 50;
        Gold -= 200;
        Console.ReadLine();
        OnEndBuyingFlour?.Invoke();
    }

    public void Save(string _path)
    { 
        File.WriteAllText(_path, $"Bread : {Bread}, Flour : {Flour}kg, Gold : {Gold}");
        OnEndSaveBakery?.Invoke();
    }

    public Bakery LoadSave(string _path)
    {
        File.ReadAllText(_path);
        OnEndReadBakerySupply?.Invoke();
        return this;
    }
}

