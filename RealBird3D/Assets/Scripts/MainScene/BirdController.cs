using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
     Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float timeCount;
    private bool isJump = false;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

    }

    private void Jump()
    {
       // animator.SetTrigger("ToDefault");
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }

}
