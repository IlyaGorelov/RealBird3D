using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameAfterCollision : MonoBehaviour
{
    [SerializeField] FreezeTime freezeTime;
    public static bool isLose;

    private void Start()
    {
        freezeTime = new();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BirdController b))
        {
            try
            {
                GameStates.score = 0;
                GameStates.speedA = 0;
                isLose = true;
                StopGame();
            }
            catch
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void StopGame()
    {
        GameStates.isGamePaused = true;
        freezeTime.Freeze();
    }

}
