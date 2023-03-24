using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    VRInputActions inputActions;
    Rigidbody heldObject;
    bool wasDropped;

    Vector3 previousPosition;
    Vector3 velocity;
    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }

    void Update()
    {
        wasDropped = false;

        if (heldObject != null)  //holding onto something
        {
            if (inputActions.Default.PrimaryButtonRightHand.WasPressedThisFrame())
            {
                heldObject.transform.parent = null;
                heldObject.isKinematic = false;

                heldObject.velocity = velocity;
                heldObject = null;

                wasDropped = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (heldObject != null)  //holding onto something
        {
            Vector3 displacement = heldObject.transform.position - previousPosition;

            velocity = displacement / Time.deltaTime;

            previousPosition = heldObject.transform.position;
        }

    }
    private void OnTriggerStay(Collider marble)
    {
        if (wasDropped == true)
        {
            return;
        }

        if (heldObject == null)
        {
            Rigidbody rb = marble.GetComponent<Rigidbody>();
            Debug.Log(marble.gameObject.name);

            if (rb != null && marble.gameObject.CompareTag("Marble"))
            {
                if (inputActions.Default.PrimaryButtonRightHand.WasPressedThisFrame())
                {
                    marble.transform.parent = transform;
                    rb.isKinematic = true;

                    heldObject = rb;
                }
            }
        }
    }
}

