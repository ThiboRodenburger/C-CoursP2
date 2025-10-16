using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car : Vehicle
{
    public const int MIN_DOORS = 2, MAX_DOORS = 4;
    public int Doors { get; private set; } = 2;


    public Car()
    {

    }
    public Car(EVehicleColor _color, int _doors) : base(_color)
    {
        Doors = _doors;
    }

    public Car(Factory<Vehicle>.FTempVehicleModel _model)
    {
        Color = _model.Color;
        Doors = _model.Doors;
    }

    public override void StartEngine()
    {
        Console.WriteLine("Start Engine Vrooooooooooooooum");
    }
    public override void StopEngine()
    {
        Console.WriteLine("Stop Engine");
        
    }

    public override string ToString() => $"New {Color} Car with {Doors} doors !";
}
