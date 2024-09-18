using TMPro;
using UnityEngine;

public class PlusScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] LayerMask layerMask;
    private bool canPlus = true;

    private void Update()
    {
        CheckOnBuildDown();
    }

    private void CheckOnBuildDown()
    {
        if(IsAnyoneUp() && Physics.Raycast(transform.position, -transform.up,out RaycastHit hit, 1000f, layerMask))
        {
            if (canPlus)
            {
                GameStates.score++;
                scoreText.text = GameStates.score.ToString();
                canPlus = false;
            }
        }
        else
        {
            canPlus = true;
        }
    }

    private bool IsAnyoneUp()
    {
        return Physics.Raycast(transform.position, transform.up, out RaycastHit hit, 1000f, layerMask);
    }
}
