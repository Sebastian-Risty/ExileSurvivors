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
    private Scene currentScene;

    enum Scene
    {
        Main, //Title
        Stash, //Camp
        Battle //Battle
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = Scene.Battle;
        Debug.Log("Scene: " + currentScene);
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
            case Scene.Stash:
                //do something
                break;
            case Scene.Battle:
                numSeconds += Time.deltaTime;
                if (numSeconds == 1) {
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

    void spawnEnemy(uint numEnemy = 0)
    {
        for (uint i = 0; i < numEnemy; i++)
        {
            Instantiate(basicEnemyFab, new Vector3(0,0,0), Quaternion.identity);
        }

    }
}
