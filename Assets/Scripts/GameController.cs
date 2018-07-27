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
    private Piece _piecePrefab;

    private Board _board;

	// Use this for initialization
	void Start ()
    {
        _board = new Board();
        InitBoard();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void InitBoard()
    {
        for(int i = 0; i < 6; ++i)
        {
            for(int j = 0; j < 7; ++j)
            {
                var cell = Instantiate(_cellPrefab, _grid.transform);
            }
        }
    }

    private void BeginTurn()
    {
        ShowArrows();
    }

    private void ShowArrows()
    {
        List<int> validColumns = _board.GetValidColumns();
    }
}
