using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreValue;



    private void Start()
    {
        SetText();
        BirdGameManager.Instance.OnHighScoreChanged += HighScore_OnHighScoreChanged;
    }

    private void HighScore_OnHighScoreChanged(object sender, System.EventArgs e)
    {
        SetText();
    }

    private void SetText()
    {
        highScoreValue.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
