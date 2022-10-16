using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float lifetime;
    private GameObject gun;
    
    private Vector3 mousePos = new Vector3();
    private void Awake() {
        gun = GameObject.Find("Gun");
        speed = gun.GetComponent<Gun>().getSpeed();
        lifetime = gun.GetComponent<Gun>().getLifetime();
        mousePos = Input.mousePosition;
        Destroy(gameObject, lifetime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);


        //var step = speed * Time.deltaTime; // calculate distance to move
        transform.GetComponent<Rigidbody2D>().velocity = (mousePos - transform.position).normalized * speed;
        //transform.Translate((transform.forward * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            collision.gameObject.GetComponent<Enemy>().setHp(0);
        }
    }
}