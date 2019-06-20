using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

    [SerializeField] Transform spawnPoint;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tag == "DeadPoint")
        {
            die();
        }
    }


    private void die()
    {
        transform.position = spawnPoint.transform.position;

    }

}
