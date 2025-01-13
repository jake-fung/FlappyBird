using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        restartButton.onClick.AddListener(() =>
        {
            BirdGameManager.Instance.RestartGame();
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        Hide();
    }

    private void Start()
    {
        BirdGameManager.Instance.OnStateChanged += GameOverScreen_OnStateChanged;
        BirdGameManager.Instance.OnHighScoreChanged += GameOverScreen_OnHighScoreChanged;
    }

    private void GameOverScreen_OnHighScoreChanged(object sender, System.EventArgs e)
    {
        highScoreText.gameObject.SetActive(true);
    }

    private void GameOverScreen_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BirdGameManager.Instance.IsGameOver())
        {
            Show();
        }
    }

    private void Show()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }
}
