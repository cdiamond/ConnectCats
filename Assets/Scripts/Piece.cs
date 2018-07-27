using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private Sprite _player1Sprite;
    [SerializeField]
    private Sprite _player2Sprite;

    private Sprite _sprite;

	// Use this for initialization
	void Start ()
    {
        _sprite = GetComponent<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetPlayer(Player player)
    {
        if(player == Player.Player1)
        {
            _sprite = _player1Sprite;
        }
        else
        {
            _sprite = _player2Sprite;
        }
    }
}
