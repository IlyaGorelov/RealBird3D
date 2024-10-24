using TMPro;
using UnityEngine;

public class ShowRightCash : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cashText;

    void Update()
    {
        cashText.text = GameStates.cash.ToString();
    }
}
