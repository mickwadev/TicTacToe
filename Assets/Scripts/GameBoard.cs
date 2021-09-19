using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public enum Player
    {
        CROSS,
        CIRCLE
    }

    public Player CurrentPlayer;
    public GameTile[] Tiles;

    public void ChangePlayer()
    {
        if (CurrentPlayer == Player.CROSS)
        {
            CurrentPlayer = Player.CIRCLE;
        }
        else
        {
            CurrentPlayer = Player.CROSS;
        }
    }

    public Player CheckWin()
    {
        return Player.CROSS;
    }
}