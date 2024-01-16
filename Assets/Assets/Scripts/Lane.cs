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

    [Serializable]
    public enum Player
    {
        Hero,
        Enemy
    }

    [Serializable]
    public enum Arrangement
    {
        Front,
        Back
    }

    [Serializable]
    public class Location
    {
        public Player playerSide;
        public Arrangement arrangement;
    }

    [SerializedDictionary("Placement", "Monster")]
    public SerializedDictionary<Location, MonsterBehavior> laneMap;
}
