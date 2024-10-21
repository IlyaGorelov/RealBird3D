using UnityEngine;

public class SpawnObstaclesAtStart : MonoBehaviour
{
    [SerializeField] ObstaclesSpawn obstaclesSpawn;
    [SerializeField] int count;
    [SerializeField] float distanceForStartedBuildings;

    private void Start()
    {
        obstaclesSpawn.SpawnRandomAtStart(count, distanceForStartedBuildings);
    }
}
