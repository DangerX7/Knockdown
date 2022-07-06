using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Initial Values Set
    public GameObject dust, trail, bossPart;
    /*
    public InputActionAsset primaryActions;  // Input Base
    InputActionMap playerActionMap;          // Input Action Map
    InputAction Jump1Action;   // Input Action
    InputAction Jump2Action;   // Input Action
    InputAction Jump3Action;   // Input Action
    InputAction Jump4Action;   // Input Action
    InputAction Dash1Action;   // Input Action
    InputAction Dash2Action;   // Input Action
    InputAction Dash3Action;   // Input Action
    InputAction Dash4Action;   // Input Action
    InputAction Move1Action;   // Input Action
    InputAction MoveUp1Action;   // Input Action
    InputAction MoveDown1Action;   // Input Action
    InputAction MoveLeft1Action;   // Input Action
    InputAction MoveRight1Action;   // Input Action
    InputAction MoveUp2Action;   // Input Action
    InputAction MoveDown2Action;   // Input Action
    InputAction MoveLeft2Action;   // Input Action
    InputAction MoveRight2Action;   // Input Action
    InputAction Teleport1Action;   // Input Action
    */
    private GameObject dizzyParent;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private ArcadeScript arcadeScript;
    private SpawnManagerScript spawnManagerScript;
    private TutorialScript tutorialScript;
    private PlayerBossScript playerBossScript;
    private SoundsScript soundScript;
    private EnergyScript energyScript;
    private JumpTriggerScript blastSphereScript;
  //  Vector2 move;
    Vector3 newRotation;
    public Rigidbody rb;
    private PlayerScript playerScript;
    private ParentScript parentScript;
    private DizzyParent dizzyScript;
    public int playerNumber;
  //  public float movementX; //player x axis, use in both onMove and FixedUpdate functions
  //  public float movementY; //player y axis, use in both onMove and FixedUpdate functions
    public float speed = 10;
    public bool inputLock;
    public bool drunk;
    public bool isJumpingAvailable;
    public bool isJumping;

    public float originalStrength;
    public byte dashState;
    public bool readStrength = false;
    float increaseLimit = 0;
    public byte dashDirrection = 0;
    Vector3 dash = Vector3.zero;
    bool didRushSoundPlayed;
    public byte chargeSoundState;
    public bool notOnGround;
    float baseStrength;
    public bool bossSwitch;
    bool jumpSpeedSwitch;

    //tutorial values
    bool leftCheck;
    bool rightCheck;
    bool upCheck;
    bool downCheck;

    string strJ1;
    string strJ2;
    string strJ3;
    string resultJ1;
    string resultJ2;
    public string jumpInput;
    string strD1;
    string strD2;
    string strD3;
    string resultD1;
    string resultD2;
    public string dashInput;
    string strM1;
    string strM2;
    string strM3;
    string strM4;
    string resultM1;
    string resultM2;
    string resultM3;
    public string moveInput;

    private Vector3 BackupBallScale;
    public bool canTeleport;
    public bool teleportCheck;
    public int shrinkStatus;
    public float power;
    public bool haveBlastSphere;

    PlayerControls controls;

    public Vector2 movementInput;
    bool switchCheck;
    #endregion


    private void Awake()
    {
        #region Skills Set for Multyplayer
        //CHOSE PLAYER
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        playerScript = GetComponent<PlayerScript>();
        if (masterScript.multiplayerMode > 10 && masterScript.multiplayerMode != 32 && masterScript.multiplayerMode != 33
        && masterScript.multiplayerMode != 34)
        {
            playerScript.strength = 100;
            playerScript.energy = 150;
            speed = 15000;
        }
        if (masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34)
        {
            playerScript.strength = 500;
            playerScript.energy = 0;
            speed = 20000;
        }
            masterScript.playerCount++;
        if ((masterScript.multiplayerMode == 12 || masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14 ||
            masterScript.multiplayerMode == 22 || masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24 ||
            masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34
            || masterScript.multiplayerMode == 50) && masterScript.playerCount == 2)
        {
            this.gameObject.name = "Player 2";
            playerNumber = 2;
            playerScript.playerNumber = 2;
        }
        if ((masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14 || masterScript.multiplayerMode == 23 ||
            masterScript.multiplayerMode == 24 || masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34)
            && masterScript.playerCount == 3)
        {
            this.gameObject.name = "Player 3";
            playerNumber = 3;
            playerScript.playerNumber = 3;
        }
        if ((masterScript.multiplayerMode == 14 || masterScript.multiplayerMode == 24 || masterScript.multiplayerMode == 34)
            && masterScript.playerCount == 4)
        {
            this.gameObject.name = "Player 4";
            playerNumber = 4;
            playerScript.playerNumber = 4;
        }
        if (masterScript.multiplayerMode == 42)
        {
            if (this.gameObject.name == "PlayerX")
            {
                this.gameObject.name = "Player 2";
                playerNumber = 2;
                playerScript.playerNumber = 2;
                bossSwitch = true;
                playerBossScript = bossPart.GetComponent<PlayerBossScript>();
            }
        }
        //   AssignPlayers();
            #endregion

            ////   controls = new PlayerControls();
            /*
            if (playerNumber == 1)
            {
                Debug.Log("Load 1");
                controls.Player.Jump1.performed += ctx => PlayerJump();
            }
            else if (playerNumber == 2)
            {
                Debug.Log("Load 2");
                controls.Player.Jump2.performed += ctx => PlayerJump();
            }
            controls.Player.Move1.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Player.Move1.performed += ctx => move = Vector2.zero;
            // Read Controls
            //   playerInput = GetComponent<PlayerInput>();
            playerActionMap = primaryActions.FindActionMap("Player");
            switch (playerNumber)
            {
                case 1:
                 //   Move1Action = playerActionMap.FindAction("Move1");
                 //   Move1Action.performed += context => move = context.ReadValue<Vector2>();
                 //   Move1Action.canceled += context => move = Vector2.zero;

                    //    MoveUp1Action = playerActionMap.FindAction("MoveUp1");
                    //    MoveUp1Action.performed += context => MoveUpF();
                    //   MoveUp1Action.canceled += context => StopMovingY();
                    //    MoveDown1Action = playerActionMap.FindAction("MoveDown1");
                    //    MoveDown1Action.performed += context => MoveDownF();
                    //    MoveDown1Action.canceled += context => StopMovingY();
                    //    MoveLeft1Action = playerActionMap.FindAction("MoveLeft1");
                    //    MoveLeft1Action.performed += context => MoveLeftF();
                    //    MoveLeft1Action.canceled += context => StopMovingX();
                    //    MoveRight1Action = playerActionMap.FindAction("MoveRight1");
                    //   MoveRight1Action.performed += context => MoveRightF();
                    //   MoveRight1Action.canceled += context => StopMovingX();

                    Jump1Action = playerActionMap.FindAction("Jump1");
                    Jump1Action.performed += context => PlayerJump();
                    Dash1Action = playerActionMap.FindAction("Dash1");
                    Dash1Action.performed += context => Dash1();
                    Dash1Action.canceled += context => Dash0();
                    //////     Move1Action = playerActionMap.FindAction("Move1");
                    Teleport1Action = playerActionMap.FindAction("Teleport1");
                    Teleport1Action.performed += context => PlayerTeleport();
                    Debug.Log("Player 1 Controls");
                    break;
                case 2:
                    /*
                    MoveUp2Action = playerActionMap.FindAction("MoveUp2");
                    MoveUp2Action.performed += context => MoveUpF();
              //      MoveUp2Action.canceled += context => StopMovingY();
                    MoveDown2Action = playerActionMap.FindAction("MoveDown2");
                    MoveDown2Action.performed += context => MoveDownF();
                 //   MoveDown2Action.canceled += context => StopMovingY();
                    MoveLeft2Action = playerActionMap.FindAction("MoveLeft2");
                    MoveLeft2Action.performed += context => MoveLeftF();
                 //   MoveLeft2Action.canceled += context => StopMovingX();
                    MoveRight2Action = playerActionMap.FindAction("MoveRight2");
                    MoveRight2Action.performed += context => MoveRightF();
                //    MoveRight2Action.canceled += context => StopMovingX();

                    Jump2Action = playerActionMap.FindAction("Jump2");
                    Jump2Action.performed += context => PlayerJump();
                    Dash2Action = playerActionMap.FindAction("Dash2");
                    Dash2Action.performed += context => Dash1();
                    Dash2Action.canceled += context => Dash0();
                    Debug.Log("Player 2 Controls");
                    break;
                case 3:
                    Jump3Action = playerActionMap.FindAction("Jump3");
                    Jump3Action.performed += context => PlayerJump();
                    Dash3Action = playerActionMap.FindAction("Dash3");
                    Dash3Action.performed += context => Dash1();
                    Dash3Action.canceled += context => Dash0();
                    break;
                case 4:
                    Jump4Action = playerActionMap.FindAction("Jump4");
                    Jump4Action.performed += context => PlayerJump();
                    Dash4Action = playerActionMap.FindAction("Dash4");
                    Dash4Action.performed += context => Dash1();
                    Dash4Action.canceled += context => Dash0();
                    break;
            }

            */
    }
    private void OnEnable()
    {
        //////////   controls.Player.Enable();
      ////////////////////  playerActionMap.Enable();
        //   JumpAction.Enable();
    }
    private void OnDisable()
    {
        ///////////  controls.Player.Disable();
        //  playerActionMap.Disable();
        //   JumpAction.Disable();
    }

    public void MoveUpF()
    {
        movementInput.y = 1;
    }
    public void MoveDownF()
    {
        movementInput.y = -1;
    }
    public void MoveRightF()
    {
        movementInput.x = 1;
    }
    public void MoveLeftF()
    {
        movementInput.x = -1;
    }
    public void StopMovingX()
    {
        movementInput.x = 0;
    }
    public void StopMovingY()
    {
        movementInput.y = 0;
    }
    #region Move Input
    //Move1 from OnMove1 function is the name of the action map of the inputs
    /*  private void OnMove1(InputValue movementValue)
      {
          if (playerNumber == 1)
          {
              Vector2 movementVector = movementValue.Get<Vector2>();
              movementX = movementVector.x;
              movementY = movementVector.y;
          }
      }
      private void OnMove2(InputValue movementValue)
      {
          if (playerNumber == 2)
          {
              Vector2 movementVector = movementValue.Get<Vector2>();
              movementX = movementVector.x;
              movementY = movementVector.y;
          }
      }
      private void OnMove3(InputValue movementValue)
      {
          if (playerNumber == 3)
          {
              Vector2 movementVector = movementValue.Get<Vector2>();
              movementX = movementVector.x;
              movementY = movementVector.y;
          }
      }
      private void OnMove4(InputValue movementValue)
      {
          if (playerNumber == 4)
          {
              Vector2 movementVector = movementValue.Get<Vector2>();
              movementX = movementVector.x;
              movementY = movementVector.y;
          }
      }*/
    #endregion

    #region Variables Set (Start)
    void Start()
    {
        BackupBallScale = transform.localScale;
        isJumpingAvailable = true;////////////////////////////////////////false
        rb = GetComponent<Rigidbody>();
        parentScript = transform.parent.gameObject.GetComponent<ParentScript>();
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        tutorialScript = GameObject.Find("SpawnManager").GetComponent<TutorialScript>();
        energyScript = GameObject.Find("EnergyManager").GetComponent<EnergyScript>();
        dizzyParent = transform.GetChild(0).gameObject;
        dizzyScript = dizzyParent.GetComponent<DizzyParent>();
        baseStrength = playerScript.strength;

        /*
        //Find tutorial inputs
    //    strJ1 = "Jump" + Jump1Action;
        strJ2 = "Player/Jump1[/Keyboard/";
        resultJ1 = strJ1.Replace(strJ2, "");
        strJ3 = "]";
        resultJ2 = resultJ1.Replace(strJ3, "");
        jumpInput = resultJ2.ToUpper();

     //   strD1 = "" + Dash1Action;
        strD2 = "Player/Dash1[/Keyboard/";
        resultD1 = strD1.Replace(strD2, "");
        strD3 = "]";
        resultD2 = resultD1.Replace(strD3, "");
        dashInput = resultD2.ToUpper();

     //   strM1 = "" + Move1Action;
        strM2 = "Player/Move1[/Keyboard/";
        resultM1 = strM1.Replace(strM2, "");
        strM3 = "/Keyboard/";
        resultM2 = resultM1.Replace(strM3, "");
        strM4 = "]";
        resultM3 = resultM2.Replace(strM4, "");
        moveInput = resultM3.ToUpper();
        */

        if (spawnManagerScript.gameMode != 0)
        {
            canTeleport = false;
        }
        power = 1;
     //   haveBlastSphere = true;
    }
    #endregion


    // Update is called once per frame
    void FixedUpdate()
    {
        switch (movementInput.x)
        {
            case < 0:
            //    movementInput.x = -1;
                break;
            case > 0:
             //   movementInput.x = 1;
                break;
        }
        switch (movementInput.y)
        {
            case < 0:
             //   movementInput.y = -1;
                break;
            case > 0:
             //   movementInput.y = 1;
                break;
        }

        //  movementInput.x = movementX;
        //   movementInput.y = movementY;

        // transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);

        /////// transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);


        if (playerNumber == 1)
        {
       //     Debug.Log("Player move values are " + movementX + " " + movementY);
        }

     //   movementX = move.x;
     //   movementY = move.y;
        //MOVE NEW
         //   move = new Vector2(-move.x, move.y) * Time.deltaTime;
         //  transform.Translate(move, Space.World);

        //Colosseum increase ball size
        if (spawnManagerScript.gameMode == 7)
        {
            GameObject Father = transform.parent.gameObject;
            Father.transform.localScale += new Vector3(0.001f * power, 0.001f * power, 0.001f * power);
            playerScript.strength += power * 1.5f * Time.deltaTime;
        }

        if (shrinkStatus == -1)
        {
            transform.localScale -= new Vector3(0.12f, 0.12f, 0.12f);
        }
        else if (shrinkStatus == 1)
        {
            transform.localScale += new Vector3(0.12f, 0.12f, 0.12f);
        }
        //Remove Dust
        if (dashState != 2)
        {
            dust.SetActive(false);
        }
        //Tutorial code
        if (tutorialScript.tutorialState == 1)
        {
            if (movementInput.x < 0)
            {
                leftCheck = true;
            }
            if (movementInput.x > 0)
            {
                rightCheck = true;
            }
            if (movementInput.y < 0)
            {
                upCheck = true;
            }
            if (movementInput.y > 0)
            {
                downCheck = true;
            }
        }
        if (leftCheck && rightCheck && upCheck && downCheck && tutorialScript.tutorialState == 1)
        {
            tutorialScript.TutorialEnemyPhase1();
            tutorialScript.tutorialState = 2;
        }

        if (tutorialScript.tutorialState == 10)
        {
            StartCoroutine(AdvanceToDashPhase());
        }

        //Reduce speed when jumping
        if (isJumping && !jumpSpeedSwitch)
        {
            speed = speed / 10 * 8;
            jumpSpeedSwitch = true;
        }
        else if (!isJumping && jumpSpeedSwitch)
        {
            speed = speed / 8 * 10;
            jumpSpeedSwitch = false;
        }
        if (playerScript.strength <= 0 && spawnManagerScript.gameMode != 1)
        {
            playerScript.strength = baseStrength;
        }
        if (dashState == 2 && transform.position.y > 2)
        {
            dashState = 1;
        }

        #region Movement Code
        if (!playerScript.inactive && !inputLock)
        {
            if (!drunk)
            {
                switch (playerNumber)
                {
                    case 1:
                        Vector3 movement1;
                        movement1 = new Vector3(movementInput.x, 0.0f, movementInput.y);
                        rb.AddForce(movement1 * speed * Time.deltaTime);
                        break;
                    case 2:
                        Vector3 movement2;
                        movement2 = new Vector3(movementInput.x, 0.0f, movementInput.y);
                        rb.AddForce(movement2 * speed * Time.deltaTime);
                 //       Debug.Log("M " + movementInput);
                        break;
                    case 3:
                        Vector3 movement3;
                        movement3 = new Vector3(movementInput.x, 0.0f, movementInput.y);
                        rb.AddForce(movement3 * speed * Time.deltaTime);
                        break;
                    case 4:
                        Vector3 movement4;
                        movement4 = new Vector3(movementInput.x, 0.0f, movementInput.y);
                        rb.AddForce(movement4 * speed * Time.deltaTime);
                        break;
                }
            }
            else if (drunk)
            {
                switch (playerNumber)
                {
                    case 1:
                        Vector3 movement1;
                        movement1 = new Vector3(-movementInput.x, 0.0f, -movementInput.y);
                        rb.AddForce(movement1 * speed * Time.deltaTime);
                        break;
                    case 2:
                        Vector3 movement2;
                        movement2 = new Vector3(-movementInput.x, 0.0f, -movementInput.y);
                        rb.AddForce(movement2 * speed * Time.deltaTime);
                        break;
                    case 3:
                        Vector3 movement3;
                        movement3 = new Vector3(-movementInput.x, 0.0f, -movementInput.y);
                        rb.AddForce(movement3 * speed * Time.deltaTime);
                        break;
                    case 4:
                        Vector3 movement4;
                        movement4 = new Vector3(-movementInput.x, 0.0f, -movementInput.y);
                        rb.AddForce(movement4 * speed * Time.deltaTime);
                        break;
                }
            }
        }
        #endregion

        #region Dash Code
        //Read dash dirrection
        if (!drunk)
        {
            if (movementInput.x == 0 & movementInput.y > 0)
            {
                dashDirrection = 1;
                newRotation = new Vector3(0, 115, 0);
            }
            else if (movementInput.x > 0 && movementInput.x < 1 && movementInput.y > 0 && movementInput.y < 1)
            {
                dashDirrection = 2;
                newRotation = new Vector3(0, 160, 0);
            }
            else if (movementInput.x > 0 & movementInput.y == 0)
            {
                dashDirrection = 3;
                newRotation = new Vector3(0, -155, 0);
            }
            else if (movementInput.x > 0 && movementInput.x < 1 && movementInput.y > -1 && movementInput.y < 0)
            {
                dashDirrection = 4;
                newRotation = new Vector3(0, -110, 0);
            }
            else if (movementInput.x == 0 & movementInput.y < 0)
            {
                dashDirrection = 5;
                newRotation = new Vector3(0, -65, 0);
            }
            else if (movementInput.x > -1 && movementInput.x < 0 && movementInput.y > -1 && movementInput.y < 0)
            {
                dashDirrection = 6;
                newRotation = new Vector3(0, -20, 0);
            }
            else if (movementInput.x < 0 & movementInput.y == 0)
            {
                dashDirrection = 7;
                newRotation = new Vector3(0, 25, 0);
            }
            else if (movementInput.x > -1 && movementInput.x < 0 && movementInput.y > 0 && movementInput.y < 1)
            {
                dashDirrection = 8;
                newRotation = new Vector3(0, 70, 0);
            }
        }
        else
        {
            if (movementInput.x == 0 & movementInput.y > 0)
            {
                dashDirrection = 5;
                newRotation = new Vector3(0, -65, 0);
            }
            else if (movementInput.x > 0 && movementInput.x < 1 && movementInput.y > 0 && movementInput.y < 1)
            {
                dashDirrection = 6;
                newRotation = new Vector3(0, -20, 0);
            }
            else if (movementInput.x > 0 & movementInput.y == 0)
            {
                dashDirrection = 7;
                newRotation = new Vector3(0, 25, 0);
            }
            else if (movementInput.x > 0 && movementInput.x < 1 && movementInput.y > -1 && movementInput.y < 0)
            {
                dashDirrection = 8;
                newRotation = new Vector3(0, 70, 0);
            }
            else if (movementInput.x == 0 & movementInput.y < 0)
            {
                dashDirrection = 1;
                newRotation = new Vector3(0, 115, 0);
            }
            else if (movementInput.x > -1 && movementInput.x < 0 && movementInput.y > -1 && movementInput.y < 0)
            {
                dashDirrection = 2;
                newRotation = new Vector3(0, 160, 0);
            }
            else if (movementInput.x < 0 & movementInput.y == 0)
            {
                dashDirrection = 3;
                newRotation = new Vector3(0, -155, 0);
            }
            else if (movementInput.x > -1 && movementInput.x < 0 && movementInput.y > 0 && movementInput.y < 1)
            {
                dashDirrection = 4;
                newRotation = new Vector3(0, -110, 0);
            }
        }


        if (dashState == 2)//Charde Mode
        {
            dust.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            dust.transform.eulerAngles = newRotation;
            if (chargeSoundState == 0 || chargeSoundState == 1)
            {
                StartCoroutine(ChargeOSoundCoroutine());
            }
            if (chargeSoundState == 2)
            {
                StartCoroutine(ChargeLSoundCoroutine());
            }
            if (!readStrength)
            {
                originalStrength = playerScript.strength;
                increaseLimit = playerScript.strength * 10;
                inputLock = true;
                readStrength = true;
            }
            if (playerScript.strength < increaseLimit)
            {
                playerScript.strength += 5;
                ArcadeScript arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
                if (!tutorialScript.tutorialLevel && !canTeleport)
                {
                    if (arcadeScript.enemiesToBeat == 28 && jsonScript.so.levelNumber == "L5-10")
                    {
                        switch (playerNumber)
                        {
                            case 1:
                                energyScript.DecreaseEnergy1(0.25f);//cut energy consumption in half for final battle and gauntlet mode
                                break;
                            case 2:
                                energyScript.DecreaseEnergy2(0.25f);//cut energy consumption in half for final battle and gauntlet mode
                                break;
                            case 3:
                                energyScript.DecreaseEnergy3(0.25f);//cut energy consumption in half for final battle and gauntlet mode
                                break;
                            case 4:
                                energyScript.DecreaseEnergy4(0.25f);//cut energy consumption in half for final battle and gauntlet mode
                                break;
                        }
                    }
                    else
                    {
                            switch (playerNumber)
                            {
                                case 1:
                                    energyScript.DecreaseEnergy1(0.5f);
                                    break;
                                case 2:
                                    energyScript.DecreaseEnergy2(0.5f);
                                    break;
                                case 3:
                                    energyScript.DecreaseEnergy3(0.5f);
                                    break;
                                case 4:
                                    energyScript.DecreaseEnergy4(0.5f);
                                    break;
                            }
                    }
                }
            }
            transform.Rotate(dash, 300 * Time.deltaTime, Space.World);
            switch (dashDirrection)
            {
                case 1:
                    dash = new Vector3(1, 0, 0);
                    break;
                case 2:
                    dash = new Vector3(1, 0, -1);
                    break;
                case 3:
                    dash = new Vector3(0, 0, -1);
                    break;
                case 4:
                    dash = new Vector3(-1, 0, -1);
                    break;
                case 5:
                    dash = new Vector3(-1, 0, 0);
                    break;
                case 6:
                    dash = new Vector3(-1, 0, 1);
                    break;
                case 7:
                    dash = new Vector3(0, 0, 1);
                    break;
                case 8:
                    dash = new Vector3(1, 0, 1);
                    break;
            }
        }

        if (dashState == 1)//Dash Mode
        {
            trail.gameObject.SetActive(true);
            chargeSoundState = 0;
            switch (dashDirrection)
            {
                case 1:
                    dash = new Vector3(0, 0, 1);
                    break;
                case 2:
                    dash = new Vector3(1, 0, 1);
                    break;
                case 3:
                    dash = new Vector3(1, 0, 0);
                    break;
                case 4:
                    dash = new Vector3(1, 0, -1);
                    break;
                case 5:
                    dash = new Vector3(0, 0, -1);
                    break;
                case 6:
                    dash = new Vector3(-1, 0, -1);
                    break;
                case 7:
                    dash = new Vector3(-1, 0, 0);
                    break;
                case 8:
                    dash = new Vector3(-1, 0, 1);
                    break;
            }
            //    GameObject EnemyT = GameObject.Find("Enemy");
            //   Vector3 awayFromPlayer = EnemyT.gameObject.transform.position - transform.position;
            //  rb.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            rb.AddForce(dash * 20, ForceMode.Impulse);

            StartCoroutine(DashEndCoroutine());
        }

        IEnumerator ChargeOSoundCoroutine()//Play First Charge Sound
        {
            if (chargeSoundState == 0)
            {
                //    soundScript.PlaySound("ChargeO");
                soundScript.PlayChargeOpening();
                chargeSoundState = 1;
            }
            yield return new WaitForSeconds(soundScript.chargeOpLength);
            if (chargeSoundState == 1)
            {
                chargeSoundState = 2;
            }
        }
        IEnumerator ChargeLSoundCoroutine()//Play Loop Charge Sound
        {
            if (chargeSoundState == 2)
            {
                //   soundScript.PlaySound("ChargeL");
                soundScript.PlayChargeLoop();
                chargeSoundState = 3;
            }
            yield return new WaitForSeconds(soundScript.chargeOpLength);
            if (chargeSoundState == 3)
            {
                chargeSoundState = 2;
            }
        }
        IEnumerator DashEndCoroutine()//End Dash and Play Dash Sound
        {
            if (!didRushSoundPlayed)
            {
                //    soundScript.PlaySound("Dash");
                soundScript.PlayDash();
                didRushSoundPlayed = true;
            }
            yield return new WaitForSeconds(0.5f);
            playerScript.strength = originalStrength;
            inputLock = false;
            readStrength = false;

            //  rb.velocity = Vector3.zero;
            didRushSoundPlayed = false;
            trail.gameObject.SetActive(false);
            dashState = 0;
        }
        #endregion

        if (dashState == 2)
        {
            rb.velocity = Vector3.zero;
            inputLock = true;
        }

        if ((playerNumber == 1 && energyScript.dizzy1) || (playerNumber == 2 && energyScript.dizzy2) || (playerNumber == 3 && energyScript.dizzy3) ||
            (playerNumber == 4 && energyScript.dizzy4))
        {
            inputLock = true;
        }
        else if (dashState != 2 && ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 && !energyScript.dizzy2) ||
            (playerNumber == 3 && !energyScript.dizzy3) || (playerNumber == 4 && !energyScript.dizzy4)))
        {
            inputLock = false;
        }
        else if (dashState != 2)
        {
            inputLock = false;
        }
    }

   // public void OnrMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    #region Jump Code
    public void PlayerJump()
    {
        Debug.Log("JUMP");
        if (bossSwitch)
        {
            //    Debug.Log("sdfgsdg");
            playerBossScript.SpawnEnemy();
        }
        if (spawnManagerScript.gameMode == 7)
        {
            //Push Opponent
        }
        if (!inputLock && !playerScript.inactive && !isJumping && isJumpingAvailable && dashState == 0 && !playerScript.dead &&
            masterScript.multiplayerMode != 32 && masterScript.multiplayerMode != 33 && masterScript.multiplayerMode != 34 &&
            masterScript.multiplayerMode != 50 && ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 &&
            !energyScript.dizzy2 && playerScript.bossLevel != 1) || (playerNumber == 3 && !energyScript.dizzy3) ||
            (playerNumber == 4 && !energyScript.dizzy4)) && !bossSwitch)
        {
            if (((playerNumber == 1 && energyScript.currentEnergy1 < energyScript.maxEnergy1 / 100 * 20) ||
                (playerNumber == 2 && energyScript.currentEnergy2 < energyScript.maxEnergy2 / 100 * 20) ||
                (playerNumber == 3 && energyScript.currentEnergy3 < energyScript.maxEnergy3 / 100 * 20) ||
                (playerNumber == 4 && energyScript.currentEnergy4 < energyScript.maxEnergy4 / 100 * 20)) && !canTeleport)
            {
                GetDizzy();
            }
            else
            {
                ArcadeScript arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
                if (!tutorialScript.tutorialLevel && !canTeleport)
                {
                    if (arcadeScript.enemiesToBeat == 28 && jsonScript.so.levelNumber == "L5-10")
                    {
                            switch (playerNumber)
                            {
                                case 1:
                                    energyScript.DecreaseEnergy1(10);//cut energy consumption in half for final battle
                                    break;
                                case 2:
                                    energyScript.DecreaseEnergy2(10);//cut energy consumption in half for final battle
                                    break;
                                case 3:
                                    energyScript.DecreaseEnergy3(10);//cut energy consumption in half for final battle
                                    break;
                                case 4:
                                    energyScript.DecreaseEnergy4(10);//cut energy consumption in half for final battle
                                    break;
                            }
                    }
                    else
                    {
                            switch (playerNumber)
                            {
                                case 1:
                                    energyScript.DecreaseEnergy1(20);
                                    break;
                                case 2:
                                    energyScript.DecreaseEnergy2(20);
                                    break;
                                case 3:
                                    energyScript.DecreaseEnergy3(20);
                                    break;
                                case 4:
                                    energyScript.DecreaseEnergy4(20);
                                    break;
                            }
                    }
                }
                float jumpHeight = 300;

                soundScript.PlaySound("Jump");
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isJumping = true;
                if (tutorialScript.tutorialState == 7 || tutorialScript.tutorialState == 8 || tutorialScript.tutorialState == 9)
                {
                    tutorialScript.tutorialState++;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obj"))
        {
            isJumping = false;
            notOnGround = false;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            notOnGround = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            notOnGround = true;
            isJumping = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            notOnGround = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            notOnGround = true;
            isJumping = true;
        }
    }
    #endregion

    #region Dash Enter & Exit Initiate
    public void Dash1()
    {
        if (dashState == 0 && !playerScript.inactive && dashDirrection != 0 && !isJumping && !notOnGround && !playerScript.dead
            && masterScript.multiplayerMode != 32 && masterScript.multiplayerMode != 33 && masterScript.multiplayerMode != 34 &&
            masterScript.multiplayerMode != 50 && spawnManagerScript.gameMode !=2
            && ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 && !energyScript.dizzy2 && playerScript.bossLevel != 1)
            || (playerNumber == 3 && !energyScript.dizzy3) || (playerNumber == 4 && !energyScript.dizzy4)))
        {
            if ((playerNumber == 1 && energyScript.currentEnergy1 < energyScript.maxEnergy1 / 100 * 20) ||
                (playerNumber == 2 && energyScript.currentEnergy2 < energyScript.maxEnergy2 / 100 * 20) ||
                (playerNumber == 3 && energyScript.currentEnergy3 < energyScript.maxEnergy3 / 100 * 20) ||
                (playerNumber == 4 && energyScript.currentEnergy4 < energyScript.maxEnergy4 / 100 * 20))
            {
                GetDizzy();
            }
            else
            {
                //   energyScript.DecreaseEnergy(30);
                if ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 && !energyScript.dizzy2) ||
                   (playerNumber == 3 && !energyScript.dizzy3) || (playerNumber == 4 && !energyScript.dizzy4))
                {
                    dust.SetActive(true);
                    dashState = 2;
                }
            }
        }
        //Activate the Blast Sphere
        if (spawnManagerScript.gameMode == 7 && haveBlastSphere)
        {
            transform.GetChild(2).transform.position = transform.position;
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public void Dash0()
    {
        if (dashState == 2 && dashDirrection != 0 && masterScript.multiplayerMode != 32 && masterScript.multiplayerMode != 33
            && masterScript.multiplayerMode != 34 && masterScript.multiplayerMode != 50 && spawnManagerScript.gameMode != 2)
        {
            dashState = 1;
        }
    }
    #endregion

    /*
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed *
        Time.deltaTime;
        transform.Translate(movement, Space.World);
    }*/

    public void GetDizzy()
    {
        switch (playerNumber)
        {
            case 1:
                energyScript.dizzy1 = true;
                break;
            case 2:
                energyScript.dizzy2 = true;
                break;
            case 3:
                energyScript.dizzy3 = true;
                break;
            case 4:
                energyScript.dizzy4 = true;
                break;
        }
        parentScript.dizzySwitch = 1;
        dizzyScript.MakeBallsAppear();
    }

    IEnumerator AdvanceToDashPhase()
    {
        yield return new WaitForSeconds(1);
        tutorialScript.TutorialEnemyPhase5();
    }

    #region Teleport Code
    public void PlayerTeleport()
    {
        if (((canTeleport && spawnManagerScript.gameMode == 0) || (spawnManagerScript.gameMode == 4))
            && !teleportCheck && (movementInput.x != 0 || movementInput.y != 0)
            && ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 && !energyScript.dizzy2 && playerScript.bossLevel != 1)
            || (playerNumber == 3 && !energyScript.dizzy3) || (playerNumber == 4 && !energyScript.dizzy4)))
        {

            if ((playerNumber == 1 && energyScript.currentEnergy1 < energyScript.maxEnergy1 / 100 * 20) ||
                (playerNumber == 2 && energyScript.currentEnergy2 < energyScript.maxEnergy2 / 100 * 20) ||
                (playerNumber == 3 && energyScript.currentEnergy3 < energyScript.maxEnergy3 / 100 * 20) ||
                (playerNumber == 4 && energyScript.currentEnergy4 < energyScript.maxEnergy4 / 100 * 20))
            {
                GetDizzy();
            }
            else
            {
                if (!canTeleport)
                {
                    switch (playerNumber)
                    {
                        case 1:
                            energyScript.DecreaseEnergy1(80);
                            break;
                        case 2:
                            energyScript.DecreaseEnergy2(80);
                            break;
                        case 3:
                            energyScript.DecreaseEnergy3(80);
                            break;
                        case 4:
                            energyScript.DecreaseEnergy4(80);
                            break;
                    }
                }
                if ((playerNumber == 1 && !energyScript.dizzy1) || (playerNumber == 2 && !energyScript.dizzy2) ||
                   (playerNumber == 3 && !energyScript.dizzy3) || (playerNumber == 4 && !energyScript.dizzy4))
                {
                    StartCoroutine(TeleportBySelf());
                }
            }
        }
    }
    IEnumerator TeleportBySelf()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        shrinkStatus = -1;
        teleportCheck = true;
        soundScript.PlaySound("Teleport");
        float roundedMoveX = 0;
        if (movementInput.x < 0) { roundedMoveX = -1; }
        else if (movementInput.x > 0) { roundedMoveX = 1; }
        float roundedMoveY = 0;
        if (movementInput.y < 0) { roundedMoveY = -1; }
        else if (movementInput.y > 0) { roundedMoveY = 1; }
        yield return new WaitForSeconds(0.2f);
        transform.position += new Vector3(roundedMoveX * 3, 0, roundedMoveY * 3);
        shrinkStatus = +1;
        yield return new WaitForSeconds(0.2f);
        shrinkStatus = 0;
        transform.localScale = BackupBallScale;
        rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(0.6f);
        teleportCheck = false;
    }
    #endregion

    public void ActivateSphere()
    {
        if (haveBlastSphere)
        {
            GameObject Father = transform.parent.gameObject;
            GameObject Sphere = Father.transform.GetChild(6).gameObject;
            Sphere.SetActive(true);
            haveBlastSphere = false;
        }
    }
}
