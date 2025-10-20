using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class InputRequest
{
    public static string StringRequest(string _msg)
    {
        Console.WriteLine(_msg);
        return Console.ReadLine();
    }

    public static int IntRequest(string _msg)
    {
        bool _valid = int.TryParse(StringRequest(_msg), out int _result);
        return _valid ? _result : IntRequest(_msg);
    }
}

