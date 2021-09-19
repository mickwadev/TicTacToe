using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    NONE,
    CROSS,
    CIRCLE
}

public class GameBoard : MonoBehaviour
{
    public Player CurrentPlayer = Player.CROSS;
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

    public void WeHaveAWinner()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            if (Tiles[i].ownedByPlayer == CurrentPlayer)
            {
                Tiles[i].SetWinnerColor();
            }
        }
    }

    public Player CheckWin()
    {
        if(Win(0, 1, 2) != Player.NONE) return CurrentPlayer;
        if(Win(3, 4, 5) != Player.NONE) return CurrentPlayer;
        if(Win(6, 7, 8) != Player.NONE) return CurrentPlayer;
        
        if(Win(0, 3, 6) != Player.NONE) return CurrentPlayer;
        if(Win(1, 4, 7) != Player.NONE) return CurrentPlayer;
        if(Win(2, 5, 8) != Player.NONE) return CurrentPlayer;
        
        if(Win(0, 4, 8) != Player.NONE) return CurrentPlayer;
        if (Win(2, 4, 6) != Player.NONE) return CurrentPlayer;
        return Player.NONE;
    }

    Player Win(int i1, int i2, int i3)
    {
        if (Tiles[i1].ownedByPlayer == Tiles[i2].ownedByPlayer &&
            Tiles[i2].ownedByPlayer == Tiles[i3].ownedByPlayer && Tiles[i1].ownedByPlayer != Player.NONE)
            return Tiles[i1].ownedByPlayer;

        return Player.NONE;
    }
}