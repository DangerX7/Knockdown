using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate : MonoBehaviour
{
    #region Variables Set
    SpawnManagerScript spawnManagerScript;
    bool rotateDirrection;
    float originalRotateSpeed = 001f / 4;
    int speedMultiplicator = 1;
    bool speedSwitch;
    int dirChangeInterval = 30;
    public bool newMapRotation;
    public int rotationState;
    public bool returnRotation;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        InvokeRepeating("ChangeDirrection", dirChangeInterval, dirChangeInterval);
        StartCoroutine(GroundRotate());
    }
    #endregion

    #region Make Rotation State
    IEnumerator GroundRotate()
    {
        yield return new WaitForSeconds(5);
        if(!returnRotation)
        {
            switch (rotationState)
            {
                case 0:
                    rotationState = Random.Range(1, 5);
                    break;
                case 1:
                 //   Debug.Log("0A");
                    rotationState = Random.Range(1, 5);
                    break;
                case 2:
               //     Debug.Log("0B");
                    rotationState = Random.Range(1, 5);
                    break;
                case 3:
                //    Debug.Log("0C");
                    rotationState = Random.Range(1, 5);
                    break;
                case 4:
                 //   Debug.Log("0D");
                    rotationState = Random.Range(1, 5);
                    break;
            }
        }
        else
        {
            switch (rotationState)
            {
                case 0:
                    //
                    break;
                case 1:
               //     Debug.Log("1A");
                    rotationState = 2;
                    break;
                case 2:
                //    Debug.Log("1B");
                    rotationState = 1;
                    break;
                case 3:
                //    Debug.Log("1C");
                    rotationState = 4;
                    break;
                case 4:
                 //   Debug.Log("1D");
                    rotationState = 2;
                    break;
            }
        }
        returnRotation = !returnRotation;
        StartCoroutine(GroundRotate());
    }
    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        //Find all object and set them as childs of this objects to move with it
        SetParent();
        #region Make Ground Rotate
        if (newMapRotation)
        {
            if ((!spawnManagerScript.isGamePaused) && (!spawnManagerScript.isGameOver))
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
                    enemyScript.aiType = 0;
                }

                switch (rotationState)
                {
                    case 1:
                        transform.Rotate(Vector3.forward, 2 * Time.deltaTime, Space.World);
                        break;
                    case 2:
                        transform.Rotate(Vector3.back, 2 * Time.deltaTime, Space.World);
                        break;
                    case 3:
                        transform.Rotate(Vector3.left, 2 * Time.deltaTime, Space.World);
                        break;
                    case 4:
                        transform.Rotate(Vector3.right, 2 * Time.deltaTime, Space.World);
                        break;
                }
            }
        }
        else
        {
            if ((!spawnManagerScript.isGamePaused) && (!spawnManagerScript.isGameOver))
            {
                if (!rotateDirrection)
                {
                    gameObject.transform.Rotate(0, originalRotateSpeed * speedMultiplicator, 0);
                }
                else
                {
                    gameObject.transform.Rotate(0, -originalRotateSpeed * speedMultiplicator, 0);
                }
            }
            if (speedMultiplicator == 1)
            {
                speedSwitch = false;
            }
            if (speedMultiplicator == 4)
            {
                speedSwitch = true;
            }
        }
        #endregion
    }
    void ChangeDirrection()
    {
        rotateDirrection = !rotateDirrection;
        if (!speedSwitch)
        {
            speedMultiplicator++;
        }
        else
        {
            speedMultiplicator--;
        }
    }

    void SetParent()
    {
        GameObject EnemiesParent = GameObject.Find("EnemiesParent");
        GameObject ItemsParent = GameObject.Find("ItemsParent");
        GameObject MapObjects = GameObject.Find("Map Objects");
        GameObject[] Balls = GameObject.FindGameObjectsWithTag("Parent");
        foreach (GameObject players in Balls)
        {
            if (players.name.StartsWith("P1"))
            {
                players.transform.parent = gameObject.transform;
            }
        }
        EnemiesParent.transform.parent = gameObject.transform;
        ItemsParent.transform.parent = gameObject.transform;
        MapObjects.transform.parent = gameObject.transform;
    }
}
