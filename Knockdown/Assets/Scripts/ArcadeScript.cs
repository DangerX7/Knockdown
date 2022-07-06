using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeScript : MonoBehaviour
{
    #region Set Initial Variables
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SpawnManagerScript spawnManager;
    private IntroLoopScriptDan bgmScript;

    public int levelState;
    public int holeCount;

    public int enemiesSpawnTime;
    public int enemySpawnLimit;
    public int enemiesToBeat;
    public float enemySpawnRangeXZ;

    public float powerupSpawnRangeXZ;
    public int powerupSpawnTime;
    public bool spawnForceItem;
    public bool spawnSpeedItem;
    public bool spawnDrunkItem;
    public bool spawnJumpItem;
    public bool spawnGrowthItem;
    public bool spawnBlastItem;

    public int enemiesLeft;
    public int clonesCount;
    public float finalFightHp;
    private bool terminateBall;
    private int enemyBarSpawnCount = 0;
    private bool go;
    private bool bossTrackCheck;
    private bool finalSwitch;

    int limit1;
    int limit2;
    int limit3;
    int limit4;
    int limit5;

    public GameObject fence, lastItems, ball, secondPhase, enemyCountRef, canvas, finalStatusBall, finalStatusLine, ItemsParent, enemy1a, enemy1b, enemy1c, enemy1d, enemy2a, enemy2b, enemy2c, enemy2d, enemy2e, enemy3a, enemy3b, enemy3c, enemy3d, enemy3e,
        enemy4a, enemy4b, enemy4c, enemy4d, enemy4e, enemy5a, enemy5b, enemy5c, enemy5d, enemy5e, enemy5f, enemy5g, enemy5h, enemyRare,
        boss, boss1, boss2, diamondsIconRef, diamondsInfoRef;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Read Start values
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
        SetLevelData();
        secondPhase.gameObject.SetActive(true);
        spawnManager = secondPhase.GetComponent<SpawnManagerScript>();
        bgmScript = GameObject.Find("New Bgm").GetComponent<IntroLoopScriptDan>();
        SpawnObjects();
        go = true;
        enemiesLeft = enemiesToBeat;
        enemyBarSpawnCount = 30;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log("l" + levelState + " e" + spawnManager.howManyEnemiesSpawned);
        //Add enemies in the level
        if (secondPhase != null)
        {
            UpdateLevelData();
        }
        //Add Enemies ball counters (UI)
        if (go)
        {
            SpawnEnemyBar();
        }
        //Clone Counter for level 4 boss
        if (clonesCount == 8)
        {
            LavaScript lavaScript = GameObject.Find("BackLava").GetComponent<LavaScript>();
            lavaScript.stop = true;
            levelState = 100;
        }

        #region Final fight conclusion
        if (!terminateBall)
        {
            if (finalFightHp >= 3000 && finalSwitch)
            {
                bgmScript.StopBgm();
                bgmScript.Boss_5BgmX();
                GameObject boss = GameObject.Find("Boss");
                EnemyScript enemyScript = boss.GetComponent<EnemyScript>();
                enemyScript.strength = 1100;
                enemyScript.speed = 7000;
                lastItems.SetActive(true);
                finalSwitch = false;
            }
            if (finalFightHp >= 4000)
            {
                GameObject boss = GameObject.Find("Boss");
                EnemyScript enemyScript = boss.GetComponent<EnemyScript>();
                enemyScript.strength = 200;
                enemyScript.speed = 6000;
                fence.SetActive(false);
                terminateBall = true;
            }
            if (finalFightHp <= -4000)
            {
                GameObject[] Balls = GameObject.FindGameObjectsWithTag("Parent");
                foreach (GameObject player in Balls)
                {
                    if (player.name.StartsWith("P1"))
                    {
                        GameObject child = player.transform.GetChild(0).gameObject;
                        PlayerScript playerScript = child.GetComponent<PlayerScript>();
                        playerScript.strength = 100;
                        PlayerController playerController = child.GetComponent<PlayerController>();
                        playerController.speed = 8000;
                    }
                }
                GameObject energyManager = GameObject.Find("EnergyManager");
                EnergyScript energyScript = energyManager.GetComponent<EnergyScript>();
                energyScript.currentEnergy1 = 0;
                fence.SetActive(false);
                terminateBall = true;
            }
        }
        #endregion

        GameObject[] Holes = GameObject.FindGameObjectsWithTag("HoleUp");
        holeCount = Holes.Length;
    }

    #region Arcade Mode Start Settings
    public void SetLevelData()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            switch (jsonScript.so.levelNumber)
            {
                #region Chapter 1
                case "L1-1":
                    
                    enemiesSpawnTime = 10;
                    enemySpawnLimit = 1;
                    enemiesToBeat = 4;
                    spawnForceItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L1-2":
                    
                    enemiesSpawnTime = 8;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 5;
                    spawnForceItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L1-3":
                    
                    enemiesSpawnTime = 7;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L1-4":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 7;
                    powerupSpawnRangeXZ = 8;
                    break;
                case "L1-5":
                    
                    enemiesSpawnTime = 6;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 9;
                    spawnForceItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 4.2f;
                    powerupSpawnRangeXZ = 4.5f;
                    break;
                case "L1-6":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 11;
                    spawnForceItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5.5f;
                    powerupSpawnRangeXZ = 6.6f;
                    break;
                #endregion
                #region Chapter 2
                case "L2-1":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L2-2":
                    
                    enemiesSpawnTime = 10;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 8;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L2-3":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 10;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 4.6f;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L2-4":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 4.2f;
                    powerupSpawnRangeXZ = 5.1f;
                    break;
                case "L2-5":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 6;
                    enemySpawnRangeXZ = 3.2f;
                    powerupSpawnRangeXZ = 4.1f;
                    break;
                case "L2-6":
                    
                    enemiesSpawnTime = 2;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 5;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 4.2f;
                    powerupSpawnRangeXZ = 5.1f;
                    break;
                case "L2-7":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L2-8":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L2-9":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 3;
                    powerupSpawnRangeXZ = 4;
                    break;
                case "L2-10":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 4;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 4.3f;
                    powerupSpawnRangeXZ = 5.2f;
                    break;
                case "L2-11":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 3.3f;
                    powerupSpawnRangeXZ = 4.2f;
                    break;
                case "L2-12":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 9;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 4.3f;
                    powerupSpawnRangeXZ = 5.2f;
                    break;
                #endregion
                #region Chapter 3
                case "L3-1":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 5;
                    spawnForceItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L3-2":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 4.3f;
                    powerupSpawnRangeXZ = 4.5f;
                    break;
                case "L3-3":
                    
                    enemiesSpawnTime = 8;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L3-4":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 9;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 6;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L3-5":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 4;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 4.4f;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L3-6":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L3-7":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 12;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L3-8":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 2.8f;
                    powerupSpawnRangeXZ = 3.4f;
                    break;
                case "L3-9":
                    
                    enemiesSpawnTime = 2;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 6;
                    powerupSpawnRangeXZ = 7.6f;
                    break;
                case "L3-10":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 14;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 6;
                    powerupSpawnRangeXZ = 7.5f;
                    break;
                case "L3-11":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 6.2f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L3-12":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 3;
                    powerupSpawnRangeXZ = 4;
                    break;
                case "L3-13":
                    
                    enemiesSpawnTime = 10;
                    enemySpawnLimit = 5;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L3-14":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 5;
                    enemiesToBeat = 20;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 6;
                    powerupSpawnRangeXZ = 7;
                    break;
                case "L3-15":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 3;
                    powerupSpawnRangeXZ = 4;
                    break;
                case "L3-16":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 13;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                #endregion
                #region Chapter 4
                case "L4-1":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "L4-2":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 6;
                    powerupSpawnRangeXZ = 7;
                    break;
                case "L4-3":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 10;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 3.2f;
                    powerupSpawnRangeXZ = 3.3f;
                    break;
                case "L4-4":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 3.2f;
                    powerupSpawnRangeXZ = 3.3f;
                    break;
                case "L4-5":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 5;
                    enemiesToBeat = 5;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L4-6":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 9;
                    spawnForceItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 3.2f;
                    powerupSpawnRangeXZ = 4.33f;
                    break;
                case "L4-7":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 13;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 6;
                    powerupSpawnRangeXZ = 7;
                    break;
                case "L4-8":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 7;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6.2f;
                    break;
                case "L4-9":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 11;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L4-10":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 7;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5.5f;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L4-11":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 11;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 4.5f;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L4-12":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 4;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L4-13":
                    
                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 16;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 4;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L4-14":
                    
                    enemiesSpawnTime = 4;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 19;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 4.5f;
                    powerupSpawnRangeXZ = 5.4f;
                    break;
                #endregion
                #region Chapter 5
                case "L5-1":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 10;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 4;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L5-2":
                    
                    enemiesSpawnTime = 2;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 12;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 4;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L5-3":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "L5-4":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 5;
                    enemiesToBeat = 6;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 2.8f;
                    powerupSpawnRangeXZ = 3.4f;
                    break;
                case "L5-5":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 13;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 3;
                    powerupSpawnRangeXZ = 3.2f;
                    break;
                case "L5-6":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 10;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 2;
                    enemySpawnRangeXZ = 3.3f;
                    powerupSpawnRangeXZ = 4.2f;
                    break;
                case "L5-7":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 4;
                    enemiesToBeat = 8;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L5-8":
                    
                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 6;
                    enemiesToBeat = 30;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 1;
                    enemySpawnRangeXZ = 10;
                    powerupSpawnRangeXZ = 11;
                    break;
                case "L5-9":
                    
                    enemiesSpawnTime = 3;
                    enemySpawnLimit = 2;
                    enemiesToBeat = 5;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 1;
                    enemySpawnRangeXZ = 4;
                    powerupSpawnRangeXZ = 5;
                    break;
                case "L5-10":
                    
                    enemiesSpawnTime = 1;//3
                    enemySpawnLimit = 4;
                    enemiesToBeat = 28;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 1;
                    enemySpawnRangeXZ = 5;
                    powerupSpawnRangeXZ = 6;
                    break;
                #endregion
                #region Others

                case "survival":

                    enemiesSpawnTime = 5;
                    enemySpawnLimit = 3;
                    enemiesToBeat = 53;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "gauntlet":

                    enemiesSpawnTime = 1;
                    enemySpawnLimit = 5;
                    enemiesToBeat = 101;
                    spawnForceItem = true;
                    powerupSpawnTime = 5;
                    enemySpawnRangeXZ = 4.0f;
                    powerupSpawnRangeXZ = 4.2f;
                    break;
                case "arena":

                    switch (masterScript.multiplayerMode)
                    {
                        case 12:
                            enemiesSpawnTime = 4;
                            enemySpawnLimit = 3;
                            enemiesToBeat = 31;
                            break;
                        case 13:
                            enemiesSpawnTime = 3;
                            enemySpawnLimit = 4;
                            enemiesToBeat = 41;
                            break;
                        case 14:
                            enemiesSpawnTime = 2;
                            enemySpawnLimit = 5;
                            enemiesToBeat = 51;
                            break;
                    }
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnTime = 3;
                    enemySpawnRangeXZ = 5.8f;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "versus":
                    
                    switch (masterScript.multiplayerMode)
                    {
                        case 22:
                            powerupSpawnTime = 4;
                            break;
                        case 33:
                            powerupSpawnTime = 3;
                            break;
                        case 44:
                            powerupSpawnTime = 2;
                            break;
                    }
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    spawnDrunkItem = true;
                    powerupSpawnRangeXZ = 6.5f;
                    break;
                case "dodgeball":
                    
                    break;
                case "control":
                    enemySpawnLimit = 3;
                    enemiesToBeat = 27;
                    spawnForceItem = true;
                    spawnSpeedItem = true;
                    powerupSpawnRangeXZ = 6;
                    break;
                case "colosseum":
                    powerupSpawnTime = 5;
                    spawnGrowthItem = true;
                    spawnBlastItem = true;
                    powerupSpawnRangeXZ = 13;
                    break;
                    #endregion
            }
        }
    }
    #endregion

    #region Arcade Mode Update Settings
    public void UpdateLevelData()
    {
        if (GameObject.Find("MASTER OBJECT") !=null)
        {
            switch (jsonScript.so.levelNumber)
            {
                #region Chapter 1
                case "L1-1":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;
                    }
                    break;
                case "L1-2":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;
                    }
                    break;
                case "L1-3":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Remove(enemy1c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L1-4":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Add(enemy1c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy1b);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L1-5":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy1c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L1-6":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Add(enemy1c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 7)
                            {
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 10)
                            {
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.lockRareEnemy = true;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                            //    enemiesToBeat = 11;
                                Debug.Log("Boss Added");
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_1Bgm();
                                bossTrackCheck = true;
                            }
                            break;
                    }
                    break;
                #endregion
                #region Chapter 2
                case "L2-1":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-2":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 7)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-3":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Remove(enemy2a);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Remove(enemy2c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-4":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-5":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-6":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-7":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy2c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-8":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy2c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Remove(enemy2b);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-9":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy5g);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-10":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-11":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 9)
                            {
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L2-12":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.lockRareEnemy = true;
                             //   enemiesToBeat = 9;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_2Bgm();
                                bossTrackCheck = true;
                            }
                            break;

                    }
                    break;
                #endregion
                #region Chapter 3
                case "L3-1":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-2":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-3":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-4":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-5":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Add(enemy3a);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-6":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-7":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-8":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 7)
                            {
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-9":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-10":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 9)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-11":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-12":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-13":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-14":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 12)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-15":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L3-16":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 12)
                            {
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.lockRareEnemy = true;
                            //    enemiesToBeat = 13;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                fence.SetActive(true);
                                bgmScript.StopBgm();
                                bgmScript.Boss_3Bgm();
                                bossTrackCheck = true;
                            }
                            break;
                    }
                    break;
                #endregion
                #region Chapter 4
                case "L4-1":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Add(enemy4a);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-2":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-3":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-4":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-5":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-6":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-7":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-8":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-9":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-10":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-11":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-12":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Remove(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-13":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L4-14":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 12)
                            {
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 18)
                            {
                                spawnManager.enemies.Remove(enemy4d);
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.lockRareEnemy = true;
                              //  enemiesToBeat = 19;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_4Bgm();
                                bossTrackCheck = true;
                            }
                            break;
                    }
                    break;
                #endregion
                #region Chapter 5
                case "L5-1":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Add(enemy5c);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-2":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy5a);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 10)
                            {
                                spawnManager.enemies.Add(enemy5d);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-3":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Remove(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-4":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-5":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy5b);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5g);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-6":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5g);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-7":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-8":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-9":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5e);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= enemiesToBeat)
                            {
                                levelState = 100;
                            }
                            break;

                    }
                    break;
                case "L5-10":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy5a);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 1)
                            {
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Add(enemy1a);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 2)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Add(enemy2c);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 3)
                            {
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Add(enemy3b);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.howManyEnemiesSpawned >= 4)
                            {
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Add(enemy5c);
                                levelState = 5;
                            }
                            break;
                        case 5:
                            if (spawnManager.howManyEnemiesSpawned >= 5)
                            {
                                spawnManager.enemies.Remove(enemy5c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 6;
                            }
                            break;
                        case 6:
                            if (spawnManager.howManyEnemiesSpawned >= 6)
                            {
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 7;
                            }
                            break;
                        case 7:
                            if (spawnManager.howManyEnemiesSpawned >= 7)
                            {
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                levelState = 8;
                            }
                            break;
                        case 8:
                            if (spawnManager.howManyEnemiesSpawned >= 8)
                            {
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Add(enemy3c);
                                levelState = 9;
                            }
                            break;
                        case 9:
                            if (spawnManager.howManyEnemiesSpawned >= 9)
                            {
                                spawnManager.enemies.Remove(enemy3c);
                                spawnManager.enemies.Add(enemy1c);
                                levelState = 10;
                            }
                            break;
                        case 10:
                            if (spawnManager.howManyEnemiesSpawned >= 10)
                            {
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Add(enemy2b);
                                levelState = 11;
                            }
                            break;
                        case 11:
                            if (spawnManager.howManyEnemiesSpawned >= 11)
                            {
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 12;
                            }
                            break;
                        case 12:
                            if (spawnManager.howManyEnemiesSpawned >= 12)
                            {
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy5d);
                                levelState = 13;
                            }
                            break;
                        case 13:
                            if (spawnManager.howManyEnemiesSpawned >= 13)
                            {
                                spawnManager.enemies.Remove(enemy5d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 14;
                            }
                            break;
                        case 14:
                            if (spawnManager.howManyEnemiesSpawned >= 14)
                            {
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy5g);
                                levelState = 15;
                            }
                            break;
                        case 15:
                            if (spawnManager.howManyEnemiesSpawned >= 15)
                            {
                                spawnManager.enemies.Remove(enemy5g);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 16;
                            }
                            break;
                        case 16:
                            if (spawnManager.howManyEnemiesSpawned >= 16)
                            {
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.enemies.Add(enemy5f);
                                levelState = 17;
                            }
                            break;
                        case 17:
                            if (spawnManager.howManyEnemiesSpawned >= 17)
                            {
                                spawnManager.enemies.Remove(enemy5f);
                                spawnManager.enemies.Add(enemy1b);
                                levelState = 18;
                            }
                            break;
                        case 18:
                            if (spawnManager.howManyEnemiesSpawned >= 18)
                            {
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Add(enemy4c);
                                levelState = 19;
                            }
                            break;
                        case 19:
                            if (spawnManager.howManyEnemiesSpawned >= 19)
                            {
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Add(enemy5e);
                                levelState = 20;
                            }
                            break;
                        case 20:
                            if (spawnManager.howManyEnemiesSpawned >= 20)
                            {
                                spawnManager.enemies.Remove(enemy5e);
                                spawnManager.enemies.Add(enemy2a);
                                levelState = 21;
                            }
                            break;
                        case 21:
                            if (spawnManager.howManyEnemiesSpawned >= 21)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Add(enemy4d);
                                levelState = 22;
                            }
                            break;
                        case 22:
                            if (spawnManager.howManyEnemiesSpawned >= 22)
                            {
                                spawnManager.enemies.Remove(enemy4d);
                                spawnManager.enemies.Add(enemy3a);
                                levelState = 23;
                            }
                            break;
                        case 23:
                            if (spawnManager.howManyEnemiesSpawned >= 23)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 24;
                            }
                            break;
                        case 24:
                            if (spawnManager.howManyEnemiesSpawned >= 24)
                            {
                                spawnManager.enemies.Remove(enemy5h);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 25;
                            }
                            break;
                        case 25:
                            if (spawnManager.howManyEnemiesSpawned >= 25)
                            {
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Add(enemy3d);
                                levelState = 26;
                            }
                            break;
                        case 26:
                            if (spawnManager.howManyEnemiesSpawned >= 26)
                            {
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Add(enemy5b);
                                levelState = 27;
                            }
                            break;
                        case 27:
                            if (spawnManager.howManyEnemiesSpawned >= 27)
                            {
                                spawnManager.enemies.Remove(enemy5b);
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                Debug.Log("AppearFinalBoss");
                                GameObject[] Balls = GameObject.FindGameObjectsWithTag("Parent");
                                foreach (GameObject player in Balls)
                                {
                                    if (player.name.StartsWith("P1"))
                                    {
                                        GameObject child = player.transform.GetChild(0).gameObject;
                                        PlayerScript playerScript = child.GetComponent<PlayerScript>();
                                        playerScript.strength = 800;
                                        PlayerController playerScript2 = child.GetComponent<PlayerController>();
                                        playerScript2.speed = 24000;
                                    }
                                }
                                spawnManager.enemies.Remove(enemy5b);
                                spawnManager.lockItems = true;
                                spawnManager.lockRareEnemy = true;
                                ball.SetActive(false);
                                fence.SetActive(true);
                                finalStatusBall.SetActive(true);
                                finalStatusLine.SetActive(true);
                           //     enemiesToBeat = 28;//DO NOT CHANGE, it is linked with energy consumption
                                bgmScript.StopBgm();
                                bgmScript.Boss_5Bgm();
                                bossTrackCheck = true;
                                diamondsInfoRef.SetActive(false);
                                diamondsIconRef.SetActive(false);
                                finalSwitch = true;
                            }
                            break;
                    }
                    break;
                #endregion
                #region Others
                case "survival":
                    if (spawnManager.enemyDefeated >= 10)
                    {
                  //      levelState = 2;
                    }
                    if (spawnManager.enemyDefeated >= 20)
                    {
                  //      levelState = 3;
                    }
                    if (spawnManager.enemyDefeated >= 30)
                    {
                  //      levelState = 4;
                    }
                    if (spawnManager.enemyDefeated >= 40)
                    {
                  //      levelState = 5;
                    }
                    if (spawnManager.enemyDefeated >= 50)
                    {
                  //      levelState = 6;
                    }
                    if (spawnManager.enemyDefeated >= 51)
                    {
                  //      levelState = 7;
                    }
                    if (spawnManager.enemyDefeated >= 52)
                    {
                 //       levelState = 99;
                    }
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 10)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 20)
                            {
                                if (spawnManager.enemyDefeated >=20)
                                {
                                    enemySpawnLimit = 4;
                                }
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 30)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.howManyEnemiesSpawned >= 40)
                            {
                                if (spawnManager.enemyDefeated >= 20)
                                {
                                    enemySpawnLimit = 5;
                                }
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Remove(enemy4d);
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 5;
                            }
                            break;
                        case 5:
                            if (spawnManager.howManyEnemiesSpawned >= 50)
                            {
                                spawnManager.lockRareEnemy = true;
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Remove(enemy5b);
                                spawnManager.enemies.Remove(enemy5c);
                                spawnManager.enemies.Remove(enemy5d);
                                spawnManager.enemies.Remove(enemy5e);
                                spawnManager.enemies.Remove(enemy5f);
                                spawnManager.enemies.Remove(enemy5g);
                                spawnManager.enemies.Remove(enemy5h);
                            //    enemiesToBeat = 53;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 6;
                            }
                            break;
                        case 6:
                            if (spawnManager.howManyEnemiesSpawned >= 51)
                            {
                                spawnManager.enemies.Remove(boss);
                                spawnManager.enemies.Add(boss1);
                                levelState = 7;
                            }
                            break;
                        case 7:
                            if (spawnManager.howManyEnemiesSpawned >= 52)
                            {
                                spawnManager.enemies.Remove(boss1);
                                spawnManager.enemies.Add(boss2);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_SBgm();
                                bossTrackCheck = true;
                            }
                            break;

                    }
                    break;
                case "gauntlet":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= 20)
                            {
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= 50)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= 100)
                            {
                                spawnManager.lockRareEnemy = true;
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Remove(enemy5c);
                                spawnManager.enemies.Remove(enemy5d);
                                spawnManager.enemies.Remove(enemy5e);
                                spawnManager.enemies.Remove(enemy5f);
                                spawnManager.enemies.Remove(enemy5h);
                            //    enemiesToBeat = 101;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_GBgm();
                                bossTrackCheck = true;
                            }
                            break;
                    }
                    break;
                case "arena":
                    switch (masterScript.multiplayerMode)
                    {
                        case 12:
                            limit1 = 4;
                            limit2 = 10;
                            limit3 = 16;
                            limit4 = 22;
                            limit5 = 30;
                            break;
                        case 13:
                            limit1 = 6;
                            limit2 = 14;
                            limit3 = 24;
                            limit4 = 30;
                            limit5 = 40;
                            break;
                        case 14:
                            limit1 = 12;
                            limit2 = 26;
                            limit3 = 34;
                            limit4 = 42;
                            limit5 = 50;
                            break;
                    }
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.howManyEnemiesSpawned >= limit1)
                            {
                                spawnManager.enemies.Remove(enemy1a);
                                spawnManager.enemies.Remove(enemy1b);
                                spawnManager.enemies.Remove(enemy1c);
                                spawnManager.enemies.Remove(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.howManyEnemiesSpawned >= limit2)
                            {
                                spawnManager.enemies.Remove(enemy2a);
                                spawnManager.enemies.Remove(enemy2b);
                                spawnManager.enemies.Remove(enemy2c);
                                spawnManager.enemies.Remove(enemy2d);
                                spawnManager.enemies.Remove(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.howManyEnemiesSpawned >= limit3)
                            {
                                spawnManager.enemies.Remove(enemy3a);
                                spawnManager.enemies.Remove(enemy3b);
                                spawnManager.enemies.Remove(enemy3c);
                                spawnManager.enemies.Remove(enemy3d);
                                spawnManager.enemies.Remove(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.howManyEnemiesSpawned >= limit4)
                            {
                                spawnManager.enemies.Remove(enemy4a);
                                spawnManager.enemies.Remove(enemy4b);
                                spawnManager.enemies.Remove(enemy4c);
                                spawnManager.enemies.Remove(enemy4d);
                                spawnManager.enemies.Remove(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 5;
                            }
                            break;
                        case 5:
                            if (spawnManager.howManyEnemiesSpawned >= limit5)
                            {
                                spawnManager.lockRareEnemy = true;
                                spawnManager.enemies.Remove(enemy5a);
                                spawnManager.enemies.Remove(enemy5b);
                                spawnManager.enemies.Remove(enemy5c);
                                spawnManager.enemies.Remove(enemy5d);
                                spawnManager.enemies.Remove(enemy5e);
                                spawnManager.enemies.Remove(enemy5f);
                                spawnManager.enemies.Remove(enemy5g);
                                spawnManager.enemies.Remove(enemy5h);
                           //     enemiesToBeat = limit5 + 1;
                                enemySpawnRangeXZ = 0;
                                spawnManager.enemies.Add(boss);
                                levelState = 99;
                            }
                            break;
                        case 101:
                            if (!bossTrackCheck)
                            {
                                bgmScript.StopBgm();
                                bgmScript.Boss_1Bgm();
                                bossTrackCheck = true;
                            }
                            break;
                    }
                    break;
                case "control":
                    switch (levelState)
                    {
                        case 0:
                            if (spawnManager.howManyEnemiesSpawned == 0)
                            {
                                spawnManager.enemies.Add(enemy1a);
                                spawnManager.enemies.Add(enemy1b);
                                spawnManager.enemies.Add(enemy1c);
                                spawnManager.enemies.Add(enemy1d);
                                spawnManager.enemies.Add(enemy2a);
                                spawnManager.enemies.Add(enemy2b);
                                spawnManager.enemies.Add(enemy2c);
                                spawnManager.enemies.Add(enemy2d);
                                spawnManager.enemies.Add(enemy2e);
                                spawnManager.enemies.Add(enemy3a);
                                spawnManager.enemies.Add(enemy3b);
                                spawnManager.enemies.Add(enemy3c);
                                spawnManager.enemies.Add(enemy3d);
                                spawnManager.enemies.Add(enemy3e);
                                spawnManager.enemies.Add(enemy4a);
                                spawnManager.enemies.Add(enemy4b);
                                spawnManager.enemies.Add(enemy4c);
                                spawnManager.enemies.Add(enemy4d);
                                spawnManager.enemies.Add(enemy4e);
                                spawnManager.enemies.Add(enemy5a);
                                spawnManager.enemies.Add(enemy5b);
                                spawnManager.enemies.Add(enemy5c);
                                spawnManager.enemies.Add(enemy5d);
                                spawnManager.enemies.Add(enemy5e);
                                spawnManager.enemies.Add(enemy5f);
                                spawnManager.enemies.Add(enemy5g);
                                spawnManager.enemies.Add(enemy5h);
                                levelState = 1;
                            }
                            break;
                        case 1:
                            if (spawnManager.enemyDefeated >= 4)
                            {
                                levelState = 2;
                            }
                            break;
                        case 2:
                            if (spawnManager.enemyDefeated >= 9)
                            {
                                levelState = 3;
                            }
                            break;
                        case 3:
                            if (spawnManager.enemyDefeated >= 14)
                            {
                                levelState = 4;
                            }
                            break;
                        case 4:
                            if (spawnManager.enemyDefeated >= 19)
                            {
                                levelState = 5;
                            }
                            break;
                        case 5:
                            if (spawnManager.enemyDefeated >= 27)
                            {
                                levelState = -1;
                            }
                            break;
                    }
                    break;
                    #endregion
            }
        }
    }
    #endregion

    #region Instantiate Player Spawner
    public void SpawnObjects()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    #endregion

    #region Enemy Bar Code (Kill Counter)
    public void SpawnEnemyBar()
    {
        while (enemyBarSpawnCount > enemiesToBeat)
        {
            RemoveBall();
            enemyBarSpawnCount--;
        }
        
        /*
        if (spawnManager.gameMode == 0 && masterScript.levelNumber!="L0")
        {
        //    if (enemyBarSpawnCount < enemiesToBeat - 1)
         //   {
         //       Instantiate(enemyCountRef, new Vector3(enemyCountRef.transform.position.x + 34.5f * (enemyBarSpawnCount + 1),
        //            enemyCountRef.transform.position.y + 20, enemyCountRef.transform.position.z), enemyCountRef.transform.rotation);
         //       ECountBar barScript = enemyCountRef.GetComponent<ECountBar>();
         //       enemyBarSpawnCount++;
           //     barScript.barNumber = enemyBarSpawnCount;
        //    }

            GameObject[] Bars = GameObject.FindGameObjectsWithTag("Bar");
            foreach (GameObject bar in Bars)
            {
                bar.transform.SetParent(canvas.transform);
                //   bar.transform.parent = canvas.transform;
            }

            if (enemyBarSpawnCount == enemiesToBeat /- 1 && spawnManager.gameMode == 0)
            {
                GameObject firstBar = GameObject.Find("Kill Count Ball");
                firstBar.transform.position = new Vector3(enemyCountRef.transform.position.x + 34.5f * (enemyBarSpawnCount + 1),
                    enemyCountRef.transform.position.y, enemyCountRef.transform.position.z);
                go = false;
                Destroy(GameObject.Find("Kill Count Ball"));
            }
        }*/
    }

    private void RemoveBall()
    {
        switch (enemyBarSpawnCount)
        {
            case 1:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 1"));
                break;
            case 2:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 2"));
                break;
            case 3:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 3"));
                break;
            case 4:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 4"));
                break;
            case 5:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 5"));
                break;
            case 6:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 6"));
                break;
            case 7:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 7"));
                break;
            case 8:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 8"));
                break;
            case 9:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 9"));
                break;
            case 10:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 10"));
                break;
            case 11:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 11"));
                break;
            case 12:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 12"));
                break;
            case 13:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 13"));
                break;
            case 14:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 14"));
                break;
            case 15:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 15"));
                break;
            case 16:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 16"));
                break;
            case 17:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 17"));
                break;
            case 18:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 18"));
                break;
            case 19:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 19"));
                break;
            case 20:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 20"));
                break;
            case 21:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 21"));
                break;
            case 22:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 22"));
                break;
            case 23:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 23"));
                break;
            case 24:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 24"));
                break;
            case 25:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 25"));
                break;
            case 26:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 26"));
                break;
            case 27:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 27"));
                break;
            case 28:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 28"));
                break;
            case 29:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 29"));
                break;
            case 30:
                GameObject.Destroy(GameObject.Find("Kill Count Ball 30")); 
                break;
        }
    }
    #endregion
}
