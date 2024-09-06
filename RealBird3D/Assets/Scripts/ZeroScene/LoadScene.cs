using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneId=0;
    [SerializeField] Slider bar;
    [SerializeField] GameObject loadScreen;

    public void StartGameButton()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }
        

    IEnumerator LoadAsync()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneId);

        while (!load.isDone)
        {
            bar.value = load.progress;
            yield return null;
        }
    }
}
