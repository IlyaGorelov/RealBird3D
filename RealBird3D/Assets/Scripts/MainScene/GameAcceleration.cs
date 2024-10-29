using UnityEngine;

public class GameAcceleration : MonoBehaviour
{
    [SerializeField] float a = 0.001f;
    int pastScore = 0;
    bool canPlus = true;

    void Update()
    {
        if (GameStates.score - pastScore >= 3 && canPlus)
        {
            GameStates.speedA += a;
            canPlus = false;
            pastScore = GameStates.score;
        }
        else canPlus = true;
    }
}
