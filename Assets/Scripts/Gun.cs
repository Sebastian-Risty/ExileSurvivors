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
    private int numShots = 1;
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
            // create new bullet
            GameObject newBullet = Instantiate(bulletFab, transform.parent.position, Quaternion.identity);

            // give a tag
            newBullet.tag = "playerAttack";


            // add damage variable
            newBullet.GetComponent<PlayerAttack>().setDamage(damage);

            // set the new bullets angle of travel
            newBullet.transform.Rotate(new Vector3(0, 0, getAttackAngle()));

            // add bullet to list to update their info
            bullets.Add(newBullet);
     
            // destroy the bullet after a certain period
            Destroy(newBullet, lifetime);

            // reset attack cooldown
            currentFireCooldown = fireCooldown;

            
        }
    }
}
