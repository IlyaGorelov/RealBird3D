using UnityEngine;

public class SpawnCoinFrontOfObstacle : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject coin;
    [SerializeField] Transform bird;
 
    private ObstacleMovement obstacleMovement;

    public void OnEnable()
    {
        obstacleMovement = GetComponent<ObstacleMovement>();
    }

    private void Update()
    {
        if (obstacleMovement.isMovementStart)
            Spawn();
    }

    private void Spawn()
    {
        float randHeight = Random.Range(minHeight, maxHeight);
        Vector3 spawn = new Vector3(transform.position.x - distance, randHeight, bird.transform.position.z);
        Instantiate(coin, spawn, Quaternion.identity);
    }
}
