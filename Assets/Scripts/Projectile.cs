//***********************************************************************
//COPYRIGHT: Team ??????
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float lifetime;
    private Gun gun;
    private float angle;
    
    private Vector3 mousePos = new Vector3();
    private Vector3 firePos = new Vector3();

    private void Awake() {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        speed = gun.getSpeed();
        lifetime = gun.getLifetime();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        firePos = transform.position;
        //Debug.Log("Mouse: " + mousePos.ToString());
        //Debug.Log("Fire Pos: " + firePos);

        angle = (float)((180 / System.Math.PI) * System.Math.Atan2(mousePos.y - firePos.y, mousePos.x - firePos.x));
        transform.Rotate(new Vector3(0, 0, angle));
        //Debug.Log("Angle: " + angle);

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.right * speed * Time.deltaTime; // use transform right since unity rotation starts North, our angle starts East
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.setHp(enemy.getHp() - gun.getDamage());

            Destroy(gameObject);
        }
    }
}