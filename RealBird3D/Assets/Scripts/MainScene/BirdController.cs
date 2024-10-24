using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
     Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float timeCount;
    private bool isJump = false;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem particle;
    public ParticleSystem coinEffect;
    public AudioSource coinSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !GameStates.isGamePaused)
        {
            Jump();
        }

    }

    private void Jump()
    {
        try { 
        audioSource.Play();
        }
        catch { }
        particle.Play();
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }



}
