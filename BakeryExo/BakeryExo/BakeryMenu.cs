using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BakeryMenu
{
    List<BakeryMenuSelection> selections = new List<BakeryMenuSelection>();
    Bakery currentBakery = null;
    string path = "BakeryStock.txt";

    public BakeryMenu() { }

    public BakeryMenu(Bakery _currentBakery)
    {
        currentBakery = _currentBakery;

        currentBakery.OnStopProduction += () =>
        {
            ShowMenu();
        };
        currentBakery.OnEndReadBakerySupply += () =>
        {
            ShowMenu();
        };
        currentBakery.OnBreadSelling += () =>
        {
            ShowMenu();
        };
        currentBakery.OnEndBuyingFlour += () =>
        {
            ShowMenu();
        };
        currentBakery.OnEndSaveBakery += () =>
        {
            ShowMenu();
        };


        selections.Add(new BakeryMenuSelection("Product Bread", () => currentBakery.StartProduction(path)));
        selections.Add(new BakeryMenuSelection("List Bakery Content",() => currentBakery.DisplayStock(path)));
        selections.Add(new BakeryMenuSelection("Sell Bread",() => currentBakery.SellBread(path)));
        selections.Add(new BakeryMenuSelection("Buy Flour",() => currentBakery.BuyFlour(path)));
        selections.Add(new BakeryMenuSelection("Save Bakery",() => currentBakery.Save(path)));
        selections.Add(new BakeryMenuSelection("Exit", () => Environment.Exit(0)));
        ShowMenu();
    }

    //void Test()
    //{
    //    Console.WriteLine("Test");
    //}

    void ShowMenu()
    {
        Console.Clear();
        int _size = selections.Count;
        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine($"{i + 1} - {selections[i].Label}");
        }
        Select();
    }

    void Select()
    {
        string _input = Console.ReadLine();
        bool _validInput = int.TryParse(_input, out int _result);
        if (!_validInput)
        {
            Console.WriteLine("Error : Characters detected instead of numbers ! try again.");
            Select();
            return;
        }
        int _size = selections.Count;
        _result = _result < 1 ? 1 :
                  _result > _size ? _size :
                  _result;
        selections[_result - 1].Execute();
    }
}

