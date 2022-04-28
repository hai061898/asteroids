using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public bool thrusting { get; private set; }
    public float thrustSpeed = 1f;

    public float turnDirection { get; private set; } = 0f;

    public float rotationSpeed = 0.1f;
    public Bullet bulletPrefab;
    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

     private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
    }

      private void FixedUpdate()
    {
        if (thrusting) {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f) {
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
    }
}
