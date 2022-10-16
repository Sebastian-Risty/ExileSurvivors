using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**********************************************************************
 * @class: Enemy
 * 
 * @breif: Enemy implements Entity, it a subclass to handle all enemy movement
 *        and actions.
 *        
 * @accessors: getLoot, setLoot, getColor, setColor, getSize, setSize
 * 
 * @methods: Move, Attack, Start, Update
 **********************************************************************/
public class Enemy : Entity
{
    private GameObject target;
    private Color color;
    private Item[] loot;
    private float size;
    private float attackCooldown = 1f, currentCooldown = 0;
    private bool touching = false;
   // test
    

    public Item[] getLoot() { return loot; }
    public void setLoot(Item[] loot) { this.loot = loot; }
    public Color getColor() { return color; }
    public float getSize() { return size; }
    public void setColor(Color color) { this.color = color; }
    public void setSize(float size) { this.size = size; }
    public GameObject getTarget() { return target; }
    public void setTarget(GameObject target) { this.target = target; }
    public float getAttackCooldown() { return attackCooldown; }
    public void setAttackCooldown(float attackCooldown) { this.attackCooldown = attackCooldown; }
    public float getCurrentCooldown() { return currentCooldown; }
    public void setCurrentCooldown(float currentCooldown) { this.currentCooldown = currentCooldown; }
    public bool isTouching() { return touching; }
    public void setTouching(bool touching) { this.touching = touching; }

    private void Awake() {
        gameObject.tag = "enemy";
        target = GameObject.Find("Player");
        setSpeed(3);
        setHp(30);
        setDamage(5);

        
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(target.transform.position.ToString());
        
        if (!touching)
        {
            Move();
        }
        // decrement attack cooldown
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
        else {
            currentCooldown = 0;
        }
    }

    /*********************************************************************
    * @breif Executes Enemy movement behavior. Movement behavior for the
    *        Enemy class is based off of the color of the Enemy, randomness,
    *        and player position.
    * 
    ********************************************************************/
    override
    public void Move() {
        var step = getSpeed() * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    /*********************************************************************
     * @breif Executes entity attack behavior. Attack behavior for the
     *        Enemy class is based off of the color of the Enemy, randomness,
     *        and ....
     * 
     ********************************************************************/
    override
    public void Attack() {
        // shooty projectile if rare enemy
    }

    override
    public void TakeDamage() {

    }


}

    
