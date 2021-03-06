using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private GameBoard _gameBoard;

    public Player ownedByPlayer = Player.NONE;
    public bool IsWinningTile = false;
	
    private void Start()
    {
        _gameBoard = FindObjectOfType<GameBoard>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (IsWinningTile)
        {
            transform.localScale = Vector3.one * ( Mathf.Abs(Mathf.Sin(Time.time *2)) + 0.3f);
        }
    }

    public void SetWinnerColor()
    {
        _renderer.color = _gameBoard.WinningColor;
    }

    private void OnMouseDown()
    {
        if(_gameBoard.IsGameFinished == true)
            return;

        if (ownedByPlayer != Player.NONE)
            return;
        ownedByPlayer = _gameBoard.CurrentPlayer;
        
        if (_gameBoard.CurrentPlayer == Player.CROSS)
        {
            _renderer.sprite = _gameBoard.CrossSprite;
        }
        else
        {
            _renderer.sprite = _gameBoard.CircleSprite;
        }

        Player winner = _gameBoard.CheckWin();
        Debug.Log($"Winner: {winner}");
        
        if (winner == Player.NONE)
        {
            _gameBoard.ChangePlayer();
        }
        else
        {
            _gameBoard.WeHaveAWinner();
        }
    }
}
