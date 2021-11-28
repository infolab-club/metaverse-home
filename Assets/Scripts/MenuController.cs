using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuController : MonoBehaviour
{
    [SerializeField] private ActionBasedController rightHand;
    [SerializeField] private ActionBasedController leftHand;
    [SerializeField] private ActionBasedController rightMenuRay;
    [SerializeField] private ActionBasedController leftMenuRay;
    [SerializeField] private UnityEvent onMenuOpen;

    public void CloseMenu()
    {
        SwitchLeft(false);
        SwitchRight(false);
    }
    
    private void Start()
    {
        leftHand.uiPressAction.action.performed += OpenMenuLeft;
        rightHand.uiPressAction.action.performed += OpenMenuRight;
    }

    private void OpenMenu(InputAction.CallbackContext obj)
    {
        onMenuOpen.Invoke();
    }
    
    private void OpenMenuLeft(InputAction.CallbackContext obj)
    {
        OpenMenu(obj);
        SwitchLeft(true);
    }
    
    private void OpenMenuRight(InputAction.CallbackContext obj)
    {
        OpenMenu(obj);
        SwitchRight(true);
    }

    private void SwitchRight(bool state)
    {
        rightHand.gameObject.SetActive(!state);
        rightMenuRay.gameObject.SetActive(state);
    }

    private void SwitchLeft(bool state)
    {
        leftHand.gameObject.SetActive(!state);
        leftMenuRay.gameObject.SetActive(state);
    }
}
