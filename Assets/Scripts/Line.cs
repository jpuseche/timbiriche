using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject InnerLine;
    public GameObject FirstCircle;
    public GameObject SecondCircle;
    public Vector2 _position;
    public bool isVertical;

    public Vector2 Pos => _position;

    public void Init(Vector2 position)
    {
        this._position = position;
    }

    private void OnMouseDown()
    {
        
        if (GameManager.Instance.GetGameState == GameManager.GameState.player1 & InnerLine.GetComponent<SpriteRenderer>().color == Color.white)
        {
            InnerLine.GetComponent<SpriteRenderer>().color = Color.blue;
            FirstCircle.GetComponent<SpriteRenderer>().color = Color.blue;
            SecondCircle.GetComponent<SpriteRenderer>().color = Color.blue;

            BoardManager.Instance.SetLine(this, true);
        
        }
        else if (GameManager.Instance.GetGameState == GameManager.GameState.player2 & InnerLine.GetComponent<SpriteRenderer>().color == Color.white)
        {
            InnerLine.GetComponent<SpriteRenderer>().color = Color.red;
            FirstCircle.GetComponent<SpriteRenderer>().color = Color.red;
            SecondCircle.GetComponent<SpriteRenderer>().color = Color.red;

            BoardManager.Instance.SetLine(this, false);
        
        }
    }
}
