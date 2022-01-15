using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowdownFactor = 0.05f;
    public float TimeLength = 2f;
    
    public float SpeedupFactor = 0.05f;

    void Update ()
    {
        Time.timeScale += (1f / TimeLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion ()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    
    public void DoSpeedUp ()
    {
        Time.timeScale = SpeedupFactor;
        Time.fixedDeltaTime = Time.timeScale - .02f;
    }

}

