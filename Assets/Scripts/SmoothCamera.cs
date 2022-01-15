using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
  public Transform MainCamera;
  public Vector3 cameraOffset;
  public float cameraSpeed = 0.1f;

  void Start()
  {
    transform.position = MainCamera.position + cameraOffset;
  }

  void FixedUpdate ()
  {
    Vector3 finalPosition = MainCamera.position + cameraOffset;
    Vector3 lerpPosition = Vector3.Lerp (transform.position, finalPosition, cameraSpeed);
    transform.position = lerpPosition;
  }
}
