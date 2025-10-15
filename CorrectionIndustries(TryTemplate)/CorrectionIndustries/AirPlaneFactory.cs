using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirPlaneFactory : Factory <Vehicle>
{
    public struct FTempPlaneModel
    {
        public EVehicleColor Color;
        public int Engines;
        public int Passengers;
    }

    public override event Action OnStartProduction = null;
    public override event Action OnStopProduction = null;
    public override event Action OnVehicleProduced = null;


    FTempPlaneModel tempPlane = new FTempPlaneModel();

    public AirPlaneFactory() { }

    public AirPlaneFactory(string _name) : base(_name)
    {
        OnStartProduction += SelectColor;
        OnColorSelected += (color) =>
        {
            tempPlane.Color = color;
            SelectSettings(
                $"Select the number of engines : [{AirPlane.MIN_ENGINE}] - [{AirPlane.MAX_ENGINE}] \n",
                AirPlane.MIN_ENGINE,
                AirPlane.MAX_ENGINE,
                "Number of Engines :",
                (engines) => tempPlane.Engines = engines);
            SelectSettings(
                $"Select the number of passengers : [{AirPlane.MIN_PASSENGER}] - [{AirPlane.MAX_PASSENGER}] \n",
                AirPlane.MIN_PASSENGER,
                AirPlane.MAX_PASSENGER,
                "Number of Passengers :",
                (passengers) => tempPlane.Passengers = passengers);
        };


    } 

    public override Vehicle CreatVehicle()
    {
        OnStartProduction?.Invoke();
        AirPlane _plane = new AirPlane(tempPlane);
        allVehicles.Add(_plane);
        OnStopProduction?.Invoke();
        OnVehicleProduced?.Invoke();
        return _plane;  
    }
}

