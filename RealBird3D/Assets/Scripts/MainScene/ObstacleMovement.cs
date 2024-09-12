using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool isMovementStart = false;
    public bool canMove = true;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    [SerializeField] float distanceBtwBuilds=30;
    [SerializeField] float speed=0.01f;

    private void Update()
    {
        if (isMovementStart && !GameStates.isGameEnd)
        {
            isMovementStart = false;
            float height = Random.Range(minHeight, maxHeight);
            transform.localPosition = new Vector3(transform.localPosition.x,height,transform.localPosition.z);
        }
        Move();
    }

    private void Move()
    {
        if (IsOtherNotThere() && !GameStates.isGameEnd)
            transform.position -= new Vector3(speed, 0, 0);
    }

    private bool IsOtherNotThere()
    {
        
            Ray ray = new Ray(transform.position, -transform.right);

        Debug.DrawRay(transform.position, -transform.right, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f))
            {
                if (Vector3.Distance(hit.point, transform.position) <= distanceBtwBuilds)
                {
                    return false;

                }
            }
        
        return true;
    }

}
