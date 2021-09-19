using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public enum CurrentPlayer
    {
        CROSS,
        CIRCLE
    }

    public CurrentPlayer Player;

    public void ChangePlayer()
    {
        if (Player == CurrentPlayer.CROSS)
        {
            Player = CurrentPlayer.CIRCLE;
        }
        else
        {
            Player = CurrentPlayer.CROSS;
        }
    }
}