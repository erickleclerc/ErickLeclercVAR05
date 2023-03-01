using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CheckersGame : MonoBehaviour
{
    public PieceBehaviour piecePrefab;
    public Material red;
    public Material black;
    public Button playAgainButton;

    private bool playerOneTurn = true;
    private bool playerTwoTurn = false;
    private PieceBehaviour selectedPiece = null;

    private void Awake()
    {
        //RED PLAYER
        //back row
        for (int i = 5; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 5);
            createdPiece.tag = "RedPlayer";
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = red;
        }
        //front row
        for (int i = 15; i <= 85; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 15);
            createdPiece.tag = "RedPlayer";
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = red;
        }

        //BLACK PLAYER
        //front row
        for (int i = 5; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 65);
            createdPiece.tag = "BlackPlayer";
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = black;
        }
        //back row
        for (int i = 15; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 75);
            createdPiece.tag = "BlackPlayer";
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = black;
        }
    } // Setup the Board

    void Update()
    {
        if (playerOneTurn == false)
        {
            GameObject[] redPieces = GameObject.FindGameObjectsWithTag("RedPlayer");

            for (int i = 0; i < redPieces.Length; i++)
            {
                redPieces[i].gameObject.layer = LayerMask.NameToLayer("NoRaycast");
            }

        } //Changing Raycast layer for player turns
        else if (playerOneTurn == true)
        {
            GameObject[] redPieces = GameObject.FindGameObjectsWithTag("RedPlayer");

            for (int i = 0; i < redPieces.Length; i++)
            {
                redPieces[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }
        }

        if (playerTwoTurn == false)
        {
            GameObject[] blackPieces = GameObject.FindGameObjectsWithTag("BlackPlayer");

            for (int i = 0; i < blackPieces.Length; i++)
            {
                blackPieces[i].gameObject.layer = LayerMask.NameToLayer("NoRaycast");
            }
        }
        else if (playerTwoTurn == true)
        {
            GameObject[] blackPieces = GameObject.FindGameObjectsWithTag("BlackPlayer");

            for (int i = 0; i < blackPieces.Length; i++)
            {
                blackPieces[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }
        }


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            int maxDistance = 100;
            int layerMask = ~(1 << LayerMask.NameToLayer("NoRaycast"));
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            bool didItHit = Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask);

            if (didItHit == true)
            {
                if (selectedPiece != null)
                {
                    // What tile did we hit on the board to place the piece?            
                    int xHit = selectedPiece.x;
                    int zHit = selectedPiece.z;
                    Debug.Log($"We hit point: {hit.point} resulting in {xHit}, {zHit}");

                    if (selectedPiece.gameObject.CompareTag("RedPlayer"))       //IF PLAYER RED = ONLY UP and RIGHT/LEFT. IF PLAYER BLACK = ONLY DOWN and RIGHT/LEFT  
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }
                        Debug.Log("Redplayer Placement");
                        zHit = selectedPiece.z + 10;
                    }
                    else if (selectedPiece.gameObject.CompareTag("BlackPlayer"))
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }
                        Debug.Log("Black player Placement");
                        zHit = selectedPiece.z - 10;
                    }

                    selectedPiece.SetPosition(xHit, zHit);


                    //IF UNOCCUPIED, SET POSITION



                    //IF OCCUPIED, CANNOT LAND THERE (!SETPOISITON)
                    //SUB IF SPACE ACROSS IS UNOCCUPIED, JUMP AND REMOVE OTHER PLAYER'S PIECE





                    selectedPiece = null;
                    //SWITCH TURNS
                    if (playerOneTurn == true)
                    {
                        playerOneTurn = false;
                        playerTwoTurn = true;

                    }
                    else if (playerTwoTurn == true)
                    {
                        playerTwoTurn = false;
                        playerOneTurn = true;
                    }
                }
                else
                {
                    selectedPiece = hit.collider.gameObject.GetComponent<PieceBehaviour>();

                    if (selectedPiece != null)
                    {
                        Debug.Log($"selected piece at {selectedPiece.x}, {selectedPiece.z}");
                    }
                }


            }
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.green, 20);
        }



        //IF A PLAYER REACHES END OF THE BOARD... CHANGE TAG TO OTHER PLAYER TO MAKE IT GO IN OTHER DIRECTION
        // EX: if gameObject.CompareTag("REDPlayer") position.z = 75 ...
        //      if gameObject.CompareTag("BlackPlayer") position.z = 5 ... gameObject.tag = "RedPlayer"





        CheckRemainingPieces();

    }

    private void CheckRemainingPieces()
    {
        //IF NOT MORE gameObject with tag"RedPlayer" or BlackPlayer ... other player wins.
        GameObject[] redPlayerPiecesLeft = GameObject.FindGameObjectsWithTag("RedPlayer");
        GameObject[] blackPlayerPiecesLeft = GameObject.FindGameObjectsWithTag("BlackPlayer");

        if (redPlayerPiecesLeft.Length == 0)
        {
            Debug.Log("No Red Pieces left");
            playAgainButton.gameObject.SetActive(true);
        }
        else if (blackPlayerPiecesLeft.Length == 0)
        {
            Debug.Log("No Black Pieces left");
            playAgainButton.gameObject.SetActive(true);
        }
    }
}
