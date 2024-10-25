using UnityEngine;
using System.Linq;

public class BirdController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float timeCount;
    private bool isJump = false;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource[] FlySounds;
    [SerializeField] AudioSource DefoltFlySound;
    [SerializeField] ParticleSystem[] FlyEffects;
    public ParticleSystem coinEffect;
    public ParticleSystem boostEffect;
    public AudioSource coinSound;
    public AudioSource boostSound;

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
        PlayEffect();
        rb.AddForce((jumpForce+GameStates.speedA) * Vector3.up, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }

    private void PlayEffect()
    {
        var activeEffects = (from e in FlyEffects
                             where e.gameObject.activeSelf
                             select e).ToArray();
        if (activeEffects.Count() > 0)
        {
            int rand = Random.Range(0, activeEffects.Count());
            PlaySound(activeEffects[rand].gameObject);
            activeEffects[rand].Play();
        }
        else
        {
            DefoltFlySound.mute = false;
            DefoltFlySound.Play();
        }
    }

    private void PlaySound(GameObject effect)
    {
        AudioSource audioSource = effect.GetComponent<AudioSource>();
        audioSource.mute = false;
        audioSource.Play();
    }



}
