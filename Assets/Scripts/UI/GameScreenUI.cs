using TMPro;
using UnityEngine;

public class GameScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject highScoreText;


    private void Awake()
    {
        Hide();
    }

    private void Start()
    {
        BirdGameManager.Instance.OnStateChanged += GameScreen_OnStateChanged;
        BirdGameManager.Instance.OnBirdScored += GameScreen_OnBirdScored;
        BirdGameManager.Instance.OnBirdBonusScored += GameScreen_OnBirdBonusScored;
    }

    private void GameScreen_OnBirdBonusScored(object sender, System.EventArgs e)
    {
        SetScoreText();
    }

    private void GameScreen_OnBirdScored(object sender, System.EventArgs e)
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = BirdGameManager.Instance.GetScore().ToString();
    }

    private void GameScreen_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BirdGameManager.Instance.IsPlaying() || BirdGameManager.Instance.IsGameOver())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }


    private void Show()
    {
        scoreText.gameObject.SetActive(true);
        highScoreText.SetActive(true);
    }

    private void Hide()
    {
        scoreText.gameObject.SetActive(false);
        highScoreText.SetActive(false);
    }
}
