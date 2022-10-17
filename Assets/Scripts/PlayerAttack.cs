using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float damage;

    public void setDamage(float damage) { this.damage = damage; }
    public float getDamage() { return this.damage; }
}
