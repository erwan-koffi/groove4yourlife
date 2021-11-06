using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed = 5f;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start() {
      body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {}

    private void FixedUpdate() {
      transform.Translate(Vector3.left * Time.deltaTime);
    }
}
