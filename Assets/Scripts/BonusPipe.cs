using UnityEngine;

public class BonusPipe : Pipe
{

    private enum Direction
    {
        Up,
        Down
    }
    private float pipeVertivalMoveSpeed;
    private float pipeVerticalMoveInterval;
    private Direction direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (Random.Range(0, 1) == 0)
        {
            direction = Direction.Up;
        }
        else
        {
            direction = Direction.Down;
        }
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
        if (direction == Direction.Up)
        {
            MoveUpAndDown();
        }
        else if (direction == Direction.Down)
        {
            MoveDownAndUp();
        }
    }

    private void MoveUpAndDown()
    {
        if (timer < pipeVerticalMoveInterval)
        {
            MoveUp();
        }
        else if (timer < 2 * pipeVerticalMoveInterval)
        {
            MoveDown();
        }
        else
        {
            ResetTimerRandomizeSpeedAndInterval();
        }
    }

    private void MoveDownAndUp()
    {
        if (timer < pipeVerticalMoveInterval)
        {
            MoveDown();
        }
        else if (timer < 2 * pipeVerticalMoveInterval)
        {
            MoveUp();
        }
        else
        {
            ResetTimerRandomizeSpeedAndInterval();
        }
    }

    private void MoveUp()
    {
        transform.position += transform.position.y >= 7.5
            ? Vector3.up * (0 * Time.deltaTime)
            : Vector3.up * (pipeVertivalMoveSpeed * Time.deltaTime);
    }

    private void MoveDown()
    {
        transform.position += transform.position.y <= -7.5
            ? Vector3.down * (0 * Time.deltaTime)
            : Vector3.down * (pipeVertivalMoveSpeed * Time.deltaTime);
    }

    private void ResetTimerRandomizeSpeedAndInterval()
    {
        timer = 0;
        pipeVertivalMoveSpeed = Random.Range(10, 30);
        pipeVerticalMoveInterval = Random.Range(0.25f, 1);
    }
}
