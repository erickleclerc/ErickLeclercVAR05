using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class VRRig : MonoBehaviour
{
    public Transform head, leftHandy, rightHandy;

    void Update()
    {
        if (XRController.leftHand != null)
        {
            Vector3 leftPosition = XRController.leftHand.devicePosition.ReadValue();
            Quaternion leftRotation = XRController.leftHand.deviceRotation.ReadValue();

            //leftHandy.SetPositionAndRotation(leftPosition + new Vector3(0, 1, 0), leftRotation); OLD FORMAT OF BELOW
            
            leftHandy.localPosition = leftPosition + new Vector3(0, 1, 0);
            leftHandy.localRotation = leftRotation;

        }                                                               //Left Hand world placement

        if (XRController.rightHand != null)
        {
            Vector3 rightPosition = XRController.rightHand.devicePosition.ReadValue();
            Quaternion rightRotation = XRController.rightHand.deviceRotation.ReadValue();

            //rightHandy.SetPositionAndRotation(rightPosition + new Vector3(0, 1, 0), rightRotation); OLD FORMAT OF BELOW

            rightHandy.localPosition = rightPosition + new Vector3(0, 1, 0);
            rightHandy.localRotation = rightRotation;
        }                                                              //Right Hand world placement

        XRHMD hmd = InputSystem.GetDevice<XRHMD>();

        if (hmd != null)                                                                                   
        {
            Vector3 headPosition = hmd.devicePosition.ReadValue();
            Quaternion headRotation = hmd.deviceRotation.ReadValue();

           // head.SetPositionAndRotation(headPosition + new Vector3(0,1,0), headRotation); OLD FORMAT

            head.localPosition= headPosition + new Vector3(0, 1, 0); 
            head.localRotation = headRotation;
        }                                                                                 //Head world placement
    }
}
