using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarFactory : Factory <Vehicle>
{


    public struct FTempCarModel
    {
        public EVehicleColor Color;
        public int Doors;
    }


    //public override event Action OnStartProduction = null;
    //public override event Action OnStopProduction = null;
    //public override event Action OnVehicleProduced = null;

    FTempCarModel tempCar= new FTempCarModel();


    public CarFactory() { }
    public CarFactory(string _name) : base(_name)
    {
        OnColorSelected += (color) =>
        {
            tempCar.Color = color;
            SelectSettings(
                $"Select Vehicle door number : [{Car.MIN_DOORS}] - [{Car.MAX_DOORS}]\n",
                Car.MIN_DOORS,
                Car.MAX_DOORS,
                "Car doors :",
                (doors) => tempCar.Doors = doors);
        };
    }

    //public override Vehicle CreatVehicle()
    //{
    //    OnStartProduction?.Invoke();
    //    Console.WriteLine("Car Manufacturing");
    //    SelectColor();
    //    Car _car = new Car(tempCar);
    //    allVehicles.Add(_car);
    //    OnStopProduction?.Invoke();
    //    OnVehicleProduced?.Invoke();
    //    return _car; 
    //}
}

