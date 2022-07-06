using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTriggerScript : MonoBehaviour
{
    public bool playerIsInSight;
    private EnemyScript enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Enemy = transform.parent.gameObject;
        enemyScript = transform.parent.gameObject.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Boss 2 Finds PLayer
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("seeplayer");
            playerIsInSight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInSight = false;
        }
    }
    #endregion
}
