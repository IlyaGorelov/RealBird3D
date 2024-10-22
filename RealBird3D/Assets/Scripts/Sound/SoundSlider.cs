using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField]  TypeOfSlider sliderType;
    [SerializeField] AudioMixer audioMixer;

    enum TypeOfSlider
    {
        Main, BG, Noise
    }

    public void ChangeVolume()
    {
        if (sliderType == TypeOfSlider.Main) ChangeVolumeOfMain();
        else if (sliderType == TypeOfSlider.BG) ChangeVolumeOfBG();
        else if (sliderType == TypeOfSlider.Noise) ChangeVolumeOfNoise();
    }

    private void ChangeVolumeOfMain()
    {
        audioMixer.SetFloat("Main", Mathf.Log10(slider.value) * 20);
        YandexGame.savesData.mainSoundLevel = Mathf.Log10(slider.value) * 20;
        YandexGame.SaveProgress();
    }

    private void ChangeVolumeOfBG()
    {
        audioMixer.SetFloat("BG", Mathf.Log10(slider.value) * 20);
        YandexGame.savesData.BGSoundLevel = Mathf.Log10(slider.value) * 20;
        YandexGame.SaveProgress();
    }

    private void ChangeVolumeOfNoise()
    {
        audioMixer.SetFloat("Noise",Mathf.Log10(slider.value)*20);
        YandexGame.savesData.BGSoundLevel = Mathf.Log10(slider.value) * 20;
        YandexGame.SaveProgress();
    }
}
