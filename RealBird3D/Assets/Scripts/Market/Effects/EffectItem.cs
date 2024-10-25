using UnityEngine;
using YG;

public class EffectItem : MonoBehaviour
{
    [SerializeField]protected int price;
    [SerializeField] protected int isBuyed;
    [SerializeField] protected int isChosen;
    [SerializeField] modsType effect;
    [SerializeField] protected string id;
    [SerializeField] protected bool isEffect = true;
    private bool doForOneTime=true;

    [Header("GameObjects")]
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject BuyedImage;
    [SerializeField] GameObject chosenImage;
    [SerializeField] GameObject chooseButton;

    enum modsType
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
            if (isEffect)
            {
                LoadEffect();
                LaunchEffectAfterLoad();
            }
        }

    }

    private void Update()
    {
        if (isBuyed == 1 && doForOneTime)
        {
            doForOneTime = false;
            BuyButton.SetActive(false);
            BuyedImage.SetActive(true);
            try
            {
                chooseButton.SetActive(true);
            }
            catch { }
            SaveEffect();
        }

        if (isChosen == 0 && isBuyed == 1)
        {
            BuyedImage.SetActive(true);
            try
            {
                chosenImage.SetActive(false);
            }
            catch { }
        }
        else if (isChosen == 1 && isBuyed == 1)
        {
            try
            {
                chosenImage.SetActive(true);
            }
            catch { }
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
        if (isEffect)
            SaveEffect();
    }

    private void SaveEffect()
    {
        switch (effect)
        {
            case modsType.air:
                YandexGame.savesData.airId = $"air-{isBuyed}-{isChosen}";
                break;
            case modsType.fire:
                YandexGame.savesData.fireId = $"fire-{isBuyed}-{isChosen}";
                break;
            case modsType.lightning:
                YandexGame.savesData.lightningId = $"lightning-{isBuyed}-{isChosen}";
                break;
            case modsType.blow:
                YandexGame.savesData.blowId = $"blow-{isBuyed}-{isChosen}";
                break;
            case modsType.confetti:
                YandexGame.savesData.confettiId = $"confetti-{isBuyed}-{isChosen}";
                break;
        }

        YandexGame.SaveProgress();
    }

    private void LoadEffect()
    {
        switch (effect)
        {
            case modsType.air:
                id = YandexGame.savesData.airId;
                break;
            case modsType.fire:
                id = YandexGame.savesData.fireId;
                break;
            case modsType.lightning:
                id = YandexGame.savesData.lightningId;
                break;
            case modsType.blow:
                id = YandexGame.savesData.blowId;
                break;
            case modsType.confetti:
                id = YandexGame.savesData.confettiId;
                break;
        }
    }

    private void LaunchEffectAfterLoad()
    {
        if (id != "")
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
}
