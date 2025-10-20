using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MenuBakery
{
    Bakery bakery = null;
    List<MenuBakerySelection> mainMenu = new List<MenuBakerySelection>();

    public MenuBakery()
    {
        bakery = new Bakery();

        bakery.OnActionDone += () => ResetMenu();

        mainMenu.Add(new MenuBakerySelection("Make bread", bakery.MakeBread));
        mainMenu.Add(new MenuBakerySelection("Sell bread", bakery.SellBread));
        mainMenu.Add(new MenuBakerySelection("Buy Flour", bakery.BuyFlourStock));
        mainMenu.Add(new MenuBakerySelection("Display Products", bakery.DisplayStock));
        mainMenu.Add(new MenuBakerySelection("Exit", Exit));

        ShowMenu();
    }

    void Exit()
    {
        //TODO Save
        Environment.Exit(0);
    }

    void ResetMenu()
    { 
        mainMenu.Clear(); 
        ShowMenu();
    }


    void ShowMenu()
    {
        if (!bakery) return;
        Console.WriteLine(bakery);

        int _size = mainMenu.Count;
        for (int i = 0; i < _size;i++)
        {
            Console.WriteLine($"{i+1} - {mainMenu[i].Label}");
        }
        Select();
    }

    void Select()
    {
        int _index = InputRequest.IntRequest("Select : ") - 1;
        if (_index < 0 || _index > mainMenu.Count)
        {
            Select();
            return;
        }
        mainMenu[_index].Execute();
    }

}

