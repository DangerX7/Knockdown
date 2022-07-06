using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDelay : MonoBehaviour
{
    private GameObject player, player2, player3, player4;
    private SpawnManagerScript spawnManagerScript;
    private TutorialScript tutorialScript;
    private MasterScript masterScript;
    private EnemySpawn2 childScript;
    private EnemyScript enemyScript;
    public byte ballNumber;
    public bool check;

    IEnumerator SpawnClone;
    public int spawnClone;
    public int spawnCoroutineTimer;
    IEnumerator CooldownClone;
    public int jumpCooldown;
    public int cooldownTimer;

    public int cloneType; //clone number
    public bool cloneReactivate;

    IEnumerator SwitchAIClone;
    public int aiSwitch;
    public int aiCoroutineTimer;

    IEnumerator ballRecoverClone;////////////////////1st
    public int ballRecoverSwitch;
    public int ballRecoverCoroutineTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        tutorialScript = GameObject.Find("SpawnManager").GetComponent<TutorialScript>();
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();

        //Code for loading spawn
        if (cloneType == 0 || cloneType == 1)
        {
            transform.parent = GameObject.Find("EnemiesParent").transform;
        }
        if ((cloneType == 0 || cloneType == 1) && ballNumber == 0 && !tutorialScript.tutorialLevel)
        {
            gameObject.SetActive(false);
        }

        childScript = transform.GetChild(0).gameObject.GetComponent<EnemySpawn2>();
        GameObject Child = transform.GetChild(0).gameObject;
        enemyScript = Child.transform.GetChild(0).gameObject.GetComponent<EnemyScript>();

        //   spawnManagerScript.enemiesSpawned += 1;
        //   spawnManagerScript.enemiesActive += 1;
        #region Read Player Data
        if (spawnManagerScript.gameMode !=4)
        {
            player = GameObject.Find("P1");
            player2 = GameObject.Find("P2");
        }
        else
        {
            player = GameObject.Find("P1Dodgeball(Clone)");
            player2 = GameObject.Find("P2Dodgeball(Clone)");
        }
        player3 = GameObject.Find("P3");
        player4 = GameObject.Find("P4");

        //Check players position to avoid spawning in their area
        if (player != null)
        {
            if (spawnManagerScript.gameMode !=4)
            {
                player = GameObject.Find("P1");
            }
            else
            {
                player = GameObject.Find("P1Dodgeball(Clone)");
            }
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 8)
            {
                check = true;
            }
        }
        if (player2 != null)
        {
            if (spawnManagerScript.gameMode != 4)
            {
                player2 = GameObject.Find("P2");
            }
            else
            {
                player2 = GameObject.Find("P2Dodgeball(Clone)");
            }
            if (Vector3.Distance(player2.transform.position, gameObject.transform.position) < 8)
            {
                check = true;
            }
        }
        if (player3 != null)
        {
            player3 = GameObject.Find("P3");
            if (Vector3.Distance(player3.transform.position, gameObject.transform.position) < 8)
            {
                check = true;
            }
        }
        if (player4 != null)
        {
            player4 = GameObject.Find("P4");
            if (Vector3.Distance(player4.transform.position, gameObject.transform.position) < 8)
            {
                check = true;
            }
        }

        if (check)
        {
            if (spawnManagerScript.gameMode !=5)
            {
                spawnManagerScript.SpawnEnemy();
            }
            else
            {
                switch (masterScript.multiplayerMode)
                {
                    case 32:
                        if (ballNumber == 1)
                        {
                            spawnManagerScript.SpawnBall1a();
                        }
                        else if (ballNumber == 2)
                        {
                            spawnManagerScript.SpawnBall2a();
                        }
                        break;
                    case 33:
                        if (ballNumber == 1)
                        {
                            spawnManagerScript.SpawnBall1b();
                        }
                        else if (ballNumber == 2)
                        {
                            spawnManagerScript.SpawnBall2b();
                        }
                        else if (ballNumber == 3)
                        {
                            spawnManagerScript.SpawnBall3b();
                        }
                        break;
                    case 34:
                        if (ballNumber == 1)
                        {
                            spawnManagerScript.SpawnBall1c();
                        }
                        else if (ballNumber == 2)
                        {
                            spawnManagerScript.SpawnBall2c();
                        }
                        else if (ballNumber == 3)
                        {
                            spawnManagerScript.SpawnBall3c();
                        }
                        else if (ballNumber == 4)
                        {
                            spawnManagerScript.SpawnBall4c();
                        }
                        break;
                }
            }
                Destroy(gameObject);
        }
        else
        {
            spawnClone = 1;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        #endregion

        if (enemyScript.isEnemyFinalBoss)
        {
            if (!IsInvoking("Stop"))
            {
                InvokeRepeating("Stop", 10f, 16f);
            }
        }
    }

    public void Stop()
    {
        StartCoroutine(StopRutine());
    }

    IEnumerator StopRutine()
    {
        enemyScript.FreezeEnemy();
        yield return new WaitForSeconds(3);
        enemyScript.UnfreezeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
        }

        if (spawnClone == 1)
        {
        //    Debug.Log("Start");
            SpawnClone = SpawnCoroutine();
            spawnCoroutineTimer = 0;
            StartCoroutine(SpawnClone);
            spawnClone = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && spawnClone == 2)
        {
        //    Debug.Log("Stop");
            transform.GetChild(0).gameObject.SetActive(false);
            StopCoroutine(SpawnClone);
            Debug.Log(spawnCoroutineTimer);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && spawnClone == 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(SpawnClone);
            spawnManagerScript.pauseCheck1 = 0;
        }


        if (jumpCooldown == 1)
        {
            //    Debug.Log("Start");
            SpawnClone = CooldownCoroutine();
            cooldownTimer = 0;
            StartCoroutine(SpawnClone);
            jumpCooldown = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && jumpCooldown == 2)
        {
            //   Debug.Log("Stop");
            transform.GetChild(0).gameObject.SetActive(false);
            StopCoroutine(CooldownClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && jumpCooldown == 2)
        {
            //    Debug.Log("Resume");
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(CooldownClone);
            spawnManagerScript.pauseCheck1 = 0;
        }

        if (cloneReactivate)
        {
        //    transform.GetChild(1).gameObject.SetActive(true);
        //    transform.GetChild(2).gameObject.SetActive(true);
            cloneReactivate = false;
        }

        if (aiSwitch == 1)
        {
            SwitchAIClone = SwitchAICoroutine();
            aiCoroutineTimer = 0;
            StartCoroutine(SwitchAIClone);
            aiSwitch = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && aiSwitch == 2)
        {
            StopCoroutine(SwitchAIClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && aiSwitch == 2)
        {
            StartCoroutine(SwitchAIClone);
            spawnManagerScript.pauseCheck1 = 0;
        }


        if (ballRecoverSwitch == 1) ////////////////////2nd
        {
            ballRecoverClone = ballRecoverCoroutine();
            ballRecoverCoroutineTimer = 0;
            StartCoroutine(ballRecoverClone);
            ballRecoverSwitch = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && ballRecoverSwitch == 2)
        {
            StopCoroutine(ballRecoverClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && ballRecoverSwitch == 2)
        {
            StartCoroutine(ballRecoverClone);
            spawnManagerScript.pauseCheck1 = 0;
        }
    }

    public IEnumerator SpawnCoroutine()
    {
        if (ballNumber == 0)
        {
            while (spawnCoroutineTimer < 100)
            {
                yield return new WaitForSeconds(0.01f);
                spawnCoroutineTimer++;
            }
        }
        else
        {
            while (spawnCoroutineTimer < 1)
            {
                yield return new WaitForSeconds(0.01f);
                spawnCoroutineTimer++;
            }
        }
        if (cloneType == 0)
        {
            transform.gameObject.tag = "Untagged";
        }
        childScript.SpawnEnemy();
        GameObject spawnChild;
        spawnChild = transform.GetChild(0).gameObject;
        if (ballNumber == 0)
        {
            GameObject textChild;
            textChild = transform.GetChild(1).gameObject;
            textChild.transform.parent = spawnChild.transform;
        }
        /////
        spawnClone = 0;
    }

    public IEnumerator CooldownCoroutine()
    {
        while (cooldownTimer < 300)
        {
            yield return new WaitForSeconds(0.01f);
            cooldownTimer++;
        }
        jumpCooldown = 0;
    }

    public IEnumerator SwitchAICoroutine()
    {
        while (aiCoroutineTimer < 1000)
        {
            yield return new WaitForSeconds(0.01f);
            aiCoroutineTimer++;
        }
        if (enemyScript.aiType == 1 || enemyScript.aiType == 2)
        {
        //    Debug.Log("switch back");
            enemyScript.aiType = 0;
        }
        else if (enemyScript.aiType == 0)
        {
        //    Debug.Log("change");
            if (enemyScript.aiRegistry == 1)
            {
                enemyScript.aiType = 1;
            }
            else if (enemyScript.aiRegistry == 2)
            {
                enemyScript.aiType = 2;
            }
        }
        aiSwitch = 1;
    }

    public IEnumerator ballRecoverCoroutine()////////////3rd
    {
        while (ballRecoverCoroutineTimer < 100)
        {
            yield return new WaitForSeconds(0.01f);
            ballRecoverCoroutineTimer++;
        }
        ballRecoverSwitch = 0;
    }
}
