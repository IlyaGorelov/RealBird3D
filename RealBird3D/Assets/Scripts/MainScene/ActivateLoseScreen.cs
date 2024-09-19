using UnityEngine;

public class ActivateLoseScreen : MonoBehaviour
{
    [SerializeField] GameObject lose;

    void Update()
    {
        if (EndGameAfterCollision.isLose)
        {
            lose.SetActive(true);
        }
    }
}
