using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{
    #region Set Initial Variables
    public GameObject spawn;
    private GameObject player, player2, player3, player4, ballBody;
    private SpawnManagerScript spawnManagerScript;
    private TutorialScript tutorialScript;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private MapRotate mapScript;
    public BossDash BossDashScript;
    private ArcadeScript arcadeScript;
    private PlayerBossScript playerBossScript;
    private JumpTriggerScript jumpTriggerScript;
    private SoundsScript soundScript;
    public EnemySpawnDelay enemySpawnDelay;
    public Rigidbody enemyRB;
    public Renderer enemyRenderer;
    public TextMesh enemyStrength;
    private SphereCollider sc;
    public Vector3 lookDirrection = new Vector3(0, 0, 0);

    private int targetCount; // add players as targets
    public int target;
    public int ballNumber; // for dodgeball mode
    public int teleportPath;
    public float strength;
    public int strengthConvert;
    public float speed;
    private float gravity = 100;
    public float targetChangeCountdown = 30;
    public bool alive = true;
    public bool isEnemyBoss;
    private bool bossDeathCheck; // for level 2 where you have 2 bosses
    private bool isEnemyOnGround;
    private bool lockHole;
    public bool canFall;

    public bool raiseStrength;
    public bool canProduceShockwave;
    public int jumpDecision;
    public bool isJumping;
    public bool blastAway;
    public bool inputLock;
    public bool canSpin;
    public bool check;
    public int split;
    public bool isEnemyclone;

    public int aiType;
    public bool rareEnemy;
    public bool targetRead;
    public int targetsReached;
    public int customTarget;
    public byte extraTarget;
    public int ofTarget;
    public int aiRegistry;
    public int aiDecision;
    public bool bladeEnemy;
    byte bossCount;
    public bool lockAI;
    bool oneTimeTrigger;
    public float Rspeed;
    public bool hitConnected;
    public bool firstGroundContact;
    public float respawnCountdown;
    public int pushedByPlayer;
    public bool isBallOnGround;
    public bool isBallInAir;
    private Vector3 lastPos;
    private Vector3 presentPos;
    float distBetweenAB;
    public bool bossAppearCheck;
    public bool isEnemyFinalBoss;
    bool noGain;
    Vector3 StartPos;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Set AI Data 
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        tutorialScript = GameObject.Find("SpawnManager").GetComponent<TutorialScript>();
        if (!tutorialScript.tutorialLevel && !isEnemyBoss)
        {
            aiDecision = UnityEngine.Random.Range(0, 21);
            switch (aiType)
            {
                case 0:
                    if (aiDecision == 1)
                    {
                        aiType = 1;
                    }
                    else if (aiDecision == 10)
                    {
                        aiType = 2;
                    }
                    break;
                case 1:
                    if (aiDecision == 1)
                    {
                        aiType = 0;
                    }
                    else if (aiDecision == 10)
                    {
                        aiType = 2;
                    }
                    break;
                case 2:
                    if (aiDecision == 1)
                    {
                        aiType = 0;
                    }
                    else if (aiDecision == 10)
                    {
                        aiType = 1;
                    }
                    break;
            }
            aiRegistry = aiType;
        }
        #endregion
        GameObject EnemyFather = transform.parent.gameObject;
        GameObject GrandFather = EnemyFather.transform.parent.gameObject;
        enemySpawnDelay = GrandFather.GetComponent<EnemySpawnDelay>();
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        if (GameObject.Find("GroundX") != null)
        {
            mapScript = GameObject.Find("GroundX").GetComponent<MapRotate>();
        }
        if ((aiType == 1 || aiType == 2) && !tutorialScript.tutorialLevel && !isEnemyBoss && !rareEnemy)
        {
            if ((((spawnManagerScript.gameMode == 0 || spawnManagerScript.gameMode == 3) && !isEnemyBoss) || spawnManagerScript.gameMode == 1) && !lockAI)
            {
                enemySpawnDelay.aiSwitch = 1;
            }
        }
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        sc = GetComponent<SphereCollider>();
        if (canProduceShockwave)
        {
            jumpTriggerScript = transform.GetChild(0).GetComponent<JumpTriggerScript>();
        }
        StartCoroutine(ShowEnemy());

        #region Get Target
        //Add players as targets
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            targetCount += 1;
            if (isEnemyBoss && masterScript.sceneNumber != 62 && !bossAppearCheck)
            {
                PlayerScript playerScript = player.GetComponent<PlayerScript>();
                playerScript.strength = strength - 100;
                spawnManagerScript.itemsAvailable = 9999;
                bossAppearCheck = true;
            }
        }
        if (spawnManagerScript.gameMode !=6)
        {
            if (GameObject.Find("Player 2") != null)
            {
                player2 = GameObject.Find("Player 2");
                targetCount += 1;
            }
            if (GameObject.Find("Player 3") != null)
            {
                player3 = GameObject.Find("Player 3");
                targetCount += 1;
            }
            if (GameObject.Find("Player 4") != null)
            {
                player4 = GameObject.Find("Player 4");
                targetCount += 1;
            }
        }
        //Select target
        switch (targetCount)
        {
            case 1:
                target = 1;
                break;
            case 2:
                target = UnityEngine.Random.Range(1, 3);
                break;
            case 3:
                target = UnityEngine.Random.Range(1, 4);
                break;
            case 4:
                target = UnityEngine.Random.Range(1, 5);
                break;
        }
        #endregion

        if (raiseStrength && spawnManagerScript.gameMode == 3)
        {
            strength += 300;
        }
        respawnCountdown = 10;

        lastPos = Vector3.zero;
        presentPos = Vector3.zero;

        if (ballNumber ==0)
        {
            enemyRenderer = GetComponent<Renderer>();
        }
        else
        {
            ballBody = transform.GetChild(0).gameObject;
        }
        StartPos = transform.position;
    }

    IEnumerator ShowEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        if (ballNumber == 0)
        {
            enemyRenderer.enabled = true;
        }
        else
        {
            ballBody.gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        if (transform.position.y <= -3 && isEnemyBoss && jsonScript.so.levelNumber == "L4-14")
        {
            transform.position = StartPos;
        }
        //Ignore collision between enemies and power ups
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("CapsuleParent");
        foreach (GameObject powerUp in powerUps)
        {
            GameObject Item = powerUp.transform.GetChild(0).gameObject;
            Physics.IgnoreCollision(Item.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (split == 1 && isEnemyOnGround && aiType == 1)
        {
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 3)
            {
                Jump();
            }
        }

        if (spawnManagerScript.gameMode == 6 && !oneTimeTrigger)
        {
            playerBossScript = GameObject.Find("Boss Player").GetComponent<PlayerBossScript>();
            if (playerBossScript.spawnLock)
            {
                playerBossScript.spawnLock = false;
            }
            oneTimeTrigger = true;
        }

        if (enemySpawnDelay.ballRecoverSwitch == 2)
        {
            switch (ballNumber)
            {
                case 1:
                    ballNumber = 2;
                    break;
                case 2:
                    ballNumber = 3;
                    break;
                case 3:
                    ballNumber = 4;
                    break;
                case 4:
                    ballNumber = 1;
                    break;
            }
        }
        else
        {
            switch (ballNumber)
            {
                case 1:
                    ballNumber = 1;
                    break;
                case 2:
                    ballNumber = 2;
                    break;
                case 3:
                    ballNumber = 3;
                    break;
                case 4:
                    ballNumber = 4;
                    break;
            }
        }

        teleportPath = UnityEngine.Random.Range(1, arcadeScript.holeCount);
        #region Find Players
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player 2");
        player3 = GameObject.Find("Player 3");
        player4 = GameObject.Find("Player 4");
        #endregion
        
        if (isEnemyBoss)
        {
            SetTarget();
        }
        else if (!isEnemyclone)
        {
            if (!isEnemyBoss)
            {
                SetTarget();
            }
        }
        else if (isEnemyclone)
        {
            if (!isEnemyBoss)
            {
                SetTarget();
            }
        }

        //Set Target Limits
        if (spawnManagerScript.playersTotal != 0 && aiType == 0)
        {
            switch (spawnManagerScript.gameMode)
            {
                case 0:
                case 1:
                case 2:
                case 6:
                    target = 1;
                    break;
                case 3:
                    switch (masterScript.multiplayerMode)
                    {
                        case 12:
                            if (target !=1 && target !=2)
                            {
                                target = UnityEngine.Random.Range(1, 3);
                            }
                            break;
                        case 13:
                            if (target != 1 && target != 2 && target != 3)
                            {
                                target = UnityEngine.Random.Range(1, 4);
                            }
                            break;
                        case 14:
                            if (target != 1 && target != 2 && target != 3 && target != 4)
                            {
                                target = UnityEngine.Random.Range(1, 5);
                            }
                            break;
                    }
                    break;
            }
        }

        if (split == 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);

            //   GameObject Parent = GameObject.Find("Boss4(Clone)");
            GameObject Father = transform.parent.gameObject;
            GameObject Parent = Father.transform.parent.gameObject;
            GameObject[] Clones = GameObject.FindGameObjectsWithTag("Clones");
            foreach (GameObject clones in Clones)
            {
                clones.transform.parent = Parent.transform;
                //   transform.gameObject.SetActive(true);
            }
            //   gameObject.SetActive(false);
            Father.tag = "Untagged";
            gameObject.SetActive(false);
        }

            strengthConvert = Convert.ToInt32(strength);
        if (spawnManagerScript.gameMode != 4 && spawnManagerScript.gameMode != 5)
        {
            enemyStrength.text = "" + strengthConvert;
        }

        //Fall in Hole
        
        if ((transform.position.y <= -8 || transform.position.x <= -18 || transform.position.x >= 18 ||
            transform.position.z <= -18 || transform.position.z >= 18) && ballNumber ==0)
        {
            Death();
        }

        #region Regular Balls Code
        //check if opponent is a regular ball (not moving)
        if (ballNumber == 0)
        {
            enemyRB.AddForce(Vector3.down * gravity * enemyRB.mass);
        }
        else
        {
            enemyRB.AddForce(Vector3.down * 50);
        }

        #endregion

        if (canFall && gameObject.active)
        {
            StartCoroutine(RemoveLimits());
        }

        if (canSpin && BossDashScript.dashSwitch == 3)
        {
            transform.Rotate(lookDirrection, 300 * Time.deltaTime, Space.World);
        }
    }

    IEnumerator RemoveLimits()
    {
        yield return new WaitForSeconds(0.2f);
        canFall = false;
    }

    public void ReadPos()
    {
        distBetweenAB = (lastPos - presentPos).magnitude;
        if (distBetweenAB < 1.5f && firstGroundContact)
        {
            if ((!isEnemyOnGround) || (isBallOnGround && distBetweenAB < 0.05f) || isBallInAir)
            {
                Debug.Log("Return Ball!");
                BallsRespawn();
            }
            hitConnected = false;
        }
    //    Debug.Log(distBetweenAB + "x");
        lastPos = presentPos;
    }

    private void FixedUpdate()
    {
        presentPos = transform.position;
        //Teleport Dedgeballs back to the field
        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y < -5 || transform.position.y > 10 ||
            transform.position.z > 20 || transform.position.z < -20)
        {
            BallsRespawn();
        }
   ////////  //   if (pushed)
        {
    //        respawnCountdown -= 5f * Time.deltaTime;
        }
        if (respawnCountdown <= 0)
        {
            BallsRespawn();
        }

        if (!IsInvoking("ReadPos"))
        {
            if (isBallOnGround)
            {
                InvokeRepeating("ReadPos", 0.1f, 0.1f);
            }
            else if (isBallInAir)
            {
                InvokeRepeating("ReadPos", 0.3f, 0.3f);
            }
        }

        //Switch target after 30 second (random)
        targetChangeCountdown -= 1f * Time.deltaTime;
        if (targetChangeCountdown <= 0)
        {
            SwitchTarget();
            targetChangeCountdown = 10;
        }

        if (raiseStrength)
        {
            strength += 1f * Time.deltaTime;
        }

        if (canProduceShockwave && jumpTriggerScript)
        {
            jumpDecision = UnityEngine.Random.Range(1, 2);
            if (jumpDecision == 1 && isEnemyOnGround && jumpTriggerScript.playerIsInSight && enemySpawnDelay.jumpCooldown == 0)
            {
                float jumpHeight = 600;

                SoundsScript soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
                soundScript.PlaySound("Jump");
                enemyRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                enemySpawnDelay.jumpCooldown = 1;
            }
        }

        if (spawnManagerScript.playersTotal == 0)
        {
            enemyRB.velocity = Vector3.zero;
            speed = 0;
            target = 0;
        }
    }
    #region Code to read player collision for player escape (unused)
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.name == ("Player"))
            {
                StartCoroutine(spawnManagerScript.EnemyHitPlayer1());
            }
            if (collision.gameObject.name == ("Player 2"))
            {
                StartCoroutine(spawnManagerScript.EnemyHitPlayer2());
            }
            if (collision.gameObject.name == ("Player 3"))
            {
                StartCoroutine(spawnManagerScript.EnemyHitPlayer3());
            }
            if (collision.gameObject.name == ("Player 4"))
            {
                StartCoroutine(spawnManagerScript.EnemyHitPlayer4());
            }
        }
    }
    #endregion

    IEnumerator StopOnHit()
    {
        inputLock = true;
        yield return new WaitForSeconds(0.5f);
        inputLock = false;
    }

    #region Collision Code
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ballNumber > 0 && isEnemyOnGround)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
                enemyRB.constraints = RigidbodyConstraints.FreezePositionY;
            }
            if (aiType == 2)
            {
                customTarget = UnityEngine.Random.Range(9, 13);
            }
            ColSound();
            //Create Script Reference For Collided Object
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (!inputLock)
            {
                StartCoroutine(StopOnHit());
            }
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;
            float updatedStrength = strength - playerScript.strength;
            if (updatedStrength < 0)
            {
                updatedStrength = 0;
            }
            if (bladeEnemy)
            {
                if (updatedStrength > 0)
                {
                    playerScript.strength -= 5;
                }
                else if (updatedStrength <= 0)
                {
                    playerScript.strength--;
                }
            }
            if (ballNumber == 0)
            {
                playerRigidbody.AddForce(awayFromEnemy * (updatedStrength), ForceMode.Impulse);
            }
            /*
            if (ballNumber > 0)
            {
                playerRigidbody.AddForce(awayFromEnemy * 250, ForceMode.Impulse);
            }
            //different strength for dodge-balls
            else if ((ballNumber == 1 && collision.transform.gameObject.name != ("Player")) ||
                (ballNumber == 2 && collision.transform.gameObject.name != ("Player 2")) ||
                (ballNumber == 3 && collision.transform.gameObject.name != ("Player 3")) ||
                (ballNumber == 4 && collision.transform.gameObject.name != ("Player 4")))
            {
                playerRigidbody.AddForce(awayFromEnemy * 250, ForceMode.Impulse);
            }*/
        }
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) && ballNumber > 0)
        {
            if (hitConnected)
            {
                Rigidbody collidedRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromBall = collision.gameObject.transform.position - transform.position;
                collidedRigidbody.AddForce(awayFromBall * 250, ForceMode.Impulse);
                hitConnected = false;
            }
        }
        if (collision.gameObject.CompareTag("Player") && ballNumber > 0 && !hitConnected)
        {
            Vector3 awayFromBall = transform.position - collision.gameObject.transform.position;
            enemyRB.AddForce(awayFromBall * 250, ForceMode.Impulse);
            hitConnected = true;
        }
        /*
        if (collision.gameObject.CompareTag("Enemy") && ballNumber > 0)
        {
            enemySpawnDelay.ballRecoverSwitch = 1;
            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromEnemy * 250, ForceMode.Impulse);
        }*/

        if (collision.gameObject.CompareTag("Ground"))
        {
            isEnemyOnGround = true;
            /*
            if ((ballNumber == 1 && collision.transform.gameObject.name != ("Ground P1")) ||
                (ballNumber == 2 && collision.transform.gameObject.name != ("Ground P2")) ||
                (ballNumber == 3 && collision.transform.gameObject.name != ("Ground P3")) ||
                (ballNumber == 4 && collision.transform.gameObject.name != ("Ground P4")))
            {
                isBallOnGround = true;
            }
            if ((ballNumber == 1 && collision.transform.gameObject.name == ("Ground P1")) ||
                (ballNumber == 2 && collision.transform.gameObject.name == ("Ground P2")) ||
                (ballNumber == 3 && collision.transform.gameObject.name == ("Ground P3")) ||
                (ballNumber == 4 && collision.transform.gameObject.name == ("Ground P4")))
            {
                isBallOnGround = false;
            }
            */
                firstGroundContact = true;
        }


        if (collision.gameObject.CompareTag("GroundX") && isEnemyclone)
        {
            arcadeScript.clonesCount++;
            isEnemyclone = false;
        }

        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClonesCounter") && isEnemyclone)
        {
            arcadeScript.clonesCount++;
            Debug.Log("count+1");
        }
        if (other.CompareTag("Hole") && !lockHole)
        {
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
         //   lockHole = true;
        }
        if (!canFall)
        {
            if (other.CompareTag("DownLimit"))
            {
                transform.position += new Vector3(0, 0, 0.2f);
                customTarget = 0;
            }
            if (other.CompareTag("UpLimit"))
            {
                transform.position += new Vector3(0, 0, -0.2f);
                customTarget = 0;
            }
            if (other.CompareTag("LeftLimit"))
            {
                transform.position += new Vector3(0.2f, 0, 0);
                customTarget = 0;
            }
            if (other.CompareTag("RightLimit"))
            {
                transform.position += new Vector3(-0.2f, 0, 0);
                customTarget = 0;
            }
            if (other.CompareTag("LeftUpLimit"))
            {
                transform.position += new Vector3(0.2f, 0, -0.2f);
                customTarget = 0;
            }
            if (other.CompareTag("RightUpLimit"))
            {
                transform.position += new Vector3(-0.2f, 0, -0.2f);
                customTarget = 0;
            }
            if (other.CompareTag("LeftDownLimit"))
            {
                transform.position += new Vector3(0.2f, 0, 0.2f);
                customTarget = 0;
            }
            if (other.CompareTag("RightDownLimit"))
            {
                transform.position += new Vector3(-0.2f, 0, 0.2f);
                customTarget = 0;
            }
        }
        if (other.transform.gameObject.name == ("Tgt0") || other.transform.gameObject.name == ("Tgt1") || other.transform.gameObject.name == ("Tgt2")
        || other.transform.gameObject.name == ("Tgt3") || other.transform.gameObject.name == ("Tgt4") || other.transform.gameObject.name == ("Tgt5")
        || other.transform.gameObject.name == ("Tgt6") || other.transform.gameObject.name == ("Tgt7") || other.transform.gameObject.name == ("Tgt8")
          || other.transform.gameObject.name == ("Tgt9") || other.transform.gameObject.name == ("Tgt10") || other.transform.gameObject.name == ("Tgt11")
           || other.transform.gameObject.name == ("Tgt12") || other.transform.gameObject.name == ("Right Limit") || other.transform.gameObject.name == ("Left Limit")
           || other.transform.gameObject.name == ("Up Limit") || other.transform.gameObject.name == ("Down Limit")
           || other.transform.gameObject.name == ("LeftUpLimit") || other.transform.gameObject.name == ("RightUpLimit")
           || other.transform.gameObject.name == ("LeftDownLimit") || other.transform.gameObject.name == ("RightDownLimit"))
        {
            targetsReached++;
            targetRead = false;
        }
        if (other.transform.gameObject.name == ("Tgt0"))
        {
            customTarget = UnityEngine.Random.Range(9, 13);
        }
        if (other.transform.gameObject.name == ("Tgt9"))
        {
            extraTarget = 9;
            customTarget = UnityEngine.Random.Range(9, 13);
        }
        if (other.transform.gameObject.name == ("Tgt10"))
        {
            extraTarget = 10;
            customTarget = UnityEngine.Random.Range(9, 13);
        }
        if (other.transform.gameObject.name == ("Tgt11"))
        {
            extraTarget = 11;
            customTarget = UnityEngine.Random.Range(9, 13);
        }
        if (other.transform.gameObject.name == ("Tgt12"))
        {
            extraTarget = 12;
            customTarget = UnityEngine.Random.Range(9, 13);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            if (canProduceShockwave)
            {
                enemyRB.mass = 10f;
                if (!isEnemyOnGround && jumpTriggerScript.playerIsInSight)
                {
                 //   enemyRB.velocity = new Vector3(0, 0, 0);
                }
            ///    enemyRB.constraints = RigidbodyConstraints.FreezeAll;
                transform.GetChild(1).transform.position = transform.position;
                transform.GetChild(1).gameObject.SetActive(true);
            }
            isEnemyOnGround = true;
            firstGroundContact = true;
        }

        if (other.gameObject.CompareTag("BossLimit") && isEnemyBoss)
        {
            FreezeEnemy();
            inputLock = false;
            BossDashScript.dashSwitch = -1;
            enemyRB.constraints = RigidbodyConstraints.None;
        }

        if ((ballNumber == 1 && (other.gameObject.CompareTag("Ball2Area") || other.gameObject.CompareTag("Ball3Area") ||
            other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 2 && (other.gameObject.CompareTag("Ball1Area") ||
            other.gameObject.CompareTag("Ball3Area") || other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 3 &&
            (other.gameObject.CompareTag("Ball1Area") || other.gameObject.CompareTag("Ball2Area") ||
            other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 4 && (other.gameObject.CompareTag("Ball1Area") ||
            other.gameObject.CompareTag("Ball2Area") || other.gameObject.CompareTag("Ball3Area"))))
        {
            isBallOnGround = true;
        }
        if ((other.gameObject.CompareTag("Ball0Area") && ballNumber > 0))
        {
            isBallInAir = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isEnemyOnGround = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (canProduceShockwave)
            {
                enemyRB.mass = 0.2f;
            }
            isEnemyOnGround = false;
        }

        if ((ballNumber == 1 && (other.gameObject.CompareTag("Ball2Area") || other.gameObject.CompareTag("Ball3Area") ||
            other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 2 && (other.gameObject.CompareTag("Ball1Area") ||
            other.gameObject.CompareTag("Ball3Area") || other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 3 &&
            (other.gameObject.CompareTag("Ball1Area") || other.gameObject.CompareTag("Ball2Area") ||
            other.gameObject.CompareTag("Ball4Area"))) || (ballNumber == 4 && (other.gameObject.CompareTag("Ball1Area") ||
            other.gameObject.CompareTag("Ball2Area") || other.gameObject.CompareTag("Ball3Area"))))
        {
            isBallOnGround = false;
        }
        if ((other.gameObject.CompareTag("Ball0Area") && ballNumber > 0))
        {
            isBallInAir = false;
        }
    }
    #endregion

    #region Set Target
    void SetTarget()
    {
        //Check for Control mode (enemies won't follow PLayer God)
        if (spawnManagerScript.gameMode != 6 && spawnManagerScript.gameMode != 5 && !inputLock)
        {
            if (aiType == 0) // follows you all the time
            {
                switch (target)
                {
                    case 1:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player") != null)
                        {
                            PlayerScript playerScript1 = player.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript1.dead)
                            {
                                lookDirrection = new Vector3(player.transform.position.x - transform.position.x, 0,
                                player.transform.position.z - transform.position.z);
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 2:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 2") != null)
                        {
                            PlayerScript playerScript2 = player2.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript2.dead)
                            {
                                lookDirrection = new Vector3(player2.transform.position.x - transform.position.x, 0,
                                player2.transform.position.z - transform.position.z);
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 3:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 3") != null)
                        {
                            PlayerScript playerScript3 = player3.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript3.dead)
                            {
                                lookDirrection = new Vector3(player3.transform.position.x - transform.position.x, 0,
                                player3.transform.position.z - transform.position.z);
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 4:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 4") != null)
                        {
                            PlayerScript playerScript4 = player4.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript4.dead)
                            {
                                lookDirrection = new Vector3(player4.transform.position.x - transform.position.x, 0,
                                player4.transform.position.z - transform.position.z);
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    //In case enemy have no target then it switches target
                    default:
                        SwitchTarget();
                        break;

                }
            }
            else if (aiType == 1) //runs casual on the map
            {
                if (!targetRead)
                {
                    target = UnityEngine.Random.Range(0, 13);
                    switch (target)
                    {
                        case 0:
                            lookDirrection = (GameObject.Find("Tgt0").transform.position - transform.position).normalized;
                            break;
                        case 1:
                            lookDirrection = (GameObject.Find("Tgt1").transform.position - transform.position).normalized;
                            break;
                        case 2:
                            lookDirrection = (GameObject.Find("Tgt2").transform.position - transform.position).normalized;
                            break;
                        case 3:
                            lookDirrection = (GameObject.Find("Tgt3").transform.position - transform.position).normalized;
                            break;
                        case 4:
                            lookDirrection = (GameObject.Find("Tgt4").transform.position - transform.position).normalized;
                            break;
                        case 5:
                            lookDirrection = (GameObject.Find("Tgt5").transform.position - transform.position).normalized;
                            break;
                        case 6:
                            lookDirrection = (GameObject.Find("Tgt6").transform.position - transform.position).normalized;
                            break;
                        case 7:
                            lookDirrection = (GameObject.Find("Tgt7").transform.position - transform.position).normalized;
                            break;
                        case 8:
                            lookDirrection = (GameObject.Find("Tgt8").transform.position - transform.position).normalized;
                            break;
                        case 9:
                            lookDirrection = (GameObject.Find("Tgt9").transform.position - transform.position).normalized;
                            break;
                        case 10:
                            lookDirrection = (GameObject.Find("Tgt10").transform.position - transform.position).normalized;
                            break;
                        case 11:
                            lookDirrection = (GameObject.Find("Tgt11").transform.position - transform.position).normalized;
                            break;
                        case 12:
                            lookDirrection = (GameObject.Find("Tgt12").transform.position - transform.position).normalized;
                            break;
                        case 13:
                            lookDirrection = (GameObject.Find("Tgt0").transform.position - transform.position).normalized;
                            break;
                    }
                    targetRead = true;
                }
                enemyRB.AddForce(lookDirrection * speed * Time.deltaTime);
                if (targetsReached > 19 && rareEnemy)
                {
                    noGain = true;
                    Death();
                }
            }
            else if (aiType == 2)
            {
                switch (target)
                {
                    case 1:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player") != null)
                        {
                            PlayerScript playerScript1 = player.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript1.dead)
                            {
                                if (strength > playerScript1.strength)
                                {
                                    if (!IsInvoking("ChangeTarget"))
                                    {
                                        InvokeRepeating("ChangeTarget", 0.01f, 1.5f);//////////////////////////////////////////////////////////////////
                                    }
                                    float edge = 1.5f;
                                    switch (ofTarget)
                                    {
                                        case 1:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x - edge, 0,
                                            player.transform.position.z - transform.position.z);
                                            break;
                                        case 2:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x + edge, 0,
                                            player.transform.position.z - transform.position.z);
                                            break;
                                        case 3:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x, 0,
                                            player.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 4:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x, 0,
                                            player.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 5:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x - edge, 0,
                                            player.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 6:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x - edge, 0,
                                            player.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 7:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x + edge, 0,
                                            player.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 8:
                                            lookDirrection = new Vector3(player.transform.position.x - transform.position.x + edge, 0,
                                            player.transform.position.z - transform.position.z + edge);
                                            break;
                                    }
                                }
                                else if (strength <= playerScript1.strength)
                                {
                                    GameObject Target = GameObject.Find("Tgt0");
                                    switch (customTarget)
                                    {
                                        case 9:
                                            if (extraTarget == 9)
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            break;
                                        case 10:
                                            if (extraTarget == 10)
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            break;
                                        case 11:
                                            if (extraTarget == 11)
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            break;
                                        case 12:
                                            if (extraTarget == 12)
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            break;
                                        case 13:
                                            customTarget = 12;
                                            break;
                                    }
                                    lookDirrection = new Vector3(Target.transform.position.x - transform.position.x, 0,
                                    Target.transform.position.z - transform.position.z);
                                }
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 2:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 2") != null)
                        {
                            PlayerScript playerScript2 = player2.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript2.dead)
                            {
                                if (strength > playerScript2.strength)
                                {
                                    if (!IsInvoking("ChangeTarget"))
                                    {
                                        InvokeRepeating("ChangeTarget", 0.01f, 1.5f);//////////////////////////////////////////////////////////////////
                                    }
                                    float edge = 1.5f;
                                    switch (ofTarget)
                                    {
                                        case 1:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x - edge, 0,
                                            player2.transform.position.z - transform.position.z);
                                            break;
                                        case 2:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x + edge, 0,
                                            player2.transform.position.z - transform.position.z);
                                            break;
                                        case 3:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x, 0,
                                            player2.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 4:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x, 0,
                                            player2.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 5:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x - edge, 0,
                                            player2.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 6:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x - edge, 0,
                                            player2.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 7:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x + edge, 0,
                                            player2.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 8:
                                            lookDirrection = new Vector3(player2.transform.position.x - transform.position.x + edge, 0,
                                            player2.transform.position.z - transform.position.z + edge);
                                            break;
                                    }
                                }
                                else if (strength <= playerScript2.strength)
                                {
                                    GameObject Target = GameObject.Find("Tgt0");
                                    switch (customTarget)
                                    {
                                        case 9:
                                            if (extraTarget == 9)
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            break;
                                        case 10:
                                            if (extraTarget == 10)
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            break;
                                        case 11:
                                            if (extraTarget == 11)
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            break;
                                        case 12:
                                            if (extraTarget == 12)
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            break;
                                        case 13:
                                            customTarget = 12;
                                            break;
                                    }
                                    lookDirrection = new Vector3(Target.transform.position.x - transform.position.x, 0,
                                    Target.transform.position.z - transform.position.z);
                                }
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 3:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 3") != null)
                        {
                            PlayerScript playerScript3 = player3.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript3.dead)
                            {
                                if (strength > playerScript3.strength)
                                {
                                    if (!IsInvoking("ChangeTarget"))
                                    {
                                        InvokeRepeating("ChangeTarget", 0.01f, 1.5f);//////////////////////////////////////////////////////////////////
                                    }
                                    float edge = 1.5f;
                                    switch (ofTarget)
                                    {
                                        case 1:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x - edge, 0,
                                            player3.transform.position.z - transform.position.z);
                                            break;
                                        case 2:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x + edge, 0,
                                            player3.transform.position.z - transform.position.z);
                                            break;
                                        case 3:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x, 0,
                                            player3.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 4:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x, 0,
                                            player3.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 5:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x - edge, 0,
                                            player3.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 6:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x - edge, 0,
                                            player3.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 7:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x + edge, 0,
                                            player3.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 8:
                                            lookDirrection = new Vector3(player3.transform.position.x - transform.position.x + edge, 0,
                                            player3.transform.position.z - transform.position.z + edge);
                                            break;
                                    }
                                }
                                else if (strength <= playerScript3.strength)
                                {
                                    GameObject Target = GameObject.Find("Tgt0");
                                    switch (customTarget)
                                    {
                                        case 9:
                                            if (extraTarget == 9)
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            break;
                                        case 10:
                                            if (extraTarget == 10)
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            break;
                                        case 11:
                                            if (extraTarget == 11)
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            break;
                                        case 12:
                                            if (extraTarget == 12)
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            break;
                                        case 13:
                                            customTarget = 12;
                                            break;
                                    }
                                    lookDirrection = new Vector3(Target.transform.position.x - transform.position.x, 0,
                                    Target.transform.position.z - transform.position.z);
                                }
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    case 4:
                        // Check if players is alive to follow him
                        if (GameObject.Find("Player 4") != null)
                        {
                            PlayerScript playerScript4 = player4.gameObject.GetComponent<PlayerScript>();
                            if (!playerScript4.dead)
                            {
                                if (strength > playerScript4.strength)
                                {
                                    if (!IsInvoking("ChangeTarget"))
                                    {
                                        InvokeRepeating("ChangeTarget", 0.01f, 1.5f);//////////////////////////////////////////////////////////////////
                                    }
                                    float edge = 1.5f;
                                    switch (ofTarget)
                                    {
                                        case 1:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x - edge, 0,
                                            player4.transform.position.z - transform.position.z);
                                            break;
                                        case 2:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x + edge, 0,
                                            player4.transform.position.z - transform.position.z);
                                            break;
                                        case 3:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x, 0,
                                            player4.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 4:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x, 0,
                                            player4.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 5:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x - edge, 0,
                                            player4.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 6:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x - edge, 0,
                                            player4.transform.position.z - transform.position.z + edge);
                                            break;
                                        case 7:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x + edge, 0,
                                            player4.transform.position.z - transform.position.z - edge);
                                            break;
                                        case 8:
                                            lookDirrection = new Vector3(player4.transform.position.x - transform.position.x + edge, 0,
                                            player4.transform.position.z - transform.position.z + edge);
                                            break;
                                    }
                                }
                                else if (strength <= playerScript4.strength)
                                {
                                    GameObject Target = GameObject.Find("Tgt0");
                                    switch (customTarget)
                                    {
                                        case 9:
                                            if (extraTarget == 9)
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            break;
                                        case 10:
                                            if (extraTarget == 10)
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            break;
                                        case 11:
                                            if (extraTarget == 11)
                                            {
                                                Target = GameObject.Find("Tgt9");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt11");
                                            }
                                            break;
                                        case 12:
                                            if (extraTarget == 12)
                                            {
                                                Target = GameObject.Find("Tgt10");
                                            }
                                            else
                                            {
                                                Target = GameObject.Find("Tgt12");
                                            }
                                            break;
                                        case 13:
                                            customTarget = 12;
                                            break;
                                    }
                                    lookDirrection = new Vector3(Target.transform.position.x - transform.position.x, 0,
                                    Target.transform.position.z - transform.position.z);
                                }
                            }
                            // In case player is not alive then enemy will switch target
                            else
                            {
                                SwitchTarget();
                            }
                        }
                        // In case player is not alive then enemy will switch target
                        else
                        {
                            SwitchTarget();
                        }
                        break;
                    //In case enemy have no target then it switches target
                    default:
                        SwitchTarget();
                        break;

                }
            }
        }/////////////////////
        else
        {
            // All enemies target player 1 in control mode
            target = 1;
            // Check if players is alive to follow him
            if (GameObject.Find("Player") != null)
            {
                PlayerScript playerScript = player.gameObject.GetComponent<PlayerScript>();
                if (!playerScript.dead)
                {
                    lookDirrection = new Vector3(player.transform.position.x - transform.position.x, 0,
                    player.transform.position.z - transform.position.z);
                }
            }
        }

         if (isEnemyOnGround == true && !inputLock && enemySpawnDelay.ballNumber == 0)
        {
            enemyRB.AddForce(lookDirrection * speed * Time.deltaTime); 
        }
    }
    #endregion

    #region Switch Target
    void SwitchTarget()
    {
        if (spawnManagerScript.playersTotal > 0 && spawnManagerScript.gameMode == 3)
        {
            target = UnityEngine.Random.Range(1, 5); //paradox need delete value
        }
        else
        {
            // Stop Movement
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

    public void Death()
    {
        if (tutorialScript.tutorialState == 3)
        {
            tutorialScript.TutorialEnemyPhase2();
        }
        if (tutorialScript.tutorialState == 5)
        {
            tutorialScript.TutorialEnemyPhase4();
        }
        if (tutorialScript.tutorialState == 12)
        {
            tutorialScript.TutorialEndPhase();
        }
        soundScript.PlaySound("Death");
        //Check if enemy is boss
        if (isEnemyBoss)
        {
            if (spawnManagerScript.gameMode == 0 || spawnManagerScript.gameMode == 2 || spawnManagerScript.gameMode == 3)
            {
                arcadeScript.levelState = 100;
            }
            else if (spawnManagerScript.gameMode == 1)
            {
                if (spawnManagerScript.defeatedBossCount < 3)
                {
                    spawnManagerScript.defeatedBossCount++;
                }
                if (spawnManagerScript.defeatedBossCount >= 3)
                {
                    arcadeScript.levelState = 100;
                }
            }
        }

        spawnManagerScript.enemiesActive -= 1;
        if (alive)
        {
            if (spawnManagerScript.gameMode == 1)
            {
                GameObject Player = GameObject.Find("Player");
                PlayerScript playerScript = Player.GetComponent<PlayerScript>();
                playerScript.strength += 50;
            }
            spawnManagerScript.enemyDefeated += 1;
            //Get Kills for Players in Arena Mode
            if (spawnManagerScript.gameMode == 3)
            {
                switch (pushedByPlayer)
                {
                    case 1:
                        spawnManagerScript.P1Kills++;
                        break;
                    case 2:
                        spawnManagerScript.P2Kills++;
                        break;
                    case 3:
                        spawnManagerScript.P3Kills++;
                        break;
                    case 4:
                        spawnManagerScript.P4Kills++;
                        break;
                }
            }
            switch (spawnManagerScript.gameMode)
            {
                case 0:
                    spawnManagerScript.itemsAvailable += 5;
                    break;
                case 1:
                case 3:
                    spawnManagerScript.itemsAvailable += 8;
                    break;
            }
            arcadeScript.enemiesLeft--;
            if (spawnManagerScript.gameMode <3)
            {
                if (rareEnemy && !noGain)
                {
                    jsonScript.so.diamonds+=100;
                }
                else
                {
                    if (spawnManagerScript.gameMode !=2)
                    {
                        jsonScript.so.diamonds++;
                    }
                    else
                    {// Win less diamonds in gauntlet
                        if (spawnManagerScript.enemyDefeated == 10 || spawnManagerScript.enemyDefeated == 20 || spawnManagerScript.enemyDefeated == 30
                             || spawnManagerScript.enemyDefeated == 40 || spawnManagerScript.enemyDefeated == 50 || spawnManagerScript.enemyDefeated == 60
                              || spawnManagerScript.enemyDefeated == 70 || spawnManagerScript.enemyDefeated == 80
                               || spawnManagerScript.enemyDefeated == 90 || spawnManagerScript.enemyDefeated == 100)
                        {
                            jsonScript.so.diamonds++;
                        }
                    }
                }
            }
            if (spawnManagerScript.gameMode == 0)
            {
                GameObject[] Bars = GameObject.FindGameObjectsWithTag("Bar");
                foreach (GameObject bar in Bars)
                {
                    ECountBar barScript = bar.GetComponent<ECountBar>();
                    if (arcadeScript.enemiesLeft == barScript.barNumber - 1)
                    {
                        barScript.destroyBar = true;
                    }
                }
            }
            alive = false;
        }
        if (spawnManagerScript.gameMode == 6)
        {
            GameObject Father = transform.parent.gameObject;
            GameObject GrandFather = Father.transform.parent.gameObject;/*
            switch (GrandFather.gameObject.name)
            {
                case "Enemy1a(Clone)":
                    playerBossScript.checkEnemy1 = false;
                    break;
                case "Enemy1b(Clone)":
                    playerBossScript.checkEnemy2 = false;
                    break;
                case "Enemy1c(Clone)":
                    playerBossScript.checkEnemy3 = false;
                    break;
                case "Enemy1d(Clone)":
                    playerBossScript.checkEnemy4 = false;
                    break;
                case "Enemy2a(Clone)":
                    playerBossScript.checkEnemy5 = false;
                    break;
                case "Enemy2b(Clone)":
                    playerBossScript.checkEnemy6 = false;
                    break;
                case "Enemy2c(Clone)":
                    playerBossScript.checkEnemy7 = false;
                    break;
                case "Enemy2d(Clone)":
                    playerBossScript.checkEnemy8 = false;
                    break;
                case "Enemy2e(Clone)":
                    playerBossScript.checkEnemy9 = false;
                    break;
                case "Enemy3a(Clone)":
                    playerBossScript.checkEnemy10 = false;
                    break;
                case "Enemy3b(Clone)":
                    playerBossScript.checkEnemy11 = false;
                    break;
                case "Enemy3c(Clone)":
                    playerBossScript.checkEnemy12 = false;
                    break;
                case "Enemy3d(Clone)":
                    playerBossScript.checkEnemy13 = false;
                    break;
                case "Enemy3e(Clone)":
                    playerBossScript.checkEnemy14 = false;
                    break;
                case "Enemy4a(Clone)":
                    playerBossScript.checkEnemy15 = false;
                    break;
                case "Enemy4b(Clone)":
                    playerBossScript.checkEnemy16 = false;
                    break;
                case "Enemy4c(Clone)":
                    playerBossScript.checkEnemy17 = false;
                    break;
                case "Enemy4d(Clone)":
                    playerBossScript.checkEnemy18 = false;
                    break;
                case "Enemy4e(Clone)":
                    playerBossScript.checkEnemy19 = false;
                    break;
                case "Enemy5a(Clone)":
                    playerBossScript.checkEnemy20 = false;
                    break;
                case "Enemy5b(Clone)":
                    playerBossScript.checkEnemy21 = false;
                    break;
                case "Enemy5c(Clone)":
                    playerBossScript.checkEnemy22 = false;
                    break;
                case "Enemy5d(Clone)":
                    playerBossScript.checkEnemy23 = false;
                    break;
                case "Enemy5e(Clone)":
                    playerBossScript.checkEnemy24 = false;
                    break;
                case "Enemy5f(Clone)":
                    playerBossScript.checkEnemy25 = false;
                    break;
                case "Enemy5g(Clone)":
                    playerBossScript.checkEnemy26 = false;
                    break;
                case "Enemy5h(Clone)":
                    playerBossScript.checkEnemy27 = false;
                    break;
            }*/
            GrandFather.SetActive(false);
        }
        if (spawnManagerScript.gameMode != 4 && spawnManagerScript.gameMode != 6)
        {
            GameObject Father = transform.parent.gameObject;
            GameObject GrandFather = Father.transform.parent.gameObject;
        //    Destroy(GrandFather);
            GrandFather.SetActive(false);
        }
    }

    public void ChangeTarget()
    {
        ofTarget = UnityEngine.Random.Range(1, 9);
    }

    public void Jump()
    {
        SoundsScript soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        float jumpHeight = 600;
        soundScript.PlaySound("Jump");
        enemyRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        isEnemyOnGround = false;
    }

    public void BallsRespawn()
    {
        switch (masterScript.multiplayerMode)
        {
            case 32:
                if (ballNumber == 1)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos1;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 2)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos2;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                break;
            case 33:
                if (ballNumber == 1)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos1;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 2)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos2;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 3)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos3;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                break;
            case 34:
                if (ballNumber == 1)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos1;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 2)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos2;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 3)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos3;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                else if (ballNumber == 4)
                {
                    enemyRB.velocity = Vector3.zero;
                    transform.position = spawnManagerScript.ballSpawnPos4;
                    enemyRB.constraints = RigidbodyConstraints.None;
                }
                break;
        }
        respawnCountdown = 10;
        hitConnected = false;
        firstGroundContact = false;
        isBallOnGround = false;
        isEnemyOnGround = false;
        isBallInAir = false;
        //    pushed = false;
    }
    public void FreezeEnemy()
    {
        enemyRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void UnfreezeEnemy()
    {
        enemyRB.constraints = RigidbodyConstraints.None;
    }
}
