using UnityEngine;

public class PipeMiddle : MonoBehaviour
{
    public BirdGameManager birdGameManager;

    private void Start()
    {
        birdGameManager = BirdGameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && birdGameManager.GetBirdIsAlive())
        {
            birdGameManager.AddScore(1);
        }
    }
}
