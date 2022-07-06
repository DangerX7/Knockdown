using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShrink : MonoBehaviour
{
    private ArcadeScript arcadeScript;
    private SpawnManagerScript spawnManagerScript;
    private float shrinkSize;
    private float multiplicator;
    public float shrinkLimit;
    // Start is called before the first frame update
    void Start()
    {
        arcadeScript = GameObject.Find("GameManager").GetComponent<ArcadeScript>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        shrinkSize = 0.0002f;
        multiplicator = 2.2f;
        shrinkLimit = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInvoking("MapShrinkMethod"))
        {
            InvokeRepeating("MapShrinkMethod", 0.01f, 0.01f);
        }
    }

    private void MapShrinkMethod()
    {
        if (transform.localScale.x > shrinkLimit && spawnManagerScript.pauseCheck1 !=1)
        {
            transform.localScale -= new Vector3(shrinkSize, 0, shrinkSize);
            arcadeScript.enemySpawnRangeXZ -= shrinkSize* multiplicator;
            arcadeScript.powerupSpawnRangeXZ -= shrinkSize* multiplicator;

            GameObject[] Objects1 = GameObject.FindGameObjectsWithTag("Obj");
            GameObject[] Objects2 = GameObject.FindGameObjectsWithTag("Hole");
            GameObject[] Objects3 = GameObject.FindGameObjectsWithTag("HoleUp");
            foreach (GameObject obj in Objects1)
            {
                if (obj.transform.position.x > 0)
                {
                    obj.transform.position -= new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.x < 0)
                {
                    obj.transform.position += new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.z > 0)
                {
                    obj.transform.position -= new Vector3(0, 0, shrinkSize * multiplicator);
                }
                if (obj.transform.position.z < 0)
                {
                    obj.transform.position += new Vector3(0, 0, shrinkSize * multiplicator);
                }
            }
            foreach (GameObject obj in Objects2)
            {
                if (obj.transform.position.x > 0)
                {
                    obj.transform.position -= new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.x < 0)
                {
                    obj.transform.position += new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.z > 0)
                {
                    obj.transform.position -= new Vector3(0, 0, shrinkSize * multiplicator);
                }
                if (obj.transform.position.z < 0)
                {
                    obj.transform.position += new Vector3(0, 0, shrinkSize * multiplicator);
                }
            }
            foreach (GameObject obj in Objects3)
            {
                if (obj.transform.position.x > 0)
                {
                    obj.transform.position -= new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.x < 0)
                {
                    obj.transform.position += new Vector3(shrinkSize * multiplicator, 0, 0);
                }
                if (obj.transform.position.z > 0)
                {
                    obj.transform.position -= new Vector3(0, 0, shrinkSize * multiplicator);
                }
                if (obj.transform.position.z < 0)
                {
                    obj.transform.position += new Vector3(0, 0, shrinkSize * multiplicator);
                }
            }
        }
    }
}
