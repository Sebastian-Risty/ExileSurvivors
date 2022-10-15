//***********************************************************************
//COPYRIGHT Sebastian Ritsy, Bradley Johnson, Matthew Dutton
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneBuilder : MonoBehaviour
{
    //list of enemies in world
    List<Enemy> enemyList;

    //num seconds in level
    float numSeconds;



    enum Scene
    {
        Main, //Title
        Stash, //Camp
        Battle //Battle
    }

    bool sceneChanged;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = Scene.Main;
        enemyList = new List<Enemy>();
        numSeconds = 0;

        // show main menu

    }

    // Update is called once per frame
    void Update()
    {
        // set up all the scenes
        switch (scene)
        {
            case Scene.Stash:
                //do something
                break;
            case Scene.Battle:
                numSeconds += Time.deltaTime;
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

        }

    }
}
