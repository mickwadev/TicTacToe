using System;
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
    public Sprite CircleSprite,CrossSprite;
    
    public GameTile[] Tiles;
    public bool IsGameFinished = false;
    public event Action<Player> OnPlayerChanged;
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

        if (OnPlayerChanged != null)
            OnPlayerChanged(CurrentPlayer);
    }

    public void WeHaveAWinner()
    {
        IsGameFinished = true;
        for (int i = 0; i < Tiles.Length; i++)
        {
            if (Tiles[i].IsWinningTile)
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
        {
            Tiles[i1].IsWinningTile = true;
            Tiles[i2].IsWinningTile = true;
            Tiles[i3].IsWinningTile = true;
            return Tiles[i1].ownedByPlayer;
        }

        return Player.NONE;
    }
}