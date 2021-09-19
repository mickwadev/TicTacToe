using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameBoard _gameBoard;

    public Image CurrentPlayerImage;
    // Start is called before the first frame update
    void Start()
    {
        _gameBoard = FindObjectOfType<GameBoard>();
        _gameBoard.OnPlayerChanged += OnPlayerChanged;
        OnPlayerChanged(_gameBoard.CurrentPlayer);
    }

    void OnPlayerChanged(Player currentPlayer)
    {
        CurrentPlayerImage.sprite = currentPlayer == Player.CROSS ? _gameBoard.CrossSprite : _gameBoard.CircleSprite;
    }
    
}
