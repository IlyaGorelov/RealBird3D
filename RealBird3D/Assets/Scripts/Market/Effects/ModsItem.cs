using UnityEngine;
using YG;

public class ModsItem : EffectItem
{
    [SerializeField] modsType mod;
    [SerializeField] int isOpened;
    [SerializeField] GameObject Close;
    [SerializeField] GameObject NextClose;

    enum modsType
    {
        moreMoney2,
        moreMoney4,
        moreMoney8,
        moreMoney10,
        booster1,
        booster5,
        booster10,
        booster15
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadMod;

    }

    private void OnDisable()
    {
        SaveMod();
        YandexGame.GetDataEvent -= LoadMod;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            if (!isEffect)
            {
                LoadMod();
                LaunchModAfterLoad();
            }
        }
    }

    public new void Buy()
    {
        if (GameStates.cash >= price)
        {
            GameStates.cash -= price;
            isBuyed = 1;
            YandexGame.savesData.cash = GameStates.cash;
            YandexGame.SaveProgress();
            NextClose.SetActive(false);
        }
    }


    public void IsOpened()
    {
            isOpened = 1;
    }

    private void SaveMod()
    {
        switch (mod)
        {
            case modsType.moreMoney2:
                YandexGame.savesData.moreMoney2Id = $"mm2-{isBuyed}-1";
                break;
            case modsType.moreMoney4:
                YandexGame.savesData.moreMoney4Id = $"mm4-{isBuyed}-{isOpened}";
                break;
            case modsType.moreMoney8:
                YandexGame.savesData.moreMoney8Id = $"mm8-{isBuyed}-{isOpened}";
                break;
            case modsType.moreMoney10:
                YandexGame.savesData.moreMoney10Id = $"mm10-{isBuyed}-{isOpened}";
                break;
            case modsType.booster1:
                YandexGame.savesData.booster1Id = $"b1-{isBuyed}-1";
                break;
            case modsType.booster5:
                YandexGame.savesData.booster5Id = $"b5-{isBuyed}-{isOpened}";
                break;
            case modsType.booster10:
                YandexGame.savesData.booster10Id = $"b10-{isBuyed}-{isOpened}";
                break;
            case modsType.booster15:
                YandexGame.savesData.booster15Id = $"b15-{isBuyed}-{isOpened}";
                break;
        }

        YandexGame.SaveProgress();
    }

    private void LoadMod()
    {
        switch (mod)
        {
            case modsType.moreMoney2:
              id = YandexGame.savesData.moreMoney2Id ;
                break;
            case modsType.moreMoney4:
               id= YandexGame.savesData.moreMoney4Id ;
                break;
            case modsType.moreMoney8:
                id = YandexGame.savesData.moreMoney8Id;
                break;
            case modsType.moreMoney10:
                id = YandexGame.savesData.moreMoney10Id;
                break;
            case modsType.booster1:
                id = YandexGame.savesData.booster1Id;
                break;
            case modsType.booster5:
                id = YandexGame.savesData.booster5Id;
                break;
            case modsType.booster10:
                id = YandexGame.savesData.booster10Id;
                break;
            case modsType.booster15:
                id = YandexGame.savesData.booster15Id;
                break;
        }
    }

    private void LaunchModAfterLoad()
    {
        if (id != null)
        {
            string[] ids = id.Split('-');
            if (ids[1] == "1")
            {
                isBuyed = 1;
            }
            if (ids[2] == "1")
            {
                isOpened = 1;
                Close.SetActive(false);
            }
        }
    }
}
