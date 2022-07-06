using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerRef;
    private GameObject player1, player2, player3, player4;
    private SpawnManagerScript spawnManagerScript;
    private Renderer textRenderer;
    Vector3 CameraDistace = Vector3.zero;
    public int followType;
    [SerializeField] private int cameraType;
    public bool secondPlayer2; // for control mode
    public bool readPlayers;
    public bool stopCamera;

    #region Stop Text Rotation
    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    #endregion

    private void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        textRenderer = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        if(!stopCamera)
        {
            UpdateCameraObjectives();

            if (followType == 1)
            {
                transform.rotation = rotation;
            }
            #region Get Follow Type
            switch (followType)
            {
                //camera follow player
                case 0:
                    CameraFollowsPlayer();
                    break;
                //text follow player
                case 1:
                    Vector3 textPos = new Vector3(0.01f, 1.1f, 0);
                    if (playerRef != null)
                    {
                        transform.position = playerRef.transform.position + textPos;
                    }
                    if (transform.position.y < -3)
                    {
                        textRenderer.enabled = false;
                    }
                    else if (transform.position.y >= -3)
                    {
                        textRenderer.enabled = true;
                    }
                    break;
                //ballon follow player
                case 2:
                    Vector3 ballonPos = new Vector3(0, 1.08f, 0);
                    if (playerRef != null)
                    {
                        transform.position = playerRef.transform.position + ballonPos;
                    }
                    break;
            }
            #endregion
        }
    }

    #region Find Players For Camera To Follow
    void UpdateCameraObjectives()
    {
        if (!readPlayers)
        {
            player1 = GameObject.Find("Player");
            // Control mode special setting
            if (!secondPlayer2)
            {
                player2 = GameObject.Find("Player 2");
            }
            else
            {
                player2 = GameObject.Find("Player 2 God");
            }
            player3 = GameObject.Find("Player 3");
            player4 = GameObject.Find("Player 4");
            readPlayers = true;
        }

        if (player1 != null)
        {
            PlayerScript playerScript1 = player1.GetComponent<PlayerScript>();
            if (!playerScript1.dead)
            {
                player1 = GameObject.Find("Player");
            }
            else if (playerScript1.dead)
            {
                player1 = null;
            }
        }
        if (player2 != null)
        {
            PlayerScript playerScript2 = player2.GetComponent<PlayerScript>();
            if (!playerScript2.dead)
            {
                // Control mode special setting
                if (!secondPlayer2)
                {
                    player2 = GameObject.Find("Player 2");
                }
                else
                {
                    player2 = GameObject.Find("Player 2 God");
                }
            }
            else if (playerScript2.dead)
            {
                player2 = null;
            }
        }
        if (player3 != null)
        {
            PlayerScript playerScript3 = player3.GetComponent<PlayerScript>();
            if (!playerScript3.dead)
            {
                player3 = GameObject.Find("Player 3");
            }
            else if (playerScript3.dead)
            {
                player3 = null;
            }
        }
        if (player4 != null)
        {
            PlayerScript playerScript4 = player4.GetComponent<PlayerScript>();
            if (!playerScript4.dead)
            {
                player4 = GameObject.Find("Player 4");
            }
            else if (playerScript4.dead)
            {
                player4 = null;
            }
        }


        // Find out which Player is Alive in order to get him in the camera objective
        if ((player1 == null) && (player2 == null) && (player3 == null) && (player4 == null))
        {
            cameraType = 0;
        }
        else if ((player1 != null) && (player2 == null) && (player3 == null) && (player4 == null))
        {
            cameraType = 1;
        }
        else if ((player1 == null) && (player2 != null) && (player3 == null) && (player4 == null))
        {
            cameraType = 2;
        }
        else if ((player1 == null) && (player2 == null) && (player3 != null) && (player4 == null))
        {
            cameraType = 3;
        }
        else if ((player1 == null) && (player2 == null) && (player3 == null) && (player4 != null))
        {
            cameraType = 4;
        }
        else if ((player1 != null) && (player2 != null) && (player3 == null) && (player4 == null))
        {
            cameraType = 12;
        }
        else if ((player1 != null) && (player2 == null) && (player3 != null) && (player4 == null))
        {
            cameraType = 13;
        }
        else if ((player1 != null) && (player2 == null) && (player3 == null) && (player4 != null))
        {
            cameraType = 14;
        }
        else if ((player1 == null) && (player2 != null) && (player3 != null) && (player4 == null))
        {
            cameraType = 23;
        }
        else if ((player1 == null) && (player2 != null) && (player3 == null) && (player4 != null))
        {
            cameraType = 24;
        }
        else if ((player1 == null) && (player2 == null) && (player3 != null) && (player4 != null))
        {
            cameraType = 34;
        }
        else if ((player1 != null) && (player2 != null) && (player3 != null) && (player4 == null))
        {
            cameraType = 123;
        }
        else if ((player1 != null) && (player2 != null) && (player3 == null) && (player4 != null))
        {
            cameraType = 124;
        }
        else if ((player1 != null) && (player2 == null) && (player3 != null) && (player4 != null))
        {
            cameraType = 134;
        }
        else if ((player1 == null) && (player2 != null) && (player3 != null) && (player4 != null))
        {
            cameraType = 234;
        }
        else if ((player1 != null) && (player2 != null) && (player3 != null) && (player4 != null))
        {
            cameraType = 1234;
        }
    }
    #endregion

    #region Make Camera Follow Players
    void CameraFollowsPlayer()
    {
        // Check for dodgeball mode
        if (spawnManagerScript.gameMode != 5)
        {
            CameraDistace = new Vector3(0, 8, -4);

            if (cameraType == 1) //follow player 1
            {
                transform.position = player1.transform.position + CameraDistace;
            }
            else if (cameraType == 2) //follow player 2
            {
                transform.position = player2.transform.position + CameraDistace; //*2
            }
            else if (cameraType == 3) //follow player 3
            {
                transform.position = player3.transform.position + CameraDistace;
            }
            else if (cameraType == 4) //follow player 4
            {
                transform.position = player4.transform.position + CameraDistace;
            }
            else if (cameraType == 12) // centrate camera between player 1 & player 2
            {
                float middleX = (player1.transform.position.x + player2.transform.position.x) / 2;
                float middleZ = (player1.transform.position.z + player2.transform.position.z) / 2;

                float zoomX = Math.Abs(player1.transform.position.x - player2.transform.position.x);
                float zoomZ = Math.Abs(player1.transform.position.z - player2.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 13) // centrate camera between player 1 & player 3
            {
                float middleX = (player1.transform.position.x + player3.transform.position.x) / 2;
                float middleZ = (player1.transform.position.z + player3.transform.position.z) / 2;

                float zoomX = Math.Abs(player1.transform.position.x - player3.transform.position.x);
                float zoomZ = Math.Abs(player1.transform.position.z - player3.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 14) // centrate camera between player 1 & player 4
            {
                float middleX = (player1.transform.position.x + player4.transform.position.x) / 2;
                float middleZ = (player1.transform.position.z + player4.transform.position.z) / 2;
                float zoomX = Math.Abs(player1.transform.position.x - player4.transform.position.x);
                float zoomZ = Math.Abs(player1.transform.position.z - player4.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 23) // centrate camera between player 2 & player 3
            {
                float middleX = (player2.transform.position.x + player3.transform.position.x) / 2;
                float middleZ = (player2.transform.position.z + player3.transform.position.z) / 2;

                float zoomX = Math.Abs(player2.transform.position.x - player3.transform.position.x);
                float zoomZ = Math.Abs(player2.transform.position.z - player3.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 24) // centrate camera between player 2 & player 4
            {
                float middleX = (player2.transform.position.x + player4.transform.position.x) / 2;
                float middleZ = (player2.transform.position.z + player4.transform.position.z) / 2;

                float zoomX = Math.Abs(player2.transform.position.x - player4.transform.position.x);
                float zoomZ = Math.Abs(player2.transform.position.z - player4.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 34) // centrate camera between player 3 & player 4
            {
                float middleX = (player3.transform.position.x + player4.transform.position.x) / 2;
                float middleZ = (player3.transform.position.z + player4.transform.position.z) / 2;

                float zoomX = Math.Abs(player3.transform.position.x - player4.transform.position.x);
                float zoomZ = Math.Abs(player3.transform.position.z - player4.transform.position.z);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 123) // centrate camera between player 1 & player 2 & player 3
            {
                float leftXEdge = new[] { player1.transform.position.x, player2.transform.position.x, player3.transform.position.x }.Min();
                float rightXEdge = new[] { player1.transform.position.x, player2.transform.position.x, player3.transform.position.x }.Max();
                float leftZEdge = new[] { player1.transform.position.z, player2.transform.position.z, player3.transform.position.z }.Min();
                float rightZEdge = new[] { player1.transform.position.z, player2.transform.position.z, player3.transform.position.z }.Max();
                float middleX = (leftXEdge + rightXEdge) / 2;
                float middleZ = (leftZEdge + rightZEdge) / 2;

                float zoomX = Math.Abs(leftXEdge - rightXEdge);
                float zoomZ = Math.Abs(leftZEdge - rightZEdge);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 124) // centrate camera between player 1 & player 2 & player 4
            {
                float leftXEdge = new[] { player1.transform.position.x, player2.transform.position.x, player4.transform.position.x }.Min();
                float rightXEdge = new[] { player1.transform.position.x, player2.transform.position.x, player4.transform.position.x }.Max();
                float leftZEdge = new[] { player1.transform.position.z, player2.transform.position.z, player4.transform.position.z }.Min();
                float rightZEdge = new[] { player1.transform.position.z, player2.transform.position.z, player4.transform.position.z }.Max();
                float middleX = (leftXEdge + rightXEdge) / 2;
                float middleZ = (leftZEdge + rightZEdge) / 2;

                float zoomX = Math.Abs(leftXEdge - rightXEdge);
                float zoomZ = Math.Abs(leftZEdge - rightZEdge);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 134) // centrate camera between player 1 & player 3 & player 4
            {
                float leftXEdge = new[] { player1.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Min();
                float rightXEdge = new[] { player1.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Max();
                float leftZEdge = new[] { player1.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Min();
                float rightZEdge = new[] { player1.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Max();
                float middleX = (leftXEdge + rightXEdge) / 2;
                float middleZ = (leftZEdge + rightZEdge) / 2;

                float zoomX = Math.Abs(leftXEdge - rightXEdge);
                float zoomZ = Math.Abs(leftZEdge - rightZEdge);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 234) // centrate camera between player 2 & player 3 & player 4
            {
                float leftXEdge = new[] { player2.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Min();
                float rightXEdge = new[] { player2.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Max();
                float leftZEdge = new[] { player2.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Min();
                float rightZEdge = new[] { player2.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Max();
                float middleX = (leftXEdge + rightXEdge) / 2;
                float middleZ = (leftZEdge + rightZEdge) / 2;

                float zoomX = Math.Abs(leftXEdge - rightXEdge);
                float zoomZ = Math.Abs(leftZEdge - rightZEdge);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
            else if (cameraType == 1234) // centrate camera between all 4 players
            {
                float leftXEdge  = new[] { player1.transform.position.x, player2.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Min();
                float rightXEdge = new[] { player1.transform.position.x, player2.transform.position.x, player3.transform.position.x, player4.transform.position.x }.Max();
                float leftZEdge  = new[] { player1.transform.position.z, player2.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Min();
                float rightZEdge = new[] { player1.transform.position.z, player2.transform.position.z, player3.transform.position.z, player4.transform.position.z }.Max();
                float middleX = (leftXEdge + rightXEdge) / 2;
                float middleZ = (leftZEdge + rightZEdge) / 2;

                float zoomX = Math.Abs(leftXEdge - rightXEdge);
                float zoomZ = Math.Abs(leftZEdge - rightZEdge);
                float zoomFinal = (zoomX + zoomZ) / 4;

                Vector3 MiddlePoint = new Vector3(middleX, zoomFinal, middleZ - zoomFinal);
                transform.position = MiddlePoint + CameraDistace;
            }
        }
    }
    #endregion
}
