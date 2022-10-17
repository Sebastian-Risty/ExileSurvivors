//***********************************************************************
//COPYRIGHT Sebastian Ritsy, Bradley Johnson, Matthew Dutton
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class BattleScene : MonoBehaviour
{
    //list of enemies in world
    private List<Enemy> enemyList;
    public GameObject basicEnemyFab; // store enemy fabs as list?

    private GameObject target;
    private Canvas pauseMenu;

    private int waveCalledLast; //Last second interval that a wave was spawned
    private float numSeconds; //num seconds in level
    private uint waveSpawnInterval; //A wave will spawn every these number of seconds
    private uint numToSpawn; //determines how many enemies will be spawned

    public static bool pause;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        pauseMenu = GameObject.Find("Pause Menu Canvas").GetComponent<Canvas>();
        pauseMenu.enabled = false; // hide by default
        pause = false;

        enemyList = new List<Enemy>();
        numSeconds = 0;
        waveCalledLast = 2; //set to non zero to prevent massove first wave
        waveSpawnInterval = 5;
        numToSpawn = 15;
        // show main menu

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Tab))
        {
            pause = !pause;
        }

        pauseHandler();

        if (!pause)
        {
            numSeconds += Time.deltaTime;
            //Every
            if ((((int)numSeconds % waveSpawnInterval == 0) || ((int)numSeconds == 0)) && (waveCalledLast != (int)numSeconds))
            {
                Debug.Log("Spawned!");
                spawnEnemy(numToSpawn);
                waveCalledLast = (int)numSeconds;
            }
        }
    }

    void spawnEnemy(uint numEnemy){
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

    void pauseHandler()
    {
        if (pause)
        {
            Time.timeScale = 0f;
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.enabled = false;
        }
    }
 }
