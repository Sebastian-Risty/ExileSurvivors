using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    private Vector3 mousePos = new Vector3();
    private void Awake() {
        mousePos = Input.mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, mousePos, step);
    }
}
