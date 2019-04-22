using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetCamera : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("List of targets the camera will follow")]
    public List<Transform> targets;
    [Tooltip("Offset from the targets")]
    public Vector3 offset;
    [Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
    public float smoothTime = 0.5f;
    [Tooltip("Minimum FOV when zooming")]
    public float minZoom = 40.0f;
    [Tooltip("Maximum FOV when zooming")]
    public float maxZoom = 10.0f;
    [Tooltip("Limiting value when zooming")]
    public float zoomLimiter = 5.0f;
    [Tooltip("Maximum or highest camera position on the Y-axis.")]
    public float maxHeight = 5f;
    [Tooltip("Minimum or lowest camera position on the Y-axis.")]
    public float minHeight = -1f;

    private Vector3 velocity;
    private Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, newZoom, Time.deltaTime);
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        newPosition.y = Mathf.Clamp(newPosition.y, minHeight, maxHeight);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
