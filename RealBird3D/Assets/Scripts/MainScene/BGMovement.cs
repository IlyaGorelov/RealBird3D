using UnityEngine;

public class BGMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        if (!GameStates.isGameEnd) Move();
    }

    private void Move()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }
}
