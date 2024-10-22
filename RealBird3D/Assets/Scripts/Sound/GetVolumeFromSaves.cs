using UnityEngine;
using UnityEngine.Audio;
using YG;

public class GetVolumeFromSaves : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

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
        audioMixer.SetFloat("Main", YandexGame.savesData.mainSoundLevel);
        audioMixer.SetFloat("BG", YandexGame.savesData.BGSoundLevel);
        audioMixer.SetFloat("Noise", YandexGame.savesData.NoiseSoundLevel);
    }
}
