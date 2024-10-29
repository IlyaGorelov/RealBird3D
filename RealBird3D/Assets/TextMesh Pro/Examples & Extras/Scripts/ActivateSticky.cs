using UnityEngine;
using YG;

public class ActivateSticky : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.StickyAdActivity(true);
    }

    private void OnDisable()
    {
        YandexGame.StickyAdActivity(false);
    }
}
