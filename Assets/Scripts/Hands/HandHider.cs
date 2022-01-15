using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    public GameObject handObject = null;

    private XRDirectInteractor interactor = null;

    public SkinnedMeshRenderer HandMesh = null;
    
    public SphereCollider SphereCollider_1 = null;
    public SphereCollider SphereCollider_2 = null;

    private void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();
        HandMesh = handObject.GetComponent<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        interactor.onSelectEntered.AddListener(Hide);
        interactor.onSelectExited.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.onSelectEntered.RemoveListener(Hide);
        interactor.onSelectExited.RemoveListener(Show);
    }
    
    
    private void Show(XRBaseInteractable interactable)
    {
        HandMesh.enabled = true;
        SphereCollider_1.enabled = true;
        SphereCollider_2.enabled = true;
    }

    private void Hide(XRBaseInteractable interactable)
    {
        HandMesh.enabled = false;
        SphereCollider_1.enabled = false;
        SphereCollider_2.enabled = false;
    }
}
