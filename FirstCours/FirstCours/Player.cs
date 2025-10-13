using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Player
{
    #region Fields
    string name = " "; 
    int age = 0;
    int life = 10;
    #endregion

    #region Properties
    public string Name => name;
    public int PlayerAge { get {return PlayerAge;} }
    #endregion

    #region Constructors
    public Player ()
    {

    }
    public Player(string _playerName, int _playerAge, int _PlayerLife)
    {
        name = _playerName;
        age = _playerAge;
        life = _PlayerLife;
    }
    #endregion

    public void RemoveHealth(int _value)
    {
        life -= _value;
    }

    public void AddHealth(int _value)
    {
        life += _value;
    }

    public void DebugHealth()
    {
        System.Console.WriteLine("Value life : ", life);
    }
}

