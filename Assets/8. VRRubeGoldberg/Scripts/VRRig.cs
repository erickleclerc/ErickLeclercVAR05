using UnityEngine;
using UnityEngine.InputSystem.XR;

public class VRRig : MonoBehaviour
{
    public Transform head, leftHandy, rightHandy;

    void Start()
    {
        
    }

    void Update()
    {


        if (XRController.leftHand != null)
        {
            Vector3 leftPosition = XRController.leftHand.devicePosition.ReadValue();
            Quaternion leftRotation = XRController.leftHand.deviceRotation.ReadValue();

            leftHandy.SetPositionAndRotation(leftPosition, leftRotation);
        }

        if (XRController.rightHand != null)
        {
            Vector3 rightPosition = XRController.rightHand.devicePosition.ReadValue();
            Quaternion rightRotation = XRController.rightHand.deviceRotation.ReadValue();

            rightHandy.SetPositionAndRotation(rightPosition, rightRotation);
        }

    }
}
