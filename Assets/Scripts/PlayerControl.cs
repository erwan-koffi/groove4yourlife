using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    const float MINIMUM = -11f;
    const float MAXIMUM = 11f;

    public float maxSpeed = 10f;

    float horizontal;
    float vertical;
    public float horizontal_position;
    public float vertical_position;
    public float horizontal_velocity;
    public float vertical_velocity;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start() {
      body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        horizontal_position = body.position.x;
        vertical_position = body.position.y;
    }

    private void FixedUpdate() {
        horizontal_velocity = horizontal * maxSpeed;
        vertical_velocity = vertical * maxSpeed;
        body.velocity = new Vector2(horizontal_velocity, vertical_velocity);
    }
}
