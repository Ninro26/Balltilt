using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{

    public string LoadLevel;

    void OnTouchDown()
    {

        SceneManager.LoadScene(LoadLevel);

    }




}
