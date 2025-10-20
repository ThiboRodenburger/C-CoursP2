using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BakeryMenuSelection
{
    public string Label { get; private set; } = "Label";

    Action callback = null;

    public BakeryMenuSelection() { }

    public BakeryMenuSelection(string _labal, Action _callback)
    {
        Label = _labal;
        callback = _callback;
    }

    public void Execute() => callback?.Invoke();
}

