using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool isMovementStart = false;
    public bool canMove = true;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    [SerializeField] float distanceBtwBuilds = 30;
    [SerializeField] float speed = 0.01f;
    [SerializeField] bool NotRightDir = false;
    [SerializeField] SpawnCoinFrontOfObstacle spawnCoin;

    private void Start()
    {
        spawnCoin=GetComponent<SpawnCoinFrontOfObstacle>();
    }

    private void Update()
    {
        if (isMovementStart && !GameStates.isGamePaused)
        {
            isMovementStart = false;
            float height = Random.Range(minHeight, maxHeight);
            transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
            spawnCoin.SpawnBoost();
            spawnCoin.Spawn();
        }
        if (!GameStates.isGamePaused)
        {
            if (!NotRightDir)
                Move();
            else MoveFix();
        }
    }

    private void Move()
    {
        if (IsOtherNotThere() && !GameStates.isGamePaused)
        {
            
            transform.Translate((-speed - GameStates.speedA) * Time.deltaTime, 0, 0);
        }
    }

    private void MoveFix()
    {
        if (IsOtherNotThere() && !GameStates.isGamePaused)
        {
        
            transform.Translate(0, 0, (-speed - GameStates.speedA)*Time.deltaTime);
        }
    }

    private bool IsOtherNotThere()
    {

        Ray ray = new Ray(transform.position, -transform.right);

        Debug.DrawRay(transform.position, -transform.right, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f))
        {
            if (Vector3.Distance(hit.point, transform.position) + transform.localScale.x / 2 <= distanceBtwBuilds)
            {
                return false;

            }
        }

        return true;
    }

}
