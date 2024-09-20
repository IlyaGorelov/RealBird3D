using TMPro;
using UnityEngine;

public class ChangeScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreOnLose;
    [SerializeField] TextMeshProUGUI score;

    private void OnEnable()
    {
        scoreOnLose.text = score.text;
    }
}
