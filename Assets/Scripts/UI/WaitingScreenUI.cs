using TMPro;
using UnityEngine;

public class WaitingScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;

    private void Awake()
    {
        Show();
    }

    private void Start()
    {
        BirdGameManager.Instance.OnStateChanged += BirdGameManager_OnStateChanged;
    }

    private void BirdGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BirdGameManager.Instance.IsPlaying())
        {
            Hide();
        }
    }

    private void Show()
    {
        interactText.gameObject.SetActive(true);
    }

    private void Hide()
    {
        interactText.gameObject.SetActive(false);
    }
}
