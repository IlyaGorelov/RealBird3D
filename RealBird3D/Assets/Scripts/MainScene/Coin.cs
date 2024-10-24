using YG;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed = 0.01f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameStates.isGamePaused)
        {
            transform.Translate(-speed- GameStates.speedA, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BirdController a))
        {
            GameStates.cash += 1;
            SaveCash();
            a.coinEffect.Play();
            a.coinSound.Play();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SaveCash()
    {
        YandexGame.savesData.cash = GameStates.cash;
        YandexGame.SaveProgress();
    }
}
