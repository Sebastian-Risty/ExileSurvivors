//***********************************************************************
//COPYRIGHT: Team ??????
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************************************************
 * @class: Entity
 * 
 * @breif: Entity is the generic base class for characters and items that
 *         show up in the game. Entities are desgined to easily interact with
 *         one another.
 *        
 * @accessors: getHp, setHp, getSpeed, setSpeed, getRB, setRB
 * 
 * @methods: Move, Attack, Start, Update
 **********************************************************************/
public abstract class Entity : MonoBehaviour
{
    private float hp;
    private float speed;
    private float damage;
    private Rigidbody2D rb;
    private float receivedDamage;



    public float getHp() { return hp; }
    public float getSpeed() { return speed; }
    public void setHp(float hp) { 
        if(hp < 0) this.hp = 0; // TODO switch scene
        else { this.hp = hp; }
    }
    public void setSpeed(float speed) { this.speed = speed; }  
    public Rigidbody2D getRB() { return rb; }                       //RB = Rigidbody, used for physics/collision/movement
    public void setRB(Rigidbody2D rb) { this.rb = rb; }
    public float getDamage() { return damage; }
    public void setDamage(float damage) { this.damage = damage; }
    public float getReceivedDamage() { return receivedDamage; }
    public void setReceivedDamage(float receivedDamage) { this.receivedDamage = receivedDamage; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update() {
        
    }
    // Executes entity movement behavior
    public abstract void Move();
    // Executes entity attack behavior
    public abstract void Attack();

    public abstract void TakeDamage();
}
