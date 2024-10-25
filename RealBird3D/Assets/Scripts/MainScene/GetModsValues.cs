using UnityEngine;
using YG;

public class GetModsValues : MonoBehaviour
{
    public int coinMod = 1;
    public int boostMod = 0;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoadCoinMod;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoadCoinMod;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoadCoinMod();
            GetLoadBoosterMod();
        }
    }

    private void GetLoadCoinMod()
    {
        string moneyMod = YandexGame.savesData.moreMoney10Id;
        coinMod = 10;
        if (moneyMod.Split('-')[1] == "0")
        {
            moneyMod = YandexGame.savesData.moreMoney8Id;
            coinMod = 8;
            if (moneyMod.Split('-')[1] == "0")
            {
                moneyMod = YandexGame.savesData.moreMoney4Id;
                coinMod = 4;
                if (moneyMod.Split('-')[1] == "0")
                {
                    moneyMod = YandexGame.savesData.moreMoney2Id;
                    coinMod = 2;
                    if (moneyMod.Split('-')[1] == "0")
                    {
                        coinMod = 1;
                    }
                }
            }
        }
    }
    private void GetLoadBoosterMod()
    {
        string boostModstr = YandexGame.savesData.booster15Id;
        boostMod = 10;
        if (boostModstr.Split('-')[1] == "0")
        {
            boostModstr = YandexGame.savesData.booster10Id;
            boostMod = 10;
            if (boostModstr.Split('-')[1] == "0")
            {
                boostModstr = YandexGame.savesData.booster5Id;
                boostMod = 5;
                if (boostModstr.Split('-')[1] == "0")
                {
                    boostModstr = YandexGame.savesData.booster1Id;
                    boostMod = 1;
                    if (boostModstr.Split('-')[1] == "0")
                    {
                        boostMod = 0;
                    }
                }
            }
        }
    }
}
