//***********************************************************************
//COPYRIGHT Sebastian Risty, Bradely Johsnon, Mathtew Dutoton
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    private Item[] inventory;
    private static Item[] stash;
    private bool isImmune = false;
    private float immunityTime = 1f, timer = 0f;
    private List<Enemy> enemiesWithin = new List<Enemy> ();

    private int scalarCorrection;

    public Item[] getInventory() { return inventory; }
    public void setInventory(Item[] inventory) { this.inventory = inventory; }
    public Item[] getStash() { return stash; }
    public void setStash(Item[] stash) { Player.stash = stash; }
    public float getImmunityTime() { return immunityTime; }
    public void setImmunityTime(float immunityTime) { this.immunityTime = immunityTime; }
    public List<Enemy> getEnemiesWithin() { return enemiesWithin; }
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        setSpeed(6);
        setHp(100);
        setDamage(30);
        gameObject.tag = "player";
        setRB(GetComponent<Rigidbody2D>());
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Immunity();
        TakeDamage();
        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }
    }

    override
    public void Move() {
        getRB().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        getRB().velocity.Normalize();
        transform.Translate(getRB().velocity * Time.deltaTime * getSpeed());
    }
      
    override
    public void Attack() {      // need to get item class at runtime
        transform.GetChild(0).GetComponent<Gun>().AttackBehavior();
    }

 /**********************************************************************
 * @breif: Immunity prevents the player object from taking damage. This
 *         function is responsible for the immuntiy cooldown timer.
 **********************************************************************/
    public void Immunity() {
        if (isImmune && timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            isImmune = false;
            timer = immunityTime;
        }

    }

    override
    public void TakeDamage() {
        if (!isImmune && enemiesWithin.Count > 0) {
            foreach (Enemy enemy in enemiesWithin) {
                if(enemy.getCurrentCooldown() == 0) {
                    setReceivedDamage(getReceivedDamage() + enemy.getDamage()); // add to applied damag
                    enemy.setCurrentCooldown(enemy.getAttackCooldown());
                    
                    
                }
            }
            setHp(getHp() - getReceivedDamage()); // apply the damage
            setReceivedDamage(0);
            //isImmune = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            enemiesWithin.Add(collision.gameObject.GetComponent<Enemy>());
            collision.gameObject.GetComponent<Enemy>().setTouching(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            enemiesWithin.Remove(collision.gameObject.GetComponent<Enemy>()); // remove collision.gameObject from list
            collision.gameObject.GetComponent<Enemy>().setTouching(false);
        }
    }
    
}
