using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool paused = false;
    [SerializeField] GameObject pauseMenu;

    public void OnTouchDown()
    {
        if (paused)
        {
            Resume();
            
        }

        else

            Pausing();
            



    }

    void Pausing()
    {
        Debug.Log("Pausing");
        Time.timeScale = 0f;
        paused = true;
        pauseMenu.SetActive(true);
    }

    void Resume()
    {
        Debug.Log("Resuming");
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }







    
}
