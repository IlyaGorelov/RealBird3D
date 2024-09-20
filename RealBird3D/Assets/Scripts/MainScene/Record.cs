using System;
using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI record;
    [SerializeField] TextMeshProUGUI score; 

    private void OnEnable()
    {
        GetRecord();
        if(Convert.ToInt32(record.text)<Convert.ToInt32(score.text))
            record.text = score.text;
    }



    private void GetRecord() { }
}
