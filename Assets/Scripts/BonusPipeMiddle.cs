using UnityEngine;
using System;

public class BonusPipeMiddle : PipeMiddle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && birdGameManager.GetBirdIsAlive())
        {
            birdGameManager.AddScore(2);
        }
    }
}
