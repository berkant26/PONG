using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UIManager : MonoBehaviour, IScoreObserver
{
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI opponentScoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private Button replayButton;


    public Button ReplayButton => replayButton;
    public TextMeshProUGUI WinnerText => winnerText;
    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        GameManager.Instance.ScoreManager.AddObserver(this);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.ScoreManager.RemoveObserver(this);
    }

    public void onScoreChanged(int playerScore, int opponentScore)
    {
        if (playerScoreText != null)
            playerScoreText.text = playerScore.ToString();

        if (opponentScoreText != null)
            opponentScoreText.text = opponentScore.ToString();
    }

    public void ShowGameOver(string winner)
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (winnerText != null)
            winnerText.gameObject.SetActive(true);
        winnerText.text = winner + " Wins!";
        replayButton.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    
}
