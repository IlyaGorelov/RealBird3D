using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameAfterCollision : MonoBehaviour
{
    [SerializeField] FreezeTime freezeTime;
    public static bool isLose;
    [SerializeField] bool isUpLimit;
    [SerializeField] bool isDownLimit;
    public static bool canLoseOneTime=true;

    private void Start()
    {
        freezeTime = new();
    }

    private void Update()
    {
        if (BirdController.isUpper || BirdController.isLower)
            if (canLoseOneTime)
            {
                canLoseOneTime = false;
            Lose();
                print(Time.timeScale);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BirdController b))
        {
            if (isUpLimit)
                BirdController.isUpper = true;
            else if (isDownLimit)
                BirdController.isLower = true;

            try
            {
                Lose();
            }
            catch
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void Lose()
    {
        GameStates.score = 0;
        GameStates.speedA = 0;
        isLose = true;
        StopGame();
    }

    private void StopGame()
    {
        GameStates.isGamePaused = true;
        freezeTime.Freeze();
    }

}
