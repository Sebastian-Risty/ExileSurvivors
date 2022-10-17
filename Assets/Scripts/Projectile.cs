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
    private GameObject gun;
    private float angle;
    
    private Vector3 mousePos = new Vector3();
    private Vector3 position = new Vector3();
    private void Awake() {
        gun = GameObject.Find("Gun");
        speed = gun.GetComponent<Gun>().getSpeed();
        lifetime = gun.GetComponent<Gun>().getLifetime();
        mousePos = Input.mousePosition;
        position = new Vector3(Screen.width / 2, Screen.height / 2, 0); // TODO update in case of resize
        angle = Vector2.Angle(position, mousePos);
        Destroy(gameObject, lifetime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 diff = mousePos - position;
        transform.position = Vector3.MoveTowards(transform.position, (transform.position + diff).normalized * 9999, speed * Time.deltaTime);
        Debug.Log(angle);
        Debug.Log("Pos: " + position.ToString() + " Mouse: " + mousePos.ToString());

        //var step = speed * Time.deltaTime; // calculate distance to move
        //transform.GetComponent<Rigidbody2D>().velocity = (mousePos - position).normalized * speed;
        //transform.Translate((transform.forward * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            collision.gameObject.GetComponent<Enemy>().setHp(0);
        }
    }
}