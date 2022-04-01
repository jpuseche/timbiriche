using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _gameState;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameState = GameState.start;
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState GetGameState => _gameState;

    public void SwitchPlayer()
    {
        if (_gameState == GameState.player1)
        {
            _gameState = GameState.player2;
        }
        else
        {
            _gameState = GameState.player1;
        }
    }

    public void EndGame()
    {
        _gameState = GameState.end;
    }

    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
            UpdateGameState(GameState.player1);
                break;
            case GameState.player1:
                break;
            case GameState.player2:
                break;
            case GameState.end:
                break;
        }
    }

    public enum GameState
    {
        start,
        player1,
        player2,
        end
    }
}