using YG;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed = 0.01f;
    [SerializeField] Transform endPoint;

    private void Update()
    {
        endPoint = GameObject.Find("EndPoint").transform;
        if (transform.position.x < endPoint.position.x)
        {
            Destroy(gameObject);
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

    private void OnDestroy()
    {
        ModsBehaviour.mods.Remove(gameObject);
    }
}
