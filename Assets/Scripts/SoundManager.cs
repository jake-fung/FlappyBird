using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource flapSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource bonusScoreSound;
    [SerializeField] private AudioSource highScoreSound;

    private void Start()
    {
        GameInput.Instance.OnFlap += PlayFlapSound;
        BirdGameManager.Instance.OnStateChanged += PlayGameOverSound;
        BirdGameManager.Instance.OnBirdScored += PlayScoreSound;
        BirdGameManager.Instance.OnBirdBonusScored += PlayBonusScoreSound;
        BirdGameManager.Instance.OnHighScoreChanged += PlayHighScoreSound;
    }

    private void PlayFlapSound(object sender, System.EventArgs e)
    {
        if (BirdGameManager.Instance.GetBirdIsAlive())
        {
            flapSound.Play();
        }
    }

    private void PlayGameOverSound(object sender, System.EventArgs e)
    {
        if (BirdGameManager.Instance.IsGameOver())
        {
            gameOverSound.Play();
        }
    }

    private void PlayScoreSound(object sender, System.EventArgs e)
    {
        scoreSound.Play();
    }

    private void PlayBonusScoreSound(object sender, System.EventArgs e)
    {
        bonusScoreSound.Play();
    }

    private void PlayHighScoreSound(object sender, System.EventArgs e)
    {
        highScoreSound.Play();
    }
}
