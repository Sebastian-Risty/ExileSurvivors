//***********************************************************************
//COPYRIGHT Sebastian Ritsy, Bradley Johnson, Matthew Dutton
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneBuilder : MonoBehaviour
{
    //list of enemies in world
    private List<Enemy> enemyList;

    //num seconds in level
    private float numSeconds;

    public GameObject basicEnemyFab;

    private bool sceneChanged;
    private SceneSelect currentScene;

    bool waveCalled = false; // use lastWave int to control

    enum SceneSelect
    {
        Main, //Title
        Stash, //Camp
        Battle //Battle
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneSelect.Battle;
        enemyList = new List<Enemy>();
        numSeconds = 0;
        // show main menu

    }

    // Update is called once per frame
    void Update()
    {
        // set up all the scenes
        switch (currentScene)
        {
            case SceneSelect.Stash:
                //do something
                break;
            case SceneSelect.Battle:
                numSeconds += Time.deltaTime;
                if ((int)numSeconds == 1) {
                    Debug.Log("Spawned!");
                    spawnEnemy(3);
                }
                break;
            //case Scene.Main:
            default:
                //if button flag
                //scene = Scene.Battle
                break;

        }
        if (sceneChanged == true)
        {
            enemyList.Clear();
            numSeconds = 0;
        }
    }

    void spawnEnemy(uint numEnemy)
    {
        if (!waveCalled) {
            for (uint i = 0; i < numEnemy; i++) {
                Debug.Log("Spawned!");
                Instantiate(basicEnemyFab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
            }
        }
        waveCalled = true;
    }
}
