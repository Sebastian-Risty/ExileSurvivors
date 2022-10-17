//***********************************************************************
//COPYRIGHT: Team ??????
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : Item
{
    private float speed = 15f; // put common stuff into item class
    private float size = 1f;
    private float damage = 5f;
    private int numShots = 1;
    private float lifetime = 2f; // how long bullet will exist 

    public float getSpeed() { return speed; }
    public float getLifetime() { return lifetime; }

    public GameObject bulletFab;
    private List<Projectile> bullets = new List<Projectile>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "weapon";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override
    public void AttackBehavior() {
        Instantiate(bulletFab, transform.parent.position, Quaternion.identity);
        bullets.Add(bulletFab.GetComponent<Projectile>()); // DELETE OBJECT AFTER SOME TIME
    }
}

//Instantiate(bulletPrefab, GUNTRANSFORM, GUNTRANSFORM.rotation, transform);