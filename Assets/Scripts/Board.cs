using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;

    private Cell[,] _cellMatrix;

    public Board()
    {
        InitBoard();
    }

    public void InitBoard()
    {
        _cellMatrix = new Cell[COLUMNS, ROWS];
        for (int i = 0; i < COLUMNS; ++i)
        {
            for (int j = 0; j < ROWS; ++j)
            {
                _cellMatrix[i, j] = new Cell();
            }
        }
    }

    public void PlayPiece(Player player, int column)
    {
        // Find where the piece will end up
        int row = ROWS - 1;
        for (int i = ROWS - 1; i > -1; --i)
        {
            if (_cellMatrix[column, i].State != Cell.CellState.Empty)
            {
                break;
            }
            else
            {
                row = i;
            }
        }

        // Set the cell state
        if (player == Player.Player1)
        {
            _cellMatrix[column, row].State = Cell.CellState.Player1;
        }
        else
        {
            _cellMatrix[column, row].State = Cell.CellState.Player2;
        }
    }

    public List<int> GetValidColumns()
    {
        List<int> columns = new List<int>();
        for(int i = 0; i < COLUMNS; ++i)
        {
            if(_cellMatrix[i, ROWS - 1].State == Cell.CellState.Empty)
            {
                columns.Add(i);
            }
        }

        return columns;
    }

    public int GetRowForColumn(int column)
    {
        int row = ROWS - 1;
        for (int i = ROWS - 1; i > -1; --i)
        {
            if (_cellMatrix[column, i].State != Cell.CellState.Empty)
            {
                break;
            }
            else
            {
                row = i;
            }
        }

        return row;
    }

    public bool ChechForWinner(Player player, int row, int column)
    {
        Cell.CellState playerCellState = player == Player.Player1 ? Cell.CellState.Player1 : Cell.CellState.Player2;
        
        // Horizontal
        int hCells = 0;
        for(int i = -1; i < 2; ++i)
        {
            if(i == 0)
            {
                continue;
            }

            for (int j = 0; j < 3; ++j)
            {
                int pos = column + (j * i) + i;
                if (pos >= 0 && pos < COLUMNS)
                {
                    if (_cellMatrix[pos, row].State == playerCellState)
                    {
                        ++hCells;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if(hCells >= 3)
        {
            return true;
        }

        // Vertical
        int vCells = 0;
        for (int i = -1; i < 2; ++i)
        {
            if (i == 0)
            {
                continue;
            }

            for (int j = 0; j < 3; ++j)
            {
                int pos = row + (j * i) + i;
                if (pos >= 0 && pos < ROWS)
                {
                    if (_cellMatrix[column, pos].State == playerCellState)
                    {
                        ++vCells;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (vCells >= 3)
        {
            return true;
        }

        int d1Cells = 0;
        for (int i = -1; i < 2; ++i)
        {
            if (i == 0)
            {
                continue;
            }

            for (int j = 0; j < 3; ++j)
            {
                int posX = column + (j * i) + i;
                int posY = row + (j * i) + i;
                if (posX >= 0 && posX < COLUMNS && posY >= 0 && posY < ROWS)
                {
                    if (_cellMatrix[posX, posY].State == playerCellState)
                    {
                        ++d1Cells;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (d1Cells >= 3)
        {
            return true;
        }

        int d2Cells = 0;
        for (int i = -1; i < 2; ++i)
        {
            if (i == 0)
            {
                continue;
            }

            for (int j = 0; j < 3; ++j)
            {
                int posX = column + (j * i) + i;
                int posY = row + (((j * i) + i) * -1);
                if (posX >= 0 && posX < COLUMNS && posY >= 0 && posY < ROWS)
                {
                    if (_cellMatrix[posX, posY].State == playerCellState)
                    {
                        ++d2Cells;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (d2Cells >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
