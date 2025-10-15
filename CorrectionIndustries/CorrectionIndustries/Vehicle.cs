using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EVehicleColor
{
    BLACK,
    RED,
    WHITE,
    YELLOW,
    GREEN
}

public abstract class Vehicle
{ 
    public EVehicleColor Color {  get; protected set; } = EVehicleColor.BLACK;
    
    public Vehicle()
    {
        Color = EVehicleColor.BLACK;
    }

    public abstract void StartEngine();
    public abstract void StopEngine();

    public Vehicle(EVehicleColor _color)
    {
        Color = _color;
    }
}

