using System;
using TMPro;
using UnityEngine;
using YG;

public class SaveAndGetRecord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI record;
    [SerializeField] TextMeshProUGUI score; 

    private void OnEnable()
    {
        GetRecord();
        if (Convert.ToInt32(record.text) < Convert.ToInt32(score.text))
            SaveRecord();

    }

    private void SaveRecord()
    {
        YandexGame.savesData.record = Convert.ToInt32(score.text);
        GameStates.record = Convert.ToInt32(record.text);
        record.text = score.text;
        YandexGame.SaveProgress();
    }

    private void GetRecord() 
    {
        record.text = GameStates.record.ToString();
    }
}
