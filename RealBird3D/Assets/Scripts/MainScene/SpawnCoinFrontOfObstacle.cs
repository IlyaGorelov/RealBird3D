using System.Collections;
using UnityEngine;

public class SpawnCoinFrontOfObstacle : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject boost;
    [SerializeField] Transform bird;
    [SerializeField] GetModsValues modsValues;
 

    public void Spawn()
    {
        for (int i = 0; i < modsValues.coinMod; i++)
        {
        float randHeight = Random.Range(minHeight, maxHeight);
        Vector3 spawn = new Vector3(transform.position.x - distance, randHeight, bird.transform.position.z);
        Instantiate(coin, spawn, Quaternion.identity);

        }
    }

    public void SpawnBoost()
    {
        for (int i = 0; i < modsValues.boostMod; i++)
        {
            float randHeight = Random.Range(minHeight, maxHeight);
            Vector3 spawn = new Vector3(transform.position.x - distance, randHeight, bird.transform.position.z);

            Instantiate(boost, spawn, Quaternion.identity);

        }
    }

}
