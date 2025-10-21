// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
Console.WriteLine("Hello, World!");

if(File.Exists("BakeryStock.txt"))
{
    Bakery _bakery = new Bakery();
    _bakery.LoadSave("BakeryStock.txt");
    BakeryMenu menu = new BakeryMenu(_bakery);
}
else
{
    Bakery _bakery = new Bakery("Bakery of Thibo", 20, 100, 15000);
    BakeryMenu _bakeryMenu = new BakeryMenu(_bakery);
}
