using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Factory <T>
{
    public struct FTempVehicleModel
    {
        public EVehicleColor Color;
        public int Engines;
        public int Passengers;
        public int Doors;
    }

    public event Action OnStartProduction;
    public event Action OnStopProduction;
    public event Action OnVehicleProduced;

    public event Action OnEndReadVehicles = null;

    public event Action<EVehicleColor> OnColorSelected = null;

    protected List<T> allVehicles = new List<T>();
    public T this[int _index] => allVehicles[_index];
    public int Count => allVehicles.Count;
    public string Name { get; private set; } = "Factory";

    FTempVehicleModel tempVehicle = new FTempVehicleModel();

    public Factory() { }
    public Factory(string _name)
    {
        Name = _name;
    }


    public void StartProduction()
    {
        CreatVehicle();
    }

    public void StopProduction() 
    {
        Console.WriteLine("Stop");
    }

    public  T CreatVehicle()
    {
        OnStartProduction?.Invoke();
        Console.WriteLine("Car Manufacturing");
        SelectColor();
        T _vehicle = new T(tempVehicle);
        allVehicles.Add(_vehicle);
        OnStopProduction?.Invoke();
        OnVehicleProduced?.Invoke();
        return _vehicle;
    }


    public void DisplayStock()
    { 
        int _size = allVehicles.Count;
        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine(allVehicles[i]);
        }
        Console.ReadLine();
        OnEndReadVehicles?.Invoke();
    }

    protected void SelectColor()
    {
        string[] _colors = Enum.GetNames(typeof(EVehicleColor));
        Console.WriteLine("Select vehicle Color : ");
        int _size = _colors.Length;
        for (int i = 0; i < _size; i++)
        {
            string _color = _colors[i];
            Console.WriteLine($"{i+1} {_color}");
        }
        Console.WriteLine();
        string _input = Console.ReadLine();
        bool _validInput = int.TryParse(_input, out int _result);
        if (!_validInput)
        {
            Console.WriteLine("Use Numbers to select your color, not characters ! Retry.");
            SelectColor();
            return;
        }
        _result = _result < 1 ? 1 : _result > _size ? _size : _result;
        EVehicleColor _selection = (EVehicleColor)_result - 1;
        Console.WriteLine($"Color Selection : {_selection}");
        OnColorSelected?.Invoke(_selection);
    }

    protected void SelectSettings(string _label, int _selectionMin, int _selectionMax, string _endMessage, Action<int> _callback)
    {
        Console.Write(_label);
        string _input = Console.ReadLine();
        bool _validInput = int.TryParse(_input, out int _result);
        if (!_validInput)
        {
            Console.WriteLine("Use Numbers to select your color, not characters ! Retry.");
            SelectSettings(_label, _selectionMin, _selectionMax, _endMessage, _callback);
            return;
        }
        _result = int.Clamp(_result, _selectionMin, _selectionMax);
        Console.WriteLine($"{_endMessage} [{_result}]");
        _callback?.Invoke(_result);
    }
}

