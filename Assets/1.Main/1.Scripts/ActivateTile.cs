using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTile : MonoBehaviour
{
    public GameObject tilemap;

    private void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        //Wait for 2 secs.
        yield return new WaitForSeconds(2);

        //Turn My game object that is set to True(on) to false(off) .
        tilemap.SetActive(false);

        //Turn the Game Oject back on after 1 sec.
        yield return new WaitForSeconds(2);

        //Game object will turn on
        tilemap.SetActive(true);

        //here we call the function again.
        StartCoroutine(ActivationRoutine());

    }
}