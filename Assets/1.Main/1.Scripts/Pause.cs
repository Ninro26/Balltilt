using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused = false;
    public GameObject Pausemenu;

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
        Pausemenu.SetActive(true);
    }

    void Resume()
    {
        Debug.Log("Resuming");
        Time.timeScale = 1f;
        paused = false;
        Pausemenu.SetActive(false);
    }








    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
