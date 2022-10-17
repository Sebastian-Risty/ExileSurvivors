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
    private float damage = 20f;
    private int numShots = 1;
    private float lifetime = 2f; // how long bullet will exist
    private float fireCooldown = 0.1f; // time between shots
    private float currentFireCooldown;

    public float getSpeed() { return speed; }
    public float getLifetime() { return lifetime; }

    public float getDamage() { return damage; }

    public GameObject bulletFab;
    private List<Projectile> bullets = new List<Projectile>();

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

    }

    override
    public void AttackBehavior() {
        if (currentFireCooldown == 0)
        {
            Instantiate(bulletFab, transform.parent.position, Quaternion.identity);
            bullets.Add(bulletFab.GetComponent<Projectile>());
            currentFireCooldown = fireCooldown;
        }
    }
}
