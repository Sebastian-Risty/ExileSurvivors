using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : Item
{
    private float speed = 4f; // put common stuff into item class
    private float size = 1f;
    private float damage = 5f;
    private int numShots = 1;
    private float lifetime = 5f; // how long bullet will exist 

    private GameObject bulletFab;
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
        Projectile currentBullet = Instantiate(bulletFab, transform.parent.position, Quaternion.identity).GetComponent<Projectile>();
        currentBullet.setSpeed(speed);
        bullets.Add(currentBullet.GetComponent<Projectile>()); // DELETE OBJECT AFTER SOME TIME
        // add trigger event below
    }
}
