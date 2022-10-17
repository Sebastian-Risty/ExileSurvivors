//***********************************************************************
//COPYRIGHT: Team ??????
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : Weapon
{
    private float speed = 15f; // put common stuff into item class
    private float size = 1f;
    private float damage = 10f;

    private int numShots = 5; // number of attacks to fire (cannot be even)
    private float spreadAngle = 5f; // angle between each attack

    private float lifetime = 2f; // how long bullet will exist
    private float fireCooldown = 0.1f; // time between shots
    private float currentFireCooldown;

    private List<GameObject> bullets = new List<GameObject> ();

    public GameObject bulletFab;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "weapon";
        currentFireCooldown = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireCooldown > 0)
        {
            currentFireCooldown -= Time.deltaTime;
        }
        else
        {
            currentFireCooldown = 0;
        }

        // update bullets
        for(int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] != null)
            {
                bullets[i].transform.position += bullets[i].transform.right * speed * Time.deltaTime;
            }
            else
            {
                bullets.RemoveAt(i);
            }
        }
    }

    override
    public void AttackBehavior() {
        if (currentFireCooldown == 0)
        {
            float fireAngle = getAttackAngle();

            // create new bullet
            GameObject newBullet = Instantiate(bulletFab, transform.parent.position, Quaternion.identity);
            // give a tag
            newBullet.tag = "playerAttack";
            // add damage variable
            newBullet.GetComponent<PlayerAttack>().setDamage(damage);
            // fire center
            newBullet.transform.Rotate(new Vector3(0, 0, fireAngle));
            // add bullet to list to update their info
            bullets.Add(newBullet);
            // destroy the bullet after a certain period
            Destroy(newBullet, lifetime);

            if (numShots > 1)
            {
                for (int i = 1; i < ((numShots - 1) / 2) + 1; i++)
                {
                    // create left and right bullets
                    GameObject newLeftBullet = Instantiate(bulletFab, transform.parent.position, Quaternion.identity);
                    GameObject newRightBullet = Instantiate(bulletFab, transform.parent.position, Quaternion.identity);

                    newLeftBullet.tag = "playerAttack";
                    newRightBullet.tag = "playerAttack";

                    newLeftBullet.GetComponent<PlayerAttack>().setDamage(damage);
                    newRightBullet.GetComponent<PlayerAttack>().setDamage(damage);

                    newLeftBullet.transform.Rotate(new Vector3(0, 0, fireAngle - (spreadAngle * i)));
                    newRightBullet.transform.Rotate(new Vector3(0, 0, fireAngle + (spreadAngle * i)));

                    bullets.Add(newLeftBullet);
                    bullets.Add(newRightBullet);

                    Destroy(newLeftBullet, lifetime);
                    Destroy(newRightBullet, lifetime);
                }

            }

            // reset attack cooldown
            currentFireCooldown = fireCooldown;
        }
    }
}
