using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DevScript : MonoBehaviour
{
    #region Get Data 1
 //   public InputActionAsset primaryActions;  // Input Base
  //  InputActionMap playerActionMap;          // Input Action Map
 //   InputAction Respawn1Action, Respawn2Action, Respawn3Action, Respawn4Action;   // Input Action
    private GameObject player1, player2, player3, player4;
    private PlayerScript playerScript1, playerScript2, playerScript3, playerScript4;
    private SpawnManagerScript spawnManagerScript;
    private EnergyScript energyScript;
    private FollowPlayer cameraScript;
    /*
    private void Awake()
    {
    //    playerInput = GetComponent<PlayerInput>();
        playerActionMap = primaryActions.FindActionMap("Player");
        Respawn1Action = playerActionMap.FindAction("Jump1");
        Respawn1Action.performed += context => RespawnP1();
        Respawn2Action = playerActionMap.FindAction("Jump2");
        Respawn2Action.performed += context => RespawnP2();
        Respawn3Action = playerActionMap.FindAction("Jump3");
        Respawn3Action.performed += context => RespawnP3();
        Respawn4Action = playerActionMap.FindAction("Jump4");
        Respawn4Action.performed += context => RespawnP4();
    }
    private void OnEnable()
    {
        playerActionMap.Enable();
      //  JumpAction.Enable();
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        energyScript = GameObject.Find("EnergyManager").GetComponent<EnergyScript>();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Get Data 2
        //Find players
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player 2");
        player3 = GameObject.Find("Player 3");
        player4 = GameObject.Find("Player 4");
        //Get players scripts
        if (player1 != null)
        {
            playerScript1 = player1.GetComponent<PlayerScript>();
        }
        if (player2 != null)
        {
            playerScript2 = player2.GetComponent<PlayerScript>();
        }
        if (player3 != null)
        {
            playerScript3 = player3.GetComponent<PlayerScript>();
        }
        if (player4 != null)
        {
            playerScript4 = player4.GetComponent<PlayerScript>();
        }
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
        #endregion
    }

    #region Respawn
    public void RespawnP1()
    {
        if ((GameObject.Find("Player") !=null) && spawnManagerScript.gameMode == 3 && !spawnManagerScript.isGameOver)
        {
            player1.SetActive(true);
            if (playerScript1.dead)
            {
                player1.transform.position = new Vector3(-6, 2, 6);
                playerScript1.dead = false;
                spawnManagerScript.isPlayer1Alive = true;
                spawnManagerScript.playersTotal++;
                energyScript.DecreaseEnergy1(50);
                cameraScript.readPlayers = false;
            }
        }
    }
    public void RespawnP2()
    {
        if ((GameObject.Find("Player 2") != null) && spawnManagerScript.gameMode == 3 && !spawnManagerScript.isGameOver)
        {
            player2.SetActive(true);
            if (playerScript2.dead)
            {
                player2.transform.position = new Vector3(6, 2, 6);
                playerScript2.dead = false;
                spawnManagerScript.isPlayer2Alive = true;
                spawnManagerScript.playersTotal++;
                energyScript.DecreaseEnergy2(50);
                cameraScript.readPlayers = false;
            }
        }
    }
    public void RespawnP3()
    {
        if ((GameObject.Find("Player 3") != null) && spawnManagerScript.gameMode == 3 && !spawnManagerScript.isGameOver)
        {
            player3.SetActive(true);
            if (playerScript3.dead)
            {
                player3.transform.position = new Vector3(-6, 2, -6);
                playerScript3.dead = false;
                spawnManagerScript.isPlayer3Alive = true;
                spawnManagerScript.playersTotal++;
                energyScript.DecreaseEnergy3(50);
                cameraScript.readPlayers = false;
            }
        }
    }
    public void RespawnP4()
    {
        if ((GameObject.Find("Player 4") != null) && spawnManagerScript.gameMode == 3 && !spawnManagerScript.isGameOver)
        {
            player4.SetActive(true);
            if (playerScript4.dead)
            {
                player4.transform.position = new Vector3(6, 2, -6);
                playerScript4.dead = false;
                spawnManagerScript.isPlayer4Alive = true;
                spawnManagerScript.playersTotal++;
                energyScript.DecreaseEnergy4(50);
                cameraScript.readPlayers = false;
            }
        }
    }
    #endregion
}
