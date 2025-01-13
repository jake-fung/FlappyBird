using UnityEngine;
using UnityEngine.UI;

public class TitleSceneUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            // Click code
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(Application.Quit);

        Time.timeScale = 1f;
    }
}
