using System;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public event EventHandler OnBirdGoingUp;
    public event EventHandler OnBirdGoingDown;
    [SerializeField] private Rigidbody2D bird;
    [SerializeField] private float flapStrength;

    private void Start()
    {
        GameInput.Instance.OnFlap += GameInput_OnFlap;
    }

    private void GameInput_OnFlap(object sender, EventArgs e)
    {
        if (BirdGameManager.instance.GetBirdIsAlive())
        {
            bird.linearVelocity = new Vector2(0, flapStrength);
        }
    }

    private void Update()
    {
        CheckBirdGoesOutOfBound();
        if (BirdGameManager.instance.GetBirdIsAlive())
        {
            if (bird.linearVelocity.y > 0)
            {
                OnBirdGoingUp?.Invoke(this, EventArgs.Empty);
            }
            else if (bird.linearVelocity.y < 0)
            {
                OnBirdGoingDown?.Invoke(this, EventArgs.Empty);
            }
        }

    }

    private void CheckBirdGoesOutOfBound()
    {
        if ((transform.position.y < -26 || transform.position.y > 26) && BirdGameManager.instance.GetBirdIsAlive())
        {
            BirdGameManager.instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BirdGameManager.instance.GetBirdIsAlive())
        {
            BirdGameManager.instance.GameOver();
        }
    }
}
