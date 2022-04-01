using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWins : MonoBehaviour
{
    private Vector2 _position;

    public Vector2 Pos => _position;

    public void Init(Vector2 position)
    {
        this._position = position;
    }
}
