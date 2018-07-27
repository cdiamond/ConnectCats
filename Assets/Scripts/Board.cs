using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;

    private Cell[,] _cellMatrix;

    private Player _currentPlayer;

    public Board()
    {
        _cellMatrix = new Cell[ROWS, COLUMNS];
        _currentPlayer = Player.Player1;
    }

    public void PlayPiece(int column)
    {
        // Find where the piece will end up
        int row = ROWS - 1;
        for (int i = ROWS - 1; i > -1; --i)
        {
            if (_cellMatrix[i, column].State != Cell.CellState.Empty)
            {
                break;
            }
            else
            {
                row = i;
            }
        }

        // Set the cell state
        if (_currentPlayer == Player.Player1)
        {
            _cellMatrix[row, column].State = Cell.CellState.Player1;
        }
        else
        {
            _cellMatrix[row, column].State = Cell.CellState.Player2;
        }

        // Set next player
        ChangePlayerTurn();
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

    public List<int> GetValidColumns()
    {
        List<int> columns = new List<int>();
        for(int i = 0; i < COLUMNS; ++i)
        {
            if(_cellMatrix[0,i].State == Cell.CellState.Empty)
            {
                columns.Add(i);
            }
        }

        return columns;
    }
}
