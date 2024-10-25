using UnityEngine;

public class PauseGameForAd : MonoBehaviour
{
    [SerializeField] OpenCloseSettings openCloseSettings;
 
    public void Pause()
    {
        openCloseSettings.PauseGame();
    }
}
