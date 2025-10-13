using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Calculatrice
{
    int number = 0;

    public int MultiplyTwo => number * 2;
    public int MultiplyThree => number * 3;
    public int Half => number / 2;
    public int Square => number * number;
    public int Cube => number * number * number;



    public Calculatrice()
    {
     
    }

    public Calculatrice(int _number) => number = _number;

}

