using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform bird;
    [SerializeField] float distance;

    private void Update()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            if (obstacle.transform.position.x-bird.position.x<=distance)
            {
                obstacle.transform.position = new Vector3(distance, obstacle.transform.position.y, obstacle.transform.position.z);
            }

        }
    }
}
