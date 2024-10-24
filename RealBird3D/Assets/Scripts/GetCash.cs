using UnityEngine;
using YG;

public class GetCash : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
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
        GameStates.cash = YandexGame.savesData.cash;
    }
}
