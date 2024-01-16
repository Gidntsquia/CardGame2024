// Code written by Jaxon Lee
// 
// Data for one of the 5 lanes. It holds references to its neighbors and the
// monsters that are in its lane.

using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Lane".
[CreateAssetMenu(fileName = "newLane", menuName = "Lane", order = 5)]
public class Lane : ScriptableObject
{
    public Lane leftNeighbor;
    public Lane rightNeighbor;

    // The side the monster is on
    [Serializable]
    public enum Player
    {
        Hero,
        Enemy
    }

    // Front or back
    [Serializable]
    public enum Position
    {
        Front,
        Back
    }

    // Place that a monster can be played. There are 4 possible spots.
    [Serializable]
    public class PlaySpot
    {
        public Player playerSide;
        public Position position;

        public PlaySpot(Player playerSide, Position position)
        {
            this.playerSide = playerSide;
            this.position = position;
        }

        public PlaySpot[] GetOpponentPlaySpots()
        {
            // Set a default value-- this will be changed in a few lines
            Player opponentSide = Player.Hero;

            // Set opponentSide ot the opposite of whatever side this PlaySpot
            // is on.
            switch (playerSide)
            {
                case Player.Hero:
                    opponentSide = Player.Enemy;
                    break;
                case Player.Enemy:
                    opponentSide = Player.Hero;
                    break;
            }

            PlaySpot opponentFront = new PlaySpot(opponentSide, Position.Front);
            PlaySpot opponentBack = new PlaySpot(opponentSide, Position.Back);

            return new PlaySpot[] { opponentFront, opponentBack };
        }
    }

    // Monsters that are in the lane
    [SerializedDictionary("Placement", "Monster")]
    public SerializedDictionary<PlaySpot, MonsterBehavior> laneMonsterMap =
        new SerializedDictionary<PlaySpot, MonsterBehavior>();
}
