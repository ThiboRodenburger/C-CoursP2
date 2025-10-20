using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Baker
{
    const int FLOUR_COST = 2;

    public Baker() { }

    public int BuyFlour(ref int _money)
    {
        if(_money < FLOUR_COST)
        {
            Console.WriteLine("You d not have enougt moneey to buy any flour");
            return 0;
        }
        int _qty = InputRequest.IntRequest($"How much flour do you wish to buy ?\n Each cost [{FLOUR_COST}]");
        if (_qty * FLOUR_COST > _money)
        {
            Console.WriteLine("This Much flour is too expensive! buy less or sell more bread !");
            _qty = BuyFlour(ref _money);
            return _qty;
        }
        _money -= _qty * FLOUR_COST;
        return _qty;
    }

    public FBread MakeBread(ref int _flourStock)
    {
        string _name = InputRequest.StringRequest("input the bread's name");
        int _flourQtyNeeded = InputRequest.IntRequest("Input the required flour quantity ");
        if (_flourQtyNeeded > _flourStock)
        {
            Console.WriteLine("Not enough flour. buy more first");
            return default;
        }
        int _price = InputRequest.IntRequest("Input the price of the bread") + _flourQtyNeeded / 2;
        _flourStock -= _flourQtyNeeded;
        return string.IsNullOrEmpty(_name) ? new FBread(_flourQtyNeeded, _price) 
                                           : new FBread(_flourQtyNeeded, _price, _name);
    }
}

