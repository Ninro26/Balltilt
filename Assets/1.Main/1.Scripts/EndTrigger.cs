using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

    // Use this for initialization
    public string LoadLevel;
    
    // here we make it so that if the endtrigger collides with the tag player it loads a new level.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(LoadLevel);
        }
    }

}
