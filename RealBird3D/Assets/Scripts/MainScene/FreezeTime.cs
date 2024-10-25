using UnityEngine;

public class FreezeTime
{
    float pastScale;

    public void Freeze()
    {
        pastScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
