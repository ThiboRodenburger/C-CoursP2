using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstCours
{
    internal class Program
    {
        ////Champs ou Fields
        //int age = 22;
        //double taille = 1.4;
        //float pointure = 43.2f;
        //string name = "Thibo";
        ////readonly
        
        ////Propriétés ou Properties
        //public int Age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //    set
        //    {
        //        age = value;
        //    }
        //}
       
        //public string Other { get { return name; } private set { name = value; } }
        //public string Name => name;


        static void Main(string[] args)
        {
            //    //int? _chiffre = null;
            //    //int _test = _chiffre ?? 50;
            //    //string _nom = null;
            //    //_nom = _nom ?? "Thibo";
            //    new Program();

            //Exo1: Player
            //Player _player = new Player("Stiilko", 18, 100);




            //Exo2 Calculatrice
            //int _number = 0;
            //Console.WriteLine("enter your number : \n");
            //string _numberString = Console.ReadLine();
            //bool _succes = int.TryParse( _numberString, out int _result );
            //Calculatrice _calculatrice = new Calculatrice(_result);
            //Console.WriteLine(_calculatrice.MultiplyTwo);
            //Console.WriteLine(_calculatrice.MultiplyThree);
            //Console.WriteLine(_calculatrice.Half);
            //Console.WriteLine(_calculatrice.Square);
            //Console.WriteLine(_calculatrice.Cube);

            //Exo3 GameRoom
            //Room _room = new Room();
            //_room.NumberPlayer = 6;
            //_room.AllPlayers = _room.AddPlayer(8);

            //Exo 4 : just Price
            //JustPrice _justPrice = new JustPrice();
            //_justPrice.GenerateRandomNumber();

            //Cours Delegate
            Delegate _del = new Delegate();
            //_del.myDelegate += Test;
            //_del.myDelegate?.Invoke();
            _del.OnActionTest += Test;



        }

        static void Test()
        {
            Console.WriteLine("Hey");
        }

        static void Test(int _int, string _text)
        {
            Console.WriteLine("");
        }

        //public Program ()
        //{
        //    age = 8;
        //    Other = "Rodenburger";
        //    Console.WriteLine(Age);
        //    Console.WriteLine(Other);
        //}
    }
}
