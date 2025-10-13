using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JustPrice
{
    public const int MIN_VALUE = 0, MAX_VALUE = 5000;
    int price = 0;
    int currentPrice = 0;

    public int Price { get { return price; } set { price = value; } }


    public JustPrice()
    {

    }
    public void GenerateRandomNumber()
    {
        Random _random = new Random();
        price = _random.Next(MIN_VALUE, MAX_VALUE);
        GameLoop();
    }

    void GameLoop()
    {
        bool _win = false;
        while (!_win)
        {
            GuessPrice();
            _win = FindingNumber(currentPrice);
        }
    }

    void GuessPrice()
    {
        Console.WriteLine("Entrer your price : ");
        string _s = Console.ReadLine();
        currentPrice = int.Parse(_s);
    }

    public bool FindingNumber(int _number)
    {

        if (_number > price)
        {
            Console.WriteLine("It's Less");
            return false;
        }
        else if (_number < price)
        {
            Console.WriteLine("It's More");
            return false;    
        }
        else
        {
            Console.WriteLine("It's Win");
            return true;
        }
    }

   
}
