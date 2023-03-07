using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class CheckersGame : MonoBehaviour
{
    public PieceBehaviour piecePrefab;
    public Material red;
    public Material black;
    public Button playAgainButton;
    public TextMeshProUGUI winnerText;

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
            createdPiece.gameObject.name = "RED";
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
            createdPiece.gameObject.name = "RED";
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
            createdPiece.gameObject.name = "BLACK";
            createdPiece.tag = "BlackPlayer";
            Renderer renderer = createdPiece.GetComponent<Renderer>();
            renderer.material = black;
        }
        //back row
        for (int i = 15; i <= 75; i += 20)
        {
            PieceBehaviour createdPiece = Instantiate(piecePrefab);
            createdPiece.SetPosition(i, 75);
            createdPiece.gameObject.name = "BLACK";
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
            GameObject[] redPiecesCrowned = GameObject.FindGameObjectsWithTag("CrownedRed");

            for (int i = 0; i < redPiecesCrowned.Length; i++)
            {
                redPiecesCrowned[i].gameObject.layer = LayerMask.NameToLayer("NoRaycast");
            }

        } //Changing Raycast layer for player turns
        else if (playerOneTurn == true)
        {
            GameObject[] redPieces = GameObject.FindGameObjectsWithTag("RedPlayer");

            for (int i = 0; i < redPieces.Length; i++)
            {
                redPieces[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }
            GameObject[] redPiecesCrowned = GameObject.FindGameObjectsWithTag("CrownedRed");

            for (int i = 0; i < redPiecesCrowned.Length; i++)
            {
                redPiecesCrowned[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }
        }

        if (playerTwoTurn == false)
        {
            GameObject[] blackPieces = GameObject.FindGameObjectsWithTag("BlackPlayer");

            for (int i = 0; i < blackPieces.Length; i++)
            {
                blackPieces[i].gameObject.layer = LayerMask.NameToLayer("NoRaycast");
            }
            GameObject[] blackPiecesCrowned = GameObject.FindGameObjectsWithTag("CrownedBlack");

            for (int i = 0; i < blackPiecesCrowned.Length; i++)
            {
                blackPiecesCrowned[i].gameObject.layer = LayerMask.NameToLayer("NoRaycast");
            }
        }
        else if (playerTwoTurn == true)
        {
            GameObject[] blackPieces = GameObject.FindGameObjectsWithTag("BlackPlayer");

            for (int i = 0; i < blackPieces.Length; i++)
            {
                blackPieces[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }

            GameObject[] blackPiecesCrowned = GameObject.FindGameObjectsWithTag("CrownedBlack");

            for (int i = 0; i < blackPiecesCrowned.Length; i++)
            {
                blackPiecesCrowned[i].gameObject.layer = LayerMask.NameToLayer("CanRaycast");
            }
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            int maxDistance = 100;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            bool didItHit = Physics.Raycast(ray, out RaycastHit hit, maxDistance);
            int layerMaskStopFromLanding = LayerMask.NameToLayer("NoRaycast");

            if (didItHit == true)
            { 
                if (hit.collider.gameObject.layer == layerMaskStopFromLanding)
                {
                    Debug.Log("HIT OTHER OBJECT. CAN'T MOVE");
                    return;
                }
                else if (selectedPiece != null)
                {
                    int xHitOG = selectedPiece.x;
                    int zHitOG = selectedPiece.z;
                    int xHit = selectedPiece.x;
                    int zHit = selectedPiece.z;
                    // Debug.Log($"We hit point: {hit.point} resulting in {xHit}, {zHit}");

                    //MOVING THE PLAYERS
                    if (selectedPiece.gameObject.CompareTag("RedPlayer"))       //IF PLAYER RED = ONLY UP and RIGHT/LEFT  
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }
                        zHit = selectedPiece.z + 10;
                    }
                    else if (selectedPiece.gameObject.CompareTag("BlackPlayer"))    //IF PLAYER BLACK = ONLY DOWN and RIGHT / LEFT
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }
                        zHit = selectedPiece.z - 10;
                    }
                    else if (selectedPiece.gameObject.CompareTag("CrownedBlack") || selectedPiece.gameObject.CompareTag("CrownedRed"))      //CROWNED PLAYER = MOVE IN ANY DIRECTION
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }

                        if (hit.point.z < zHit || hit.point.z > 75)
                        {
                            zHit = selectedPiece.z - 10;
                        }
                        else if (hit.point.z > zHit || hit.point.z < 5)
                        {
                            zHit = selectedPiece.z + 10;
                        }
                    }
                    selectedPiece.SetPosition(xHit, zHit);


                    //CHECK FOR OVERLAP
                    CheckForOverlap(hit, xHitOG, zHitOG, ref xHit, ref zHit);
                    CheckForOverlapTwo(hit, xHitOG, zHitOG, ref xHit, ref zHit);


                    selectedPiece = null; //LET GO OF PIECE
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

                    //if (selectedPiece != null)
                    //{
                    //    Debug.Log($"selected piece at {selectedPiece.x}, {selectedPiece.z}");
                    //}
                } // MAKING SURE PIECE HAS BEEN ACCESSED
            }
            // Debug.DrawRay(ray.origin, ray.direction * 80, Color.green, 5);
        }

        CheckForCrowning();
        CheckRemainingPieces();  //CHECK TO DETERMINE WINNER
    }

    private void CheckForOverlapTwo(RaycastHit hit, int xHitOG, int zHitOG, ref int xHit, ref int zHit)
    {
        foreach (GameObject otherRedPiece in GameObject.FindGameObjectsWithTag("RedPlayer"))
        {
            if (otherRedPiece != selectedPiece.gameObject)
            {
                if (selectedPiece.gameObject.name == "BLACK")
                {
                    if (selectedPiece.gameObject.transform.position == otherRedPiece.transform.position)
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }

                        if (hit.point.z < zHit || hit.point.z > 75)
                        {
                            zHit = selectedPiece.z - 10;
                        }
                        else if (hit.point.z > zHit || hit.point.z < 5)
                        {
                            zHit = selectedPiece.z + 10;
                        }
                        selectedPiece.SetPosition(xHit, zHit);
                        Destroy(otherRedPiece.gameObject);
                        Debug.Log("JUMPED");
                    }
                }
                else if (selectedPiece.gameObject.name == "RED")
                {
                    if (selectedPiece.gameObject.transform.position == otherRedPiece.transform.position)
                    {
                        selectedPiece.SetPosition(xHitOG, zHitOG);
                        Debug.Log("Blocked by own red");

                    }
                }

            }

        }
    }

    private void CheckForOverlap(RaycastHit hit, int xHitOG, int zHitOG, ref int xHit, ref int zHit)
    {
        foreach (GameObject otherBlackPiece in GameObject.FindGameObjectsWithTag("BlackPlayer"))
        {
            if (otherBlackPiece != selectedPiece.gameObject)
            {
                if (selectedPiece.gameObject.name == "RED")
                {
                    if (selectedPiece.gameObject.transform.position == otherBlackPiece.transform.position)
                    {
                        if (hit.point.x < xHit)
                        {
                            xHit = selectedPiece.x - 10;
                        }
                        else if (hit.point.x > xHit)
                        {
                            xHit = selectedPiece.x + 10;
                        }

                        if (hit.point.z < zHit || hit.point.z > 75)
                        {
                            zHit = selectedPiece.z - 10;
                        }
                        else if (hit.point.z > zHit || hit.point.z < 5)
                        {
                            zHit = selectedPiece.z + 10;
                        }
                        selectedPiece.SetPosition(xHit, zHit);
                        Destroy(otherBlackPiece.gameObject);
                    }
                }
                else if (selectedPiece.gameObject.name == "BLACK")
                {
                    if (selectedPiece.gameObject.transform.position == otherBlackPiece.transform.position)
                    {
                        selectedPiece.SetPosition(xHitOG, zHitOG);
                        Debug.Log("Blocked by own black");
                    }
                }
            }

        }

    }

    private static void CheckForCrowning()
    {
        GameObject[] toBeCrownedRed = GameObject.FindGameObjectsWithTag("RedPlayer");
        for (int i = 0; i < toBeCrownedRed.Length; i++)
        {
            if (toBeCrownedRed[i].transform.position.z > 20)
            {
                toBeCrownedRed[i].gameObject.tag = "CrownedRed";
            }
        }

        GameObject[] toBeCrownedBlack = GameObject.FindGameObjectsWithTag("BlackPlayer");
        for (int i = 0; i < toBeCrownedBlack.Length; i++)
        {
            if (toBeCrownedBlack[i].transform.position.z < 10)
            {
                toBeCrownedBlack[i].gameObject.tag = "CrownedBlack";
            }
        }
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
            winnerText.gameObject.SetActive(true);
            winnerText.text = "Black WINS!!!";
        }
        else if (blackPlayerPiecesLeft.Length == 0)
        {
            Debug.Log("No Black Pieces left");
            playAgainButton.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(true);
            winnerText.text = "Red WINS!!!";
        }
    }
}
