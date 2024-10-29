using UnityEngine;

public class BGMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        if (!GameStates.isGamePaused) Move();
    }

    private void Move()
    {
        transform.Translate((-speed-GameStates.speedA)*Time.deltaTime, 0, 0);
    }
}
