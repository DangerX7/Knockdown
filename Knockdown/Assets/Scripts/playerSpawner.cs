using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    #region Variables Set
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SpawnManagerScript spawnManager;
    public GameObject secondPhase, playerSkin1, playerSkin2, playerSkin3, playerSkin4, playerSkin5, playerSkin6,
        playerSkin7, playerSkin8, playerSkin9, playerSkin10, playerSkin11, playerSkin12, playerSkin13, playerSkin14, playerSkin15, playerSkin16,
        playerSkin17, playerSkin18, playerSkin19, playerSkin20, playerSkin21, playerSkin22, playerSkin23, playerSkin24, playerSkin25,
        playerSkin26, playerSkin27, playerSkin28, playerSkin29, playerSkin30, playerSkin31, playerSkin32, playerSkin33, playerSkin34,
        playerSkin35, playerSkin36, playerSkin37, playerSkin38, playerSkin39, playerSkin40, playerSkin41, playerSkin42, playerSkin43,
        playerSkin44, playerSkin45, playerSkin46, playerSkin47, playerSkin48, playerSkin49, playerSkin50, playerSkin51, playerSkin52,
        playerSkin53, playerSkin101, playerSkin102, playerSkin103, playerSkin104, playerSkin105, playerSkin106, playerSkin107, playerSkin108,
        playerSkin109, playerSkin110, playerSkin111, playerSkin112, playerSkin121, playerSkin122, playerSkin123, playerSkin124,
        playerSkin125, playerSkin126, playerSkin127, playerSkin128, playerSkin129, playerSkin130, bossSkin1, bossSkin2, bossSkin3,
        bossSkin4, bossSkin5, bossSkin6, bossSkin7;
    private Vector3 P1pos;
    private Vector3 P2pos;
    private Vector3 P3pos;
    private Vector3 P4pos;
    private float distance;
    private bool dodgeScale;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region Set Player Spawn Position
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
        spawnManager = secondPhase.GetComponent<SpawnManagerScript>();
        distance = 1;

        if (masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 50)
        {
            P1pos = new Vector3(distance * -10, 0, 0);
            P2pos = new Vector3(distance * 10, 0, 0);
        }
        else if (masterScript.multiplayerMode == 33)
        {
            P1pos = new Vector3(0, 0, 20);
            P2pos = new Vector3(distance * -12, 0, 0);
            P3pos = new Vector3(distance * 12, 0, 0);
        }
        else if (masterScript.multiplayerMode == 34)
        {
            P1pos = new Vector3(distance * -10, 0, -10);
            P2pos = new Vector3(distance * 10, 0, -10);
            P3pos = new Vector3(distance * -10, 0, 10);
            P4pos = new Vector3(distance * 10, 0, 10);
        }
        else
        {
            P1pos = new Vector3(-distance, 0, -distance);
            P2pos = new Vector3(distance, 0, distance);
            P3pos = new Vector3(-distance, 0, distance);
            P4pos = new Vector3(distance, 0, -distance);
        }
        SpawnPlayer();
        #endregion
        dodgeScale = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Scale Balls for Dodgebal Mode
        if (!dodgeScale && (masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 33 || masterScript.multiplayerMode == 34))
        {
            if (GameObject.Find("Player") != null)
            {
                GameObject P1 = GameObject.Find("Player");
                P1.transform.localScale += new Vector3(1, 1, 1);
            }
            if (GameObject.Find("Player 2") != null)
            {
                GameObject P2 = GameObject.Find("Player 2");
                P2.transform.localScale += new Vector3(1, 1, 1);
            }
            if (GameObject.Find("Player 3") != null)
            {
                GameObject P3 = GameObject.Find("Player 3");
                P3.transform.localScale += new Vector3(1, 1, 1);
            }
            if (GameObject.Find("Player 4") != null)
            {
                GameObject P4 = GameObject.Find("Player 4");
                P4.transform.localScale += new Vector3(1, 1, 1);
            }
            dodgeScale = true;
        }
        #endregion
    }

    public void SpawnPlayer()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            //Spawn player
            if (spawnManager.gameMode == 0)
            {
                switch (jsonScript.so.playerSkin)
                {
                    case 1:
                        Instantiate(playerSkin1, Vector3.zero, playerSkin1.transform.rotation);
                        break;
                    case 2:
                        Instantiate(playerSkin2, Vector3.zero, playerSkin2.transform.rotation);
                        break;
                    case 3:
                        Instantiate(playerSkin3, Vector3.zero, playerSkin3.transform.rotation);
                        break;
                    case 4:
                        Instantiate(playerSkin4, Vector3.zero, playerSkin4.transform.rotation);
                        break;
                    case 5:
                        Instantiate(playerSkin5, Vector3.zero, playerSkin5.transform.rotation);
                        break;
                    case 6:
                        Instantiate(playerSkin6, Vector3.zero, playerSkin6.transform.rotation);
                        break;
                    case 7:
                        Instantiate(playerSkin7, Vector3.zero, playerSkin7.transform.rotation);
                        break;
                    case 8:
                        Instantiate(playerSkin8, Vector3.zero, playerSkin8.transform.rotation);
                        break;
                    case 9:
                        Instantiate(playerSkin9, Vector3.zero, playerSkin9.transform.rotation);
                        break;
                    case 10:
                        Instantiate(playerSkin10, Vector3.zero, playerSkin10.transform.rotation);
                        break;
                    case 11:
                        Instantiate(playerSkin11, Vector3.zero, playerSkin11.transform.rotation);
                        break;
                    case 12:
                        Instantiate(playerSkin12, Vector3.zero, playerSkin12.transform.rotation);
                        break;
                    case 13:
                        Instantiate(playerSkin13, Vector3.zero, playerSkin13.transform.rotation);
                        break;
                    case 14:
                        Instantiate(playerSkin14, Vector3.zero, playerSkin14.transform.rotation);
                        break;
                    case 15:
                        Instantiate(playerSkin15, Vector3.zero, playerSkin15.transform.rotation);
                        break;
                    case 16:
                        Instantiate(playerSkin16, Vector3.zero, playerSkin16.transform.rotation);
                        break;
                    case 101:
                        Instantiate(playerSkin101, Vector3.zero, playerSkin101.transform.rotation);
                        break;
                    case 102:
                        Instantiate(playerSkin102, Vector3.zero, playerSkin102.transform.rotation);
                        break;
                    case 103:
                        Instantiate(playerSkin103, Vector3.zero, playerSkin103.transform.rotation);
                        break;
                    case 104:
                        Instantiate(playerSkin104, Vector3.zero, playerSkin104.transform.rotation);
                        break;
                    case 111:
                        Instantiate(playerSkin111, Vector3.zero, playerSkin111.transform.rotation);
                        break;
                    case 112:
                        Instantiate(playerSkin112, Vector3.zero, playerSkin112.transform.rotation);
                        break;
                    case 121:
                        Instantiate(playerSkin121, Vector3.zero, playerSkin121.transform.rotation);
                        break;
                    case 122:
                        Instantiate(playerSkin122, Vector3.zero, playerSkin122.transform.rotation);
                        break;
                    case 123:
                        Instantiate(playerSkin123, Vector3.zero, playerSkin123.transform.rotation);
                        break;
                    case 124:
                        Instantiate(playerSkin124, Vector3.zero, playerSkin124.transform.rotation);
                        break;
                    case 125:
                        Instantiate(playerSkin125, Vector3.zero, playerSkin125.transform.rotation);
                        break;
                    case 126:
                        Instantiate(playerSkin126, Vector3.zero, playerSkin126.transform.rotation);
                        break;
                    case 127:
                        Instantiate(playerSkin127, Vector3.zero, playerSkin127.transform.rotation);
                        break;
                    case 128:
                        Instantiate(playerSkin128, Vector3.zero, playerSkin128.transform.rotation);
                        break;
                    case 129:
                        Instantiate(playerSkin129, Vector3.zero, playerSkin129.transform.rotation);
                        break;
                    case 130:
                        Instantiate(playerSkin130, Vector3.zero, playerSkin130.transform.rotation);
                        break;
                }
            }
            else if (spawnManager.gameMode == 1)
            {
                Instantiate(playerSkin5, Vector3.zero, playerSkin5.transform.rotation);
            }
            else if (spawnManager.gameMode == 2)
            {
                Instantiate(playerSkin6, Vector3.zero, playerSkin6.transform.rotation);
            }
            #region Multiplayer Spawn
            else if (spawnManager.gameMode >= 3)//CHANGE TO OTHER SKINS
            {
                switch (masterScript.multiplayerMode)
                {
                    case 12:
                    case 22:
                    case 32:
                    case 50:
                        SpawnP1();
                        SpawnP2();
                        break;
                    case 13:
                    case 23:
                    case 33:
                        SpawnP1();
                        SpawnP2();
                        SpawnP3();
                        break;
                    case 14:
                    case 24:
                    case 34:
                        SpawnP1();
                        SpawnP2();
                        SpawnP3();
                        SpawnP4();
                        break;
                    case 42:
                        SpawnP1();
                        SpawnP2Boss();
                        break;
                }
            }
            #endregion
        }
    }

    #region Spawn Base Functions
    public void SpawnP1()
    {
        switch (masterScript.P1skin)
        {
            case 1:
                Instantiate(playerSkin1, Vector3.zero + P1pos, playerSkin1.transform.rotation);
                break;
            case 2:
                Instantiate(playerSkin2, Vector3.zero + P1pos, playerSkin2.transform.rotation);
                break;
            case 3:
                Instantiate(playerSkin3, Vector3.zero + P1pos, playerSkin3.transform.rotation);
                break;
            case 4:
                Instantiate(playerSkin4, Vector3.zero + P1pos, playerSkin4.transform.rotation);
                break;
            case 5:
                Instantiate(playerSkin5, Vector3.zero + P1pos, playerSkin5.transform.rotation);
                break;
            case 6:
                Instantiate(playerSkin6, Vector3.zero + P1pos, playerSkin6.transform.rotation);
                break;
            case 7:
                Instantiate(playerSkin7, Vector3.zero + P1pos, playerSkin7.transform.rotation);
                break;
            case 8:
                Instantiate(playerSkin8, Vector3.zero + P1pos, playerSkin8.transform.rotation);
                break;
            case 9:
                Instantiate(playerSkin9, Vector3.zero + P1pos, playerSkin9.transform.rotation);
                break;
            case 10:
                Instantiate(playerSkin10, Vector3.zero + P1pos, playerSkin10.transform.rotation);
                break;
            case 11:
                Instantiate(playerSkin11, Vector3.zero + P1pos, playerSkin11.transform.rotation);
                break;
            case 12:
                Instantiate(playerSkin12, Vector3.zero + P1pos, playerSkin12.transform.rotation);
                break;
            case 13:
                Instantiate(playerSkin13, Vector3.zero + P1pos, playerSkin13.transform.rotation);
                break;
            case 14:
                Instantiate(playerSkin14, Vector3.zero + P1pos, playerSkin14.transform.rotation);
                break;
            case 15:
                Instantiate(playerSkin15, Vector3.zero + P1pos, playerSkin15.transform.rotation);
                break;
            case 16:
                Instantiate(playerSkin16, Vector3.zero + P1pos, playerSkin16.transform.rotation);
                break;
            case 17:
                Instantiate(playerSkin17, Vector3.zero + P1pos, playerSkin17.transform.rotation);
                break;
            case 18:
                Instantiate(playerSkin18, Vector3.zero + P1pos, playerSkin18.transform.rotation);
                break;
            case 19:
                Instantiate(playerSkin19, Vector3.zero + P1pos, playerSkin19.transform.rotation);
                break;
            case 20:
                Instantiate(playerSkin20, Vector3.zero + P1pos, playerSkin20.transform.rotation);
                break;
            case 21:
                Instantiate(playerSkin21, Vector3.zero + P1pos, playerSkin21.transform.rotation);
                break;
            case 22:
                Instantiate(playerSkin22, Vector3.zero + P1pos, playerSkin22.transform.rotation);
                break;
            case 23:
                Instantiate(playerSkin23, Vector3.zero + P1pos, playerSkin23.transform.rotation);
                break;
            case 24:
                Instantiate(playerSkin24, Vector3.zero + P1pos, playerSkin24.transform.rotation);
                break;
            case 25:
                Instantiate(playerSkin25, Vector3.zero + P1pos, playerSkin25.transform.rotation);
                break;
            case 26:
                Instantiate(playerSkin26, Vector3.zero + P1pos, playerSkin26.transform.rotation);
                break;
            case 27:
                Instantiate(playerSkin27, Vector3.zero + P1pos, playerSkin27.transform.rotation);
                break;
            case 28:
                Instantiate(playerSkin28, Vector3.zero + P1pos, playerSkin28.transform.rotation);
                break;
            case 29:
                Instantiate(playerSkin29, Vector3.zero + P1pos, playerSkin29.transform.rotation);
                break;
            case 30:
                Instantiate(playerSkin30, Vector3.zero + P1pos, playerSkin30.transform.rotation);
                break;
            case 31:
                Instantiate(playerSkin31, Vector3.zero + P1pos, playerSkin31.transform.rotation);
                break;
            case 32:
                Instantiate(playerSkin32, Vector3.zero + P1pos, playerSkin32.transform.rotation);
                break;
            case 33:
                Instantiate(playerSkin33, Vector3.zero + P1pos, playerSkin33.transform.rotation);
                break;
            case 34:
                Instantiate(playerSkin34, Vector3.zero + P1pos, playerSkin34.transform.rotation);
                break;
            case 35:
                Instantiate(playerSkin35, Vector3.zero + P1pos, playerSkin35.transform.rotation);
                break;
            case 36:
                Instantiate(playerSkin36, Vector3.zero + P1pos, playerSkin36.transform.rotation);
                break;
            case 37:
                Instantiate(playerSkin37, Vector3.zero + P1pos, playerSkin37.transform.rotation);
                break;
            case 38:
                Instantiate(playerSkin38, Vector3.zero + P1pos, playerSkin38.transform.rotation);
                break;
            case 39:
                Instantiate(playerSkin39, Vector3.zero + P1pos, playerSkin39.transform.rotation);
                break;
            case 40:
                Instantiate(playerSkin40, Vector3.zero + P1pos, playerSkin40.transform.rotation);
                break;
            case 41:
                Instantiate(playerSkin41, Vector3.zero + P1pos, playerSkin41.transform.rotation);
                break;
            case 42:
                Instantiate(playerSkin42, Vector3.zero + P1pos, playerSkin42.transform.rotation);
                break;
            case 43:
                Instantiate(playerSkin43, Vector3.zero + P1pos, playerSkin43.transform.rotation);
                break;
            case 44:
                Instantiate(playerSkin44, Vector3.zero + P1pos, playerSkin44.transform.rotation);
                break;
            case 45:
                Instantiate(playerSkin45, Vector3.zero + P1pos, playerSkin45.transform.rotation);
                break;
            case 46:
                Instantiate(playerSkin46, Vector3.zero + P1pos, playerSkin46.transform.rotation);
                break;
            case 47:
                Instantiate(playerSkin47, Vector3.zero + P1pos, playerSkin47.transform.rotation);
                break;
            case 48:
                Instantiate(playerSkin48, Vector3.zero + P1pos, playerSkin48.transform.rotation);
                break;
            case 49:
                Instantiate(playerSkin49, Vector3.zero + P1pos, playerSkin49.transform.rotation);
                break;
            case 50:
                Instantiate(playerSkin50, Vector3.zero + P1pos, playerSkin50.transform.rotation);
                break;
            case 51:
                Instantiate(playerSkin51, Vector3.zero + P1pos, playerSkin51.transform.rotation);
                break;
            case 52:
                Instantiate(playerSkin52, Vector3.zero + P1pos, playerSkin52.transform.rotation);
                break;
            case 101:
                Instantiate(playerSkin101, Vector3.zero + P1pos, playerSkin101.transform.rotation);
                break;
            case 102:
                Instantiate(playerSkin102, Vector3.zero + P1pos, playerSkin102.transform.rotation);
                break;
            case 103:
                Instantiate(playerSkin103, Vector3.zero + P1pos, playerSkin103.transform.rotation);
                break;
            case 104:
                Instantiate(playerSkin104, Vector3.zero + P1pos, playerSkin104.transform.rotation);
                break;
            case 105:
                Instantiate(playerSkin105, Vector3.zero + P1pos, playerSkin105.transform.rotation);
                break;
            case 106:
                Instantiate(playerSkin106, Vector3.zero + P1pos, playerSkin106.transform.rotation);
                break;
            case 107:
                Instantiate(playerSkin107, Vector3.zero + P1pos, playerSkin107.transform.rotation);
                break;
            case 108:
                Instantiate(playerSkin108, Vector3.zero + P1pos, playerSkin108.transform.rotation);
                break;
            case 109:
                Instantiate(playerSkin109, Vector3.zero + P1pos, playerSkin109.transform.rotation);
                break;
            case 110:
                Instantiate(playerSkin110, Vector3.zero + P1pos, playerSkin110.transform.rotation);
                break;
            case 111:
                Instantiate(playerSkin111, Vector3.zero + P1pos, playerSkin111.transform.rotation);
                break;
            case 112:
                Instantiate(playerSkin112, Vector3.zero + P1pos, playerSkin112.transform.rotation);
                break;
            case 121:
                Instantiate(playerSkin121, Vector3.zero + P1pos, playerSkin121.transform.rotation);
                break;
            case 122:
                Instantiate(playerSkin122, Vector3.zero + P1pos, playerSkin122.transform.rotation);
                break;
            case 123:
                Instantiate(playerSkin123, Vector3.zero + P1pos, playerSkin123.transform.rotation);
                break;
            case 124:
                Instantiate(playerSkin124, Vector3.zero + P1pos, playerSkin124.transform.rotation);
                break;
            case 125:
                Instantiate(playerSkin125, Vector3.zero + P1pos, playerSkin125.transform.rotation);
                break;
            case 126:
                Instantiate(playerSkin126, Vector3.zero + P1pos, playerSkin126.transform.rotation);
                break;
            case 127:
                Instantiate(playerSkin127, Vector3.zero + P1pos, playerSkin127.transform.rotation);
                break;
            case 128:
                Instantiate(playerSkin128, Vector3.zero + P1pos, playerSkin128.transform.rotation);
                break;
            case 129:
                Instantiate(playerSkin129, Vector3.zero + P1pos, playerSkin129.transform.rotation);
                break;
            case 130:
                Instantiate(playerSkin130, Vector3.zero + P1pos, playerSkin130.transform.rotation);
                break;
        }
    }
    public void SpawnP2()
    {
        switch (masterScript.P2skin)
        {
            case 1:
                Instantiate(playerSkin1, Vector3.zero + P2pos, playerSkin1.transform.rotation);
                break;
            case 2:
                Instantiate(playerSkin2, Vector3.zero + P2pos, playerSkin2.transform.rotation);
                break;
            case 3:
                Instantiate(playerSkin3, Vector3.zero + P2pos, playerSkin3.transform.rotation);
                break;
            case 4:
                Instantiate(playerSkin4, Vector3.zero + P2pos, playerSkin4.transform.rotation);
                break;
            case 5:
                Instantiate(playerSkin5, Vector3.zero + P2pos, playerSkin5.transform.rotation);
                break;
            case 6:
                Instantiate(playerSkin6, Vector3.zero + P2pos, playerSkin6.transform.rotation);
                break;
            case 7:
                Instantiate(playerSkin7, Vector3.zero + P2pos, playerSkin7.transform.rotation);
                break;
            case 8:
                Instantiate(playerSkin8, Vector3.zero + P2pos, playerSkin8.transform.rotation);
                break;
            case 9:
                Instantiate(playerSkin9, Vector3.zero + P2pos, playerSkin9.transform.rotation);
                break;
            case 10:
                Instantiate(playerSkin10, Vector3.zero + P2pos, playerSkin10.transform.rotation);
                break;
            case 11:
                Instantiate(playerSkin11, Vector3.zero + P2pos, playerSkin11.transform.rotation);
                break;
            case 12:
                Instantiate(playerSkin12, Vector3.zero + P2pos, playerSkin12.transform.rotation);
                break;
            case 13:
                Instantiate(playerSkin13, Vector3.zero + P2pos, playerSkin13.transform.rotation);
                break;
            case 14:
                Instantiate(playerSkin14, Vector3.zero + P2pos, playerSkin14.transform.rotation);
                break;
            case 15:
                Instantiate(playerSkin15, Vector3.zero + P2pos, playerSkin15.transform.rotation);
                break;
            case 16:
                Instantiate(playerSkin16, Vector3.zero + P2pos, playerSkin16.transform.rotation);
                break;
            case 17:
                Instantiate(playerSkin17, Vector3.zero + P2pos, playerSkin17.transform.rotation);
                break;
            case 18:
                Instantiate(playerSkin18, Vector3.zero + P2pos, playerSkin18.transform.rotation);
                break;
            case 19:
                Instantiate(playerSkin19, Vector3.zero + P2pos, playerSkin19.transform.rotation);
                break;
            case 20:
                Instantiate(playerSkin20, Vector3.zero + P2pos, playerSkin20.transform.rotation);
                break;
            case 21:
                Instantiate(playerSkin21, Vector3.zero + P2pos, playerSkin21.transform.rotation);
                break;
            case 22:
                Instantiate(playerSkin22, Vector3.zero + P2pos, playerSkin22.transform.rotation);
                break;
            case 23:
                Instantiate(playerSkin23, Vector3.zero + P2pos, playerSkin23.transform.rotation);
                break;
            case 24:
                Instantiate(playerSkin24, Vector3.zero + P2pos, playerSkin24.transform.rotation);
                break;
            case 25:
                Instantiate(playerSkin25, Vector3.zero + P2pos, playerSkin25.transform.rotation);
                break;
            case 26:
                Instantiate(playerSkin26, Vector3.zero + P2pos, playerSkin26.transform.rotation);
                break;
            case 27:
                Instantiate(playerSkin27, Vector3.zero + P2pos, playerSkin27.transform.rotation);
                break;
            case 28:
                Instantiate(playerSkin28, Vector3.zero + P2pos, playerSkin28.transform.rotation);
                break;
            case 29:
                Instantiate(playerSkin29, Vector3.zero + P2pos, playerSkin29.transform.rotation);
                break;
            case 30:
                Instantiate(playerSkin30, Vector3.zero + P2pos, playerSkin30.transform.rotation);
                break;
            case 31:
                Instantiate(playerSkin31, Vector3.zero + P2pos, playerSkin31.transform.rotation);
                break;
            case 32:
                Instantiate(playerSkin32, Vector3.zero + P2pos, playerSkin32.transform.rotation);
                break;
            case 33:
                Instantiate(playerSkin33, Vector3.zero + P2pos, playerSkin33.transform.rotation);
                break;
            case 34:
                Instantiate(playerSkin34, Vector3.zero + P2pos, playerSkin34.transform.rotation);
                break;
            case 35:
                Instantiate(playerSkin35, Vector3.zero + P2pos, playerSkin35.transform.rotation);
                break;
            case 36:
                Instantiate(playerSkin36, Vector3.zero + P2pos, playerSkin36.transform.rotation);
                break;
            case 37:
                Instantiate(playerSkin37, Vector3.zero + P2pos, playerSkin37.transform.rotation);
                break;
            case 38:
                Instantiate(playerSkin38, Vector3.zero + P2pos, playerSkin38.transform.rotation);
                break;
            case 39:
                Instantiate(playerSkin39, Vector3.zero + P2pos, playerSkin39.transform.rotation);
                break;
            case 40:
                Instantiate(playerSkin40, Vector3.zero + P2pos, playerSkin40.transform.rotation);
                break;
            case 41:
                Instantiate(playerSkin41, Vector3.zero + P2pos, playerSkin41.transform.rotation);
                break;
            case 42:
                Instantiate(playerSkin42, Vector3.zero + P2pos, playerSkin42.transform.rotation);
                break;
            case 43:
                Instantiate(playerSkin43, Vector3.zero + P2pos, playerSkin43.transform.rotation);
                break;
            case 44:
                Instantiate(playerSkin44, Vector3.zero + P2pos, playerSkin44.transform.rotation);
                break;
            case 45:
                Instantiate(playerSkin45, Vector3.zero + P2pos, playerSkin45.transform.rotation);
                break;
            case 46:
                Instantiate(playerSkin46, Vector3.zero + P2pos, playerSkin46.transform.rotation);
                break;
            case 47:
                Instantiate(playerSkin47, Vector3.zero + P2pos, playerSkin47.transform.rotation);
                break;
            case 48:
                Instantiate(playerSkin48, Vector3.zero + P2pos, playerSkin48.transform.rotation);
                break;
            case 49:
                Instantiate(playerSkin49, Vector3.zero + P2pos, playerSkin49.transform.rotation);
                break;
            case 50:
                Instantiate(playerSkin50, Vector3.zero + P2pos, playerSkin50.transform.rotation);
                break;
            case 51:
                Instantiate(playerSkin51, Vector3.zero + P2pos, playerSkin51.transform.rotation);
                break;
            case 52:
                Instantiate(playerSkin52, Vector3.zero + P2pos, playerSkin52.transform.rotation);
                break;
            case 53:
                Instantiate(playerSkin53, Vector3.zero + P2pos, playerSkin53.transform.rotation);
                break;
            case 101:
                Instantiate(playerSkin101, Vector3.zero + P2pos, playerSkin101.transform.rotation);
                break;
            case 102:
                Instantiate(playerSkin102, Vector3.zero + P2pos, playerSkin102.transform.rotation);
                break;
            case 103:
                Instantiate(playerSkin103, Vector3.zero + P2pos, playerSkin103.transform.rotation);
                break;
            case 104:
                Instantiate(playerSkin104, Vector3.zero + P2pos, playerSkin104.transform.rotation);
                break;
            case 105:
                Instantiate(playerSkin105, Vector3.zero + P2pos, playerSkin105.transform.rotation);
                break;
            case 106:
                Instantiate(playerSkin106, Vector3.zero + P2pos, playerSkin106.transform.rotation);
                break;
            case 107:
                Instantiate(playerSkin107, Vector3.zero + P2pos, playerSkin107.transform.rotation);
                break;
            case 108:
                Instantiate(playerSkin108, Vector3.zero + P2pos, playerSkin108.transform.rotation);
                break;
            case 109:
                Instantiate(playerSkin109, Vector3.zero + P2pos, playerSkin109.transform.rotation);
                break;
            case 110:
                Instantiate(playerSkin110, Vector3.zero + P2pos, playerSkin110.transform.rotation);
                break;
            case 111:
                Instantiate(playerSkin111, Vector3.zero + P2pos, playerSkin111.transform.rotation);
                break;
            case 112:
                Instantiate(playerSkin112, Vector3.zero + P2pos, playerSkin112.transform.rotation);
                break;
            case 121:
                Instantiate(playerSkin121, Vector3.zero + P2pos, playerSkin121.transform.rotation);
                break;
            case 122:
                Instantiate(playerSkin122, Vector3.zero + P2pos, playerSkin122.transform.rotation);
                break;
            case 123:
                Instantiate(playerSkin123, Vector3.zero + P2pos, playerSkin123.transform.rotation);
                break;
            case 124:
                Instantiate(playerSkin124, Vector3.zero + P2pos, playerSkin124.transform.rotation);
                break;
            case 125:
                Instantiate(playerSkin125, Vector3.zero + P2pos, playerSkin125.transform.rotation);
                break;
            case 126:
                Instantiate(playerSkin126, Vector3.zero + P2pos, playerSkin126.transform.rotation);
                break;
            case 127:
                Instantiate(playerSkin127, Vector3.zero + P2pos, playerSkin127.transform.rotation);
                break;
            case 128:
                Instantiate(playerSkin128, Vector3.zero + P2pos, playerSkin128.transform.rotation);
                break;
            case 129:
                Instantiate(playerSkin129, Vector3.zero + P2pos, playerSkin129.transform.rotation);
                break;
            case 130:
                Instantiate(playerSkin130, Vector3.zero + P2pos, playerSkin130.transform.rotation);
                break;
        }
    }
    public void SpawnP3()
    {
        switch (masterScript.P3skin)
        {
            case 1:
                Instantiate(playerSkin1, Vector3.zero + P3pos, playerSkin1.transform.rotation);
                break;
            case 2:
                Instantiate(playerSkin2, Vector3.zero + P3pos, playerSkin2.transform.rotation);
                break;
            case 3:
                Instantiate(playerSkin3, Vector3.zero + P3pos, playerSkin3.transform.rotation);
                break;
            case 4:
                Instantiate(playerSkin4, Vector3.zero + P3pos, playerSkin4.transform.rotation);
                break;
            case 5:
                Instantiate(playerSkin5, Vector3.zero + P3pos, playerSkin5.transform.rotation);
                break;
            case 6:
                Instantiate(playerSkin6, Vector3.zero + P3pos, playerSkin6.transform.rotation);
                break;
            case 7:
                Instantiate(playerSkin7, Vector3.zero + P3pos, playerSkin7.transform.rotation);
                break;
            case 8:
                Instantiate(playerSkin8, Vector3.zero + P3pos, playerSkin8.transform.rotation);
                break;
            case 9:
                Instantiate(playerSkin9, Vector3.zero + P3pos, playerSkin9.transform.rotation);
                break;
            case 10:
                Instantiate(playerSkin10, Vector3.zero + P3pos, playerSkin10.transform.rotation);
                break;
            case 11:
                Instantiate(playerSkin11, Vector3.zero + P3pos, playerSkin11.transform.rotation);
                break;
            case 12:
                Instantiate(playerSkin12, Vector3.zero + P3pos, playerSkin12.transform.rotation);
                break;
            case 13:
                Instantiate(playerSkin13, Vector3.zero + P3pos, playerSkin13.transform.rotation);
                break;
            case 14:
                Instantiate(playerSkin14, Vector3.zero + P3pos, playerSkin14.transform.rotation);
                break;
            case 15:
                Instantiate(playerSkin15, Vector3.zero + P3pos, playerSkin15.transform.rotation);
                break;
            case 16:
                Instantiate(playerSkin16, Vector3.zero + P3pos, playerSkin16.transform.rotation);
                break;
            case 17:
                Instantiate(playerSkin17, Vector3.zero + P3pos, playerSkin17.transform.rotation);
                break;
            case 18:
                Instantiate(playerSkin18, Vector3.zero + P3pos, playerSkin18.transform.rotation);
                break;
            case 19:
                Instantiate(playerSkin19, Vector3.zero + P3pos, playerSkin19.transform.rotation);
                break;
            case 20:
                Instantiate(playerSkin20, Vector3.zero + P3pos, playerSkin20.transform.rotation);
                break;
            case 21:
                Instantiate(playerSkin21, Vector3.zero + P3pos, playerSkin21.transform.rotation);
                break;
            case 22:
                Instantiate(playerSkin22, Vector3.zero + P3pos, playerSkin22.transform.rotation);
                break;
            case 23:
                Instantiate(playerSkin23, Vector3.zero + P3pos, playerSkin23.transform.rotation);
                break;
            case 24:
                Instantiate(playerSkin24, Vector3.zero + P3pos, playerSkin24.transform.rotation);
                break;
            case 25:
                Instantiate(playerSkin25, Vector3.zero + P3pos, playerSkin25.transform.rotation);
                break;
            case 26:
                Instantiate(playerSkin26, Vector3.zero + P3pos, playerSkin26.transform.rotation);
                break;
            case 27:
                Instantiate(playerSkin27, Vector3.zero + P3pos, playerSkin27.transform.rotation);
                break;
            case 28:
                Instantiate(playerSkin28, Vector3.zero + P3pos, playerSkin28.transform.rotation);
                break;
            case 29:
                Instantiate(playerSkin29, Vector3.zero + P3pos, playerSkin29.transform.rotation);
                break;
            case 30:
                Instantiate(playerSkin30, Vector3.zero + P3pos, playerSkin30.transform.rotation);
                break;
            case 31:
                Instantiate(playerSkin31, Vector3.zero + P3pos, playerSkin31.transform.rotation);
                break;
            case 32:
                Instantiate(playerSkin32, Vector3.zero + P3pos, playerSkin32.transform.rotation);
                break;
            case 33:
                Instantiate(playerSkin33, Vector3.zero + P3pos, playerSkin33.transform.rotation);
                break;
            case 34:
                Instantiate(playerSkin34, Vector3.zero + P3pos, playerSkin34.transform.rotation);
                break;
            case 35:
                Instantiate(playerSkin35, Vector3.zero + P3pos, playerSkin35.transform.rotation);
                break;
            case 36:
                Instantiate(playerSkin36, Vector3.zero + P3pos, playerSkin36.transform.rotation);
                break;
            case 37:
                Instantiate(playerSkin37, Vector3.zero + P3pos, playerSkin37.transform.rotation);
                break;
            case 38:
                Instantiate(playerSkin38, Vector3.zero + P3pos, playerSkin38.transform.rotation);
                break;
            case 39:
                Instantiate(playerSkin39, Vector3.zero + P3pos, playerSkin39.transform.rotation);
                break;
            case 40:
                Instantiate(playerSkin40, Vector3.zero + P3pos, playerSkin40.transform.rotation);
                break;
            case 41:
                Instantiate(playerSkin41, Vector3.zero + P3pos, playerSkin41.transform.rotation);
                break;
            case 42:
                Instantiate(playerSkin42, Vector3.zero + P3pos, playerSkin42.transform.rotation);
                break;
            case 43:
                Instantiate(playerSkin43, Vector3.zero + P3pos, playerSkin43.transform.rotation);
                break;
            case 44:
                Instantiate(playerSkin44, Vector3.zero + P3pos, playerSkin44.transform.rotation);
                break;
            case 45:
                Instantiate(playerSkin45, Vector3.zero + P3pos, playerSkin45.transform.rotation);
                break;
            case 46:
                Instantiate(playerSkin46, Vector3.zero + P3pos, playerSkin46.transform.rotation);
                break;
            case 47:
                Instantiate(playerSkin47, Vector3.zero + P3pos, playerSkin47.transform.rotation);
                break;
            case 48:
                Instantiate(playerSkin48, Vector3.zero + P3pos, playerSkin48.transform.rotation);
                break;
            case 49:
                Instantiate(playerSkin49, Vector3.zero + P3pos, playerSkin49.transform.rotation);
                break;
            case 50:
                Instantiate(playerSkin50, Vector3.zero + P3pos, playerSkin50.transform.rotation);
                break;
            case 51:
                Instantiate(playerSkin51, Vector3.zero + P3pos, playerSkin51.transform.rotation);
                break;
            case 52:
                Instantiate(playerSkin52, Vector3.zero + P3pos, playerSkin52.transform.rotation);
                break;
            case 53:
                Instantiate(playerSkin53, Vector3.zero + P3pos, playerSkin53.transform.rotation);
                break;
            case 101:
                Instantiate(playerSkin101, Vector3.zero + P3pos, playerSkin101.transform.rotation);
                break;
            case 102:
                Instantiate(playerSkin102, Vector3.zero + P3pos, playerSkin102.transform.rotation);
                break;
            case 103:
                Instantiate(playerSkin103, Vector3.zero + P3pos, playerSkin103.transform.rotation);
                break;
            case 104:
                Instantiate(playerSkin104, Vector3.zero + P3pos, playerSkin104.transform.rotation);
                break;
            case 105:
                Instantiate(playerSkin105, Vector3.zero + P3pos, playerSkin105.transform.rotation);
                break;
            case 106:
                Instantiate(playerSkin106, Vector3.zero + P3pos, playerSkin106.transform.rotation);
                break;
            case 107:
                Instantiate(playerSkin107, Vector3.zero + P3pos, playerSkin107.transform.rotation);
                break;
            case 108:
                Instantiate(playerSkin108, Vector3.zero + P3pos, playerSkin108.transform.rotation);
                break;
            case 109:
                Instantiate(playerSkin109, Vector3.zero + P3pos, playerSkin109.transform.rotation);
                break;
            case 110:
                Instantiate(playerSkin110, Vector3.zero + P3pos, playerSkin110.transform.rotation);
                break;
            case 111:
                Instantiate(playerSkin111, Vector3.zero + P3pos, playerSkin111.transform.rotation);
                break;
            case 112:
                Instantiate(playerSkin112, Vector3.zero + P3pos, playerSkin112.transform.rotation);
                break;
            case 121:
                Instantiate(playerSkin121, Vector3.zero + P3pos, playerSkin121.transform.rotation);
                break;
            case 122:
                Instantiate(playerSkin122, Vector3.zero + P3pos, playerSkin122.transform.rotation);
                break;
            case 123:
                Instantiate(playerSkin123, Vector3.zero + P3pos, playerSkin123.transform.rotation);
                break;
            case 124:
                Instantiate(playerSkin124, Vector3.zero + P3pos, playerSkin124.transform.rotation);
                break;
            case 125:
                Instantiate(playerSkin125, Vector3.zero + P3pos, playerSkin125.transform.rotation);
                break;
            case 126:
                Instantiate(playerSkin126, Vector3.zero + P3pos, playerSkin126.transform.rotation);
                break;
            case 127:
                Instantiate(playerSkin127, Vector3.zero + P3pos, playerSkin127.transform.rotation);
                break;
            case 128:
                Instantiate(playerSkin128, Vector3.zero + P3pos, playerSkin128.transform.rotation);
                break;
            case 129:
                Instantiate(playerSkin129, Vector3.zero + P3pos, playerSkin129.transform.rotation);
                break;
            case 130:
                Instantiate(playerSkin130, Vector3.zero + P3pos, playerSkin130.transform.rotation);
                break;
        }
    }
    public void SpawnP4()
    {
        switch (masterScript.P4skin)
        {
            case 1:
                Instantiate(playerSkin1, Vector3.zero + P4pos, playerSkin1.transform.rotation);
                break;
            case 2:
                Instantiate(playerSkin2, Vector3.zero + P4pos, playerSkin2.transform.rotation);
                break;
            case 3:
                Instantiate(playerSkin3, Vector3.zero + P4pos, playerSkin3.transform.rotation);
                break;
            case 4:
                Instantiate(playerSkin4, Vector3.zero + P4pos, playerSkin4.transform.rotation);
                break;
            case 5:
                Instantiate(playerSkin5, Vector3.zero + P4pos, playerSkin5.transform.rotation);
                break;
            case 6:
                Instantiate(playerSkin6, Vector3.zero + P4pos, playerSkin6.transform.rotation);
                break;
            case 7:
                Instantiate(playerSkin7, Vector3.zero + P4pos, playerSkin7.transform.rotation);
                break;
            case 8:
                Instantiate(playerSkin8, Vector3.zero + P4pos, playerSkin8.transform.rotation);
                break;
            case 9:
                Instantiate(playerSkin9, Vector3.zero + P4pos, playerSkin9.transform.rotation);
                break;
            case 10:
                Instantiate(playerSkin10, Vector3.zero + P4pos, playerSkin10.transform.rotation);
                break;
            case 11:
                Instantiate(playerSkin11, Vector3.zero + P4pos, playerSkin11.transform.rotation);
                break;
            case 12:
                Instantiate(playerSkin12, Vector3.zero + P4pos, playerSkin12.transform.rotation);
                break;
            case 13:
                Instantiate(playerSkin13, Vector3.zero + P4pos, playerSkin13.transform.rotation);
                break;
            case 14:
                Instantiate(playerSkin14, Vector3.zero + P4pos, playerSkin14.transform.rotation);
                break;
            case 15:
                Instantiate(playerSkin15, Vector3.zero + P4pos, playerSkin15.transform.rotation);
                break;
            case 16:
                Instantiate(playerSkin16, Vector3.zero + P4pos, playerSkin16.transform.rotation);
                break;
            case 17:
                Instantiate(playerSkin17, Vector3.zero + P4pos, playerSkin17.transform.rotation);
                break;
            case 18:
                Instantiate(playerSkin18, Vector3.zero + P4pos, playerSkin18.transform.rotation);
                break;
            case 19:
                Instantiate(playerSkin19, Vector3.zero + P4pos, playerSkin19.transform.rotation);
                break;
            case 20:
                Instantiate(playerSkin20, Vector3.zero + P4pos, playerSkin20.transform.rotation);
                break;
            case 21:
                Instantiate(playerSkin21, Vector3.zero + P4pos, playerSkin21.transform.rotation);
                break;
            case 22:
                Instantiate(playerSkin22, Vector3.zero + P4pos, playerSkin22.transform.rotation);
                break;
            case 23:
                Instantiate(playerSkin23, Vector3.zero + P4pos, playerSkin23.transform.rotation);
                break;
            case 24:
                Instantiate(playerSkin24, Vector3.zero + P4pos, playerSkin24.transform.rotation);
                break;
            case 25:
                Instantiate(playerSkin25, Vector3.zero + P4pos, playerSkin25.transform.rotation);
                break;
            case 26:
                Instantiate(playerSkin26, Vector3.zero + P4pos, playerSkin26.transform.rotation);
                break;
            case 27:
                Instantiate(playerSkin27, Vector3.zero + P4pos, playerSkin27.transform.rotation);
                break;
            case 28:
                Instantiate(playerSkin28, Vector3.zero + P4pos, playerSkin28.transform.rotation);
                break;
            case 29:
                Instantiate(playerSkin29, Vector3.zero + P4pos, playerSkin29.transform.rotation);
                break;
            case 30:
                Instantiate(playerSkin30, Vector3.zero + P4pos, playerSkin30.transform.rotation);
                break;
            case 31:
                Instantiate(playerSkin31, Vector3.zero + P4pos, playerSkin31.transform.rotation);
                break;
            case 32:
                Instantiate(playerSkin32, Vector3.zero + P4pos, playerSkin32.transform.rotation);
                break;
            case 33:
                Instantiate(playerSkin33, Vector3.zero + P4pos, playerSkin33.transform.rotation);
                break;
            case 34:
                Instantiate(playerSkin34, Vector3.zero + P4pos, playerSkin34.transform.rotation);
                break;
            case 35:
                Instantiate(playerSkin35, Vector3.zero + P4pos, playerSkin35.transform.rotation);
                break;
            case 36:
                Instantiate(playerSkin36, Vector3.zero + P4pos, playerSkin36.transform.rotation);
                break;
            case 37:
                Instantiate(playerSkin37, Vector3.zero + P4pos, playerSkin37.transform.rotation);
                break;
            case 38:
                Instantiate(playerSkin38, Vector3.zero + P4pos, playerSkin38.transform.rotation);
                break;
            case 39:
                Instantiate(playerSkin39, Vector3.zero + P4pos, playerSkin39.transform.rotation);
                break;
            case 40:
                Instantiate(playerSkin40, Vector3.zero + P4pos, playerSkin40.transform.rotation);
                break;
            case 41:
                Instantiate(playerSkin41, Vector3.zero + P4pos, playerSkin41.transform.rotation);
                break;
            case 42:
                Instantiate(playerSkin42, Vector3.zero + P4pos, playerSkin42.transform.rotation);
                break;
            case 43:
                Instantiate(playerSkin43, Vector3.zero + P4pos, playerSkin43.transform.rotation);
                break;
            case 44:
                Instantiate(playerSkin44, Vector3.zero + P4pos, playerSkin44.transform.rotation);
                break;
            case 45:
                Instantiate(playerSkin45, Vector3.zero + P4pos, playerSkin45.transform.rotation);
                break;
            case 46:
                Instantiate(playerSkin46, Vector3.zero + P4pos, playerSkin46.transform.rotation);
                break;
            case 47:
                Instantiate(playerSkin47, Vector3.zero + P4pos, playerSkin47.transform.rotation);
                break;
            case 48:
                Instantiate(playerSkin48, Vector3.zero + P4pos, playerSkin48.transform.rotation);
                break;
            case 49:
                Instantiate(playerSkin49, Vector3.zero + P4pos, playerSkin49.transform.rotation);
                break;
            case 50:
                Instantiate(playerSkin50, Vector3.zero + P4pos, playerSkin50.transform.rotation);
                break;
            case 51:
                Instantiate(playerSkin51, Vector3.zero + P4pos, playerSkin51.transform.rotation);
                break;
            case 52:
                Instantiate(playerSkin52, Vector3.zero + P4pos, playerSkin52.transform.rotation);
                break;
            case 53:
                Instantiate(playerSkin53, Vector3.zero + P4pos, playerSkin53.transform.rotation);
                break;
            case 101:
                Instantiate(playerSkin101, Vector3.zero + P4pos, playerSkin101.transform.rotation);
                break;
            case 102:
                Instantiate(playerSkin102, Vector3.zero + P4pos, playerSkin102.transform.rotation);
                break;
            case 103:
                Instantiate(playerSkin103, Vector3.zero + P4pos, playerSkin103.transform.rotation);
                break;
            case 104:
                Instantiate(playerSkin104, Vector3.zero + P4pos, playerSkin104.transform.rotation);
                break;
            case 105:
                Instantiate(playerSkin105, Vector3.zero + P4pos, playerSkin105.transform.rotation);
                break;
            case 106:
                Instantiate(playerSkin106, Vector3.zero + P4pos, playerSkin106.transform.rotation);
                break;
            case 107:
                Instantiate(playerSkin107, Vector3.zero + P4pos, playerSkin107.transform.rotation);
                break;
            case 108:
                Instantiate(playerSkin108, Vector3.zero + P4pos, playerSkin108.transform.rotation);
                break;
            case 109:
                Instantiate(playerSkin109, Vector3.zero + P4pos, playerSkin109.transform.rotation);
                break;
            case 110:
                Instantiate(playerSkin110, Vector3.zero + P4pos, playerSkin110.transform.rotation);
                break;
            case 111:
                Instantiate(playerSkin111, Vector3.zero + P4pos, playerSkin111.transform.rotation);
                break;
            case 112:
                Instantiate(playerSkin112, Vector3.zero + P4pos, playerSkin112.transform.rotation);
                break;
            case 121:
                Instantiate(playerSkin121, Vector3.zero + P4pos, playerSkin121.transform.rotation);
                break;
            case 122:
                Instantiate(playerSkin122, Vector3.zero + P4pos, playerSkin122.transform.rotation);
                break;
            case 123:
                Instantiate(playerSkin123, Vector3.zero + P4pos, playerSkin123.transform.rotation);
                break;
            case 124:
                Instantiate(playerSkin124, Vector3.zero + P4pos, playerSkin124.transform.rotation);
                break;
            case 125:
                Instantiate(playerSkin125, Vector3.zero + P4pos, playerSkin125.transform.rotation);
                break;
            case 126:
                Instantiate(playerSkin126, Vector3.zero + P4pos, playerSkin126.transform.rotation);
                break;
            case 127:
                Instantiate(playerSkin127, Vector3.zero + P4pos, playerSkin127.transform.rotation);
                break;
            case 128:
                Instantiate(playerSkin128, Vector3.zero + P4pos, playerSkin128.transform.rotation);
                break;
            case 129:
                Instantiate(playerSkin129, Vector3.zero + P4pos, playerSkin129.transform.rotation);
                break;
            case 130:
                Instantiate(playerSkin130, Vector3.zero + P4pos, playerSkin130.transform.rotation);
                break;
        }
    }
    public void SpawnP2Boss()
    {
        switch (masterScript.P2skin)
        {
            case -1:
                Instantiate(bossSkin1, Vector3.zero + P2pos, bossSkin1.transform.rotation);
                break;
            case -2:
                Instantiate(bossSkin2, Vector3.zero + P2pos, bossSkin2.transform.rotation);
                break;
            case -3:
                Instantiate(bossSkin1, Vector3.zero + P2pos, bossSkin3.transform.rotation);
                break;
            case -4:
                Instantiate(bossSkin4, Vector3.zero + P2pos, bossSkin4.transform.rotation);
                break;
            case -5:
                Instantiate(bossSkin5, Vector3.zero + P2pos, bossSkin5.transform.rotation);
                break;
            case -6:
                Instantiate(bossSkin6, Vector3.zero + P2pos, bossSkin6.transform.rotation);
                break;
            case -7:
                Instantiate(bossSkin7, Vector3.zero + P2pos, bossSkin7.transform.rotation);
                break;
        }
    }
    #endregion
}
