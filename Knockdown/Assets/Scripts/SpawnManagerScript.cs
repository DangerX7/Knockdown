using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManagerScript : MonoBehaviour
{
    #region Set Initial Variables
    public List<GameObject> enemies;
    private GameObject backgroundPauseMenu;
    public GameObject forcePowerup, jumpPowerup, drunkPowerup, speedPowerup, superForcePowerup, spherePowerup, growthPowerup, pl2Ref, plC2Ref, P1Dod, P2Dod,
        ball1, ball2, ball3, ball4, ground, ballParent, skinUnlockText, modeUnlockText, diamondsBoss, diamondsEarnParent;
    public TextMeshProUGUI killCounter, gameText, levelNumberText, gauntletHighText, player1WinsText, player2WinsText, player3WinsText, player4WinsText,
        P1KillCounter, P2KillCounter, P3KillCounter, P4KillCounter, diamondsText, diamondsEarnText;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private ArcadeScript arcadeScript;
    private IntroLoopScriptDan bgmScript;
    private TutorialScript tutorialScript;
    private FollowPlayer cameraScript;
    private SoundsScript soundScript;
  //  MenuControls menuControls;

    public int gameMode;   //NEW 0 = Arcade, 1 = Survival, 2 = Gauntlet, 3 = Arena, 4 = Versus, 5 = Dodgeball, 6 = Control, 7 = Colosseum
                           //OLD 0 = Arcade Mode, 1 = Survival Mode, 2 = Versus Mode, 3 = Gauntlet, 4 = Dodgeball, 5 = Control
    public bool finalRound;
    public bool isGamePaused;
    public bool isGameOver;
    public bool allLevelsCompleted;
    private int survivalSetting; // survival settings for rounds change
    private bool didSoundPlayed;
    public bool startSettings;

    private int playersAtStart; // for survival settings
    public int playersTotal;
    public int pauseCheck1, pauseCheck2, pauseCheck3, pauseCheck4;
    public bool readPlayerData;
    public bool isPlayer1Alive, isPlayer2Alive, isPlayer3Alive, isPlayer4Alive;
    public int winner;
    public bool finishedLevel;

    public int enemiesSpawned;
    public int enemiesActive;
    public int enemyDefeated;
    public bool enemyStop;
    public bool allEnemiesDefeated;
    public int defeatedBossCount; // for level 2 where you have 2 bosses
    private bool addedRegularEnemies;
    private bool addEnemies;
    public byte player1Hits, player2Hits, player3Hits, player4Hits;

    public int powerUpsOnScreen;
    public int gauntletScore;
    private float enemiesStartDelay;
    private int randomBall1SpawnPos, randomBall2SpawnPos;
    private int randomP1SpawnPos, randomP2SpawnPos;
    private bool isTextsShown;
    private bool registerWinner;
    private bool wasShiftPressed;
    public bool didBallsSpawned; // Dodgebal mode check
    public byte gauntletEnemiesState;
    private int rareEnemyRate;
    public int howManyEnemiesSpawned;
    public bool startEnemyDisplay;
    public int enemyNumber;
    public int forceItemsSpawned;
    public int speedItemsSpawned;
    public int drunkItemsSpawned;
    public int growthItemsSpawned;
    public int blastItemsSpawned;
    public bool checkForceItemsSpawn;
    public bool checkSpeedItemsSpawn;
    public bool checkDrunkItemsSpawn;
    public bool checkGrowthItemsSpawn;
    public bool checkBlastItemsSpawn;
    public int itemNumber;
    public bool startItemsDisplay;
    public int totalItems;
    public bool lockRareEnemy;
    private bool lockInfo;
    public bool lockItems;
    public int itemsAvailable;
    public Vector3 ballSpawnPos1, ballSpawnPos2, ballSpawnPos3, ballSpawnPos4;

    public int P1Kills, P2Kills, P3Kills, P4Kills;

    public bool bossLock;
    #endregion
    /*
    private void Awake()
    {
        menuControls = new MenuControls();
        menuControls.Menu.Pause.performed += ctx => PauseFunction();
        menuControls.Menu.ShowInfo.performed += ctx => ShowInfoText();
        menuControls.Menu.Return.performed += ctx => ReturnToTitleScreen();
        menuControls.Menu.Restart.performed += ctx => RestartFunction();
    }
    private void OnEnable()
    {
        menuControls.Menu.Enable();
    }
    private void OnDisable()
    {
        menuControls.Menu.Disable();
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        //get player number
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
            playersTotal = masterScript.playersTotalReg;
        }
        diamondsText = GameObject.Find("Diamonds Count").GetComponent<TextMeshProUGUI>();
        diamondsBoss = GameObject.Find("Diamond Boss");
        pauseCheck1 = 2;
          enemiesStartDelay = 1f;
        switch (gameMode)
        {
            case 0:
                if (masterScript.sceneNumber !=52)
                {
                    itemsAvailable = 5;
                }
                else
                {
                    itemsAvailable = 999;
                }
                break;
            case 1:
                itemsAvailable = 8;
                break;
            case 3:
                itemsAvailable = 10;
                break;
            case 2:
            case 4:
            case 6:
            case 7:
                itemsAvailable = 999;
                break;
        }

        #region Find Sound And Players and player2Boss
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        bgmScript = GameObject.Find("New Bgm").GetComponent<IntroLoopScriptDan>();
        tutorialScript = GetComponent<TutorialScript>();
        if (gameMode == 2)
        {
            gauntletScore = jsonScript.so.gauntletHighScore;
        }
        backgroundPauseMenu = GameObject.Find("backgroundCV");
        if (!tutorialScript.tutorialLevel)
        {
            backgroundPauseMenu.SetActive(false);
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
        #endregion


        #region Other Starting Variables Set
     //   Debug.Log("scene number is " + sceneNumber);

        playersAtStart = playersTotal;
        Invoke("HideText", 0.01f);

        if (gameMode == 5)
        {
            //dodgebal mode settings
            playersTotal += 2;
            StartCoroutine(BallWait());
        }

        if (gameMode == 6)
        {
            //control mode settings
            GameObject PlayerChild = GameObject.Find("Player 2");
            GameObject Parent = PlayerChild.transform.parent.gameObject;
            GameObject BossObject = Parent.transform.GetChild(3).gameObject;
            BossObject.SetActive(true);
        }

        //Add high score text for gauntlet mode
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            if (gameMode == 2)
            {
                gauntletHighText.text = jsonScript.so.gauntletHighScore + " High";
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            diamondsText.text = "" + jsonScript.so.diamonds;
        }
        if (GameObject.Find("Boss4(Clone)") != null)
        {
            lockInfo = true;
        }
    //    Debug.Log("spawned " + howManyEnemiesSpawned + " limit " + arcadeScript.enemiesToBeat);
        if (howManyEnemiesSpawned == arcadeScript.enemiesToBeat)
        {
            startEnemyDisplay = true;
        }
        if (arcadeScript.spawnForceItem)
        {
            if (forceItemsSpawned == 10)
            {
                checkForceItemsSpawn = true;
            }
        }
        else
        {
            checkForceItemsSpawn = true;
        }
        if (arcadeScript.spawnSpeedItem)
        {
            if (speedItemsSpawned == 10)
            {
                checkSpeedItemsSpawn = true;
            }
        }
        else
        {
            checkSpeedItemsSpawn = true;
        }
        if (arcadeScript.spawnDrunkItem)
        {
            if (drunkItemsSpawned == 4)
            {
                checkDrunkItemsSpawn = true;
            }
        }
        else
        {
            checkDrunkItemsSpawn = true;
        }
        if (arcadeScript.spawnGrowthItem)
        {
            if (growthItemsSpawned == 8)
            {
                checkGrowthItemsSpawn = true;
            }
        }
        else
        {
            checkGrowthItemsSpawn = true;
        }
        if (arcadeScript.spawnBlastItem)
        {
            if (blastItemsSpawned == 2)
            {
                checkBlastItemsSpawn = true;
            }
        }
        else
        {
            checkBlastItemsSpawn = true;
        }
        if (checkForceItemsSpawn && checkSpeedItemsSpawn && checkDrunkItemsSpawn && checkGrowthItemsSpawn && checkBlastItemsSpawn)
        {
            startItemsDisplay = true;
        }
        totalItems = forceItemsSpawned + speedItemsSpawned + drunkItemsSpawned + growthItemsSpawned + blastItemsSpawned;
        itemNumber = Random.Range(0, totalItems-1);
        rareEnemyRate = Random.Range(1, 51);

        if (arcadeScript.levelState == 99)
        {
             if ((enemiesSpawned == arcadeScript.enemiesToBeat - 1 && !bossLock && gameMode !=1) ||
                (enemiesSpawned == arcadeScript.enemiesToBeat - 3 && !bossLock && gameMode == 1))
             {
                bossLock = true;
             }
             if ((enemyDefeated == arcadeScript.enemiesToBeat - 1 && bossLock && gameMode != 1) ||
                (enemyDefeated == arcadeScript.enemiesToBeat - 3 && bossLock && gameMode == 1))
             {
                bossLock = false;
                arcadeScript.levelState = 101;
             }
        }

        #region Invoke Methods
        if (!tutorialScript.tutorialLevel)
        {
            if ((gameMode == 0 || gameMode == 1 || gameMode == 2 || gameMode == 3) && !isGamePaused)
            {
                if (!IsInvoking("SetEnemy"))
                {
                    InvokeRepeating("SetEnemy", 0.01f, 0.1f);
                }
                if (!IsInvoking("SpawnEnemy") && startEnemyDisplay)
                {
                    InvokeRepeating("SpawnEnemy", enemiesStartDelay, arcadeScript.enemiesSpawnTime);
                }

                if (!IsInvoking("SetForcePowerup"))
                {
                    InvokeRepeating("SetForcePowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetSpeedPowerup"))
                {
                    InvokeRepeating("SetSpeedPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetDrunkPowerup"))
                {
                    InvokeRepeating("SetDrunkPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetGrowthPowerup"))
                {
                    InvokeRepeating("SetGrowthPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetBlastPowerup"))
                {
                    InvokeRepeating("SetBlastPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SpawnPowerups") && startItemsDisplay)
                {
                    InvokeRepeating("SpawnPowerups", 2, arcadeScript.powerupSpawnTime);
                }
            }
            else if ((gameMode == 4) && !isGamePaused)
            {
                if (!IsInvoking("SetForcePowerup"))
                {
                    InvokeRepeating("SetForcePowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetSpeedPowerup"))
                {
                    InvokeRepeating("SetSpeedPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetDrunkPowerup"))
                {
                    InvokeRepeating("SetDrunkPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SpawnPowerups") && startItemsDisplay)
                {
                    InvokeRepeating("SpawnPowerups", 2, arcadeScript.powerupSpawnTime);
                }
            }
            else if (gameMode == 6 && !isGamePaused)
            {
                if (!IsInvoking("SetEnemy"))
                {
                    InvokeRepeating("SetEnemy", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetForcePowerup"))
                {
                    InvokeRepeating("SetForcePowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetSpeedPowerup"))
                {
                    InvokeRepeating("SetSpeedPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetDrunkPowerup"))
                {
                    InvokeRepeating("SetDrunkPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SpawnPowerups") && startItemsDisplay)
                {
                    InvokeRepeating("SpawnPowerups", 2, arcadeScript.powerupSpawnTime);
                }
            }
            else if (gameMode == 7 && !isGamePaused)
            {
                if (!IsInvoking("SetGrowthPowerup"))
                {
                    InvokeRepeating("SetGrowthPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SetBlastPowerup"))
                {
                    InvokeRepeating("SetBlastPowerup", 0.01f, 0.1f);
                }
                if (!IsInvoking("SpawnPowerups") && startItemsDisplay)
                {
                    InvokeRepeating("SpawnPowerups", 2, arcadeScript.powerupSpawnTime);
                }
            }
        }
            #endregion
            /*
            #region Enemy Add in Gauntlet
            if (levelNumber == 6)
            {
                if (gauntletEnemiesState == 0 && enemyDefeated >= 10)
                {
                    enemies.RemoveAt(0);
                    enemies.Add(smallEnemy);
                    gauntletEnemiesState = 1;
                }
                if (gauntletEnemiesState == 1 && enemyDefeated >= 60)
                {
                    enemies.Add(bestEnemy);
                    enemies.Add(fastEnemy);
                    enemies.Add(survivalEnemy);
                    gauntletEnemiesState = 2;
                }
                if (gauntletEnemiesState == 2 && enemyDefeated >= 90)
                {
                    enemies.RemoveAt(0);
                    enemies.RemoveAt(0);
                    enemies.Add(boss2);
                    gauntletEnemiesState = 3;
                }
            }
            #endregion
            */
            #region Extra Starting Settings Part 1
            /*
            if (!startSettings)
            {
                StartCoroutine(Wait());
            }

            if (startSettings)
            {
                SpawnBoss();
                if (gameMode == 1)
                {
                    SurvivalModeSettings();
                }
            }*/
            #endregion

            #region Show Canvas (no strength text) [versus mode win text]
            if (gameMode == 0 && GameObject.Find("MASTER OBJECT") != null)
        {
         //   levelNumberText.text = "Level " + masterScript.levelNumber;
        }
        else if (gameMode == 1)
        {
        //    levelNumberText.text = "Survival";
        }
        else if ((gameMode == 4 || gameMode == 5) && GameObject.Find("MASTER OBJECT") !=null)
        {
            player1WinsText.text = "P1: " + masterScript.player1Wins;
            player2WinsText.text = "P2: " + masterScript.player2Wins;
            if (playersTotal > 2)
            {
                player3WinsText.text = "P3: " + masterScript.player3Wins;
            }
            if (playersTotal > 3)
            {
                player4WinsText.text = "P4: " + masterScript.player4Wins;
            }
        }
        else if (gameMode == 2)
        {
         //   levelNumberText.text = "Gauntlet";
        }
        else if (gameMode == 5)
        {
         //   levelNumberText.text = "Dodgeball";
            if (GameObject.Find("MASTER OBJECT") != null)
            {
                player1WinsText.text = "P1: " + masterScript.player1Wins;
                player2WinsText.text = "P2: " + masterScript.player2Wins;
            }
        }
        else if (gameMode == 6 || gameMode == 7)
        {
         //   levelNumberText.text = "Control ";
            if (GameObject.Find("MASTER OBJECT") != null)
            {
                player1WinsText.text = "P1: " + masterScript.player1Wins;
                player2WinsText.text = "P2: " + masterScript.player2Wins;
            }
        }


        //Show kill Counter text
        if (gameMode == 1 || gameMode == 2)
        {
            killCounter.text = "Kills: " + enemyDefeated;
        }
        // Kill Counter for Arena Mode
        if (gameMode == 3)
        {
            P1KillCounter.text = "P1 Kills: " + P1Kills;
            P2KillCounter.text = "P2 Kills: " + P2Kills;
            if (masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14)
            {
                P3KillCounter.text = "P3 Kills: " + P3Kills;
            }
            if (masterScript.multiplayerMode == 14)
            {
                P4KillCounter.text = "P4 Kills: " + P4Kills;
            }
        }

        if (gameMode == 4 || gameMode == 5 || gameMode == 6 || gameMode == 7)
        {
            //When only 1 player remain in versus mode, show the winner
            if (playersTotal <= 1)
            {
                LockPlayersControls();
                isGameOver = true;
                if (!didSoundPlayed)
                {
                    bgmScript.StopBgm();
                    soundScript.PlaySound("WinX");
                    didSoundPlayed = true;
                }
                StartCoroutine(WaitForWinner());
            }
        }

        IEnumerator WaitForWinner()
        {
            yield return new WaitForSeconds(0.1f);
            if (isPlayer1Alive)
            {
                winner = 1;
                if ((GameObject.Find("MASTER OBJECT") != null) && !registerWinner)
                {
                    masterScript.player1Wins++;
                    registerWinner = true;
                }
                PlayerScript playerScript1;
                playerScript1 = GameObject.Find("Player").GetComponent<PlayerScript>();
                /*
                if (gameMode != 5)
                {
                    playerScript1 = GameObject.Find("Player").GetComponent<PlayerScript>();
                }
                else
                {
                    playerScript1 = GameObject.Find("P1Dodgeball(Clone)").GetComponent<PlayerScript>();
                }*/
                playerScript1.inactive = true;
            }
            if (isPlayer2Alive)
            {
                winner = 2;
                if ((GameObject.Find("MASTER OBJECT") != null) && !registerWinner)
                {
                    masterScript.player2Wins++;
                    registerWinner = true;
                }
                PlayerScript playerScript2;
                playerScript2 = GameObject.Find("Player 2").GetComponent<PlayerScript>();

                playerScript2.inactive = true;
                /*
                if (masterScript.levelNumber != 5)
                {
                    PlayerScript playerScript2;
                    if (gameMode != 4)
                    {
                        playerScript2 = GameObject.Find("Player 2").GetComponent<PlayerScript>();
                    }
                    else
                    {
                        playerScript2 = GameObject.Find("P2Dodgeball(Clone)").GetComponent<PlayerScript>();
                    }
                    playerScript2.inactive = true;
                }*/
            }
            if (isPlayer3Alive)
            {
                winner = 3;
                if ((GameObject.Find("MASTER OBJECT") != null) && !registerWinner)
                {
                    masterScript.player3Wins++;
                    registerWinner = true;
                }
                PlayerScript playerScript3 = GameObject.Find("Player 3").GetComponent<PlayerScript>();
                playerScript3.inactive = true;
            }
            if (isPlayer4Alive)
            {
                winner = 4;
                if ((GameObject.Find("MASTER OBJECT") != null) && !registerWinner)
                {
                    masterScript.player4Wins++;
                    registerWinner = true;
                }
                PlayerScript playerScript4 = GameObject.Find("Player 4").GetComponent<PlayerScript>();
                playerScript4.inactive = true;
            }
            backgroundPauseMenu.SetActive(true);
            gameText.text = "Player " + winner + " wins!\nPress Enter or Start To Retry\nPress Escape or Circle To Return";
        }
        #endregion

        #region Check Level Status In Order To Restart, Start New Level Or Get Replay The First Level
        //If all players are dead then the game is over
        if (playersTotal <= 0)
        {
            GameOver();
        }

        if (arcadeScript.levelState == 100)   //allEnemiesDefeated
        {
            Debug.Log("LEVEL COMPLETE!!!");
            LevelComplete();
        }

        if (allLevelsCompleted)
        {
            RestartGame();
        }
        #endregion

        #region Show Strength Text Code
        if (gameMode !=5)
        {
            if (isTextsShown)
            {
                GameObject[] Parents = GameObject.FindGameObjectsWithTag("Parent");
                foreach (GameObject item in Parents)
                {
                    item.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            else
            {
                GameObject[] Items = GameObject.FindGameObjectsWithTag("InfoText");
                foreach (GameObject item in Items)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        #endregion

        #region Set Dodgeball bals position

        switch (masterScript.multiplayerMode)
        {
            case 32:
                //      ballSpawnPos1 = new Vector3(-7, 3, Random.Range(-6, 6));
                //      ballSpawnPos2 = new Vector3(7, 3, Random.Range(-6, 6));
                ballSpawnPos1 = new Vector3(-7, 3, 0);
                ballSpawnPos2 = new Vector3(7, 3, 0);
                break;

            case 33:
                int randomP1Chose = Random.Range(0, 2);
                float randomSpacer1 = Random.Range(0, 3.01f);
                float randomSpacer23 = Random.Range(0, 3.01f);
                if (randomP1Chose == 0)
                {
                    ballSpawnPos1 = new Vector3(-2-randomSpacer1, 3, 13 + randomSpacer1);
                }
                else if (randomP1Chose == 1)
                {
                    ballSpawnPos1 = new Vector3(2+randomSpacer1, 3, 13 + randomSpacer1);
                }
                ballSpawnPos2 = new Vector3(-8.5f+randomSpacer23, 3, 3-randomSpacer23);
                ballSpawnPos3 = new Vector3(8.5f-randomSpacer23, 3, 3-randomSpacer23);
                break;

            case 34:
                float randomSpacer = Random.Range(0, 4.01f);
                ballSpawnPos1 = new Vector3(-10+randomSpacer, 3, -6-randomSpacer);
                ballSpawnPos2 = new Vector3(10-randomSpacer, 3, -6-randomSpacer);
                ballSpawnPos3 = new Vector3(-10+randomSpacer, 3, 6+randomSpacer);
                ballSpawnPos4 = new Vector3(10-randomSpacer, 3, 6+randomSpacer);
                break;
        }

        #endregion
    }

    #region Dodgeball Spawn Code//////////////////////////////////////////////////////////////////////////////////////////////////////
    IEnumerator BallWait()
    {
        yield return new WaitForSeconds(0.1f);
        //    SpawnPlayers();
        switch (masterScript.multiplayerMode)
        {
            case 32:
                SpawnBall1a();
                SpawnBall2a();
                break;
            case 33:
                SpawnBall1b();
                SpawnBall2b();
                SpawnBall3b();
                break;
            case 34:
                SpawnBall1c();
                SpawnBall2c();
                SpawnBall3c();
                SpawnBall4c();
                break;
        }
        didBallsSpawned = true;
    }

    void SpawnPlayers()
    {
        float zSpawn1 = 0;
        float zSpawn2 = 0;
        switch (randomP1SpawnPos)
        {
            case 1:
                zSpawn1 = -16;
                break;
            case 2:
                zSpawn1 = -8;
                break;
            case 3:
                zSpawn1 = -0;
                break;
            case 4:
                zSpawn1 = 8;
                break;
            case 5:
                zSpawn1 = 16;
                break;

        }
        switch (randomP2SpawnPos)
        {
            case 1:
                zSpawn2 = -16;
                break;
            case 2:
                zSpawn2 = -8;
                break;
            case 3:
                zSpawn2 = -0;
                break;
            case 4:
                zSpawn2 = 8;
                break;
            case 5:
                zSpawn2 = 16;
                break;

        }
        Instantiate(P1Dod, new Vector3(-20, 3, zSpawn1), P1Dod.transform.rotation);
        Instantiate(P2Dod, new Vector3(20, 3, zSpawn2), P2Dod.transform.rotation);
        didBallsSpawned = true;
    }
    /////use it when ball get in 32 x-axis range
    public void SpawnBall1a()
    {
        Instantiate(ball1, ballSpawnPos1, ball1.transform.rotation);
    }
    public void SpawnBall2a()
    {
        Instantiate(ball2, ballSpawnPos2, ball2.transform.rotation);
    }
    public void SpawnBall1b()
    {
        Instantiate(ball1, ballSpawnPos1, ball1.transform.rotation);
    }
    public void SpawnBall2b()
    {
        Instantiate(ball2, ballSpawnPos2, ball2.transform.rotation);
    }
    public void SpawnBall3b()
    {
        Instantiate(ball3, ballSpawnPos3, ball3.transform.rotation);
    }
    public void SpawnBall1c()
    {
        Instantiate(ball1, ballSpawnPos1, ball1.transform.rotation);
    }
    public void SpawnBall2c()
    {
        Instantiate(ball2, ballSpawnPos2, ball2.transform.rotation);
    }
    public void SpawnBall3c()
    {
        Instantiate(ball3, ballSpawnPos3, ball3.transform.rotation);
    }
    public void SpawnBall4c()
    {
        Instantiate(ball4, ballSpawnPos4, ball4.transform.rotation);
    }
    #endregion


    #region Extra Starting Settings Part 2
    /*
    IEnumerator Wait()
        yield return new WaitForSeconds(0.0001f/10);
        switch (playersTotal)
        {
            case 1:
                enemySpawnRangeXZ -= enemySpawnRangeXZ / 20;
                powerupSpawnRangeXZ -= powerupSpawnRangeXZ / 20;
                ground.transform.localScale -= ground.gameObject.transform.localScale / 20;
                break;
            case 3:
                enemySpawnRangeXZ += enemySpawnRangeXZ / 20;
                powerupSpawnRangeXZ += powerupSpawnRangeXZ / 20;
                ground.transform.localScale += ground.gameObject.transform.localScale / 20;
                break;
            case 4:
                enemySpawnRangeXZ += enemySpawnRangeXZ / 10;
                powerupSpawnRangeXZ += powerupSpawnRangeXZ / 10;
                ground.transform.localScale += ground.gameObject.transform.localScale / 10;
                break;
        }
        startSettings = true;
    }
        */
    #endregion

    #region Spawn Enemy & Boss
    public void SetEnemy()
    {
   //     Debug.Log("Set Base");
        if (howManyEnemiesSpawned < arcadeScript.enemiesToBeat)
        {
       //     Debug.Log("Set Call");
            //    Debug.Log("spawned");
            float randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
            float randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
            Vector3 spawnPos = new Vector3(randomPosX, 0, randomPosZ);
            int randomIndex = Random.Range(0, enemies.Count);


            if (rareEnemyRate == 1 && !lockRareEnemy && gameMode == 0)
            {
        //        Debug.Log("Set 1");
                //Spawn rare golden enemy
                Instantiate(arcadeScript.enemyRare, spawnPos, arcadeScript.enemyRare.transform.rotation);
            }
            else if (gameMode == 6 && howManyEnemiesSpawned < 27)
            {
         //       Debug.Log("Set 2");
                Instantiate(enemies[0+howManyEnemiesSpawned], spawnPos, enemies[0+howManyEnemiesSpawned].transform.rotation);
                if (howManyEnemiesSpawned == 26)
                {
                    arcadeScript.enemiesToBeat = 20;
                }
            }
            else
            {
         //       Debug.Log("Set 3");
                //  Debug.Log("ENEMY APPEARED");
                Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
            }
            howManyEnemiesSpawned++;
        }
    }
    public void SpawnEnemy()
    {
        Debug.Log("Spawn Base");
        //Check if all enemies that you have to beat has spawned, if the limit of enemies per screen have been touched and if boss has spawned
        if ((enemiesSpawned < arcadeScript.enemiesToBeat) && (enemiesActive < arcadeScript.enemySpawnLimit) && !enemyStop && !isGamePaused && !bossLock)
        {
            Debug.Log("Spawn Call");
            GameObject Spawner = GameObject.Find("EnemiesParent");
        //    Debug.Log("enemy number " + enemyNumber);
            Spawner.transform.GetChild(enemyNumber).gameObject.SetActive(true);
            enemiesSpawned++;
            enemiesActive++;
            enemyNumber++;
        }
    }

    void SpawnBoss()
    {/*
        if (enemyDefeated >= arcadeScript.enemiesToBeat && !enemyStop && !isGamePaused && gameMode != 2 && gameMode != 4)
        {
            switch (arcadeScript.levelNumber)
            {
                case 1:
                    Instantiate(levelBoss, new Vector3(0, 3, 0), levelBoss.transform.rotation);
                    break;
                case 2:
                    Instantiate(levelBoss, new Vector3(-4, 2.6f, -4), levelBoss.transform.rotation);
                    Instantiate(levelBoss, new Vector3(4, 2.6f, 4), levelBoss.transform.rotation);
                    break;
                case 3:
                    Instantiate(levelBoss, new Vector3(0, 4, 0), levelBoss.transform.rotation);
                    break;
                case 4:
                    Instantiate(levelBoss, new Vector3(0, 5, 0), levelBoss.transform.rotation);
                    break;
                case 6:
                    RestartGame();
                    break;
            }
            musicScript.bossHasAppeared = true;
            if (gameMode == 5)
            {
                //Spawn player 2 control Boss
                FollowPlayer followplayerScript = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
                followplayerScript.secondPlayer2 = false;
                pl2Ref.SetActive(true);
                player2Script = GameObject.Find("Player 2").GetComponent<PlayerScript>();
                player2Script.strength = playerBossScript.strength;
                plC2Ref.SetActive(false);
            }
            enemyStop = true;
        }*/
            }
    #endregion

    #region Spawn Items
    void SetForcePowerup()
    {
        if (!isGamePaused && arcadeScript.spawnForceItem && forceItemsSpawned < 10)
        {
            Instantiate(forcePowerup, GenerateItemSpawnPos(), forcePowerup.transform.rotation);
            forceItemsSpawned++;
        }
    }
    void SetSpeedPowerup()
    {
        if ((!isGamePaused) && arcadeScript.spawnSpeedItem && (speedItemsSpawned < 10))
        {
            Instantiate(speedPowerup, GenerateItemSpawnPos(), speedPowerup.transform.rotation);
            speedItemsSpawned++;
        }
    }
    void SetDrunkPowerup()
    {
        if (!isGamePaused && arcadeScript.spawnDrunkItem && drunkItemsSpawned < 4)
        {
            Instantiate(drunkPowerup, GenerateItemSpawnPos(), drunkPowerup.transform.rotation);
            drunkItemsSpawned++;
        }
    }
    void SetGrowthPowerup()
    {
        if ((!isGamePaused) && arcadeScript.spawnGrowthItem && (growthItemsSpawned < 8))
        {
            Instantiate(growthPowerup, GenerateItemSpawnPos(), growthPowerup.transform.rotation);
            growthItemsSpawned++;
        }
    }
    void SetBlastPowerup()
    {
        if ((!isGamePaused) && arcadeScript.spawnBlastItem && (blastItemsSpawned < 2))
        {
            Instantiate(spherePowerup, GenerateItemSpawnPos(), spherePowerup.transform.rotation);
            blastItemsSpawned++;
        }
    }
    public void SpawnPowerups()
    {
        if (checkForceItemsSpawn && checkSpeedItemsSpawn && checkDrunkItemsSpawn && checkGrowthItemsSpawn && checkBlastItemsSpawn && itemsAvailable > 0)
        {
            if ((gameMode !=2 && powerUpsOnScreen < 10) || (gameMode == 2 && powerUpsOnScreen < 1))
            {
                GameObject Spawner = GameObject.Find("ItemsParent");
                if (!lockItems)
                {
                    Spawner.transform.GetChild(itemNumber).gameObject.SetActive(true);
                }
                if (lockItems)
                {
                    GameObject[] items = GameObject.FindGameObjectsWithTag("CapsuleParent");
                    foreach (GameObject item in items)
                    {
                        item.transform.gameObject.SetActive(false);
                    }
                }
                powerUpsOnScreen++;
            }
        }
    }/*
    void SpawnSuperForcePowerup()
    {
        if ((!isGamePaused) && ((gameMode != 3 && powerUpsOnScreen < 20) || (gameMode == 3 && powerUpsOnScreen < 1)))
        {
            Instantiate(superForcePowerup, GenerateItemSpawnPos(), forcePowerup.transform.rotation);
            powerUpsOnScreen++;
        }
    }
    void SpawnJumpPowerup()
    {
        if (!isGamePaused && powerUpsOnScreen < 20)
        {
            Instantiate(jumpPowerup, GenerateItemSpawnPos(), jumpPowerup.transform.rotation);
            powerUpsOnScreen++;
        }
    }*/
    private Vector3 GenerateItemSpawnPos()
    {
        float randomPosX = Random.Range(-arcadeScript.powerupSpawnRangeXZ, arcadeScript.powerupSpawnRangeXZ);
        float randomPosZ = Random.Range(-arcadeScript.powerupSpawnRangeXZ, arcadeScript.powerupSpawnRangeXZ);
        Vector3 spawnPos = new Vector3(randomPosX, 0, randomPosZ);
        return spawnPos;
    }
    #endregion

    #region Survival Mode Settings
    void SurvivalModeSettings()
    {/*
            //Change setting (check players number)
            if (playersAtStart == 1)
            {
                switch (enemyDefeated)
                {
                    case 0:
                        if (survivalSetting == 0)
                        {
                            enemySpawnLimit = 3;
                            survivalSetting = 1;
                        }
                        break;
                    case 1:
                        if (survivalSetting == 1)
                        {
                            ground.transform.localScale -= ground.gameObject.transform.localScale / 10;
                            enemySpawnRangeXZ -= enemySpawnRangeXZ / 10;
                            powerupSpawnRangeXZ -= powerupSpawnRangeXZ / 10;
                            enemySpawnLimit = 4;
                            enemies.Add(bestEnemy);
                            enemies.Add(fastEnemy);
                            enemies.Add(survivalEnemy);
                            survivalSetting = 2;
                        }
                        break;
                    case 2:
                        if (survivalSetting == 2)
                        {
                            ground.transform.localScale -= ground.gameObject.transform.localScale / 10;
                            enemySpawnRangeXZ -= enemySpawnRangeXZ / 10;
                            powerupSpawnRangeXZ -= powerupSpawnRangeXZ / 10;
                            enemySpawnLimit = 4;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.Add(boss1);
                            enemies.Add(boss2);
                            survivalSetting = 3;
                        }
                        break;
                    case 3:
                        if (survivalSetting == 3)
                        {
                            ground.transform.localScale -= ground.gameObject.transform.localScale / 10;
                            enemySpawnRangeXZ -= enemySpawnRangeXZ / 11;
                            powerupSpawnRangeXZ -= powerupSpawnRangeXZ / 11;
                            enemySpawnLimit = 5;
                            enemies.Add(boss3);
                            survivalSetting = 4;
                        }
                        break;
                    case 4:
                        if (survivalSetting == 4)
                        {
                            ground.transform.localScale -= ground.gameObject.transform.localScale / 10;
                            enemySpawnRangeXZ -= enemySpawnRangeXZ / 10;
                            powerupSpawnRangeXZ -= powerupSpawnRangeXZ / 10;
                            enemySpawnLimit = 6;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            survivalSetting = 5;
                        }
                        break;
                }
            }
            if (playersAtStart == 2)
            {
                switch (enemyDefeated)
                {
                    case 0:
                        if (survivalSetting == 0)
                        {
                            enemySpawnLimit = 3;
                            survivalSetting = 1;
                        }
                        break;
                    case 12:
                        if (survivalSetting == 1)
                        {
                            enemySpawnLimit = 5;
                            enemies.Add(bestEnemy);
                            enemies.Add(fastEnemy);
                            enemies.Add(survivalEnemy);
                            survivalSetting = 2;
                        }
                        break;
                    case 24:
                        if (survivalSetting == 2)
                        {
                            enemySpawnLimit = 5;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.Add(boss1);
                            enemies.Add(boss2);
                            survivalSetting = 3;
                        }
                        break;
                    case 36:
                        if (survivalSetting == 3)
                        {
                            enemySpawnLimit = 5;
                            enemies.Add(boss3);
                            survivalSetting = 4;
                        }
                        break;
                    case 48:
                        if (survivalSetting == 4)
                        {
                            enemySpawnLimit = 7;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            survivalSetting = 5;
                        }
                        break;
                }
            }
            if (playersAtStart == 3)
            {
                switch (enemyDefeated)
                {
                    case 0:
                        if (survivalSetting == 0)
                        {
                            enemySpawnLimit = 4;
                            survivalSetting = 1;
                        }
                        break;
                    case 14:
                        if (survivalSetting == 1)
                        {
                            enemySpawnLimit = 5;
                            enemies.Add(bestEnemy);
                            enemies.Add(fastEnemy);
                            enemies.Add(survivalEnemy);
                            survivalSetting = 2;
                        }
                        break;
                    case 28:
                        if (survivalSetting == 2)
                        {
                            enemySpawnLimit = 6;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.Add(boss1);
                            enemies.Add(boss2);
                            survivalSetting = 3;
                        }
                        break;
                    case 42:
                        if (survivalSetting == 3)
                        {
                            enemySpawnLimit = 6;
                            enemies.Add(boss3);
                            survivalSetting = 4;
                        }
                        break;
                    case 56:
                        if (survivalSetting == 4)
                        {
                            enemySpawnLimit = 7;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            survivalSetting = 5;
                        }
                        break;
                }
            }
            if (playersAtStart == 4)
            {
                switch (enemyDefeated)
                {
                    case 0:
                        if (survivalSetting == 0)
                        {
                            enemySpawnLimit = 4;
                            survivalSetting = 1;
                        }
                        break;
                    case 16:
                        if (survivalSetting == 1)
                        {
                            enemySpawnLimit = 6;
                            enemies.Add(bestEnemy);
                            enemies.Add(fastEnemy);
                            enemies.Add(survivalEnemy);
                            survivalSetting = 2;
                        }
                        break;
                    case 32:
                        if (survivalSetting == 2)
                        {
                            enemySpawnLimit = 6;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.Add(boss1);
                            enemies.Add(boss2);
                            survivalSetting = 3;
                        }
                        break;
                    case 48:
                        if (survivalSetting == 3)
                        {
                            enemySpawnLimit = 7;
                            enemies.Add(boss3);
                            survivalSetting = 4;
                        }
                        break;
                    case 62:
                        if (survivalSetting == 4)
                        {
                            enemySpawnLimit = 8;
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            enemies.RemoveAt(0);
                            survivalSetting = 5;
                        }
                        break;
                }
            }
        */
    }
    #endregion

    #region Game Over & Advance Level & Game Complete & ReturnToTitleScreen Functions
    public void GameOver()
    {
        jsonScript.Save();
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            isGameOver = true;
            backgroundPauseMenu.SetActive(true);
            if (gameMode <=3)
            {
                gameText.text = "Game Over!\nPress Enter or Start To Retry\nPress Escape or Select To Return To Title\nPress Backspace or Circle To Return To Map";

            }
            if (gameMode == 2)
            {
                gauntletScore = enemyDefeated;
                if (gauntletScore > jsonScript.so.gauntletHighScore)
                {
                    jsonScript.so.gauntletHighScore = gauntletScore;
                }
            }
            if (!didSoundPlayed)
            {
                bgmScript.StopBgm();
                soundScript.PlaySound("GameOver");
                didSoundPlayed = true;
            }
        //    if (Input.GetKeyDown(KeyCode.Return))
            {
           //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    //Advance to next level
    public void LevelComplete()
    {
        jsonScript.Save();
        LockPlayersControls();
        isGameOver = true;
        if (gameMode == 0)
        {
            backgroundPauseMenu.SetActive(true);
            gameText.text = "Level Complete!\nPress Enter or Start To Continue\nPress Escape or Circle To Return";
            finishedLevel = true;
            UnlockNewLevel();
        }
        else if (gameMode == 1 || gameMode == 2 || gameMode == 3)
        {
            if (gameMode == 1)
            {
                if (!jsonScript.so.isSurvivalFinished)
                {
                    int pay = 2000;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isSurvivalFinished = true;
                    jsonScript.so.isSkin15Available = true;
                    skinUnlockText.SetActive(true);
                }
            }
            if (gameMode == 2)
            {
                if (!jsonScript.so.isGauntletFinished)
                {
                    int pay = 2000;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isGauntletFinished = true;
                    jsonScript.so.isSkin15Available = true;
                    skinUnlockText.SetActive(true);
                }
            }
            backgroundPauseMenu.SetActive(true);
            gameText.text = "Level Complete!\nPress Enter or Start To Replay\nPress Escape or Circle To Return";
        }
        if (!didSoundPlayed)
        {
            bgmScript.StopBgm();
            soundScript.PlaySound("WinX");
            didSoundPlayed = true;
        }
    }

    //Restart Game mode
    public void RestartGame()
    {
        LockPlayersControls();
        isGameOver = true;
        backgroundPauseMenu.SetActive(true);
        gameText.text = "Congratulation!\nPress Enter or Start To Play Again";
        if (jsonScript.so.levelNumber == "gauntlet")
        {
            allLevelsCompleted = true;
            if (gameMode == 2)
            {
                gauntletScore = enemyDefeated;
                if (gauntletScore > jsonScript.so.gauntletHighScore)
                {
                    jsonScript.so.gauntletHighScore = gauntletScore;
                }
            }
        }
        if (!didSoundPlayed)
        {
            bgmScript.StopBgm();
            soundScript.PlaySound("WinX");
            didSoundPlayed = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Return))
        {/*
            if (masterScript.levelNumber == 4 || masterScript.levelNumber == 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            }*/
        }
    }

    public void ReturnToTitleScreen()
    {
        if ((isGamePaused && gameMode !=0)|| isGameOver)
        {
            //Get Back to Mode Select
            if (GameObject.Find("MASTER OBJECT"))
            {
                masterScript.player1Wins = 0;
                masterScript.player2Wins = 0;
                masterScript.player3Wins = 0;
                masterScript.player4Wins = 0;
                masterScript.playerCount = 0;
            }
            SceneManager.LoadScene("Title Screen");
        }
        if (gameMode == 0 && ((isGamePaused && !tutorialScript.tutorialLevel) || (!isGamePaused && tutorialScript.tutorialLevel)))
        {
            masterScript.playerCount = 0;
            SceneManager.LoadScene("Map Menu");
        }
    }
    public void RestartFunction()
    {
        if (isGamePaused || (isGameOver && gameMode != 0))
        {
            masterScript.playerCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (isGameOver && gameMode == 0 /*&& arcadeScript.levelState !=100*/)
        {
            masterScript.playerCount = 0;
            SceneManager.LoadScene("Map Menu");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    #region Text Code Part 2
    public void ShowInfoText()
    {
        if (!isGamePaused && !isGameOver && !wasShiftPressed && !lockInfo)
        {
            wasShiftPressed = true;
            isTextsShown = true;
            StartCoroutine(HideTextCoroutine());
        }
    }
    IEnumerator HideTextCoroutine()
    {
        if (isTextsShown)
        {
            yield return new WaitForSeconds(2);
            wasShiftPressed = false;
            isTextsShown = false;
        }
    }

    void HideText()
    {
        isTextsShown = false;
    }
    #endregion


    #region Pause Code
    public void PauseFunction()
    {
        if (!tutorialScript.tutorialLevel)
        {
            if (isGameOver)
            {
                if (gameMode != 0)
                {
                    RestartFunction();
                }
                else
                {
                    if (arcadeScript.levelState != 100)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    else
                    {
                        if (masterScript.sceneNumber  == 62)
                        {
                            SceneManager.LoadScene("Credits");
                        }
                        else
                        {
                            SceneManager.LoadScene("Map Menu");
                        }
                    }
                }
            }
            else if (!isGameOver && jsonScript.so.levelNumber != "L4-14")
            {
                if ((gameMode == 5 && didBallsSpawned) || (gameMode != 5 && !didBallsSpawned))
                {
                    if (!isGamePaused)
                    {
                        PauseGame();
                    }
                    else
                    {
                        UnpauseGame();
                    }
                }
            }
        }
        else
        {
            tutorialScript.Advance();
        }
    }
    public void PauseGame()
    {
        bgmScript.PauseBgm();
        CancelInvoke();
        //Get all moving objects into the parent Object
        if (gameMode < 10)
        {
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in Players)
            {
                player.gameObject.SetActive(false);
            }
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in Enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        }
        else
        {
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in Players)
            {
         //       player.transform.parent = ballParent.transform;
            }
         //   ballParent.transform.GetChild(0).gameObject.SetActive(false);
         //   ballParent.transform.GetChild(1).gameObject.SetActive(false);
        }
        isTextsShown = false;
        isGamePaused = true;
        pauseCheck1 = 1;
        pauseCheck2 = 1;
        pauseCheck3 = 1;
        pauseCheck4 = 1;
        backgroundPauseMenu.SetActive(true);
        gameText.text = "Press Enter or Start to resume\nPress Backspace or Circle To Restart\nPress Escape or Select To Return";
    }

    public void UnpauseGame()
    {
       // Debug.Log("work");
        StartCoroutine(UnpauseGameWait());
    }
    IEnumerator UnpauseGameWait()
    {
        yield return new WaitForSeconds(0.5f);
        bgmScript.ResumeBgm();
        cameraScript.readPlayers = false;
        if (gameMode < 10)
        {
            GameObject[] Parents = GameObject.FindGameObjectsWithTag("Parent");
            foreach (GameObject Parent in Parents)
            {
                Parent.transform.GetChild(0).gameObject.SetActive(true);
            }

            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in Players)
            {
                PlayerController playerScriptCtrl = player.GetComponent<PlayerController>();
                playerScriptCtrl.movementInput.x = 0;
                playerScriptCtrl.movementInput.y = 0;
            }
        }
        else
        {
            ballParent.transform.GetChild(0).gameObject.SetActive(true);
            ballParent.transform.GetChild(1).gameObject.SetActive(true);
        }
        isGamePaused = false;
        pauseCheck1 = 2;
        pauseCheck2 = 2;
        pauseCheck3 = 2;
        pauseCheck4 = 2;
        backgroundPauseMenu.SetActive(false);
        gameText.text = "";
    }
    #endregion

    #region Lock Controls
    void LockPlayersControls()
    {
        if (isPlayer1Alive)
        {
            PlayerScript playerScript1;
            playerScript1 = GameObject.Find("Player").GetComponent<PlayerScript>();
            playerScript1.inactive = true;
        }
        if (isPlayer2Alive)
        {
            PlayerScript playerScript2;
            if (gameMode !=6)
            {
                playerScript2 = GameObject.Find("Player 2").GetComponent<PlayerScript>();
                playerScript2.inactive = true;
            }
            else if (gameMode == 6)
            {
                playerScript2 = GameObject.Find("Player 2").GetComponent<PlayerScript>();
                playerScript2.inactive = true;
            }
        }
        if (isPlayer3Alive)
        {
            PlayerScript playerScript3 = GameObject.Find("Player 3").GetComponent<PlayerScript>();
            playerScript3.inactive = true;
        }
        if (isPlayer4Alive)
        {
            PlayerScript playerScript4 = GameObject.Find("Player 4").GetComponent<PlayerScript>();
            playerScript4.inactive = true;
        }
    }
    #endregion

    #region Escape Code Part 1
    public IEnumerator EnemyHitPlayer1()
    {
        player1Hits++;
     //   Debug.Log(player1Hits);
        yield return new WaitForSeconds(2);
        player1Hits = 0;
    }
    public IEnumerator EnemyHitPlayer2()
    {
        player2Hits++;
        yield return new WaitForSeconds(2);
        player2Hits = 0;
    }
    public IEnumerator EnemyHitPlayer3()
    {
        player3Hits++;
        yield return new WaitForSeconds(2);
        player3Hits = 0;
    }
    public IEnumerator EnemyHitPlayer4()
    {
        player4Hits++;
        yield return new WaitForSeconds(2);
        player4Hits = 0;
    }
    #endregion

    #region Levels Unlock
    public void UnlockNewLevel()
    {
        switch (jsonScript.so.levelNumber)
        {
            case "L0":
                if (!jsonScript.so.isLevel0Finished)
                {
                    int pay = 5;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x1Available = true;
                    jsonScript.so.isLevel0Finished = true;
                    jsonScript.Save();
                }
                break;
            case "L1-1":
                if (!jsonScript.so.isLevel1x1Finished)
                {
                    int pay = 20;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x2Available = true;
                    jsonScript.so.isSkin2Available = true;
                    skinUnlockText.SetActive(true);
                    jsonScript.so.isLevel1x1Finished = true;
                }
                break;
            case "L1-2":
                if (!jsonScript.so.isLevel1x2Finished)
                {
                    int pay = 40;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x3Available = true;
                    jsonScript.so.isLevel1x4Available = true;
                    jsonScript.so.isLevel1x2Finished = true;
                }
                break;
            case "L1-3":
                if (!jsonScript.so.isLevel1x3Finished)
                {
                    int pay = 60;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x5Available = true;
                    jsonScript.so.isLevel1x3Finished = true;
                }
                break;
            case "L1-4":
                if (!jsonScript.so.isLevel1x4Finished)
                {
                    int pay = 50;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x5Available = true;
                    jsonScript.so.isLevel1x4Finished = true;
                }
                break;
            case "L1-5":
                if (!jsonScript.so.isLevel1x5Finished)
                {
                    int pay = 70;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel1x6Available = true;
                    jsonScript.so.isLevel1x5Finished = true;
                }
                break;
            case "L1-6":
                if (!jsonScript.so.isLevel1x6Finished)
                {
                    int pay = 200;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x1Available = true;
                    jsonScript.so.isSkin10Available = true;
                    jsonScript.so.isSkin18Available = true;
                    jsonScript.so.isSkin19Available = true;
                    jsonScript.so.isSkin20Available = true;
                    jsonScript.so.isSkin21Available = true;
                    jsonScript.so.isSkin22Available = true;
                    jsonScript.so.isSkin23Available = true;
                    jsonScript.so.isSkin24Available = true;
                    jsonScript.so.isSkin25Available = true;
                    jsonScript.so.isSkin26Available = true;
                    jsonScript.so.isSkin27Available = true;
                    jsonScript.so.isSkin28Available = true;
                    jsonScript.so.isSkin29Available = true;
                    jsonScript.so.isSkin30Available = true;
                    jsonScript.so.isSkin31Available = true;
                    jsonScript.so.isSkin32Available = true;
                    jsonScript.so.isSkin33Available = true;
                    jsonScript.so.isSkin34Available = true;
                    jsonScript.so.isSkin35Available = true;
                    jsonScript.so.isSkin36Available = true;
                    jsonScript.so.isSkin37Available = true;
                    jsonScript.so.isSkin38Available = true;
                    jsonScript.so.isSkin39Available = true;
                    jsonScript.so.isSkin40Available = true;
                    jsonScript.so.isSkin41Available = true;
                    jsonScript.so.isSkin42Available = true;
                    jsonScript.so.isSkin43Available = true;
                    jsonScript.so.isSkin44Available = true;
                    jsonScript.so.isSkin45Available = true;
                    skinUnlockText.SetActive(true);
             //       jsonScript.so.isDodgeballAvailable = true;
                    jsonScript.so.isLevel1x6Finished = true;
                }
                break;
            case "L2-1":
                if (!jsonScript.so.isLevel2x1Finished)
                {
                    int pay = 150;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x2Available = true;
                    jsonScript.so.isLevel2x3Available = true;
                    jsonScript.so.isLevel2x1Finished = true;
                }
                break;
            case "L2-2":
                if (!jsonScript.so.isLevel2x2Finished)
                {
                    int pay = 170;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x4Available = true;
                    jsonScript.so.isLevel2x2Finished = true;
                }
                break;
            case "L2-3":
                if (!jsonScript.so.isLevel2x3Finished)
                {
                    int pay = 260;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x4Available = true;
                    jsonScript.so.isLevel2x3Finished = true;
                }
                break;
            case "L2-4":
                if (!jsonScript.so.isLevel2x4Finished)
                {
                    int pay = 210;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x5Available = true;
                    jsonScript.so.isLevel2x6Available = true;
                    jsonScript.so.isLevel2x7Available = true;
                    jsonScript.so.isLevel2x8Available = true;
                    jsonScript.so.isLevel2x4Finished = true;
                }
                break;
            case "L2-5":
                if (!jsonScript.so.isLevel2x5Finished)
                {
                    int pay = 230;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x5Finished = true;
                }
                jsonScript.so.isLevel2x9Available = true;
                break;
            case "L2-6":
                if (!jsonScript.so.isLevel2x6Finished)
                {
                    int pay = 220;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x9Available = true;
                    jsonScript.so.isLevel2x6Finished = true;
                }
                break;
            case "L2-7":
                if (!jsonScript.so.isLevel2x7Finished)
                {
                    int pay = 270;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x9Available = true;
                    jsonScript.so.isLevel2x7Finished = true;
                }
                break;
            case "L2-8":
                if (!jsonScript.so.isLevel2x8Finished)
                {
                    int pay = 240;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x9Available = true;
                    jsonScript.so.isLevel2x8Finished = true;
                }
                break;
            case "L2-9":
                if (!jsonScript.so.isLevel2x9Finished)
                {
                    int pay = 240;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x10Available = true;
                    jsonScript.so.isLevel2x11Available = true;
                    jsonScript.so.isLevel2x9Finished = true;
                }
                break;
            case "L2-10":
                if (!jsonScript.so.isLevel2x10Finished)
                {
                    int pay = 320;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x12Available = true;
                    jsonScript.so.isLevel2x10Finished = true;
                }
                break;
            case "L2-11":
                if (!jsonScript.so.isLevel2x11Finished)
                {
                    int pay = 310;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel2x12Available = true;
                    jsonScript.so.isLevel2x11Finished = true;
                }
                break;
            case "L2-12":
                if (!jsonScript.so.isLevel2x12Finished)
                {
                    int pay = 400;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x1Available = true;
                    jsonScript.so.isSkin11Available = true;
                    skinUnlockText.SetActive(true);
              //      jsonScript.so.isSurvivalAvailable = true;
                    jsonScript.so.isLevel2x12Finished = true;
                }
                break;
            case "L3-1":
                if (!jsonScript.so.isLevel3x1Finished)
                {
                    int pay = 340;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x2Available = true;
                    jsonScript.so.isLevel3x1Finished = true;
                }
                break;
            case "L3-2":
                if (!jsonScript.so.isLevel3x2Finished)
                {
                    int pay = 410;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x3Available = true;
                    jsonScript.so.isLevel3x2Finished = true;
                }
                break;
            case "L3-3":
                if (!jsonScript.so.isLevel3x3Finished)
                {
                    int pay = 420;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x4Available = true;
                    jsonScript.so.isLevel3x5Available = true;
                    jsonScript.so.isLevel3x3Finished = true;
                }
                break;
            case "L3-4":
                if (!jsonScript.so.isLevel3x4Finished)
                {
                    int pay = 360;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x6Available = true;
                    jsonScript.so.isLevel3x7Available = true;
                    jsonScript.so.isLevel3x4Finished = true;
                }
                break;
            case "L3-5":
                if (!jsonScript.so.isLevel3x5Finished)
                {
                    int pay = 340;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x7Available = true;
                    jsonScript.so.isLevel3x8Available = true;
                    jsonScript.so.isLevel3x5Finished = true;
                }
                break;
            case "L3-6":
                if (!jsonScript.so.isLevel3x6Finished)
                {
                    int pay = 390;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x9Available = true;
                    jsonScript.so.isLevel3x6Finished = true;
                }
                break;
            case "L3-7":
                if (!jsonScript.so.isLevel3x7Finished)
                {
                    int pay = 360;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x9Available = true;
                    jsonScript.so.isLevel3x7Finished = true;
                }
                break;
            case "L3-8":
                if (!jsonScript.so.isLevel3x8Finished)
                {
                    int pay = 420;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x9Available = true;
                    jsonScript.so.isLevel3x8Finished = true;
                }
                break;
            case "L3-9":
                if (!jsonScript.so.isLevel3x9Finished)
                {
                    int pay = 540;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x10Available = true;
                    jsonScript.so.isLevel3x11Available = true;
                    jsonScript.so.isLevel3x12Available = true;
                    jsonScript.so.isLevel3x13Available = true;
                    jsonScript.so.isLevel3x9Finished = true;
                }
                break;
            case "L3-10":
                if (!jsonScript.so.isLevel3x10Finished)
                {
                    int pay = 440;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x14Available = true;
                    jsonScript.so.isLevel3x10Finished = true;
                }
                break;
            case "L3-11":
                if (!jsonScript.so.isLevel3x11Finished)
                {
                    int pay = 430;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x14Available = true;
                    jsonScript.so.isLevel3x11Finished = true;
                }
                break;
            case "L3-12":
                if (!jsonScript.so.isLevel3x12Finished)
                {
                    int pay = 420;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x15Available = true;
                    jsonScript.so.isLevel3x12Finished = true;
                }
                break;
            case "L3-13":
                if (!jsonScript.so.isLevel3x13Finished)
                {
                    int pay = 410;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x15Available = true;
                    jsonScript.so.isLevel3x13Finished = true;
                }
                break;
            case "L3-14":
                if (!jsonScript.so.isLevel3x14Finished)
                {
                    int pay = 450;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x16Available = true;
                    jsonScript.so.isLevel3x14Finished = true;
                }
                break;
            case "L3-15":
                if (!jsonScript.so.isLevel3x15Finished)
                {
                    int pay = 530;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel3x16Available = true;
                    jsonScript.so.isLevel3x15Finished = true;
                }
                break;
            case "L3-16":
                if (!jsonScript.so.isLevel3x16Finished)
                {
                    int pay = 600;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x1Available = true;
                    jsonScript.so.isSkin12Available = true;
                    skinUnlockText.SetActive(true);
               //     jsonScript.so.isControlAvailable = true;
                    jsonScript.so.isLevel3x16Finished = true;
                }
                break;
            case "L4-1":
                if (!jsonScript.so.isLevel4x1Finished)
                {
                    int pay = 620;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x2Available = true;
                    jsonScript.so.isLevel4x1Finished = true;
                }
                break;
            case "L4-2":
                if (!jsonScript.so.isLevel4x2Finished)
                {
                    int pay = 570;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x3Available = true;
                    jsonScript.so.isLevel4x2Finished = true;
                }
                break;
            case "L4-3":
                if (!jsonScript.so.isLevel4x3Finished)
                {
                    int pay = 540;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x4Available = true;
                    jsonScript.so.isLevel4x5Available = true;
                    jsonScript.so.isLevel4x3Finished = true;
                }
                break;
            case "L4-4":
                if (!jsonScript.so.isLevel4x4Finished)
                {
                    int pay = 520;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x6Available = true;
                    jsonScript.so.isLevel4x4Finished = true;
                }
                break;
            case "L4-5":
                if (!jsonScript.so.isLevel4x5Finished)
                {
                    int pay = 480;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x7Available = true;
                    jsonScript.so.isLevel4x5Finished = true;
                }
                break;
            case "L4-6":
                if (!jsonScript.so.isLevel4x6Finished)
                {
                    int pay = 490;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x8Available = true;
                    jsonScript.so.isLevel4x6Finished = true;
                }
                break;
            case "L4-7":
                if (!jsonScript.so.isLevel4x7Finished)
                {
                    int pay = 520;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x8Available = true;
                    jsonScript.so.isLevel4x7Finished = true;
                }
                break;
            case "L4-8":
                if (!jsonScript.so.isLevel4x8Finished)
                {
                    int pay = 620;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x9Available = true;
                    jsonScript.so.isLevel4x8Finished = true;
                }
                break;
            case "L4-9":
                if (!jsonScript.so.isLevel4x9Finished)
                {
                    int pay = 630;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x10Available = true;
                    jsonScript.so.isLevel4x9Finished = true;
                }
                break;
            case "L4-10":
                if (!jsonScript.so.isLevel4x10Finished)
                {
                    int pay = 670;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x11Available = true;
                    jsonScript.so.isLevel4x12Available = true;
                    jsonScript.so.isLevel4x13Available = true;
                    jsonScript.so.isLevel4x10Finished = true;
                }
                break;
            case "L4-11":
                if (!jsonScript.so.isLevel4x11Finished)
                {
                    int pay = 710;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x14Available = true;
                    jsonScript.so.isLevel4x11Finished = true;
                }
                break;
            case "L4-12":
                if (!jsonScript.so.isLevel4x12Finished)
                {
                    int pay = 690;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x14Available = true;
                    jsonScript.so.isLevel4x12Finished = true;
                }
                break;
            case "L4-13":
                if (!jsonScript.so.isLevel4x13Finished)
                {
                    int pay = 620;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel4x14Available = true;
                    jsonScript.so.isLevel4x13Finished = true;
                }
                break;
            case "L4-14":
                if (!jsonScript.so.isLevel4x14Finished)
                {
                    int pay = 800;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x1Available = true;
                    jsonScript.so.isSkin13Available = true;
                    skinUnlockText.SetActive(true);
            //        jsonScript.so.isGauntletAvailable = true;
                    jsonScript.so.isLevel4x14Finished = true;
                }
                break;
            case "L5-1":
                if (!jsonScript.so.isLevel5x1Finished)
                {
                    int pay = 720;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x2Available = true;
                    jsonScript.so.isLevel5x3Available = true;
                    jsonScript.so.isLevel5x1Finished = true;
                }
                break;
            case "L5-2":
                if (!jsonScript.so.isLevel5x2Finished)
                {
                    int pay = 740;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x4Available = true;
                    jsonScript.so.isLevel5x2Finished = true;
                }
                break;
            case "L5-3":
                if (!jsonScript.so.isLevel5x3Finished)
                {
                    int pay = 680;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x4Available = true;
                    jsonScript.so.isLevel5x3Finished = true;
                }
                break;
            case "L5-4":
                if (!jsonScript.so.isLevel5x4Finished)
                {
                    int pay = 640;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x5Available = true;
                    jsonScript.so.isLevel5x6Available = true;
                    jsonScript.so.isLevel5x4Finished = true;
                }
                break;
            case "L5-5":
                if (!jsonScript.so.isLevel5x5Finished)
                {
                    int pay = 730;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x7Available = true;
                    jsonScript.so.isLevel5x5Finished = true;
                }
                break;
            case "L5-6":
                if (!jsonScript.so.isLevel5x6Finished)
                {
                    int pay = 760;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x7Available = true;
                    jsonScript.so.isLevel5x6Finished = true;
                }
                break;
            case "L5-7":
                if (!jsonScript.so.isLevel5x7Finished)
                {
                    int pay = 900;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x8Available = true;
                    jsonScript.so.isLevel5x7Finished = true;
                }
                break;
            case "L5-8":
                if (!jsonScript.so.isLevel5x8Finished)
                {
                    int pay = 940;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x9Available = true;
                    jsonScript.so.isLevel5x8Finished = true;
                }
                break;
            case "L5-9":
                if (!jsonScript.so.isLevel5x9Finished)
                {
                    int pay = 990;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isLevel5x10Available = true;
                    jsonScript.so.isLevel5x9Finished = true;
                }
                break;
            case "L5-10":
                if (!jsonScript.so.isLevel5x10Finished)
                {
                    int pay = 2000;
                    jsonScript.so.diamonds += pay;
                    diamondsBoss.transform.GetChild(0).gameObject.SetActive(true);
                    diamondsEarnText = GameObject.Find("Diamonds Earn Count").GetComponent<TextMeshProUGUI>();
                    diamondsEarnText.text = "" + pay;
                    jsonScript.so.isSkin14Available = true;
                    jsonScript.so.isSkin46Available = true;
                    jsonScript.so.isSkin47Available = true;
                    jsonScript.so.isSkin48Available = true;
                    jsonScript.so.isSkin49Available = true;
                    jsonScript.so.isSkin50Available = true;
                    jsonScript.so.isSkin51Available = true;
                    jsonScript.so.isSkin52Available = true;
                    jsonScript.so.isSkin105Available = true;
                    jsonScript.so.isSkin106Available = true;
                    jsonScript.so.isSkin107Available = true;
                    jsonScript.so.isSkin108Available = true;
                    jsonScript.so.isSkin109Available = true;
                    jsonScript.so.isSkin110Available = true;
                    skinUnlockText.SetActive(true);
            //        jsonScript.so.isArenaAvailable = true;
                    jsonScript.so.isLevel5x10Finished = true;
                    //Scroll Credits
                }
                break;
        }
        jsonScript.Save();
    }
    #endregion
}
