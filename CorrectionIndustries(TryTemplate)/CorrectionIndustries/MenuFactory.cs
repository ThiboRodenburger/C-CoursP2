using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class MenuFactory
{
    List<MenuFactorySelection> selections = new List<MenuFactorySelection>();
    Factory<Vehicle> currentFactory = null;

    public MenuFactory() { }

    public MenuFactory(Factory<Vehicle> _currentFactory)
    {
        currentFactory = _currentFactory;

        currentFactory.OnStopProduction += () =>
        {
            ShowMenu();
        };
        currentFactory.OnEndReadVehicles += () =>
        {
            ShowMenu();
        };


        selections.Add(new MenuFactorySelection("Creat New Vehicle", currentFactory.StartProduction));
        selections.Add(new MenuFactorySelection("List all Vehicle", currentFactory.DisplayStock));
        selections.Add(new MenuFactorySelection("Exit",() => Environment.Exit(0)));
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

