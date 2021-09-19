using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    public Sprite Cross;
    public Sprite Circle;

    private SpriteRenderer _renderer;
    private GameBoard _gameBoard;
     
    private bool used = false;
    private void Start()
    {
        _gameBoard = FindObjectOfType<GameBoard>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (used) return;
            used = true;
        
        if (_gameBoard.CurrentPlayer == GameBoard.Player.CROSS)
        {
            _renderer.sprite = Cross;
        }
        else
        {
            _renderer.sprite = Circle;
        }
        _gameBoard.ChangePlayer();
    }
}
