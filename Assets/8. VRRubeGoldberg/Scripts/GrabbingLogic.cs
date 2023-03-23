using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    public Transform grabOrigin;
    public float grabRadius = 0.1f;
    public bool triggerPressed;

    private GrabbableObject highlightedObject;
    private GrabbableObject heldObject;

    VRInputActions inputActions;

    private void Awake()
    {

        inputActions = new VRInputActions();
        inputActions.Enable();
    }

    private void Update()
    {
        // Are we holding an object?
        if (heldObject != null)
        {
            if (!triggerPressed || !inputActions.Default.PrimaryButtonRightHand.WasPressedThisFrame())
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;

                heldObject = null;
            }
        }
        // If not, highlight and allow grabbing.
        else
        {
            if (highlightedObject != null)
            {
                highlightedObject.SetHighlight(false);
                highlightedObject = null;
            }

            // Are we hovering over any objects?
            // If so, which one?
            Collider[] cols = Physics.OverlapSphere(grabOrigin.position, grabRadius);

            // Did we hit anything at all?
            foreach (Collider col in cols)
            {
                GrabbableObject grabbable = col.GetComponent<GrabbableObject>();

                if (grabbable != null)
                {
                    // Grab the object if the user wants to (i.e., presses the trigger).
                    if (triggerPressed || inputActions.Default.PrimaryButtonRightHand.WasPressedThisFrame())
                    {
                        heldObject = grabbable;

                        heldObject.transform.parent = transform;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    else
                    {
                        highlightedObject = grabbable;
                        highlightedObject.SetHighlight(true);
                    }

                    // Exit the loop, we've found something to grab!
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(grabOrigin.position, grabRadius);
    }
}
