// Code written by Jaxon Lee
// 
// Data for a deck, which holds up to 40 cards and the player customizes.
// This is a deck that you build in the deck builder.

using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Lane".
[CreateAssetMenu(fileName = "newLane", menuName = "Lane", order = 2)]
public class Lane : ScriptableObject
{
    public Lane left;
    public Lane right;

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
    }

    // Monsters that are in the lane
    [SerializedDictionary("Placement", "Monster")]
    public SerializedDictionary<PlaySpot, MonsterBehavior> laneMap =
        new SerializedDictionary<PlaySpot, MonsterBehavior>();
}
