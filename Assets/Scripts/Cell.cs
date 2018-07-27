using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public enum CellState
    {
        Empty,
        Player1,
        Player2
    }

    public CellState State { get; set; }

    public Cell()
    {
        State = CellState.Empty;
    }
}
