using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup _grid;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private Transform _arrayOfPositions;

    [Header("Pieces")]
    [SerializeField]
    private Piece _piecePrefab;

    [SerializeField]
    private Color _player1Color;

    [SerializeField]
    private Color _player2Color;

    private Board _board;
    private Transform[,] _cellMatrix;

    private Player _currentPlayer;

    // Use this for initialization
    void Start ()
    {
        _board = new Board();
        InitBoard();
        _currentPlayer = Player.Player1;

        HideArrows();
        BeginTurn();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void InitBoard()
    {
        _cellMatrix = new Transform[7, 6];

        for (int i = 0; i < 7; ++i)
        {
            for(int j = 0; j < 6; ++j)
            {
                _cellMatrix[i,j] = Instantiate(_cellPrefab, _grid.transform).transform;
            }
        }
    }

    public void PlayPiece(int column)
    {
        int row = _board.GetRowForColumn(column);
        var piece = Instantiate(_piecePrefab, _cellMatrix[column, row]);
        piece.GetComponent<Image>().color = _currentPlayer == Player.Player1 ? _player1Color : _player2Color;

        _board.PlayPiece(_currentPlayer, column);

        bool winner = _board.ChechForWinner(_currentPlayer, row, column);
        if(winner)
        {
            Debug.Log("Winner");
        }

        EndTurn();
    }

    private void BeginTurn()
    {
        ShowArrows();
    }

    private void EndTurn()
    {
        ChangePlayerTurn();

        HideArrows();

        BeginTurn();
    }

    private void ChangePlayerTurn()
    {
        if (_currentPlayer == Player.Player1)
        {
            _currentPlayer = Player.Player2;
        }
        else
        {
            _currentPlayer = Player.Player1;
        }
    }

    private void ShowArrows()
    {
        List<int> validColumns = _board.GetValidColumns();
        foreach(int column in validColumns)
        {
            _arrayOfPositions.GetChild(column).gameObject.SetActive(true);
        }
    }

    private void HideArrows()
    {
        for(int i = 0; i < _arrayOfPositions.childCount; ++i)
        {
            _arrayOfPositions.GetChild(i).gameObject.SetActive(false);
        }
    }
}
