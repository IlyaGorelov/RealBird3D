using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed = 0.01f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameStates.isGamePaused)
            transform.Translate(-speed - GameStates.speedA, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameStates.cash += 1;
        Destroy(gameObject);
    }
}
