using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossScript : MonoBehaviour
{
    #region Set Initial Variables
    private GameObject EnemiesParent, playerRef;
    private ArcadeScript arcadeScript;
    private SpawnManagerScript spawnManager;
    public int levelState;
    public int enemy;
    public bool spawnLock;
    public bool enemySwitch;

    public bool checkEnemy1;
    public bool checkEnemy2;
    public bool checkEnemy3;
    public bool checkEnemy4;
    public bool checkEnemy5;
    public bool checkEnemy6;
    public bool checkEnemy7;
    public bool checkEnemy8;
    public bool checkEnemy9;
    public bool checkEnemy10;
    public bool checkEnemy11;
    public bool checkEnemy12;
    public bool checkEnemy13;
    public bool checkEnemy14;
    public bool checkEnemy15;
    public bool checkEnemy16;
    public bool checkEnemy17;
    public bool checkEnemy18;
    public bool checkEnemy19;
    public bool checkEnemy20;
    public bool checkEnemy21;
    public bool checkEnemy22;
    public bool checkEnemy23;
    public bool checkEnemy24;
    public bool checkEnemy25;
    public bool checkEnemy26;
    public bool checkEnemy27;

    int switchCheck;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
    //    InstantiateAllEnemies();
        EnemiesParent = GameObject.Find("EnemiesParent");
        playerRef = GameObject.Find("Player 2");
    }
    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
    //    Debug.Log(cooldown);
        if (cooldown>0)
        {
            cooldown -= 1 * Time.deltaTime;
        }
        if (GameObject.Find("Boss Player") !=null)
        {
            transform.position = playerRef.transform.position;
        }
        switch (arcadeScript.levelState)
        {
            case 1:
                enemy = Random.Range(1, 5);
                break;
            case 2:
                if (switchCheck == 0)
                {
                    enemySwitch = false;
                    switchCheck = 3;
                }
                enemy = Random.Range(5, 10);
                break;
            case 3:
                if (switchCheck == 3)
                {
                    enemySwitch = false;
                    switchCheck = 4;
                }
                enemy = Random.Range(10, 15);
                break;
            case 4:
                if (switchCheck == 4)
                {
                    enemySwitch = false;
                    switchCheck = 5;
                }
                enemy = Random.Range(15, 20);
                break;
            case 5:
                if (switchCheck == 5)
                {
                    enemySwitch = false;
                    switchCheck = 9;
                }
                enemy = Random.Range(20, 28);
                break;
        }
    }

    #region PlayerBoss Spawns Enemies
    public void SpawnEnemy()
    {
        if (cooldown <= 0)
        {
            Debug.Log("Spawn0a");
            if ((spawnManager.enemiesActive < arcadeScript.enemySpawnLimit) && !spawnManager.enemyStop && !spawnManager.isGamePaused && !spawnLock)
            {
                Debug.Log("Spawn0b");
                switch (enemy)
                {
                    case 1:
                        if (!checkEnemy1)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(0).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(0).gameObject.SetActive(true);
                            checkEnemy1 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy1Appeared");
                            enemySwitch = true;
                            enemy = 2;
                            SpawnEnemy();
                        }
                        break;
                    case 2:
                        if (!checkEnemy2)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(1).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(1).gameObject.SetActive(true);
                            checkEnemy2 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy2Appeared");
                            enemySwitch = true;
                            enemy = 3;
                            SpawnEnemy();
                        }
                        break;
                    case 3:
                        if (!checkEnemy3)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(2).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(2).gameObject.SetActive(true);
                            checkEnemy3 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy3Appeared");
                            enemySwitch = true;
                            enemy = 4;
                            SpawnEnemy();
                        }
                        break;
                    case 4:
                        if (!checkEnemy4)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(3).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(3).gameObject.SetActive(true);
                            checkEnemy4 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy4Appeared");
                            enemySwitch = true;
                            enemy = 1;
                            SpawnEnemy();
                        }
                        break;
                    case 5:
                        if (!checkEnemy5)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(4).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(4).gameObject.SetActive(true);
                            checkEnemy5 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy5Appeared");
                            enemySwitch = true;
                            enemy = 6;
                            SpawnEnemy();
                        }
                        break;
                    case 6:
                        if (!checkEnemy6)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(5).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(5).gameObject.SetActive(true);
                            checkEnemy6 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy6Appeared");
                            enemySwitch = true;
                            enemy = 7;
                            SpawnEnemy();
                        }
                        break;
                    case 7:
                        if (!checkEnemy7)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(6).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(6).gameObject.SetActive(true);
                            checkEnemy7 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy7Appeared");
                            enemySwitch = true;
                            enemy = 8;
                            SpawnEnemy();
                        }
                        break;
                    case 8:
                        if (!checkEnemy8)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(7).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(7).gameObject.SetActive(true);
                            checkEnemy8 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy8Appeared");
                            enemySwitch = true;
                            enemy = 9;
                            SpawnEnemy();
                        }
                        break;
                    case 9:
                        if (!checkEnemy9)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(8).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(8).gameObject.SetActive(true);
                            checkEnemy9 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy9Appeared");
                            enemySwitch = true;
                            enemy = 5;
                            SpawnEnemy();
                        }
                        break;
                    case 10:
                        if (!checkEnemy10)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(9).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(9).gameObject.SetActive(true);
                            checkEnemy10 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy10Appeared");
                            enemySwitch = true;
                            enemy = 11;
                            SpawnEnemy();
                        }
                        break;
                    case 11:
                        if (!checkEnemy11)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(10).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(10).gameObject.SetActive(true);
                            checkEnemy11 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy11Appeared");
                            enemySwitch = true;
                            enemy = 12;
                            SpawnEnemy();
                        }
                        break;
                    case 12:
                        if (!checkEnemy12)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(11).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(11).gameObject.SetActive(true);
                            checkEnemy12 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy12Appeared");
                            enemySwitch = true;
                            enemy = 13;
                            SpawnEnemy();
                        }
                        break;
                    case 13:
                        if (!checkEnemy13)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(12).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(12).gameObject.SetActive(true);
                            checkEnemy13 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy13Appeared");
                            enemySwitch = true;
                            enemy = 14;
                            SpawnEnemy();
                        }
                        break;
                    case 14:
                        if (!checkEnemy14)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(13).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(13).gameObject.SetActive(true);
                            checkEnemy14 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy14Appeared");
                            enemySwitch = true;
                            enemy = 10;
                            SpawnEnemy();
                        }
                        break;
                    case 15:
                        if (!checkEnemy15)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(14).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(14).gameObject.SetActive(true);
                            checkEnemy15 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy15Appeared");
                            enemySwitch = true;
                            enemy = 16;
                            SpawnEnemy();
                        }
                        break;
                    case 16:
                        if (!checkEnemy16)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(15).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(15).gameObject.SetActive(true);
                            checkEnemy16 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy16Appeared");
                            enemySwitch = true;
                            enemy = 17;
                            SpawnEnemy();
                        }
                        break;
                    case 17:
                        if (!checkEnemy17)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(16).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(16).gameObject.SetActive(true);
                            checkEnemy17 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy17Appeared");
                            enemySwitch = true;
                            enemy = 18;
                            SpawnEnemy();
                        }
                        break;
                    case 18:
                        if (!checkEnemy18)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(17).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(17).gameObject.SetActive(true);
                            checkEnemy18 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy18Appeared");
                            enemySwitch = true;
                            enemy = 19;
                            SpawnEnemy();
                        }
                        break;
                    case 19:
                        if (!checkEnemy19)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(18).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(18).gameObject.SetActive(true);
                            checkEnemy19 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy19Appeared");
                            enemySwitch = true;
                            enemy = 15;
                            SpawnEnemy();
                        }
                        break;
                    case 20:
                        if (!checkEnemy20)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(19).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(19).gameObject.SetActive(true);
                            checkEnemy20 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy20Appeared");
                            enemySwitch = true;
                            enemy = 21;
                            SpawnEnemy();
                        }
                        break;
                    case 21:
                        if (!checkEnemy21)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(20).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(20).gameObject.SetActive(true);
                            checkEnemy21 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy21Appeared");
                            enemySwitch = true;
                            enemy = 22;
                            SpawnEnemy();
                        }
                        break;
                    case 22:
                        if (!checkEnemy22)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(21).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(21).gameObject.SetActive(true);
                            checkEnemy22 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy22Appeared");
                            enemySwitch = true;
                            enemy = 23;
                            SpawnEnemy();
                        }
                        break;
                    case 23:
                        if (!checkEnemy23)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(22).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(22).gameObject.SetActive(true);
                            checkEnemy23 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy23Appeared");
                            enemySwitch = true;
                            enemy = 24;
                            SpawnEnemy();
                        }
                        break;
                    case 24:
                        if (!checkEnemy24)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(23).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(23).gameObject.SetActive(true);
                            checkEnemy24 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy24Appeared");
                            enemySwitch = true;
                            enemy = 25;
                            SpawnEnemy();
                        }
                        break;
                    case 25:
                        if (!checkEnemy25)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(24).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(24).gameObject.SetActive(true);
                            checkEnemy25 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy25Appeared");
                            enemySwitch = true;
                            enemy = 26;
                            SpawnEnemy();
                        }
                        break;
                    case 26:
                        if (!checkEnemy26)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(25).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(25).gameObject.SetActive(true);
                            checkEnemy26 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy26Appeared");
                            enemySwitch = true;
                            enemy = 27;
                            SpawnEnemy();
                        }
                        break;
                    case 27:
                        if (!checkEnemy27)
                        {
                            Debug.Log("Spawn1");
                            EnemiesParent.transform.GetChild(26).transform.position = transform.position;
                            EnemiesParent.transform.GetChild(26).gameObject.SetActive(true);
                            checkEnemy27 = true;
                            enemySwitch = false;
                            spawnManager.enemiesActive++;
                            spawnLock = true;
                        }
                        else
                        {
                            Debug.Log("Enemy27Appeared");
                            enemySwitch = true;
                            enemy = 20;
                            SpawnEnemy();
                        }
                        break;
                }
            }
            cooldown = 3;
        }
    }
    #endregion

    #region Enemies Set
    void InstantiateAllEnemies()
    {
        float randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        float randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Vector3 spawnPos = new Vector3(randomPosX, 0, randomPosZ);
        Instantiate(spawnManager.enemies[0], spawnPos, spawnManager.enemies[0].transform.rotation);

        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[1], spawnPos, spawnManager.enemies[1].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[2], spawnPos, spawnManager.enemies[2].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[3], spawnPos, spawnManager.enemies[3].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[4], spawnPos, spawnManager.enemies[4].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[5], spawnPos, spawnManager.enemies[5].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[6], spawnPos, spawnManager.enemies[6].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[7], spawnPos, spawnManager.enemies[7].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[8], spawnPos, spawnManager.enemies[8].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[9], spawnPos, spawnManager.enemies[9].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[10], spawnPos, spawnManager.enemies[10].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[11], spawnPos, spawnManager.enemies[11].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[12], spawnPos, spawnManager.enemies[12].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[13], spawnPos, spawnManager.enemies[13].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[14], spawnPos, spawnManager.enemies[14].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[15], spawnPos, spawnManager.enemies[15].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[16], spawnPos, spawnManager.enemies[17].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[17], spawnPos, spawnManager.enemies[17].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[18], spawnPos, spawnManager.enemies[18].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[19], spawnPos, spawnManager.enemies[19].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[20], spawnPos, spawnManager.enemies[20].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[21], spawnPos, spawnManager.enemies[21].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[22], spawnPos, spawnManager.enemies[22].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[23], spawnPos, spawnManager.enemies[23].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[24], spawnPos, spawnManager.enemies[24].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[25], spawnPos, spawnManager.enemies[25].transform.rotation);
        randomPosX = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        randomPosZ = Random.Range(-arcadeScript.enemySpawnRangeXZ, arcadeScript.enemySpawnRangeXZ);
        Instantiate(spawnManager.enemies[26], spawnPos, spawnManager.enemies[26].transform.rotation);
    }
    #endregion
}
