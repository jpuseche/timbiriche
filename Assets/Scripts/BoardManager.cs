using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width = 4;
    public int Height = 4;
    public Point PointPrefab;
    public Line VerticalLinePrefab;
    public Line HorizontalLinePrefab;
    public int[,] VerticalLines;
    public int[,] HorizontalLines;
    public PlayerWins PlayerOneWinsPrefab;
    public PlayerWins PlayerTwoWinsPrefab;
    public Text PlayerOneScore;
    public Text PlayerTwoScore;
   
   private void Awake()
   {
       Instance = this;
   }
    void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                var p = new Vector2(i, j);
                Instantiate(PointPrefab, p, Quaternion.identity);
            }
        }

        VerticalLines =  new int[Height, Width-1];
        HorizontalLines =  new int[Height-1, Width];
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height-1; j++)
            {
                VerticalLines[i,j] = 0;
                var l = new Vector2(i, j);
                VerticalLinePrefab._position = new Vector2(i, j);
                VerticalLinePrefab.isVertical = true;
                Instantiate(VerticalLinePrefab, l, Quaternion.identity);
                
                HorizontalLines[j,i] = 0;
                l = new Vector2(j, i);
                HorizontalLinePrefab._position = new Vector2(j, i);
                HorizontalLinePrefab.isVertical = false;
                Instantiate(HorizontalLinePrefab, l, Quaternion.identity);
                
            }
        }

        var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    public void SetLine(Line l, bool isPlayerOne)
    {
        if (l.isVertical)
        {
            if (isPlayerOne)
            {
                VerticalLines[(int)l._position.x, (int)l._position.y] = 1;
            }
            else
            {
                VerticalLines[(int)l._position.x, (int)l._position.y] = 2;
            }
        }
        else
        {
            if (isPlayerOne)
            {
                HorizontalLines[(int)l._position.x, (int)l._position.y] = 1;
            }
            else
            {
                HorizontalLines[(int)l._position.x, (int)l._position.y] = 2;
            }
        }

        int P1Score = 0;
        int P2Score = 0;
        for (int i = 0; i < Width-1; i++)
        {
            for (int j = 0; j < Height-1; j++)
            {
                if (HorizontalLines[j, i] == 1 & VerticalLines[j+1, i] == 1 & HorizontalLines[j, i+1] == 1 & VerticalLines[j, i] == 1)
                {
                    P1Score = P1Score + 1;
                    PlayerOneScore.text = "P1: " + P1Score;

                    if (P1Score == 2)
                    {
                        Instantiate(PlayerOneWinsPrefab);
                        GameManager.Instance.EndGame();
                    }
                }
                if (HorizontalLines[j, i] == 2 & VerticalLines[j+1, i] == 2 & HorizontalLines[j, i+1] == 2 & VerticalLines[j, i] == 2)
                {
                    P2Score = P2Score + 1;
                    PlayerTwoScore.text = "P2: " + P2Score;

                    if (P2Score == 2)
                    {
                        Instantiate(PlayerTwoWinsPrefab);
                        GameManager.Instance.EndGame();
                    }
                }
            }
        }

        GameManager.Instance.SwitchPlayer();
    }
}
