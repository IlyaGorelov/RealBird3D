using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform end;
    [SerializeField] float distance;
    [SerializeField] Transform spawn;
    [SerializeField] List<GameObject> pull;

    private void Start()
    {
        pull = new();
    }

    private void Update()
    {
        CheckOnExit();
        if (isFarFromSpawn() && pull.Count>=5 && !GameStates.isGameEnd) SpawnRandom();

    }


    private void CheckOnExit()
    {
        foreach (var obstacle in obstacles)
        {
            if (obstacle.transform.position.x<= end.position.x)
            {
                if(!pull.Contains(obstacle))
                pull.Add(obstacle);
            }

        }
    }

    

    private void SpawnRandom()
    {
        int r = Random.Range(0,pull.Count);
        pull[r].transform.position = new Vector3(spawn.position.x, spawn.position.y, pull[r].transform.position.z);
        ObstacleMovement obstacleHeight = pull[r].GetComponent<ObstacleMovement>();
        obstacleHeight.isMovementStart = true;
        pull.RemoveAt(r);
    }

    private bool isFarFromSpawn()
    {
        foreach (var obstacle in obstacles)
        {
            if (Mathf.Abs(obstacle.transform.position.x - spawn.position.x)<=distance)
            {
                return false;
            }

        }
        return true;
    }
}
