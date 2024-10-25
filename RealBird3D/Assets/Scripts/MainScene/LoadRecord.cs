using UnityEngine;
using YG;

public class LoadRecord : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent+=GetLoad;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoad();
        }
    }

    public void GetLoad()
    {
        GameStates.record = YandexGame.savesData.record;
    }
}
