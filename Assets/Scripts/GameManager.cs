using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int winningScore = 5;
    [SerializeField] private BallMovement ball;
    [SerializeField] private UIManager uiManager;

    private ScoreManager _scoreManager;
    private bool _gameOver;

    public ScoreManager ScoreManager => _scoreManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _scoreManager = GetComponent<ScoreManager>();
        if (_scoreManager == null)
            _scoreManager = gameObject.AddComponent<ScoreManager>();
    }

    public void OnScoreZoneHit(bool isPlayerZone)
    {
        if (_gameOver) return;

        if (isPlayerZone)
            _scoreManager.AddOpponentScore();
        else
            _scoreManager.AddPlayerScore();

        CheckWinCondition();

        if (!_gameOver && ball != null)
            ball.ResetBall();
    }

    private void CheckWinCondition()
    {
        if (_scoreManager.PlayerScore >= winningScore)
        {
            EndGame("Player");
        }
        else if (_scoreManager.OpponentScore >= winningScore)
        {
            EndGame("Opponent");
        }
    }

    private void EndGame(string winner)
    {
        _gameOver = true;
        if (uiManager != null)
            uiManager.ShowGameOver(winner);
    }

    public void RestartGame()
    {
        _gameOver = false;
        uiManager.ReplayButton.gameObject.SetActive(false);
        uiManager.WinnerText.gameObject.SetActive(false);

        _scoreManager.ResetScores();

        if (uiManager != null)
            uiManager.HideGameOver();

        if (ball != null)
            ball.ResetBall();
    }
}