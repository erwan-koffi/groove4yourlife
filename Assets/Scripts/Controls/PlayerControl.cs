using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float maxSpeed = 10f;

    float horizontal;
    float vertical;
    public float horizontal_velocity;
    public float vertical_velocity;

    public Joystick joystick;

    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start() {
      body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;
        vertical = Input.GetAxis("Vertical") + joystick.Vertical;
    }

    private void FixedUpdate() {
        horizontal_velocity = horizontal * maxSpeed;
        vertical_velocity = vertical * maxSpeed;
        body.velocity = new Vector2(horizontal_velocity, vertical_velocity);
    }
}
