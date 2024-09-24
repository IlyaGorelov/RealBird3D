using UnityEngine;
using YG;

public class SavesData : MonoBehaviour
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
