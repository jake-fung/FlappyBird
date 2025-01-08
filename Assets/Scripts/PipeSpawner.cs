using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject bonusPipePrefab;
    private float spawnRate = 0.75f;
    private float timer = 0;
    private float heightOffset = 8;
    private float spawnTimeLowerBound = 0.75f;
    private float spawnTimeUpperBound = 1f;

    private void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnRate = Random.Range(spawnTimeLowerBound, spawnTimeUpperBound);
            timer = 0;
            spawnGeneralPipe();
        }
    }

    private void spawnGeneralPipe()
    {
        if (Random.Range(0, 9) == 0)
        {
            spawnBonusPipe();
        }
        else
        {
            spawnPipe();
        }
    }

    private void spawnPipe()
    {
        float height = transform.position.y + Random.Range(-heightOffset, heightOffset);
        Instantiate(pipePrefab, new Vector3(transform.position.x, height, 0), transform.rotation);
    }

    private void spawnBonusPipe()
    {
        float height = transform.position.y + Random.Range(-heightOffset, heightOffset);
        Instantiate(bonusPipePrefab, new Vector3(transform.position.x, height, 0), transform.rotation);
    }
}
