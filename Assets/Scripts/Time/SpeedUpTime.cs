using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedUpTime : MonoBehaviour
{
    [SerializeField] public InputActionReference SpeedUpActivate;

    public TimeManager TimeManager;

    // Start is called before the first frame update
    void Start()
    {
        SpeedUpActivate.action.performed += SpeedUpActivatevoid;
    }

    private void SpeedUpActivatevoid(InputAction.CallbackContext obj)
    {
        TimeManager.DoSpeedUp();
    }
}