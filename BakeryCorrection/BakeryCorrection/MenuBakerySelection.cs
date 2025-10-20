using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MenuBakerySelection
{
    public string Label { get; private set; } = "Label";
    Action callback = null;
    public MenuBakerySelection() { }

    public MenuBakerySelection(string _label, Action _callback)
    {
        Label = _label;
        callback = _callback;
    }

    public void Execute() => callback();
}

