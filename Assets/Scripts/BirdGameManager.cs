using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using System.Data;

public class BirdGameManager : MonoBehaviour
{
    private enum State
    {
        WaitingToStart,
        Playing,
        GameOver
    }

    private State state;
    public static BirdGameManager instance { get; private set; }
    public event EventHandler OnStateChanged;
    public event EventHandler OnBirdDeath;
    public event EventHandler OnBirdBonusScored;
    public event EventHandler OnBirdScored;
    public event EventHandler OnHighScoreChanged;
    private int playerScore;
    private bool birdIsAlive = true;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        state = State.WaitingToStart;
        GameInput.Instance.OnInteract += BirdGameManager_OnInteract;
    }

    private void BirdGameManager_OnInteract(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            Time.timeScale = 1;
            state = State.Playing;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Update()
    {

        switch (state)
        {
            case State.WaitingToStart:
                Time.timeScale = 0;
                break;
            case State.Playing:
                if (!birdIsAlive)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                birdIsAlive = false;
                OnBirdDeath?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        int scoring = 1;
        int bonusScoring = 2;
        playerScore += scoreToAdd;
        if (scoreToAdd == bonusScoring)
        {
            OnBirdBonusScored?.Invoke(this, EventArgs.Empty);
        }
        else if (scoreToAdd == scoring)
        {
            OnBirdScored?.Invoke(this, EventArgs.Empty);
        }
    }

    public void GameOver()
    {
        OnStateChanged?.Invoke(this, EventArgs.Empty);
        birdIsAlive = false;
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            SetHighScore();
        }
    }

    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", playerScore);
        OnHighScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool GetBirdIsAlive()
    {
        return birdIsAlive;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public bool IsWaitingToStart()
    {
        return state == State.WaitingToStart;
    }

    public bool IsPlaying()
    {
        return state == State.Playing;
    }
}
