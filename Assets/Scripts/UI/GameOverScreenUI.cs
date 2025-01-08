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
            BirdGameManager.instance.RestartGame();
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        Hide();
    }

    private void Start()
    {
        BirdGameManager.instance.OnStateChanged += GameOverScreen_OnStateChanged;
        BirdGameManager.instance.OnHighScoreChanged += GameOverScreen_OnHighScoreChanged;
    }

    private void GameOverScreen_OnHighScoreChanged(object sender, System.EventArgs e)
    {
        highScoreText.gameObject.SetActive(true);
    }

    private void GameOverScreen_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BirdGameManager.instance.IsGameOver())
        {
            Show();
        }
    }

    public void Show()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }
}
