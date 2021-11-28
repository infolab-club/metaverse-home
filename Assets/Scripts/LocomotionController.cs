using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

public class LocomotionController : MonoBehaviour
{
    [SerializeField] private ActionBasedController rightTeleportRay;
    [SerializeField] private ActionBasedController leftTeleportRay;
    [SerializeField] private float activationThreshold = 0.1f;

    private void Update()
    {
        if(leftTeleportRay)
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        if(rightTeleportRay)
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
    }

    private bool CheckIfActivated(ActionBasedController controller)
    {
        return  controller.selectAction.action.ReadValue<float>() >= activationThreshold;
    }
}
