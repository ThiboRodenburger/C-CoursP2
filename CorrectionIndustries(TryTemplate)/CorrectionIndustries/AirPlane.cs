using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirPlane : Vehicle
{
    public const int MIN_PASSENGER = 100, MAX_PASSENGER = 1000;
    public const int MIN_ENGINE = 2, MAX_ENGINE = 4;

    public int Engines { get; private set; } = 2;
    public int Passengers { get; private set; } = 100;


    public AirPlane() { }

    public AirPlane(EVehicleColor _color, int _engines, int _passengers) : base(_color)
    {
        Engines = _engines;
        Passengers = _passengers;
    }

    public AirPlane(Factory<Vehicle>.FTempVehicleModel _model) : base(_model.Color) 
    {
        Engines = _model.Engines;
        Passengers = _model.Passengers;
    }

    public override void StartEngine() => Console.WriteLine("Start Plane");

    public override void StopEngine() => Console.WriteLine("Stop Plane");

    public override string ToString() => $"New plane {Color} with {Engines} engines and {Passengers} passengers !";

}
