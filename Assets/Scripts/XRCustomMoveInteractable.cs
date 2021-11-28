using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomMoveInteractable : XRBaseInteractable
{
    [SerializeField] private LayerMask surfaceMask;
    [SerializeField] private float maxDistance = 30f;
    
    private bool _isMoving = false;
    private Vector3 _lastPosition;
    private Transform _interactorTransform;
    
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        _isMoving = true;
        _interactorTransform = args.interactor.transform;
        _lastPosition = _interactorTransform.position;
    }
    
    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        _isMoving = false;
    }
    
    private void Update()
    {
        if (_isMoving)
        {
            if (Physics.Raycast(_interactorTransform.position, _interactorTransform.forward, out RaycastHit hit, maxDistance, surfaceMask))
            {
                transform.position = hit.point;
            }
        }
    }
}
