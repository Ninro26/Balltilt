using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

   
{
    public bool isFlat = true;
    public Rigidbody2D rigid2d;
    public float speed = 15f;
    public float maxSpeed = 5f;
    
    // here we look for the specific component rigidbody2d

    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        // here we use the gyroscope of the mobile to input force on the rigidbody.
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        float gx = Input.acceleration.x * speed;
        float gy = Input.acceleration.y * speed;
        Physics2D.gravity = new Vector2(gx, gy);
        rigid2d.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt);
    }

  


    void FixedUpdate()
    {
        if (rigid2d.velocity.magnitude > maxSpeed)
        {
            rigid2d.velocity = rigid2d.velocity.normalized * maxSpeed;
        }
    }




          
        
 }


