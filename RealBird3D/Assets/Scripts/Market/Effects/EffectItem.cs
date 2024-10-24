using UnityEngine;
using YG;

public class EffectItem : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] int isBuyed;
    [SerializeField] int isChosen;
    [SerializeField] effectType effect;
    [SerializeField] string id;

    [Header("GameObjects")]
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject BuyedImage;
    [SerializeField] GameObject chosenImage;
    [SerializeField] GameObject chooseButton;

    enum effectType
    {
        air, fire, lightning, blow, confetti
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadEffect;
        
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadEffect;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadEffect();
            LaunchEffectAfterLoad();
        }
        
    }

    private void Update()
    {
        if (isBuyed == 1)
        {
            BuyButton.SetActive(false);
            BuyedImage.SetActive(true);
            chooseButton.SetActive(true);
            SaveEffect();
        }

        if (isChosen == 0 && isBuyed==1)
        {
            BuyedImage.SetActive(true);
            chosenImage.SetActive(false);
        }
        else if(isChosen == 1 && isBuyed == 1)
        {
            chosenImage.SetActive(true);
            BuyedImage.SetActive(false);
        }
    }

    public void Buy()
    {
        if (GameStates.cash >= price)
        {
            GameStates.cash -= price;
            isBuyed = 1;
            YandexGame.savesData.cash = GameStates.cash;
            YandexGame.SaveProgress();
        }
    }

    public void Choose()
    {
        if (isChosen == 0)
        {
            isChosen = 1;
        }
        else
        {
            isChosen = 0;

        }
        SaveEffect();
    }

    private void SaveEffect()
    {
        switch (effect)
        {
            case effectType.air:
                YandexGame.savesData.airId = $"air-{isBuyed}-{isChosen}";
                break;
            case effectType.fire:
                YandexGame.savesData.fireId = $"fire-{isBuyed}-{isChosen}";
                break;
            case effectType.lightning:
                YandexGame.savesData.lightningId = $"lightning-{isBuyed}-{isChosen}";
                break;
            case effectType.blow:
                YandexGame.savesData.blowId = $"blow-{isBuyed}-{isChosen}";
                break;
            case effectType.confetti:
                YandexGame.savesData.confettiId = $"confetti-{isBuyed}-{isChosen}";
                break;
        }

        YandexGame.SaveProgress();
    }

    private void LoadEffect()
    {
        switch (effect)
        {
            case effectType.air:
                id = YandexGame.savesData.airId;
                break;
            case effectType.fire:
                id = YandexGame.savesData.fireId;
                break;
            case effectType.lightning:
                id = YandexGame.savesData.lightningId;
                break;
            case effectType.blow:
                id = YandexGame.savesData.blowId;
                break;
            case effectType.confetti:
                id = YandexGame.savesData.confettiId;
                break;
        }
    }

    private void LaunchEffectAfterLoad()
    {
        string[] ids = id.Split('-');
        if (ids[1] == "1")
        {
            isBuyed = 1;
        }
        if (ids[2] == "1")
        {
            isChosen = 1;
        }
        if (ids[2] == "0")
        {
            isChosen = 0;
        }
    }
}
