using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMaster : MonoBehaviour
{
    public int playerNumber;
    Vector2 moveValue;
    MasterScript masterScript;
    OptionsScript optionsScript;
    MapMenuScript mapMenuScript;
    SkinSelectorArcade skinSelectorArcade;
    multiplayerMenuControls skinSelectorMultiplayerBoss;
    SkinSelectorMultyplayer skinSelectorMultyplayer;
    SpawnManagerScript spawnManagerScript;
    DevScript devScript;
    PlayerController playerControllerScript;
    public void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
    }

    private void Update()
    {
       /// Debug.Log("MoveValue is " + moveValue.x + " & " + moveValue.y);
        ///   transform.Translate(moveValue);

        //GET THE RIGHT REFERENCE FOR CONTROLS
        switch (masterScript.sceneNumber)
        {
            case 1:
                optionsScript = GameObject.Find("SelectorT").GetComponent<OptionsScript>();
                break;
            case 2:
                mapMenuScript = GameObject.Find("Selector").GetComponent<MapMenuScript>();
                break;
            case 3:
                skinSelectorArcade = GameObject.Find("Selector").GetComponent<SkinSelectorArcade>();
                break;
            case 63:
                skinSelectorMultiplayerBoss = GameObject.Find("Manager").GetComponent<multiplayerMenuControls>();
                switch (playerNumber)
                {
                    case 1:
                        skinSelectorMultyplayer = GameObject.Find("Selector P1").GetComponent<SkinSelectorMultyplayer>();
                        break;
                    case 2:
                        if (masterScript.multiplayerMode !=42)
                        {
                            skinSelectorMultyplayer = GameObject.Find("Selector P2").GetComponent<SkinSelectorMultyplayer>();
                        }
                        else // for Control Mode
                        {
                            skinSelectorMultyplayer = GameObject.Find("Selector P2x").GetComponent<SkinSelectorMultyplayer>();
                        }
                        break;
                    case 3:
                        if (masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14 ||
                            masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24 ||
                            masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34)
                        {
                            skinSelectorMultyplayer = GameObject.Find("Selector P3").GetComponent<SkinSelectorMultyplayer>();
                        }
                        break;
                    case 4:
                        if (masterScript.multiplayerMode == 14 || masterScript.multiplayerMode == 24 || masterScript.multiplayerMode == 34)
                        {
                            skinSelectorMultyplayer = GameObject.Find("Selector P4").GetComponent<SkinSelectorMultyplayer>();
                        }
                        break;
                }
                break;

            case 67:
                devScript = GameObject.Find("SpawnManager").GetComponent<DevScript>();
                break;
        }
        if ((masterScript.sceneNumber >=4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72))
        {
            spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
            if (!spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
            {
                switch (playerNumber)
                {
                    case 1:
                        if (spawnManagerScript.isPlayer1Alive)
                        {
                            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
                        }
                        break;
                    case 2:
                        if (spawnManagerScript.isPlayer2Alive)
                        {
                            playerControllerScript = GameObject.Find("Player 2").GetComponent<PlayerController>();
                        }
                        break;
                    case 3:
                        if (spawnManagerScript.isPlayer3Alive)
                        {
                            playerControllerScript = GameObject.Find("Player 3").GetComponent<PlayerController>();
                        }
                        break;
                    case 4:
                        if (spawnManagerScript.isPlayer4Alive)
                        {
                            playerControllerScript = GameObject.Find("Player 4").GetComponent<PlayerController>();
                        }
                        break;
                }
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
            && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
        {
            playerControllerScript.movementInput = context.ReadValue<Vector2>();
        }
        //    Debug.Log("Move");
        //in UPDATE   GameObject.Find("Player").transform.Translate(moveValue);

        /*  private void OnMove1(InputValue movementValue)
            {
              if (playerNumber == 1)
              {
              Vector2 movementVector = movementValue.Get<Vector2>();
              movementX = movementVector.x;
              movementY = movementVector.y;
              }
            }  */
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
         //   Debug.Log("Jump");
            switch (masterScript.sceneNumber)
            {
                case 63:
                    switch (playerNumber)
                    {
                        case 1:
                            if (!skinSelectorMultyplayer.selection)
                            {
                                skinSelectorMultiplayerBoss.isP1Ready = true;
                                skinSelectorMultiplayerBoss.confirmTextRef1.gameObject.SetActive(true);
                                skinSelectorMultyplayer.LockMove();
                            }
                            break;
                        case 2:
                            if (!skinSelectorMultyplayer.selection)
                            {
                                skinSelectorMultiplayerBoss.isP2Ready = true;
                                if (masterScript.multiplayerMode != 42)
                                {
                                    skinSelectorMultiplayerBoss.confirmTextRef2.gameObject.SetActive(true);
                                    skinSelectorMultyplayer.LockMove();
                                }
                                else
                                {
                                    skinSelectorMultiplayerBoss.confirmTextRef2X.gameObject.SetActive(true);
                                    skinSelectorMultyplayer.LockMove();
                                }
                            }
                            break;
                        case 3:
                            if (!skinSelectorMultyplayer.selection)
                            {
                                skinSelectorMultiplayerBoss.isP3Ready = true;
                                skinSelectorMultiplayerBoss.confirmTextRef3.gameObject.SetActive(true);
                                skinSelectorMultyplayer.LockMove();
                            }
                            break;
                        case 4:
                            if (!skinSelectorMultyplayer.selection)
                            {
                                skinSelectorMultiplayerBoss.isP4Ready = true;
                                skinSelectorMultiplayerBoss.confirmTextRef4.gameObject.SetActive(true);
                                skinSelectorMultyplayer.LockMove();
                            }
                            break;
                    }
                    break;
                case 67:
                    switch (playerNumber)
                    {
                        case 1:
                            devScript.RespawnP1();
                            break;
                        case 2:
                            devScript.RespawnP2();
                            break;
                        case 3:
                            devScript.RespawnP3();
                            break;
                        case 4:
                            devScript.RespawnP4();
                            break;
                    }
                    break;
                case 66:
                    playerControllerScript.ActivateSphere();
                    break;
            }
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver && masterScript.sceneNumber != 66)
            {
                playerControllerScript.PlayerJump();
            }
        }
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
         //   Debug.Log("Dash");
            switch (masterScript.sceneNumber)
            {
                case 63:
                    switch (playerNumber)
                    {
                        case 1:
                            skinSelectorMultiplayerBoss.isP1Ready = false;
                            skinSelectorMultiplayerBoss.confirmTextRef1.gameObject.SetActive(false);
                            break;
                        case 2:
                            skinSelectorMultiplayerBoss.isP2Ready = false;
                            if (masterScript.multiplayerMode != 42)
                            {
                                skinSelectorMultiplayerBoss.confirmTextRef2.gameObject.SetActive(false);
                            }
                            else
                            {
                                skinSelectorMultiplayerBoss.confirmTextRef2X.gameObject.SetActive(false);
                            }
                            break;
                        case 3:
                            skinSelectorMultiplayerBoss.isP3Ready = false;
                            skinSelectorMultiplayerBoss.confirmTextRef3.gameObject.SetActive(false);
                            break;
                        case 4:
                            skinSelectorMultiplayerBoss.isP4Ready = false;
                            skinSelectorMultiplayerBoss.confirmTextRef4.gameObject.SetActive(false);
                            break;
                    }
                    skinSelectorMultyplayer.UnlockMove();
                    break;
            }
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
            {
                playerControllerScript.Dash1();
            }
        }
        else if (context.canceled)
        {
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
            {
                playerControllerScript.Dash0();
            }
        }
    }
    public void Teleport(InputAction.CallbackContext context)
    {
        if (context.started)
        {
         //   Debug.Log("Teleport");
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
            {
                playerControllerScript.PlayerTeleport();
            }
        }
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
         //   Debug.Log("Pause");
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72))
            {
                if (!spawnManagerScript.isGameOver)
                {
                    spawnManagerScript.PauseFunction();
                }
                else if (spawnManagerScript.isGameOver)
                {
                    if (spawnManagerScript.gameMode!=0)
                    {
                        spawnManagerScript.RestartFunction();
                    }
                    else
                    {
                        if (masterScript.sceneNumber == 62)//Get to credits when beating final boss
                        {
                            spawnManagerScript.PauseFunction();
                        }
                        else
                        {
                            if (!spawnManagerScript.finishedLevel)
                            {
                                spawnManagerScript.RestartLevel();
                            }
                            else
                            {
                                spawnManagerScript.RestartFunction();
                            }
                        }
                    }
                }
            }
            if (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
            {
            //    Debug.Log("D");
                if (spawnManagerScript.isGameOver)
                {
            //        Debug.Log("E");
           //         spawnManagerScript.RestartFunction();
                }
            }
            switch (masterScript.sceneNumber)
            {
                case 63:
                    switch (masterScript.multiplayerMode)
                    {
                        case 12:
                        case 22:
                        case 32:
                        case 42:
                        case 50:
                            if (skinSelectorMultiplayerBoss.isP1Ready && skinSelectorMultiplayerBoss.isP2Ready)
                            {
                                skinSelectorMultiplayerBoss.AdvanceMode();
                            }
                            break;
                        case 13:
                        case 23:
                        case 33:
                            if (skinSelectorMultiplayerBoss.isP1Ready && skinSelectorMultiplayerBoss.isP2Ready && skinSelectorMultiplayerBoss.isP3Ready)
                            {
                                skinSelectorMultiplayerBoss.AdvanceMode();
                            }
                            break;
                        case 14:
                        case 24:
                        case 34:
                            if (skinSelectorMultiplayerBoss.isP1Ready && skinSelectorMultiplayerBoss.isP2Ready &&
                                skinSelectorMultiplayerBoss.isP3Ready && skinSelectorMultiplayerBoss.isP4Ready)
                            {
                                skinSelectorMultiplayerBoss.AdvanceMode();
                            }
                            break;
                    }
                    break;
            }
        }
    }
    public void Restart(InputAction.CallbackContext context)
    {
        if (context.started)
        {
       //     Debug.Log("Restart");
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && (spawnManagerScript.isGamePaused || spawnManagerScript.isGameOver))
            {
                spawnManagerScript.RestartFunction();
            }
        }
    }
    public void Return(InputAction.CallbackContext context)
    {
        if (context.started)
        {
         //   Debug.Log("Return");
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && (spawnManagerScript.isGamePaused || spawnManagerScript.isGameOver))
            {
                spawnManagerScript.ReturnToTitleScreen();
            }
        }
    }
    public void ShowData(InputAction.CallbackContext context)
    {
        if (context.started)
        {
       //     Debug.Log("ShowData");
            switch (masterScript.sceneNumber)
            {
                case 2:
                    mapMenuScript.ChangeSkin();
                    break;
                case 3:
                    skinSelectorArcade.ChangePage();
                    break;
            }
            if ((masterScript.sceneNumber >= 4 && masterScript.sceneNumber <= 62) || (masterScript.sceneNumber >= 64 && masterScript.sceneNumber <= 72)
                && !spawnManagerScript.isGamePaused && !spawnManagerScript.isGameOver)
            {
                spawnManagerScript.ShowInfoText();
            }
        }
    }
    public void Decision(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        //    Debug.Log("Decision");
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.AdvanceMode();
                    break;
                case 2:
                    mapMenuScript.StartLevel();
                    break;
                case 3:
                    skinSelectorArcade.ReturnToMap();
                    break;
            }
        }
    }
    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
       //     Debug.Log("Cancel");
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.ReturnMode();
                    break;
                case 2:
                    mapMenuScript.ReturnToTitleScreen();
                    break;
                case 3:
                    skinSelectorArcade.ReturnToTitleScreen();
                    break;
                case 63:
                    skinSelectorMultiplayerBoss.ReturnToTitleScreen();
                    break;
            }
        }
    }
    public void GoUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
     //       Debug.Log("GoUp");
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.GoUp();
                    break;
                case 2:
                    mapMenuScript.GoUp();
                    break;
                case 3:
                    skinSelectorArcade.GoUp();
                    break;
            }
        }
    }
    public void GoDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
       //     Debug.Log("GoDown");
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.GoDown();
                    break;
                case 2:
                    mapMenuScript.GoDown();
                    break;
                case 3:
                    skinSelectorArcade.GoDown();
                    break;
            }
        }
    }
    public void GoLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.GoLeft();
                    break;
                case 2:
                    mapMenuScript.GoLeft();
                    break;
                case 3:
                    skinSelectorArcade.GoLeft();
                    break;
                case 63:
                    skinSelectorMultyplayer.ToLeft();
                    break;
            }
        }
        else if (context.canceled)
        {
            switch (masterScript.sceneNumber)
            {
                case 63:
                    skinSelectorMultyplayer.StopMove();
                    break;
            }
        }
    }
    public void GoRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switch (masterScript.sceneNumber)
            {
                case 1:
                    optionsScript.GoRight();
                    break;
                case 2:
                    mapMenuScript.GoRight();
                    break;
                case 3:
                    skinSelectorArcade.GoRight();
                    break;
                case 63:
                    skinSelectorMultyplayer.ToRight();
                    break;
            }
        }
        else if (context.canceled)
        {
            switch (masterScript.sceneNumber)
            {
                case 63:
                    skinSelectorMultyplayer.StopMove();
                    break;
            }
        }
    }
}
