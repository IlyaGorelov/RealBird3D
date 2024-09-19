using UnityEngine;

public class GetEndScreen : MonoBehaviour
{
    public GameObject lose;
    public static GameObject lose2;

    private void Start()
    {
        lose2 = lose;
    }
}
