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
    }


    private void Start()
    {
         freezeTime = new();
    }

    public void Ressurect()
    {
        birdCollider = Bird.GetComponent<SphereCollider>();
        birdCollider.enabled = false;
        GameStates.score = Convert.ToInt32(score.text);
        GameStates.isGamePaused = true;
        EndGameAfterCollision.isLose = false;
        LoseUI.SetActive(false);
        Settings.SetActive(true);
        YandexGame.RewVideoShow(0);
        freezeTime.Continue();
        StartCoroutine(Wait(5));
        
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        birdCollider.enabled = true;
    }
}
