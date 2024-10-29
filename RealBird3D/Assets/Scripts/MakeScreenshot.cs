using UnityEngine;

public class MakeScreenshot : MonoBehaviour
{
    public static MakeScreenshot instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance = this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ScreenCapture.CaptureScreenshot("screen.png");
            print("screen");
        }
    }
}
