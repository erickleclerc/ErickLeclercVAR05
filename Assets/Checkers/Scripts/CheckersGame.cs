using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckersGame : MonoBehaviour
{
    public PieceBehaviour piecePrefab;


    private void Awake()
    {
        PieceBehaviour piece = new PieceBehaviour() { x = 2, z = 3 };

        //spawn piece
        var spawnedPiece = Instantiate(piecePrefab);
        spawnedPiece.transform.position = new Vector3(piece.x, 0, piece.z);
    }


    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            bool didItHit = Physics.Raycast(ray, out RaycastHit hit);

            if (didItHit == true)
            {
                Debug.Log("HITIITITITI");

                //round to INT to place on grid style
            }
            else
            {
                PieceBehaviour clickedPiece = hit.collider.gameObject.GetComponent<PieceBehaviour>();

            }


            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green, 2);
        }
    }
}
