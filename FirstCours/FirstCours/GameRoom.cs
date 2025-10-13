using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GameRoom
{
    #region Fields
    int numberPlayer = 0;
    #endregion

    #region Properties
    public string GameName { get; private set; }
    #endregion

    #region Constructors
    public GameRoom()
    {
        GameName = "Lobby";
    }
    public GameRoom(string _roomName)
    {
        GameName = _roomName;
    }

    public GameRoom(string _roomName, int _roomPlayer)
    {
        GameName = _roomName;
      numberPlayer = _roomPlayer;
    }
    #endregion

    #region Methods
    public void StartGame(int _numberPlayer)
    {
       numberPlayer = _numberPlayer;
       Console.WriteLine("Game Start {0} -> {1} Players ! ", GameName, numberPlayer);

    }

    public void DisplayRoomName() => Console.WriteLine("Game Start {0} ! ", GameName); // ecriture simplifrié si une seule instruction
    #endregion
}


