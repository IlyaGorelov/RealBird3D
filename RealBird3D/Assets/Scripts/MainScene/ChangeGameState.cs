using UnityEngine;
using YG;

public class ChangeGameState : MonoBehaviour
{
    void Update()
    {
        if(GameStates.isGamePaused)
            YandexGame.GameplayStop();
        else YandexGame.GameplayStart();

    }
}
