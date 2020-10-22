using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool GamePaused;

    public void Pause()
    {
        if (GamePaused)
        {
            Time.timeScale = 1;
            GamePaused = false;
            Debug.Log("unpaused");
        }
        else
        {
            Time.timeScale = 0;
            GamePaused = true;
            Debug.Log("paused");
        }
    }
}