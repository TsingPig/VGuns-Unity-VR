using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.InputSystem.XR.XRController;


public class TeleportationManager : MonoBehaviour

{

    [SerializeField] public InputActionReference activate;

    [SerializeField] public XRRayInteractor _RayInteractor;

    [SerializeField] public GameObject teleportable;
    
    [SerializeField] public TeleportationProvider _teleportationProvider;

    void Start()

    {
        _RayInteractor.enabled = false;

        activate.action.performed += TeleportActivate;
        
        activate.action.canceled += TeleportCancled;
        
        for (int i = 0; i < teleportable.transform.childCount; i++)
        {
            var child = teleportable.transform.GetChild(i).gameObject;
            
            if (child != null)
                child.SetActive(false);
        }

    }

    private void TeleportCancled(InputAction.CallbackContext obj)

    {

        if (_RayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit ray) &&  _RayInteractor.enabled == true)

        {

            TeleportRequest teleportRequest = new TeleportRequest();

            teleportRequest.destinationPosition = ray.point;

            _teleportationProvider.QueueTeleportRequest(teleportRequest);

        }

        _RayInteractor.enabled = false;
        

        for (int i = 0; i < teleportable.transform.childCount; i++)
        {
            var child = teleportable.transform.GetChild(i).gameObject;
            
            if (child != null)
                child.SetActive(false);
        }

    }

    private void TeleportActivate(InputAction.CallbackContext obj)

    {

        _RayInteractor.enabled = true;
        
        for (int i = 0; i < teleportable.transform.childCount; i++)
        {
            var child = teleportable.transform.GetChild(i).gameObject;
            
            if (child != null)
                child.SetActive(true);
        }

    }
    
}