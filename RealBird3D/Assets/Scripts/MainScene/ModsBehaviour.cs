using System.Collections.Generic;
using UnityEngine;

public class ModsBehaviour : MonoBehaviour
{
    public static List<GameObject> mods;
    [SerializeField] GameObject[] managers;
    [SerializeField] float distance;
    [SerializeField] BirdController birdController;
    private Transform bird;
    [SerializeField] float speed=1;

    private void Start()
    {
        
        
        mods = new List<GameObject>();
        bird = birdController.gameObject.transform;
    }


    void Update()
    {
        foreach (GameObject mod in mods)
        {
            Move(mod);
            if (mod.transform.position.x - bird.position.x <= distance)
                mod.SetActive(true);
        }
        
    }

    private void Move(GameObject mod)
    {
        if (!GameStates.isGamePaused)
        {
            mod.transform.Translate((-speed - GameStates.speedA) * Time.deltaTime, 0, 0);
        }
    }
}
