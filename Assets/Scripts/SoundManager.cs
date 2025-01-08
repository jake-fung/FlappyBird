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
        BirdGameManager.instance.OnStateChanged += PlayGameOverSound;
        BirdGameManager.instance.OnBirdScored += PlayScoreSound;
        BirdGameManager.instance.OnBirdBonusScored += PlayBonusScoreSound;
        BirdGameManager.instance.OnHighScoreChanged += PlayHighScoreSound;
    }

    private void PlayFlapSound(object sender, System.EventArgs e)
    {
        if (BirdGameManager.instance.GetBirdIsAlive())
        {
            flapSound.Play();
        }
    }

    private void PlayGameOverSound(object sender, System.EventArgs e)
    {
        if (BirdGameManager.instance.IsGameOver())
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
