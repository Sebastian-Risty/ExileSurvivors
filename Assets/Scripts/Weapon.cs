using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    private Vector3 mousePos = new Vector3();
    private Vector3 firePos = new Vector3();
    private float angle;

    //private GameObject player = GameObject.Find("Player");

    public float getAttackAngle()
    {
        updateAngle();
        return angle;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void AttackBehavior();

    private void updateAngle()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        firePos = transform.position;
        angle = (float)((180 / System.Math.PI) * System.Math.Atan2(mousePos.y - firePos.y, mousePos.x - firePos.x));
    }
}
