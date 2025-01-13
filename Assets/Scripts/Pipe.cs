using UnityEngine;

public class Pipe : MonoBehaviour
{
    protected float timer = 0;
    [SerializeField] protected int pipeHorizontalMoveSpeed = 2;
    private int destroyXPos = -60;

    // Update is called once per frame
    protected void Update()
    {

        transform.position += Vector3.left * (pipeHorizontalMoveSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (transform.position.x < destroyXPos)
        {
            Destroy(gameObject);
        }
    }

}
