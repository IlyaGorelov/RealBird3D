using UnityEngine;
using YG;

public class OpenCloseSettings : MonoBehaviour
{
    [SerializeField] GameObject settings;
    [SerializeField] FreezeTime freezeTime;

    private void OnEnable()
    {
        freezeTime = new();
        YandexGame.onVisibilityWindowGame += Open;
    }

    private void OnDisable()
    {
        freezeTime = new();
        YandexGame.onVisibilityWindowGame -= Open;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameStates.isGamePaused)
        {
            settings.SetActive(true);
            GameStates.isGamePaused = true;
            freezeTime.Freeze();
        }else if(Input.GetKeyDown(KeyCode.Escape) && GameStates.isGamePaused)
        {
            settings.SetActive(false);
            GameStates.isGamePaused = false;
            freezeTime.Continue();
        }
    }

    public void Stop() 
    {
        freezeTime.Freeze();
        GameStates.isGamePaused = true;
    } 
    public void Continue()
    {
        GameStates.isGamePaused = false;
        freezeTime.Continue();
    }

    private void Open(bool isActive)
    {
        if(!isActive)
        {
            settings.SetActive(true);
            GameStates.isGamePaused = true;
            freezeTime.Freeze();
        }
    }
}
