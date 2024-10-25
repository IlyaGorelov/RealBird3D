using UnityEngine;
using YG;

public class ActivateEffectOnMain : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] EffectsType effectsType;
    [SerializeField] string id;

    enum EffectsType
    {
        air,fire,blow,confetti,lightning
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadEffectStates;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadEffectStates;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadEffectStates();
            TryActivateEffect();
        }
    }

    private void TryActivateEffect()
    {
        string[] ids = id.Split('-');
        if (ids[2]=="1")
            _effect.SetActive(true);
     }

    private void LoadEffectStates()
    {
        switch (effectsType)
        {
            case EffectsType.air:
                id = YandexGame.savesData.airId; break;
            case EffectsType.fire:
                id = YandexGame.savesData.fireId; break;
            case EffectsType.blow:
                id = YandexGame.savesData.blowId; break;
            case EffectsType.confetti:
                id = YandexGame.savesData.confettiId; break;
            case EffectsType.lightning:
                id = YandexGame.savesData.lightningId; break;

        }
    }
}
