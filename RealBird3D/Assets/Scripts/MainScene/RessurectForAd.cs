using System;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class RessurectForAd : MonoBehaviour
{
    [SerializeField] GameObject LoseUI;
    [SerializeField] GameObject Settings;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject Bird;
    FreezeTime freezeTime;
    SphereCollider birdCollider;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

   public void Rewarded(int id)
    {
        if (id == 0)
        {
            birdCollider = Bird.GetComponent<SphereCollider>();
            birdCollider.enabled = false;
            EndGameAfterCollision.canLoseOneTime = true;
            GameStates.score = Convert.ToInt32(score.text);
            GameStates.isGamePaused = true;
            EndGameAfterCollision.isLose = false;
            LoseUI.SetActive(false);
            Settings.SetActive(true);
            freezeTime.Continue();
            StartCoroutine(Wait(5));
            if (BirdController.isLower)
            {
                Bird.transform.Translate(0, 10, 0);
                BirdController.isLower = false;
            }
            else if(BirdController.isUpper)
            {
                Bird.transform.Translate(0, -10, 0);
                BirdController.isUpper = false;
            }


        }
    }


    private void Start()
    {
         freezeTime = new();
    }

    public void Ressurect()
    {
        YandexGame.RewVideoShow(0);
     
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        birdCollider.enabled = true;
    }
}
