using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct FBread
{
    public int FlourQty {  get; private set; }
    public int Price { get; private set; }
    public string Name { get; private set; }
    public FBread(int _flourQty, int _price, string _name = "baguette")
    {
        FlourQty = _flourQty;
        Price = _price;
        Name = _name;
    }

    public override string ToString() => $"{Name} _ {Price} - {FlourQty}";
}

public class Bakery
{

    public event Action<FBread> OnBreadMade = null;
    public event Action<int> OnBreadSold = null;
    public event Action OnStockDisplayed = null;
    public event Action<int> OnFlourBought = null;
    public event Action OnActionDone = null;

    List<FBread> allBread = new List<FBread>();
    int flourStock = 100;
    int money = 0;
    Baker baker = null;

    public int Money => money;
    public int FlourStock => flourStock;
    public List<FBread> AllBread => allBread;
    public FBread this[int _index] => allBread[_index];

    public Bakery() 
    { 
        baker = new Baker();
    }

    public void MakeBread()
    {
        FBread _bread = baker.MakeBread(ref flourStock);
        if(string.IsNullOrEmpty(_bread.Name))
        {
            Console.ReadLine();
            OnActionDone?.Invoke();
            return;
        }
        allBread.Add(_bread);
        OnBreadMade?.Invoke(_bread);
        OnActionDone?.Invoke();
    }

    public void SellBread()
    {
        if (allBread.Count < 1)
        {
            Console.WriteLine("No Bread to sell");
            Console.ReadLine();
            OnActionDone?.Invoke();
            return;
        }
        int _lastIndex = allBread.Count - 1;
        money += allBread[_lastIndex].Price;
        OnBreadSold?.Invoke(allBread[_lastIndex].Price);
        allBread.Remove(allBread[_lastIndex]);
        OnActionDone?.Invoke();
    }

    public void BuyFlourStock()
    {
        
        flourStock += baker.BuyFlour(ref money);
        OnFlourBought?.Invoke(money);
        OnActionDone?.Invoke();
    }

    public void DisplayStock()
    {
        int _size = allBread.Count;
        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine($"{i + 1} - {allBread[i]}");
        }
        Console.ReadLine();
        OnStockDisplayed?.Invoke();
        OnActionDone?.Invoke();
    }


    public override string ToString() => $"CurrentFlour Stock : {flourStock} - Money : {money}";

    public static bool operator !(Bakery _this)
    {
        return _this == null;
    }
}

