using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class RightHand : MonoBehaviour
{
    VRInputActions inputActions;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }
    private void Update()
    {
        //OculusTouchController right = (OculusTouchController)XRController.rightHand;

        //if (right != null)
        //{
        //    if (right.primaryButton.wasPressedThisFrame)
        //    {
        //        Debug.Log("Click!");
        //    }
        //}


        //if (inputActions.Default.PrimaryButton.WasPressedThisFrame())
        //{
        //    Debug.Log("HIT!");
        //}
    }
}
