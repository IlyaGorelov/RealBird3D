using UnityEngine;

public class Cheats : MonoBehaviour
{
    SphereCollider sphereCollider;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        Invincible();
        PlusScore();
        PlusCash();
    }

    private void Invincible()
    {
        if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.N) &&
            Input.GetKey(KeyCode.V) &&
            Input.GetKey(KeyCode.C))
            sphereCollider.enabled = false;
    }

    private void PlusScore()
    {
        if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.O) &&
            Input.GetKey(KeyCode.Y) &&
            Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
            GameStates.score+=3;
    }

    private void PlusCash()
    {
        if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.O) &&
            Input.GetKey(KeyCode.P) &&
            Input.GetKey(KeyCode.A))
        {
            GameStates.cash += 3;
            print("plus");
        }

    }
}
