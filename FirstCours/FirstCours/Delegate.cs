using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Delegate
{
    public delegate void DelegateTest(); //Creation du type de delegate
    public delegate void DelegateTestParam(int _int, string _text);
    public delegate int DelegateReturn();
    public delegate void DelegateArgs(int _int, string _s);

    //Action avec seulement des paramettre
    public event Action<int, string> OnActionTest = null; // on peut pas mettre event et a ce moment action fonctionne comme un delegate
   //action avec type de retour
    public event Func<int, string> OnFuncTest = null;// premier est un parametre et le deuxieme est le type renvoyé

    public DelegateTest myDelegate;
    public DelegateTestParam myDelegateParam;
    public DelegateReturn myDelegateReturn;
    public DelegateArgs myDelegateArgs;

    public Delegate()
    {
        //Basic delegate
        //myDelegate += Test;
        //myDelegate.Invoke();
        //myDelegate -= Test;
        //myDelegate?.Invoke();

        //Param Delegate
        //myDelegateParam += TestParam;
        //myDelegateParam.Invoke(15, "Salut");
        //myDelegateParam -= TestParam;
        //myDelegateParam = null;

        //Return Delegate
        //myDelegateReturn += Addition;
        //int? _number = myDelegateReturn?.Invoke();
        //Console.WriteLine(_number);

        //Args Delegate
        //myDelegateArgs += (_n, _s) => { Test(); };
        //myDelegateArgs?.Invoke(15, "dede");
        //myDelegateArgs = null;

        //event action
        //OnActionTest += TestParam;
        //OnActionTest?.Invoke(20, "slt");

        //event Func
        OnFuncTest += GetNumberToText;
        Console.WriteLine(OnFuncTest?.Invoke(2));
    }

    void Test()
    {
        Console.WriteLine("Test");
    }

    void TestParam(int _int, string _text)
    {
        Console.WriteLine("TestParam {0} {1}", _int, _text);
    }

    int Addition()
    { 
        return 2+2; 
    }
    string GetNumberToText(int _number)
    {
        return _number.ToString();
    }

}

