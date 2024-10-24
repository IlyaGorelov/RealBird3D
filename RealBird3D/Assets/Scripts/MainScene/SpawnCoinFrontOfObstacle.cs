using System.Collections;
using UnityEngine;

public class SpawnCoinFrontOfObstacle : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject coin;
    [SerializeField] Transform bird;
 

    public void Spawn()
    {
        print("spawn");
        float randHeight = Random.Range(minHeight, maxHeight);
        Vector3 spawn = new Vector3(transform.position.x - distance, randHeight, bird.transform.position.z);
        print(transform.position.x);
        var a = Instantiate(coin, spawn, Quaternion.identity);
    }

}
