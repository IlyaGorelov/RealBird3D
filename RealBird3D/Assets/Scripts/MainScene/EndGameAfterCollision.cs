using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameAfterCollision : MonoBehaviour
{
    [SerializeField] GameObject EndScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BirdController b))
        {
            try
            {
                EndScreen.SetActive(true);
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
        GameStates.isGameEnd = true;
    }
}
