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
        transform.Translate(-speed-GameStates.speedA, 0, 0);
    }
}
