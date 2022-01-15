using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.InputSystem.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class LocomotionChanger : MonoBehaviour
{
    
    public GameObject LocomotionSystemRight = null;
    public GameObject LocomotionSystemLeft = null;
    
    public void ChangeHandLocomotion()
    {
        LocomotionSystemRight = GameObject.Find("Locomotion System (Left Hand)");
        LocomotionSystemLeft = GameObject.Find("Locomotion System (Right Hand)");

        LocomotionSystemRight.GetComponent<ContinuousMoveProviderBase>();
        LocomotionSystemRight.GetComponent<ContinuousMoveProviderBase>();
        
        LocomotionSystemRight.GetComponent<ContinuousTurnProviderBase>();
        LocomotionSystemRight.GetComponent<ContinuousTurnProviderBase>();
        
        LocomotionSystemRight.GetComponent<ActionBasedSnapTurnProvider>();
        LocomotionSystemRight.GetComponent<ActionBasedSnapTurnProvider>();
    }

    public void TurnTypeChange()
    {
        //change Snap to Continuous
        if (LocomotionSystemRight.GetComponent<ActionBasedSnapTurnProvider>().enabled == true)
        {
            LocomotionSystemRight.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            LocomotionSystemRight.GetComponent<ContinuousTurnProviderBase>().enabled = true;
        }
        else
        {
            if (LocomotionSystemLeft.GetComponent<ActionBasedSnapTurnProvider>().enabled == true)
            {
                LocomotionSystemLeft.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
                LocomotionSystemLeft.GetComponent<ContinuousTurnProviderBase>().enabled = true;
            }
        }

        //change Continuous to Snap
        if (LocomotionSystemRight.GetComponent<ContinuousTurnProviderBase>().enabled == true)
        {
            LocomotionSystemRight.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            LocomotionSystemRight.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        }
        else
        {
            if (LocomotionSystemLeft.GetComponent<ContinuousTurnProviderBase>().enabled == true)
            {
                LocomotionSystemLeft.GetComponent<ContinuousTurnProviderBase>().enabled = false;
                LocomotionSystemLeft.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            }
        }
    }
}
