//***********************************************************************
//COPYRIGHT Sebastian Ritsy, Bradley Johnson, Matthew Dutton
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SceneBuilder : MonoBehaviour
{
    //list of enemies in world
    private List<Enemy> enemyList;

    //num seconds in level
    private float numSeconds;

    public GameObject basicEnemyFab;

    private bool sceneChanged;
    private SceneSelect currentScene;

    private GameObject target;

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
        target = GameObject.Find("Player");
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
                    spawnEnemy(15);
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
            float maxShift = 20f, xShift, yShift;
            int quadrant;
            for (uint i = 0; i < numEnemy; i++) {
                quadrant = Random.Range(0, 3);
                xShift = Random.Range(-maxShift, maxShift); // get new pos from player + offset
                yShift = Random.Range(-maxShift, maxShift);

                Vector3 spawnPos = new Vector3();

                switch (quadrant) {
                    case 0: // top
                        spawnPos = new Vector3(target.transform.position[0] + xShift, target.transform.position[1] + maxShift, 0);
                        break;
                    case 1: // left
                        spawnPos = new Vector3(target.transform.position[0] - maxShift, target.transform.position[1] + yShift, 0);
                        break;
                    case 2: // bottom
                        spawnPos = new Vector3(target.transform.position[0] + xShift, target.transform.position[1] - maxShift, 0);
                        break;
                    case 3: // right
                        spawnPos = new Vector3(target.transform.position[0] + maxShift, target.transform.position[1] + yShift, 0);
                        break;
                }
                Debug.Log("Spawned!");
                Instantiate(basicEnemyFab, spawnPos, Quaternion.identity);
            }
        }
        waveCalled = true;
    }
}