using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckersGame : MonoBehaviour
{
    public PieceBehaviour piecePrefab;
    public Material red;
    public Material black;

    

    private void Awake()
    {

        //RED PLAYER
        for (int i = 5; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 5);
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = red;
        }

        for (int i = 15; i <= 85; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 15);
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = red;
        }

        //BLACK PLAYER
        for (int i = 5; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 65);
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = black;
        }
        for (int i = 15; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 75);
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = black;
        }



        //PieceBehaviour firstPiece = Instantiate(piecePrefab);
        //firstPiece.SetPosition(5, 5);

        //PieceBehaviour secondPiece = Instantiate(piecePrefab);
        //secondPiece.SetPosition(25, 5);

    }

    private PieceBehaviour selectedPiece = null;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            bool didItHit = Physics.Raycast(ray, out RaycastHit hit);

            if (didItHit == true)
            {
                if (selectedPiece != null)
                {
                    // What tile did we hit on the board?             
                    int xHit = (int)Mathf.Round(hit.point.x/5)*5;
                    int zHit = (int)Mathf.Round(hit.point.z/5)*5;


                    Debug.Log($"We hit point: {hit.point} resulting in {xHit}, {zHit}");

                    selectedPiece.SetPosition(xHit, zHit);

                    selectedPiece = null;
                }
                else
                {
                    selectedPiece = hit.collider.gameObject.GetComponent<PieceBehaviour>();

                    if (selectedPiece != null)
                    {
                        Debug.Log($"selected piece at {selectedPiece.x}, {selectedPiece.z}");
                    }
                }
                Debug.DrawRay(hit.point, Vector3.up, Color.cyan, 2);


            }
            

            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green, 2);
        }
    }
}
