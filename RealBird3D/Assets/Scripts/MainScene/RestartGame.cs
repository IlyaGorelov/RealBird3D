using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void Re()
    {
        Time.timeScale = 1.0f;
        GameStates.isGamePaused = false;
        EndGameAfterCollision.isLose = false;
    }
}
