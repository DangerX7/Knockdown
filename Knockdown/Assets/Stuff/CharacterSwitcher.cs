using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public int index;
    bool removeZero;
    public List<GameObject> fighters = new List<GameObject>();
    public PlayerInputManager manager;
    private MasterScript masterScript;
    multiplayerMenuControls skinSelectorMultiplayerBoss;
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        manager = GetComponent<PlayerInputManager>();
        index = 0;
        //   index = Random.Range(0, fighters.Count);
        manager.playerPrefab = fighters[index];
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        if (masterScript.sceneNumber == 1)
        {
            index += 1;
            manager.playerPrefab = fighters[index];
        }
    }

    private void Update()
    {
     //   Debug.Log(index);
        if(!removeZero && GameObject.Find("P0 Ctrl(Clone)") != null)
        {
            Destroy(GameObject.Find("P0 Ctrl(Clone)"));
            removeZero = true;
        }
    }
}
