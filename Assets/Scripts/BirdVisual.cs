using UnityEngine;
using UnityEngine.UI;

public class BirdVisual : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private GameObject wingdown;
    [SerializeField] private GameObject wingup;
    private float rotateSpeed = 10f;

    private void Start()
    {
        bird.OnBirdGoingUp += BirdVisualScript_OnBirdGoingUp;
        bird.OnBirdGoingDown += BirdVisualScript_OnBirdGoingDown;
        BirdGameManager.Instance.OnBirdDeath += BirdVisualScript_OnBirdDeath;
    }


    private void BirdVisualScript_OnBirdGoingDown(object sender, System.EventArgs e)
    {
        wingdown.SetActive(true);
        wingup.SetActive(false);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * rotateSpeed);
    }

    private void BirdVisualScript_OnBirdGoingUp(object sender, System.EventArgs e)
    {
        wingdown.SetActive(false);
        wingup.SetActive(true);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime * rotateSpeed);
    }

    private void BirdVisualScript_OnBirdDeath(object sender, System.EventArgs e)
    {
        wingdown.SetActive(true);
        wingup.SetActive(false);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * rotateSpeed);
    }
}
