using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    #region Set Initial Variables
    public GameObject jumpPowerupIndicator, HolesParent;
    private GameObject opponent1, opponent2, opponent3;
    public TextMesh playerStrength;
    public Renderer playerRenderer;
    private MasterScript masterScript;
    private SpawnManagerScript spawnManagerScript;
    private TutorialScript tutorialScript;
    private ArcadeScript arcadeScript;
    private PlayerController playerController;
    private ParentScript parentScript;
    private SoundsScript soundScript;
    private EnergyScript energyScript;
    private Rigidbody playerRB;
    public Color originalColor;
    public Color angryColor;
    Collider m_ObjectCollider;

    public int playerNumber;
    public int strengthConvert; // for strength text
    public int teleportPath;
    public float strength;
    public bool dead;
    public bool inactive;

    private float strengthIncrement;
    private float speedIncrement;
    private float gravity = 18;
    public float energy;
    public int bossLevel;
    [SerializeField] private bool useSeparateMaterial;
    // private float horizontalInput = 0;
    //   private float verticalInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set Energy
        energyScript = GameObject.Find("EnergyManager").GetComponent<EnergyScript>();
        energyScript.maxEnergy1 = energy;
        energyScript.maxEnergy2 = energy;
        energyScript.maxEnergy3 = energy;
        energyScript.maxEnergy4 = energy;
        energyScript.setEnergy = true;

        playerRB = GetComponent<Rigidbody>();
        // Add the players spawn Manager Script
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        tutorialScript = GameObject.Find("SpawnManager").GetComponent<TutorialScript>();
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        playerController = GetComponent<PlayerController>();
        m_ObjectCollider = GetComponent<Collider>();
        if (spawnManagerScript.gameMode != 5)
        {
            parentScript = transform.parent.gameObject.GetComponent<ParentScript>();
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        playerRenderer = gameObject.GetComponent<Renderer>();
        angryColor = Color.red;
        originalColor = Color.white;

        //Set Increments
        strengthIncrement = strength / 4;
        speedIncrement = playerController.speed / 50;


        switch (playerNumber)
        {
            case 1:
                spawnManagerScript.isPlayer1Alive = true;
                break;
            case 2:
                spawnManagerScript.isPlayer2Alive = true;
                break;
            case 3:
                spawnManagerScript.isPlayer3Alive = true;
                break;
            case 4:
                spawnManagerScript.isPlayer4Alive = true;
                break;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Game Over for Survival mode
        if (strength <= 0 && spawnManagerScript.gameMode == 1)
        {
            spawnManagerScript.GameOver();
        }
        #region Control Mode Boss Settings
        if (spawnManagerScript.gameMode == 6 && playerNumber == 2 && bossLevel == 0)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.clear;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            playerRB.constraints = RigidbodyConstraints.FreezePositionY;
            m_ObjectCollider.isTrigger = true;
            bossLevel = 1;
        }
        if (arcadeScript.levelState == -1 && playerNumber == 2 && bossLevel == 1)
        {
            transform.localScale += new Vector3(1, 1, 1);
            transform.position = Vector3.zero;
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.white;
            playerController.bossSwitch = false;
            m_ObjectCollider.isTrigger = false;
            playerRB.constraints = RigidbodyConstraints.None;
            bossLevel = 2;
        }

        //Restrict Movements
        if (bossLevel == 1)
        {
            if (transform.position.x < -16)
            {
                transform.position = new Vector3(-16, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 16)
            {
                transform.position = new Vector3(16, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -16)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -16);
            }
            if (transform.position.z > 16)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 16);
            }
        }
        #endregion

        #region Strength Text Code
        strengthConvert = Convert.ToInt32(strength);
        //check for dodgeball mode
        if (spawnManagerScript.gameMode !=5 && !dead)
        {
            playerStrength.text ="" + strengthConvert;
            //   playerStrength.text ="P" + playerNumber + "\n" + strengthConvert; PC VERSION
        }
        else if (spawnManagerScript.gameMode == 5)
        {
            playerStrength.text = "";
        }
        #endregion

        //Add gravity to player
        playerRB.AddForce(Vector3.down * gravity * playerRB.mass);
        teleportPath = UnityEngine.Random.Range(1, arcadeScript.holeCount);

        #region Death Code
        //start of the fall code

        if ((transform.position.y < -5 || (spawnManagerScript.gameMode != 5 && (transform.position.x <= -18 || transform.position.x >= 18 ||
            transform.position.z <= -18 || transform.position.z >= 18))) && !dead && !tutorialScript.tutorialLevel)
        {
            if (GameObject.Find("GroundX") != null)
            {
                //In case Map is Inclinating you won't die because of the edges, only when you hit the ground
            }
            else
            {
                Death();
            }
        }
        if (transform.position.y < -5 && tutorialScript.tutorialLevel)
        {
            transform.position = new Vector3(0, 1, 0);
        }

        if (inactive)
        {
            playerController.inputLock = true;
            playerController.isJumpingAvailable = false;
            playerRB.velocity = new Vector3(0, 0, 0);
        }

        if (!dead)
        {
            if (useSeparateMaterial)
            {
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                playerRenderer.enabled = true;
            } 
        }
        else if (dead)
        {
            if (useSeparateMaterial)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                playerRenderer.enabled = false;
            }
        }
        #endregion

        //Regain control
        if (playerController.inputLock && !inactive)
        {
            StartCoroutine(parentScript.InputRountine());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Survival Mode Strength Reduction
        //lose strength in survival mode
        if (spawnManagerScript.gameMode == 1)
        {
            if (spawnManagerScript.enemyDefeated < 50)
            {
                if (strength < 100)
                {
                    strength -= 1f * Time.deltaTime;
                }
                if (strength > 100 && strength <= 200)
                {
                    strength -= 2f * Time.deltaTime;
                }
                else if (strength > 200 && strength <= 400)
                {
                    strength -= 4f * Time.deltaTime;
                }
                else if (strength > 400 && strength <= 800)
                {
                    strength -= 6f * Time.deltaTime;
                }
                else if (strength > 800)
                {
                    strength -= 8f * Time.deltaTime;
                }
            }
            else
            {
                strength -= 1 * Time.deltaTime;
            }
        }
        #endregion

        if (dead && spawnManagerScript.gameMode != 6)
        {
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (!dead && spawnManagerScript.gameMode !=6)
        {
            playerRB.constraints = RigidbodyConstraints.None;
        }
    }

    #region Ball Collision & Ground & Items
    //Check collision applying force
    private void OnCollisionEnter(Collision collision)
    {
        #region Boss Collision
        if (playerController.dashState == 2 && collision.gameObject.name == ("Boss"))
        {
            strength = playerController.originalStrength;
            playerController.inputLock = false;
            playerController.readStrength = false;
            playerController.dashState = 0;
        }
        #endregion

        #region Enemy Collision
        //Collide with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if ((playerController.playerNumber == 1 && (playerController.movementInput.x != 0 || playerController.movementInput.y != 0)) ||
                (playerController.playerNumber == 2 && (playerController.movementInput.x != 0 || playerController.movementInput.y != 0)) ||
                (playerController.playerNumber == 3 && (playerController.movementInput.x != 0 || playerController.movementInput.y != 0)) ||
                (playerController.playerNumber == 4 && (playerController.movementInput.x != 0 || playerController.movementInput.y != 0)))
            {
                ColSound();
                //Create Script Reference For Collided Object
                EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
                if (spawnManagerScript.gameMode != 5)
                {
                    playerController.inputLock = true;
                }
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = Vector3.zero;
                if (masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34)
                {
                    awayFromPlayer = collision.gameObject.transform.position - transform.position + new Vector3(0, 0.1f, 0);
                }
                else
                {
                    awayFromPlayer = collision.gameObject.transform.position - transform.position;
                }
                float updatedStrength = strength - enemyScript.strength;
                if (spawnManagerScript.lockItems)
                {
                    arcadeScript.finalFightHp += updatedStrength;
                    GameObject finalStatusBall = GameObject.Find("Status");
                    finalStatusBall.transform.position += new Vector3(updatedStrength / 4.8f, 0, 0);
                }
                if (updatedStrength < 0)
                {
                    updatedStrength = 0;
                }
                if (playerController.dashState != 2)
                {
                    enemyRigidbody.AddForce(awayFromPlayer * updatedStrength, ForceMode.Impulse);
                }
                if (updatedStrength > 0 && enemyScript.split == 1 && playerController.dashState != 2)
                {
                    enemyScript.split = 2;
                }
                enemyScript.canFall = true;
                //Get Enemy hit for Arena Mode Kills
                switch (playerNumber)
                {
                    case 1:
                        enemyScript.pushedByPlayer = 1;
                        break;
                    case 2:
                        enemyScript.pushedByPlayer = 2;
                        break;
                    case 3:
                        enemyScript.pushedByPlayer = 3;
                        break;
                    case 4:
                        enemyScript.pushedByPlayer = 4;
                        break;
                }
            }
            if (playerController.dashState == 2)
            {
                //      playerController.chargeSoundState = 0;
                //       strength = playerController.originalStrength;
                //         playerController.readStrength = false;
                //       playerController.dashState = 0;
                strength -= strengthIncrement * 2;
            }
            if (tutorialScript.tutorialState == 4)
            {
                StartCoroutine(PushEnemyInTutorial());
            }
        }
        #endregion

        #region Player Collision
        //Collide with player in versus mode
        if (collision.gameObject.CompareTag("Player") && (spawnManagerScript.gameMode == 4 || spawnManagerScript.gameMode == 6))
        {
            ColSound();
            //Create Script Reference For Collided Object
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerController.inputLock = true;
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            float updatedStrength = strength - playerScript.strength;
            if (updatedStrength < 0) { updatedStrength = 0; }
            enemyRigidbody.AddForce(awayFromPlayer * updatedStrength, ForceMode.Impulse);
        }
        #endregion

        if (collision.gameObject.CompareTag("Hole Wall"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z);
        }


        #region Item Collision
        // Increase strength
        if (collision.gameObject.CompareTag("ForceCapsule"))
        {
            soundScript.PlaySound("Drunk");
            spawnManagerScript.powerUpsOnScreen--;
            spawnManagerScript.itemsAvailable--;
            if (spawnManagerScript.gameMode !=1)
            {
                if (bossLevel == 0 || bossLevel == 2)
                {
                    if (!playerController.readStrength)
                    {
                        strength += strengthIncrement;
                        if (masterScript.sceneNumber == 52 && spawnManagerScript.enemyDefeated >= 18)
                        {
                            strength += strengthIncrement;
                        }
                    }
                    else
                    {
                        playerController.originalStrength += strengthIncrement;
                    }
                }
                else
                {
                    if (!playerController.readStrength)
                    {
                        strength += strengthIncrement / 3;
                    }
                    else
                    {
                        playerController.originalStrength += strengthIncrement / 3;
                    }
                }
            }
            else
            {
                strength += strengthIncrement / 2;
            }
            collision.transform.parent.gameObject.SetActive(false);
        }
        // Increase Speed
        if (collision.gameObject.CompareTag("SpeedCapsule"))
        {
            soundScript.PlaySound("Drunk");
            spawnManagerScript.powerUpsOnScreen--;
            spawnManagerScript.itemsAvailable--;
            if (bossLevel == 0)
            {
                playerController.speed += speedIncrement;
            }
            else
            {
                playerController.speed += speedIncrement / 5;
            }
            collision.transform.parent.gameObject.SetActive(false);
        }
        // Make Opponents Drunk
        if (collision.gameObject.CompareTag("DrunkCapsule"))
        {
            if (((spawnManagerScript.gameMode == 0 || spawnManagerScript.gameMode == 3)/* && parentScript.drunkCoroutineTimerAI == 0*/) ||
                (spawnManagerScript.gameMode == 4))
            {
                soundScript.PlaySound("Drunk");
                spawnManagerScript.powerUpsOnScreen--;
                spawnManagerScript.itemsAvailable--;
                //Check to see if Single or Multiplayer to get the right balls drunk
                if (spawnManagerScript.gameMode == 0 || spawnManagerScript.gameMode == 3)
                {
                    GetDrunk();
                }
                else if (spawnManagerScript.gameMode == 4)
                {
                    Debug.Log("1WORKS");
                    //Get the right players
                    switch (playerNumber)
                    {
                        case 1:
                            opponent1 = GameObject.Find("Player 2");
                            opponent2 = GameObject.Find("Player 3");
                            opponent3 = GameObject.Find("Player 4");
                            break;
                        case 2:
                            opponent1 = GameObject.Find("Player");
                            opponent2 = GameObject.Find("Player 3");
                            opponent3 = GameObject.Find("Player 4");
                            break;
                        case 3:
                            opponent1 = GameObject.Find("Player");
                            opponent2 = GameObject.Find("Player 2");
                            opponent3 = GameObject.Find("Player 4");
                            break;
                        case 4:
                            opponent1 = GameObject.Find("Player");
                            opponent2 = GameObject.Find("Player 2");
                            opponent3 = GameObject.Find("Player 3");
                            break;
                    }

                    if (masterScript.multiplayerMode == 22 || masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24)
                    {
                        if ((playerNumber == 1 && spawnManagerScript.isPlayer2Alive) || (playerNumber >= 2 && spawnManagerScript.isPlayer1Alive))
                        {
                            PlayerScript opponentScript1 = opponent1.GetComponent<PlayerScript>();
                            opponentScript1.GetDrunk();
                        }
                    }
                    if (masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24)
                    {
                        if ((playerNumber <= 2 && spawnManagerScript.isPlayer3Alive) || (playerNumber >= 3 && spawnManagerScript.isPlayer2Alive))
                        {
                            PlayerScript opponentScript2 = opponent2.GetComponent<PlayerScript>();
                            opponentScript2.GetDrunk();
                        }
                    }
                    if (masterScript.multiplayerMode == 24)
                    {
                        if ((playerNumber <= 3 && spawnManagerScript.isPlayer4Alive) || (playerNumber == 4 && spawnManagerScript.isPlayer3Alive))
                        {
                            PlayerScript opponentScript3 = opponent3.GetComponent<PlayerScript>();
                            opponentScript3.GetDrunk();
                        }
                    }
                }
                collision.transform.parent.gameObject.SetActive(false);
            }
        }
        // Increase strength to max
        if (collision.gameObject.CompareTag("SuperCapsule"))
        {
            parentScript.gauntletSwitch = 1;
            collision.transform.parent.gameObject.SetActive(false);
            //   Destroy(other.transform.parent.gameObject);  //don't destroy
        }
        // Add jumping skill
        if (collision.gameObject.CompareTag("JumpCapsule") && parentScript.ballonSwitch == 0)
        {
            spawnManagerScript.powerUpsOnScreen--;
            spawnManagerScript.itemsAvailable--;
            playerController.isJumpingAvailable = true;
            jumpPowerupIndicator.gameObject.SetActive(true);
            Destroy(collision.transform.parent.gameObject);
            parentScript.ballonSwitch = 1;
        }
        // Increase Growth Speed
        if (collision.gameObject.CompareTag("PowerCapsule"))
        {
            soundScript.PlaySound("Drunk");
            spawnManagerScript.powerUpsOnScreen--;
            spawnManagerScript.itemsAvailable--;
            playerController.power += 1;
            collision.transform.parent.gameObject.SetActive(false);
        }
        // Add Blast Sphere
        if (collision.gameObject.CompareTag("SphereCapsule"))
        {
            soundScript.PlaySound("Drunk");
            spawnManagerScript.powerUpsOnScreen--;
            spawnManagerScript.itemsAvailable--;
            playerController.haveBlastSphere = true;
            collision.transform.parent.gameObject.SetActive(false);
        }
        #endregion
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        #region Portals Enter Collision
        if (other.CompareTag("Hole"))
        {
            playerController.isJumping = true;
            GameObject portal1 = GameObject.Find("black hole 1");
            GameObject portal2 = GameObject.Find("black hole 2");
            GameObject portal3 = GameObject.Find("black hole 3");
            GameObject portal4 = GameObject.Find("black hole 4");
            GameObject portal5 = GameObject.Find("black hole 5");
            GameObject portal6 = GameObject.Find("black hole 6");
            GameObject portal7 = GameObject.Find("black hole 7");
            GameObject portal8 = GameObject.Find("black hole 8");

            soundScript.PlaySound("Teleport");
            switch (teleportPath)
            {
                case 1:
                    BlackHoleRotationScript portalScript1 = portal1.GetComponent<BlackHoleRotationScript>();
                    portalScript1.showGfx = true;
                    transform.position = portal1.transform.position;
                    break;
                case 2:
                    BlackHoleRotationScript portalScript2 = portal2.GetComponent<BlackHoleRotationScript>();
                    portalScript2.showGfx = true;
                    transform.position = portal2.transform.position;
                    break;
                case 3:
                    BlackHoleRotationScript portalScript3 = portal3.GetComponent<BlackHoleRotationScript>();
                    portalScript3.showGfx = true;
                    transform.position = portal3.transform.position;
                    break;
                case 4:
                    BlackHoleRotationScript portalScript4 = portal4.GetComponent<BlackHoleRotationScript>();
                    portalScript4.showGfx = true;
                    transform.position = portal4.transform.position;
                    break;
                case 5:
                    BlackHoleRotationScript portalScript5 = portal5.GetComponent<BlackHoleRotationScript>();
                    portalScript5.showGfx = true;
                    transform.position = portal5.transform.position;
                    break;
                case 6:
                    BlackHoleRotationScript portalScript6 = portal6.GetComponent<BlackHoleRotationScript>();
                    portalScript6.showGfx = true;
                    transform.position = portal6.transform.position;
                    break;
                case 7:
                    BlackHoleRotationScript portalScript7 = portal7.GetComponent<BlackHoleRotationScript>();
                    portalScript7.showGfx = true;
                    transform.position = portal7.transform.position;
                    break;
                case 8:
                    BlackHoleRotationScript portalScript8 = portal8.GetComponent<BlackHoleRotationScript>();
                    portalScript8.showGfx = true;
                    transform.position = portal8.transform.position;
                    break;
            }
        }
        #endregion

        if (other.gameObject.CompareTag("PlayerLimit") && !dead)
        {
            Death();
        }
        if (playerController.bossSwitch)
        {

            if (other.gameObject.CompareTag("ForceCapsule"))
            {
                soundScript.PlaySound("Drunk");
                spawnManagerScript.powerUpsOnScreen--;
                spawnManagerScript.itemsAvailable--;
                if (bossLevel == 0)
                {
                    if (!playerController.readStrength)
                    {
                        strength += strengthIncrement;
                    }
                    else
                    {
                        playerController.originalStrength += strengthIncrement;
                    }
                }
                else
                {
                    if (!playerController.readStrength)
                    {
                        strength += strengthIncrement / 4;
                    }
                    else
                    {
                        playerController.originalStrength += strengthIncrement / 4;
                    }
                }
                other.transform.parent.gameObject.SetActive(false);
            }
        }
    }

    #region Drunk Set
    public void GetDrunk()
    {
        Debug.Log("2WORKS");
        if (spawnManagerScript.gameMode == 0 || spawnManagerScript.gameMode == 3)
        {
            GetEnemyDrunk();
        }
        else
        {
            playerController.drunk = true;
            Debug.Log("3WORKS");
            switch (playerNumber)
            {
                case 1:
                    parentScript.drunkSwitch1 = 1;
                    break;
                case 2:
                    parentScript.drunkSwitch2 = 1;
                    break;
                case 3:
                    parentScript.drunkSwitch3 = 1;
                    break;
                case 4:
                    parentScript.drunkSwitch4 = 1;
                    break;
            }
        }
    }

    public void GetEnemyDrunk()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            EnemyScript enemyScript;
            enemyScript = enemy.GetComponent<EnemyScript>();
            if (!enemyScript.isEnemyclone && !enemyScript.isEnemyBoss)
            {
                enemyScript.aiType = 1;
                parentScript.drunkSwitchAI = 1;
            }
        }

    }
    public void RecoverEnemyDrunk()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            EnemyScript enemyScript;
            enemyScript = enemy.GetComponent<EnemyScript>();
            if (!enemyScript.isEnemyclone && !enemyScript.isEnemyBoss)
            {
                if (enemyScript.aiRegistry == 0)
                {
                    enemyScript.aiType = 0;
                }
                else if (enemyScript.aiRegistry == 2)
                {
                    enemyScript.aiType = 2;
                }
            }
        }
    }
    #endregion

    #region Collision Sound
    void ColSound()
    {
        int collisionSound = UnityEngine.Random.Range(0, 3);
        switch (collisionSound)
        {
            case 1:
                soundScript.PlaySound("Hit1");
                break;
            case 2:
                soundScript.PlaySound("Hit2");
                break;
            case 3:
                soundScript.PlaySound("Hit3");
                break;

        }
    }
    #endregion

    #region Death
    public void Death()
    {
        //Reduce boss speed to 0 to avoid him following you and jump into the hole
        if (spawnManagerScript.gameMode < 3 && GameObject.Find("Boss") != null)
        {
            GameObject Boss = GameObject.Find("Boss");
            EnemyScript bossScript = Boss.GetComponent<EnemyScript>();
            bossScript.speed = 0;
            bossScript.enemyRB.constraints = RigidbodyConstraints.FreezeAll;
        }
        soundScript.PlaySound("Fall");
        spawnManagerScript.playersTotal -= 1;
        switch (playerNumber)
        {
            case 1:
                spawnManagerScript.isPlayer1Alive = false;
                break;
            case 2:
                spawnManagerScript.isPlayer2Alive = false;
                break;
            case 3:
                spawnManagerScript.isPlayer3Alive = false;
                break;
            case 4:
                spawnManagerScript.isPlayer4Alive = false;
                break;
        }
        dead = true;
        if (spawnManagerScript.gameMode != 4)
        {
        //    playerController.isJumpingAvailable = false;
        //    jumpPowerupIndicator.gameObject.SetActive(false);
        }
    }
    #endregion

    IEnumerator PushEnemyInTutorial()
    {
        yield return new WaitForSeconds(2);
        tutorialScript.TutorialEnemyPhase3();
    }
}
