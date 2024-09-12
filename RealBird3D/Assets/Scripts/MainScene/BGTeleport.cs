using UnityEngine;

public class BGTeleport : MonoBehaviour
{
    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;
    [SerializeField] float from;
    [SerializeField] Transform to;

    private void Update()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (bg1.transform.position.x <= from)
        {
            bg1.transform.position = to.position;
        }else if (bg2.transform.position.x <= from)
            bg2.transform.position = to.position;
    }
}
