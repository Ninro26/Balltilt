using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2DCamera : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("Reference to the target GameObject")]
    public Transform target;
    [Tooltip("Current relative offset to the target")]
    public Vector3 offset;
    [Tooltip("Multiplier for the movement speed")]
    [Range(0f, 5f)]
    public float smoothSpeed = 0.125f;
    [Tooltip("Maximum or highest camera position on the Y-axis.")]
    public float maxHeight = 5f;
    [Tooltip("Minimum or lowest camera position on the Y-axis.")]
    public float minHeight = -1f;

    private bool perspective = false;

    // Use this for initialization
    void Start()
    {
        if(!Camera.main.orthographic)
        {
            perspective = true;
        }
	}

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, target.position + offset, smoothSpeed);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minHeight, maxHeight);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, target.position.z + offset.z);

        if(perspective)
        {
            transform.LookAt(target);
        }
    }
}
