using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameBoard _gameBoard;

    public Image CurrentPlayerImage;

    public Text GameStatusLabel;
    // Start is called before the first frame update
    void Start()
    {
        _gameBoard = FindObjectOfType<GameBoard>();
        _gameBoard.OnPlayerChanged += OnPlayerChanged;
        _gameBoard.OnGameFinished += GameBoardOnOnGameFinished;
        OnPlayerChanged(_gameBoard.CurrentPlayer);
    }

    private void GameBoardOnOnGameFinished(Player obj)
    {
        GameStatusLabel.text = $"Wygrały {(obj == Player.CROSS?"Krzyżyki":"Kółka")} :)";
    }

    void OnPlayerChanged(Player currentPlayer)
    {
        CurrentPlayerImage.sprite = currentPlayer == Player.CROSS ? _gameBoard.CrossSprite : _gameBoard.CircleSprite;
    }
    
}
