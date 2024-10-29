using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] float speed = 0.02f;
    [SerializeField] Transform endPoint;

    private void Update()
    {
        endPoint = GameObject.Find("EndPoint").transform;
        if (transform.position.x +500< endPoint.position.x)
        {
            Destroy(gameObject);
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BirdController a))
        {
            a.boostEffect.Play();
            a.boostSound.mute = false;
            a.boostSound.Play();
            transform.Translate(0, 100, 0);
            StartCoroutine(Accelerate());
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Accelerate()
    {
        GameStates.speedA += 0.5f;
        yield return new WaitForSeconds(10);
        print("a is gone");
        if(GameStates.speedA>= 0.5f)
        GameStates.speedA -= 0.5f;
        else GameStates.speedA = 0;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ModsBehaviour.mods.Remove(gameObject);
    }
}
