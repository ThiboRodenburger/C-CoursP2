using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Room
{
    public const int MIN_PLAYER = 2, MAX_PLAYER = 4;
    string roomName = "Room";
    int numberPlayer = 0;
    Player[] allPlayers = new Player[] { }; // Init Basique tableau
    //Player[] allPlayers = new Player[MAX_PLAYER]; // Init par taille (accepte uniquement les statiques)
    //Player[] allPlayers = new Player[] { new Player(), new Player() }; // Init par valeur
    //Player[] allPlayers = { new Player(), new Player() }; // Init Simplifié


    public string RoomName
    {

        get
        {
            return string.Format("Room {0} ! {1}", roomName, "{0}"); 
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                roomName = " The Big Room";
                return;
            }
            roomName = value.ToLower();
        }
    }

    public GameRoom CurrentGame { get; private set; } = new GameRoom();
    public int NumberPlayer
    {
        get { return numberPlayer; }
        set
        {
            numberPlayer = value > MAX_PLAYER ? MAX_PLAYER :
                           value < MIN_PLAYER ? MIN_PLAYER :
                           value;
            CurrentGame.StartGame(numberPlayer);
        }
    }

    public Player[] AllPlayers { get; set; } = new Player[] { };

    public Room()
    {
        
    }

    public Player[] AddPlayer(int _NumberPlayer = MAX_PLAYER)
    {
        NumberPlayer = _NumberPlayer;
        Player[] _players = new Player[NumberPlayer];
        for (int i = 0; i < numberPlayer; i++)
        {
            string _name = string.Format("Player {0}", i + 1);
            _players[i] = new Player(_name, 18, 100);
            Console.WriteLine("{0}", _name);
        }
        return _players;
    }
}

